using System;
using System.Collections.Generic;
using System.Text;

namespace DataObjects
{
    /// <summary>
    /// Project class groups a set of items under a parent item.
    /// </summary>
    public class Assembly
    {
        public Assembly()
        {
            children = new List<Item>();
            Parent = new Item();
            ID = -1;
        }

        public int ID { get; set; }
        public Item Parent { get; set; }
        public string ChildrenIds {
            get
            {
                StringBuilder ids = new StringBuilder();
                foreach (Item item in Children)
                {
                    ids.Append(item.ID.ToString());
                    ids.Append(";");
                }
                return ids.ToString();
            }
        }
        private List<Item> children;
        public List<Item> Children { get { return children; } set { children = value; } }
    }
}
