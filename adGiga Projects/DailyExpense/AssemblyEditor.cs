using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Business;
using DataObjects;

namespace ShopKeeper
{
    public partial class AssemblyEditor : Form
    {
        AssemblyManager am = new AssemblyManager();

        public AssemblyEditor()
        {
            InitializeComponent();
        }

        private void Project_Assembly_Load(object sender, EventArgs e)
        {
            BuildTree();
            treeView1.Nodes[0].Expand();
        }

        private void BuildTree()
        {
            List<Item> items = (new ItemManager()).GetAllItems();
            List<Assembly> assemblies = am.GetAllAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                if (GetNodesWithItem(assembly.Parent).Length == 0)
                {
                    //if there are no nodes for the parent of the assembly,
                    //then add the assembly at the tree root
                    AddAssemblyUnderNode(treeView1.TopNode, assembly);
                }
                else
                {
                    //if there are nodes containing the parent of the assembly already in tree,
                    // then add the children of the assembly under all those nodes
                    foreach (TreeNode matchingNode in GetNodesWithItem(assembly.Parent))
                    {
                        AddItemsUnderNode(matchingNode, assembly.Children);
                    }
                }
            }
        }

        private void AddItemsUnderNode(TreeNode parentNode, List<Item> children)
        {
            foreach (Item child in children)
            {
                parentNode.Nodes.Add(child.ID.ToString(), child.Name).ContextMenuStrip = editTreeMenuStrip;
            }
        }

        private void AddAssemblyUnderNode(TreeNode topNode, Assembly assembly)
        {
            //add parent
            TreeNode parent = topNode.Nodes.Add(assembly.Parent.ID.ToString(), assembly.Parent.Name);
            parent.ContextMenuStrip = editTreeMenuStrip;
            //add children
            AddItemsUnderNode(parent, assembly.Children);
        }

        private TreeNode[] GetNodesWithItem(Item item)
        {
            if (treeView1.Nodes != null)
            {
                if (treeView1.Nodes.Count > 0)
                {
                    return treeView1.Nodes.Find(item.ID.ToString(), true);
                }
            }
            return null;
        }

        private void editTreeMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)
            {
                deleteToolStripMenuItem.Enabled = false;                
            }
            else
            {
                deleteToolStripMenuItem.Enabled = true;
            }
            if (treeView1.SelectedNode.Level > 3)
            {
                addChildToolStripMenuItem.Enabled = false;
            }
            else
            {
                addChildToolStripMenuItem.Enabled = true;
            }
        }

        private void addChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new CommonManager()).BeginBatchOperation();
            CommonEditor commonEditor = new CommonEditor();
            string candidateName = 
                commonEditor.GetValue("Item name", typeof(string), string.Empty, true, (new ItemManager()).GetNamesOfItems());
            if (candidateName.Length > 0)
            {
                if (treeView1.SelectedNode.Level == 0)
                {
                    am.AddChild((new ItemManager()).GetItemByName(candidateName), null);
                }
                else
                {
                    am.AddChild(
                     (new ItemManager()).GetItemByName(treeView1.SelectedNode.Text),
                     (new ItemManager()).GetItemByName(candidateName));
                }
            }
            (new CommonManager()).ConfirmBatchOperation();
            BuildTree();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            
        }

    }
}
