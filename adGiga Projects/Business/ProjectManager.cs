using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using ObjectCache;

namespace Business
{
    public class ProjectManager
    {
        public List<DataObjects.Project> RetrieveAllActiveProjects()
        {

            List<Project> allProjects = RetrieveAllProjects();
            List<Project> allActiveProjects = new List<Project>();
            foreach (Project p in allProjects)
            {
                if (p.Status == Project.ProjectStatus.InProgress || p.Status == Project.ProjectStatus.Started)
                {
                    allActiveProjects.Add(p);
                }
            }
            return allActiveProjects;
        }

        private void InsertNewProject(Project p)
        {
            ProjectCache.GetInstance().InsertProject(p);
        }

        public Project SyncProject(Project p)
        {
            if (ProjectCache.GetInstance().GetProjectById(p.ID) == null)
            {
                InsertNewProject(p);
            }
            else
            {
                ProjectCache.GetInstance().UpdateProject(p);
            }
            return GetProject(p.Name);
        }

        public string[] GetNamesOfActiveProjects()
        {
            List<string> nameList = new List<string>();
            foreach (Project project in RetrieveAllActiveProjects())
            {
                nameList.Add(project.Name);
            }
            return nameList.ToArray();
        }

        /// <summary>
        /// Get project by name
        /// </summary>
        /// <param name="name">name of project</param>
        /// <returns>default project if empty string, new project object if new project name, existing project if already there</returns>
        public Project GetProject(string name)
        {
            Project project = ProjectCache.GetInstance().GetProjectByName(name);
            if (project == null)
            {
                project = new Project();
                project.ID = -1;
                project.Name = name;
            }
            return project;
        }

        public Project GetProject(int id)
        {
            return ProjectCache.GetInstance().GetProjectById(id);
        }

        public List<Project> RetrieveAllProjects()
        {
            if (ProjectCache.GetInstance().GetProjectByName(string.Empty) == null)
            {
                Project noProject = new Project();
                noProject.Name = string.Empty;
                noProject.Status = Project.ProjectStatus.InProgress;
                noProject.StartDate = new DateTime(2000, 1, 1);
                noProject.EndDate = new DateTime(2099, 1, 1);
                noProject.Comment = string.Empty;
                ProjectCache.GetInstance().InsertProject(noProject);
            }
            return ProjectCache.GetInstance().Projects;
        }

        private List<Transaction> GetAllTransactions(Project p)
        {
            return (new TransactionManager()).GetTransactionsByProjectId(p.ID);
        }

        public List<Transaction> GetPurchases(Project p)
        {
            return GetAllTransactions(p).FindAll(delegate(Transaction a)
            {
                return a.IsPurchase;
            }
            );
        }

        public double GetPurchaseTotal(Project p)
        {
            double sum = 0.0;
            foreach (Transaction t in GetPurchases(p))
            {
                sum += t.TransactionSum;
            }
            return sum;
        }

        public List<Transaction> GetSales(Project p)
        {
            return GetAllTransactions(p).FindAll(delegate(Transaction a)
            {
                return !a.IsPurchase;
            }
            );
        }

        public double GetSaleTotal(Project p)
        {
            double sum = 0.0;
            foreach (Transaction t in GetSales(p))
            {
                sum += t.TransactionSum;
            }
            return sum;
        }

        public double GetProjectProfit(Project p)
        {
            return GetSaleTotal(p) - GetPurchaseTotal(p);
        }

        internal void RefreshCache()
        {
            ProjectCache.GetInstance().Clear();
            ProjectCache.GetInstance();
        }

        public void DeleteProject(int p)
        {
            TransactionManager tm = new TransactionManager();
            //find all transactions under the project to be deleted
            List<Transaction> transactions = tm.GetTransactionsByProjectId(p);
            //replace the project of all the above transactions with the default project
            foreach (Transaction t in transactions)
            {
                t.ParentProject = GetProject(string.Empty);
                tm.SyncTransaction(t);
            }
            //now delete the project from db and cache
            ProjectCache.GetInstance().DeleteProject(p);
        }
    }
}
