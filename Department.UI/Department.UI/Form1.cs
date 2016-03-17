using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Department.DAL;
namespace Department.UI
    
{
    public partial class Form1 : Form
    {
        TreeNode CurrNode;
        TreeNode CurrEditNode;
        public DataTable tw_data;
        List<Department.Employee> emp;
        public Form1()
        {
            InitializeComponent();
            RepositoryContext.Active = new DepartmentsRep();
            tw_data = RepositoryContext.Active.GetTreeNodes();
            CreateNodes();
        }

        private void CreateNodes()
        {
            string expression = "ParentNoteID = -1";
            DataRow[] CoreNodes = tw_data.Select(expression);
            tv_Departments.Nodes.Clear();
            TreeNode[] nodes = RecurseRows(CoreNodes);
            tv_Departments.Nodes.AddRange(nodes);
        }

        private TreeNode[] RecurseRows(DataRow[] rows)
        {
            List<TreeNode> nodeList = new List<TreeNode>();
            TreeNode node = null;
            foreach (DataRow dr in rows)
            {
                node = new TreeNode(dr["NoteName"].ToString());
                node.Tag = Convert.ToInt32(dr["NoteID"]);
                DataRow[] childRows = tw_data.Select("ParentNoteID = " + dr["NoteID"]);
                if (childRows.Length > 0)
                {
                    TreeNode[] childNodes = RecurseRows(childRows);
                    node.Nodes.AddRange(childNodes);
                }
                nodeList.Add(node);

            }
            TreeNode[] nodeArr = nodeList.ToArray();
            return nodeArr;
        }

        private void btn_addEmp_Click(object sender, EventArgs e)
        {
            if (CurrNode.Tag != null)
            {
                this.Enabled = false;
                AddEmployeeFrm frmEmpAdd = new AddEmployeeFrm((int)CurrNode.Tag);
                frmEmpAdd.AddEmpEvent += this.HandleAddEmpEvent;
                frmEmpAdd.Show();
                
            }
        }
        void HandleAddEmpEvent(object sender, SetMessage e)
        {
            ShowEmployeeGrid((int)CurrNode.Tag);
            this.Enabled = true;
            
        }
        private void tv_Departments_AfterSelect(object sender, TreeViewEventArgs e)
        {
             CurrNode = e.Node;
        }

        private void tv_Departments_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            CurrNode = e.Node;
            CurrEditNode = e.Node;
            ShowEmployeeGrid((int)e.Node.Tag);
            if (RepositoryContext.Active.IsAnyChild((int)e.Node.Tag))
            {
                btn_remEmp.Enabled = false;
                btn_addEmp.Enabled = false;
                btn_empEDIT.Enabled = false;
            }
            else
            {
                if (dg_Employee.Rows.Count != 0)
                {
                    btn_remEmp.Enabled = true;
                    btn_empEDIT.Enabled = true;
                }
                btn_addEmp.Enabled = true;
            }
        }
        private void ShowEmployeeGrid(int tag)
        {
            dg_Employee.Rows.Clear();
            tw_data = RepositoryContext.Active.GetEmployeeTable(tag);
            DataRow[] rows = new DataRow[tw_data.Rows.Count];
            tw_data.Rows.CopyTo(rows, 0);
            emp = new List<Department.Employee>();
            emp = (from DataRow row in tw_data.Rows
                   select new Department.Employee(row["Name"].ToString(), row["Surname"].ToString(), row["MiddleName"].ToString(),
                   row["Age"].ToString(), row["Profession"].ToString(), row["BirthDay"].ToString().Substring(0,row["BirthDay"].ToString().IndexOf("0:00:00")-1), (row["Sex"].ToString() == "True") ? "Мужской" : "Женский",
                   row["EmployeeNumber"].ToString(),"void", row["Id"].ToString())).ToList();
            dg_Employee.ColumnCount = 9;
            dg_Employee.ColumnHeadersVisible = true;
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.Beige;
            columnHeaderStyle.Font = new Font("Verdana", 9, FontStyle.Bold);
            dg_Employee.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dg_Employee.Columns[0].Name = "Имя";
            dg_Employee.Columns[1].Name = "Фамилия";
            dg_Employee.Columns[2].Name = "Отчество";
            dg_Employee.Columns[3].Name = "Возраст";
            dg_Employee.Columns[4].Name = "Профессия";
            dg_Employee.Columns[5].Name = "Пол";
            dg_Employee.Columns[6].Name = "ТН";
            dg_Employee.Columns[7].Name = "ID";
            dg_Employee.Columns[7].Visible = false;
            dg_Employee.Columns[8].Name = "Дата Рождения";
            foreach (Department.Employee x in emp)
            {
                dg_Employee.Rows.Add(new string[] { x.name, x.surname, x.mIddleName,x.age,x.profession,x.sex,
           x.employeeNumber,x.id,x.birthday});
            }
        }
        void HandleAddNodeEvent(object sender, SetMessage e)
        {
            this.Enabled = true;
            if(e.Message != "0k")
            if (CurrEditNode != null)
            {
                CurrEditNode.Nodes.Add(e.Message).Tag=e.Tag;
            }
            else
            {
                tv_Departments.Nodes.Add(e.Message).Tag=e.Tag;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (CurrEditNode == null)
            {
                AddNodeFrm frm = new AddNodeFrm(-1);
                frm.AddNodeEvent += this.HandleAddNodeEvent;
                frm.Show();
            }
            else {
                AddNodeFrm frm = new AddNodeFrm((int)CurrEditNode.Tag);
                frm.AddNodeEvent += this.HandleAddNodeEvent;
                frm.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CurrNode != null)
            {
                RepositoryContext.Active.DropNode((int)CurrNode.Tag);
                tv_Departments.Nodes.Remove(CurrNode);
                CurrNode = null;
                CurrEditNode = null;
            }
        }

        private void btn_remEmp_Click(object sender, EventArgs e)
        {
            RepositoryContext.Active.DeleteEmpoyee(CurrNode.Tag.ToString(), (string)dg_Employee.SelectedRows[0].Cells[7].Value);
            ShowEmployeeGrid((int)CurrNode.Tag);
            if (dg_Employee.Rows.Count==0)
            {
                btn_remEmp.Enabled = false;
                btn_empEDIT.Enabled = false;
            }
            else
            {
                btn_remEmp.Enabled = true;
                btn_empEDIT.Enabled = true;
            }
        }

        private void dg_Employee_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            RepositoryContext.Active.UpdateEmpoyee(new Employee(
                (string)dg_Employee.SelectedRows[0].Cells[0].Value,
                (string)dg_Employee.SelectedRows[0].Cells[1].Value,
                (string)dg_Employee.SelectedRows[0].Cells[2].Value,
                (string)dg_Employee.SelectedRows[0].Cells[3].Value,
                (string)dg_Employee.SelectedRows[0].Cells[4].Value,
                (string)dg_Employee.SelectedRows[0].Cells[8].Value,
                (string)dg_Employee.SelectedRows[0].Cells[5].Value,
                (string)dg_Employee.SelectedRows[0].Cells[6].Value,
                CurrNode.Tag.ToString(),
                (string)dg_Employee.SelectedRows[0].Cells[7].Value));
        }

        private void btn_empEDIT_Click(object sender, EventArgs e)
        {
            if (CurrNode.Tag != null)
            {
                this.Enabled = false;
                AddEmployeeFrm frmEmpAdd = new AddEmployeeFrm(new Employee(
                (string)dg_Employee.SelectedRows[0].Cells[0].Value,
                (string)dg_Employee.SelectedRows[0].Cells[1].Value,
                (string)dg_Employee.SelectedRows[0].Cells[2].Value,
                (string)dg_Employee.SelectedRows[0].Cells[3].Value,
                (string)dg_Employee.SelectedRows[0].Cells[4].Value,
                (string)dg_Employee.SelectedRows[0].Cells[8].Value,
                (string)dg_Employee.SelectedRows[0].Cells[5].Value,
                (string)dg_Employee.SelectedRows[0].Cells[6].Value,
                CurrNode.Tag.ToString(),
                (string)dg_Employee.SelectedRows[0].Cells[7].Value));
                frmEmpAdd.AddEmpEvent += this.HandleAddEmpEvent;
                frmEmpAdd.Show();

            }
        }

        private void tv_Departments_Leave(object sender, EventArgs e)
        {
            //CurrEditNode = null;
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {
            CurrEditNode = null;
        }
    }

     
}
