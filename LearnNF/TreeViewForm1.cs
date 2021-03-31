using System;
using System.Data;
using System.Windows.Forms;
//using LearnNF.data;
using TekinMssqlFLib;

namespace LearnNF
{
    public partial class TreeViewForm1 : Form
    {
        public TreeViewForm1()
        {
            InitializeComponent();
        }
        private void TreeViewForm1_Load(object sender, EventArgs e)
        {
           //
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

            return SqlHelper.ExecuteDataTable(sql,CommandType.Text, new System.Data.SqlClient.SqlParameter("@pid", DbType.Int32) { Value = pid });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData(treeView1.Nodes, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获取选中的当前节点
            if (treeView1.SelectedNode != null)
            {
                //2. 获取选中当前节点对应的id
                int id = (int)treeView1.SelectedNode.Tag;
                //3.从数据库中删除
                RecussionDel(id);
                // 4. 从界面上删除
                treeView1.SelectedNode.Remove();
                treeView1.SelectedNode = null;

                MessageBox.Show("删除成功", "OK");
            }
            else
            {
                MessageBox.Show("请先选择数据", "Fail");
            }

        }
        // 递归删除
        private int RecussionDel(int id) {

            DataTable dt = GetDataTableByPid(id);
            if (dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    //递归删除
                    RecussionDel(Convert.ToInt32(row[0]));
                }
            }

            string sql = "delete from tb_area where id=@id";
           return data.SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new System.Data.SqlClient.SqlParameter("@id", DbType.Int32) { Value = id });
        }
    }
}
