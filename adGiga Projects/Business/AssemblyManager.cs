using System;
using System.Collections.Generic;
using System.Text;
using DataObjects;
using ObjectCache;

namespace Business
{
    public class AssemblyManager
    {
        public List<Item> GetChildren(Item item)
        {
            Assembly assembly = GetAssemblyWithParent(item);
            if (assembly != null)
            {
                return assembly.Children;
            }
            else
            {
                return new List<Item>();
            }
        }

        public List<Item> GetParents(Item item)
        {
            //loop through all assemblies to check if it has the item as child.
            List<Item> parents = new List<Item>();
            foreach (Assembly assembly in AssemblyCache.GetInstance().Assemblies)
            {
                foreach (Item child in assembly.Children)
                {
                    if (item.ID == child.ID)
                    {
                        parents.Add(assembly.Parent);
                        break;
                    }
                }
            }
            return parents;
        }

        public List<Assembly> GetAllAssemblies()
        {
            return AssemblyCache.GetInstance().Assemblies;
        }

        public bool AddChild(Item parent, Item childCandidate)
        {
            if (childCandidate == null)
            {
                childCandidate = new Item();
                childCandidate.ID = -1;
            }

            //check if childCandidate is already a child
            foreach (Item child in GetChildren(parent))
            {
                if (child.ID == childCandidate.ID)
                {
                    return false;
                }
            }

            //check if the childCandidate is same as parent
            if (parent.ID == childCandidate.ID)
            {
                return false; //do not add as child
            }
            //check if the childCandidate is a parent of parent
            if (CheckIfForeFather(parent, childCandidate))
            {
                return false;
            }
            Assembly assembly = GetAssemblyWithParent(parent);
            if (assembly == null)
            {   //in case there are no assemblies with the parent, create new assembly.
                assembly = new Assembly();
                assembly.Parent = parent;
            }
            if (childCandidate.ID >= 0)
            {
                assembly.Children.Add(childCandidate);
            }
            SaveAssembly(assembly);
            return true;
        }

        public void SaveAssembly(Assembly assembly)
        {
            //check if assembly already exists
            if (GetAssemblyWithParent(assembly.Parent) == null)
            {
                //insert this to the db and cache
                AssemblyCache.GetInstance().InsertAssembly(assembly);
            }
            else
            {
                //update existing assembly in db and cache
                AssemblyCache.GetInstance().UpdateAssembly(assembly);
            }
        }

        private Assembly GetAssemblyWithParent(Item parent)
        {
            return AssemblyCache.GetInstance().GetAssemblyByParentName(parent.Name);
        }

        public bool CheckIfForeFather(Item parent, Item childCandidate)
        {
            foreach (Item p in GetParents(parent))
            {
                if (p.ID == childCandidate.ID)
                {
                    return true;
                }
                else
                {
                    return CheckIfForeFather(p, childCandidate);
                }
            }
            return false;
        }

        internal void RefreshCache()
        {
            AssemblyCache.GetInstance().Clear();
            AssemblyCache.GetInstance();
        }
    }
}
