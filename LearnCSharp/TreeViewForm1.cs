using System;
using System.Data;
using System.Windows.Forms;

namespace LearnCSharp
{
    public partial class TreeViewForm1 : Form
    {
        public TreeViewForm1()
        {
            InitializeComponent();
        }

        private void TreeViewForm1_Load(object sender, EventArgs e)
        {
            LoadData(treeView1.Nodes, 0);
        }

        private void LoadData(TreeNodeCollection nodes, int pid)
        {
            DataTable dt = GetDataTableByPid(pid);
            if (dt.Rows.Count>0)
            {
                //遍历数据并加载到TreeView上面
                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row[0]);
                    string name = row[1].ToString();

                    TreeNode node = nodes.Add(name);
                    node.Tag = id;
                    //递归实现TreeView 省市节点加载
                    LoadData(node.Nodes, id);
                }
            }
        }

        private DataTable GetDataTableByPid(int pid) {
            string sql = "select id, name from tb_area where pid=@pid";

            return Tools.SqlHelper.ExecuteDataTable(sql,CommandType.Text, new System.Data.SqlClient.SqlParameter("@pid", DbType.Int32) { Value = pid });
        }
    }
}
