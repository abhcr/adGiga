using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;
using System.Diagnostics;

namespace ObjectCache
{
    public class ProjectCache
    {
        List<Project> projects = new List<Project>();

        public List<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        private List<KeyValuePair<DateTime, Project.ProjectStatus>> GetIncidentsFromRawString(string rawString)
        {
            List<KeyValuePair<DateTime, Project.ProjectStatus>> dates = new List<KeyValuePair<DateTime, Project.ProjectStatus>>();
            KeyValuePair<DateTime, Project.ProjectStatus> statusChange;
            string[] statusChanges = rawString.Split(';');
            foreach (string incident in statusChanges)
            {
                if (incident != string.Empty)
                {
                    statusChange = new KeyValuePair<DateTime, Project.ProjectStatus>(
                        DateTime.Parse(incident.Split('*')[0]), ParseStatus(incident.Split('*')[1]));
                    dates.Add(statusChange);
                }
            }
            statusChanges = null;
            return dates;
        }


        private Project.ProjectStatus ParseStatus(string status)
        {

            switch (status)
            {
                case "0": return Project.ProjectStatus.Started;
                case "1": return Project.ProjectStatus.InProgress;
                case "2": return Project.ProjectStatus.Completed;
                case "3": return Project.ProjectStatus.OnHold;
                default:
                    return Project.ProjectStatus.Started;
            }
        }

        private int StatusAsNumber(Project.ProjectStatus projectStatus)
        {
            switch (projectStatus)
            {
                case Project.ProjectStatus.Started:
                    return 0;
                case Project.ProjectStatus.InProgress:
                    return 1;
                case Project.ProjectStatus.Completed:
                    return 2;
                case Project.ProjectStatus.OnHold:
                    return 3;
                default:
                    return 0;
            }
        }

        object dummy = new object();
        private ProjectCache()
        {
            lock (dummy)
            {
                OleDbDataReader reader;
                ItemCache.GetInstance(); //keep itemcache ready.
                //check if Projects table exists in the db. if not, create it.
                if (!DBFunctions.GetInstance().CheckIfTableExistsInDB("Projects"))
                {
                    //create table if not in db
                    DBFunctions.GetInstance().GetCommand(
                        "Create Table Projects (ID COUNTER PRIMARY KEY, Name VARCHAR(255), Status NUMBER, Comment VARCHAR(255), StartDate Date, EndDate Date);")
                        .ExecuteNonQuery();
                }
                projects.Clear();
                Project project;
                DBFunctions.GetInstance().OpenConnection();
                reader = DBFunctions.GetInstance().GetReader("Select ID, Name, Status, Comment, StartDate, EndDate from Projects");
                while (reader.Read())
                {
                    project = new Project();
                    project.ID = (int)reader[0];
                    project.Name = reader[1].ToString();
                    project.Status = ParseStatus(reader[2].ToString());
                    project.Comment = reader[3].ToString();
                    project.StartDate = DateTime.Parse(reader[4].ToString());
                    project.EndDate = DateTime.Parse(reader[5].ToString());
                    projects.Add(project);
                }
                //check if default project exists in the set, if not, create it and add it to db and cache
                if (GetProjectByName(string.Empty) == null)
                {
                    project = new Project();
                    project.Name = string.Empty;
                    project.Status = Project.ProjectStatus.InProgress;
                    project.Comment = string.Empty;
                    project.StartDate = new DateTime(2000, 1, 1);
                    project.EndDate = new DateTime(2099, 1, 1);
                    InsertProject(project);
                }
            }
        }
        private static ProjectCache instance;
        public static ProjectCache GetInstance()
        {
            if (instance == null)
            {
                instance = new ProjectCache();
            }
            return instance;
        }
        /// <summary>
        /// Get the project object by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Project GetProjectByName(string name)
        {
            return projects.Find(delegate(Project p)
            { return p.Name.Trim().ToLower() == name.Trim().ToLower(); });
        }

        public Project GetProjectById(int projectId)
        {
            return projects.Find(delegate(Project p) { return p.ID == projectId; });
        }
        public void InsertProject(Project project)
        {
            if (GetProjectByName(project.Name) == null)
            {
                InsertProjectToDb(project);
                //then add it to cache with db ID
                projects.Add(GetProjectFromDbByName(project.Name));
            }
        }

        private Project GetProjectFromDbByName(string name)
        {
            Project project = new Project();
            project.Name = name;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID,Name, Status, Comment, StartDate, EndDate From Projects Where Name = ?");
            command.Parameters.AddWithValue("Name", name);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                project.ID = (int)reader[0];
                project.Name = reader[1].ToString();
                project.Status = ParseStatus(reader[2].ToString());
                project.Comment = reader[3].ToString();
                project.StartDate = DateTime.Parse(reader[4].ToString());
                project.EndDate = DateTime.Parse(reader[5].ToString());
            }
            else
            {
                project = null;
            }
            return project;
        }

        private void InsertProjectToDb(Project project)
        {
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Insert Into Projects " +
                "(Name, Status, Comment, StartDate, EndDate) Values(?,?,?,?,?)");
            command.Parameters.AddWithValue("Name", project.Name);
            command.Parameters.AddWithValue("Status", StatusAsNumber(project.Status));
            command.Parameters.AddWithValue("Comment", project.Comment);
            command.Parameters.Add("StartDate", OleDbType.Date).Value = project.StartDate;
            command.Parameters.Add("EndDate", OleDbType.Date).Value = project.EndDate;
            command.ExecuteNonQuery();
        }

        private void UpdateProjectToDb(Project project)
        {
            //do not update stock here.. it is updated by stock cache
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Update Projects " +
                "Set Name=?, Status=?, Comment=?, StartDate=?, EndDate=? Where ID=?");
            command.Parameters.AddWithValue("Name", project.Name);
            command.Parameters.AddWithValue("Status", StatusAsNumber(project.Status));
            command.Parameters.AddWithValue("Comment", project.Comment);
            command.Parameters.Add("StartDate", OleDbType.Date).Value = project.StartDate;
            command.Parameters.Add("EndDate", OleDbType.Date).Value = project.EndDate;
            command.Parameters.AddWithValue("Id", project.ID);
            command.ExecuteNonQuery();
        }

        public void Clear()
        {
            if (projects != null)
            {
                projects.Clear();
            }
            instance = null;
        }

        public void UpdateProject(Project project)
        {
            Project projectInCache = GetProjectById(project.ID);
            UpdateProjectToDb(project);
            //update item to cache
            projects[projects.IndexOf(projectInCache)] = project;
        }

        public void DeleteProject(int selectedProjectId)
        {
            //remove from db
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Delete From Projects Where Id=?");
            command.Parameters.AddWithValue("Id", selectedProjectId);
            command.ExecuteNonQuery();
            //remove from cache
            projects.Remove(GetProjectById(selectedProjectId));
        }
    }
}

