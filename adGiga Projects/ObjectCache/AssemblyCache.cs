using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using System.Data.OleDb;
using System.Diagnostics;

namespace ObjectCache
{
    public class AssemblyCache
    {
        List<Assembly> assemblies = new List<Assembly>();

        public List<Assembly> Assemblies
        {
            get { return assemblies; }
            set { assemblies = value; }
        }

        object dummy = new object();
        private AssemblyCache()
        {
            lock (dummy)
            {
                OleDbDataReader reader;
                ItemCache.GetInstance(); //keep itemcache ready.
                //check if Projects table exists in the db. if not, create it.
                if (!DBFunctions.GetInstance().CheckIfTableExistsInDB("Assemblies"))
                {
                    //create table if not in db
                    DBFunctions.GetInstance().GetCommand(
                        "Create Table Assemblies (ID COUNTER PRIMARY KEY, Parent INTEGER, Children VARCHAR(255));")
                        .ExecuteNonQuery();
                }
                assemblies.Clear();
                Assembly assembly;
                DBFunctions.GetInstance().OpenConnection();
                reader = DBFunctions.GetInstance().GetReader(
                    "Select ID, Parent, Children from Assemblies");
                while (reader.Read())
                {
                    assembly = new Assembly();
                    assembly.ID = (int)reader[0];
                    assembly.Parent =  ItemCache.GetInstance().GetItemById((int)reader[1]) ;
                    string[] childrenIds = reader[2].ToString().Split(';');
                    foreach (string childId in childrenIds)
                    {
                        if (childId != string.Empty)
                        {
                            assembly.Children.Add(ItemCache.GetInstance().GetItemById(int.Parse(childId)));
                        }
                    }
                    childrenIds = null;
                    assemblies.Add(assembly);
                }
            }
        }
        private static AssemblyCache instance;
        public static AssemblyCache GetInstance()
        {
            if (instance == null)
            {
                instance = new AssemblyCache();
            }
            return instance;
        }
        /// <summary>
        /// Get the project object by the name of parent.
        /// </summary>
        /// <param name="parentName"></param>
        /// <returns></returns>
        public Assembly GetAssemblyByParentName(string parentName)
        {
            return assemblies.Find(delegate(Assembly p) 
            { Debug.Print(p.Parent.Name +"\n\r"); return p.Parent.Name.Trim().ToLower() == parentName.Trim().ToLower(); });
        }

        public Assembly GetAssemblyById(int assemblyId)
        {
            return assemblies.Find(delegate(Assembly p) { return p.ID == assemblyId; });
        }
        public Assembly GetAssemblyByParentId(int parentId)
        {
            return assemblies.Find(delegate(Assembly p) { return p.Parent.ID == parentId; });
        }

        public void InsertAssembly(Assembly assembly)
        {
            if (GetAssemblyByParentName(assembly.Parent.Name) == null)
            {
                InsertAssemblyToDb(assembly);
                //then add it to cache with db ID
                assemblies.Add(GetAssemblyFromDbByParentName(assembly.Parent.Name));
            }
        }

        private Assembly GetAssemblyFromDbByParentName(string name)
        {
            Assembly assembly = new Assembly();
            assembly.Parent.Name = name;
            OleDbCommand command = DBFunctions.GetInstance().GetCommand(
                "Select ID,Parent,Children From Assemblies Where Parent = ?");
            command.Parameters.AddWithValue("Parent", ItemCache.GetInstance().GetItemByName(assembly.Parent.Name).ID);
            OleDbDataReader reader = DBFunctions.GetInstance().GetReader(command);
            if (reader.Read())
            {
                assembly.ID = (int)reader[0];
                assembly.Parent = ItemCache.GetInstance().GetItemById((int)reader[1]);
                string []childrenIds = reader[2].ToString().Split(';');
                foreach (string childId in childrenIds)
                {
                    if (childId.Length > 0)
                    {
                        assembly.Children.Add(ItemCache.GetInstance().GetItemById(int.Parse(childId)));
                    }
                }
            }
            else
            {
                assembly = null;
            }
            return assembly;
        }

        private void InsertAssemblyToDb(Assembly assembly)
        {
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Insert Into Assemblies " +
                "(Parent,Children) Values(?,?)");
            command.Parameters.AddWithValue("Parent", assembly.Parent.ID);
            command.Parameters.AddWithValue("Children", assembly.ChildrenIds);
            command.ExecuteNonQuery();
        }

        public void UpdateAssemblyWithParentName(Assembly assembly)
        {
            Assembly projectInCache = GetAssemblyByParentName(assembly.Parent.Name);
            //get the id
            assembly.ID = projectInCache.ID;
            UpdateAssemblyToDb(assembly);
            //update item to cache
            assemblies[assemblies.IndexOf(projectInCache)] = assembly;
        }

        private void UpdateAssemblyToDb(Assembly assembly)
        {
            //do not update stock here.. it is updated by stock cache
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Update Assemblies " +
                "Set Parent=?, Children=? Where ID=?");
            command.Parameters.AddWithValue("parent", assembly.Parent.ID);
            command.Parameters.AddWithValue("children", assembly.ChildrenIds);
            command.Parameters.AddWithValue("Id", assembly.ID);
            command.ExecuteNonQuery();
        }

        public void Clear()
        {
            if (assemblies!= null)
            {
                assemblies.Clear();
            }
            instance = null;
        }

        public void UpdateAssembly(Assembly assembly)
        {
            Assembly projectInCache = GetAssemblyById(assembly.ID);
            UpdateAssemblyToDb(assembly);
            //update item to cache
            assemblies[assemblies.IndexOf(projectInCache)] = assembly;
        }

        public void DeleteAssembly(int selectedAssemblyId)
        {
            //remove from db
            DBFunctions.GetInstance().OpenConnection();
            OleDbCommand command = DBFunctions.GetInstance().GetCommand("Delete From Assemblies Where Id=?");
            command.Parameters.AddWithValue("Id", selectedAssemblyId);
            command.ExecuteNonQuery();
            //remove from cache
            assemblies.Remove(GetAssemblyById(selectedAssemblyId));
        }
    }
}
