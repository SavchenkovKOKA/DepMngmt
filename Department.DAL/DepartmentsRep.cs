using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Department.DAL
{
    public class DepartmentsRep
    {
        string conSTR = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DepartmentData.mdf;Integrated Security=True";
        string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        DataTable dt;
        DataRow[] rows;
        Stack<DataTable> dtList;
        Stack<string> rowStack;
        DataTable dtUnion;
        Stack<int> parent;

        public DepartmentsRep()
        {
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            dt = new DataTable();
            dtUnion = new DataTable();
            dtList = new Stack<DataTable>();
        }
        public  bool IsEmployeeNumberValid(string number)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataRow[] rows;
            DataRow[] tmprow;
            string q = "SELECT NoteID from dbo.[DepartmentNotes]";
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand cmd = new SqlCommand(q, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    dt1.Load(cmd.ExecuteReader());
                    rows = dt1.Select();
                    sqlConn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                    return false;
                }
            }
            foreach (var x in rows)
            {
                string q2 = "if (OBJECT_ID('" + GetTabeName((int)x["NoteID"]) + "') is not null) BEGIN SELECT Name from dbo.[" + GetTabeName((int)x["NoteID"]) + "] WHERE EmployeeNumber=" + number+" END";
                using (SqlConnection sqlConn = new SqlConnection(conSTR))
                using (SqlCommand cmd = new SqlCommand(q2, sqlConn))
                {
                    try
                    {
                        sqlConn.Open();
                        dt2.Load(cmd.ExecuteReader());
                        tmprow = dt2.Select();
                        sqlConn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                        return false;
                    }
                }
                if(tmprow.Length != 0)
                {
                    return false;
                }
            }
            return true;
        }
        public  bool IsAnyChild(int tag)
        {
            DataTable dt = new DataTable();
            string q = "SELECT NoteID from dbo.[DepartmentNotes] WHERE ParentNoteID=" + tag.ToString();
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand cmd = new SqlCommand(q, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    dt.Load(cmd.ExecuteReader());
                    sqlConn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                    return false;
                }
            }
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else {
                return true;
            }
        }
        public DataTable GetTreeNodes()
        {
            string query = "SELECT * FROM dbo.[DepartmentNotes]";
            DataTable returnvalue = null;
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    sqlConn.Close();
                    return dt;
                }
                catch 
                {
                    MessageBox.Show("Ошибка подключения"); // тут наверно нужно что-то похитрее
                    return returnvalue;
                }
            }



        }
        public void DropNode(int tag)
        {
            this.parent = new Stack<int>();
            if (IsAnyChild(tag))
            {
                _DropNode(tag);
            }
            DropTable(tag);
            string q = "DELETE FROM dbo.[DepartmentNotes] WHERE NoteID=" + tag.ToString();
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand cmd = new SqlCommand(q, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                }
            }
        }
        private void _DropNode(int tag)
        {
            try {
                DataTable dt = new DataTable();
                DataRow[] rows;
                string q = "SELECT NoteID FROM dbo.[DepartmentNotes] WHERE ParentNoteID=" + tag.ToString();
                using (SqlConnection sqlConn = new SqlConnection(conSTR))
                using (SqlCommand cmd = new SqlCommand(q, sqlConn))
                {

                    sqlConn.Open();
                    dt.Load(cmd.ExecuteReader());
                    rows = dt.Select();
                    sqlConn.Close();

                }
                if (rows.Length != 0) // есть дети 
                {
                    foreach (var x in rows)
                    {
                        this.parent.Push(int.Parse(x["NoteID"].ToString()));
                    }
                }
                else // нет детей 
                {
                    DropTable(int.Parse(tag.ToString()));
                    q = "DELETE FROM dbo.[DepartmentNotes] WHERE NoteID=" + tag.ToString();
                    using (SqlConnection sqlConn = new SqlConnection(conSTR))
                    using (SqlCommand command = new SqlCommand(q, sqlConn))
                    {

                        sqlConn.Open();
                        command.ExecuteNonQuery();
                        sqlConn.Close();


                    }
                    if (this.parent.Count != 0)
                        this.parent.Pop();
                }
                if (this.parent.Count != 0) _DropNode(this.parent.Peek());
            }
            catch
            {
                MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
            }
        }
        private  void DropTable(int tag)
        {
            string q = "if (OBJECT_ID('" + GetTabeName(tag) + "') is not null) BEGIN DROP TABLE " + "dbo.[" + GetTabeName(tag) + "] END";
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand command = new SqlCommand(q, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    command.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                }

            }

        }
        private  void RenameTable(int oldtag, int newtag)
        {

            string q = "if (OBJECT_ID('" + GetTabeName(oldtag) + "') is not null) BEGIN EXEC sp_rename" + "'" + GetTabeName(oldtag) + "'" + ", " + "'" + GetTabeName(newtag) + "' END";
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand command = new SqlCommand(q, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    command.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                }

            }

        }
        public  int AddNode(int tag, string Name, int case_)
        {
            try {
                int lastindex;
                DataTable dt = new DataTable();
                DataRow[] rows;
                DataRow row;
                string q = "INSERT INTO dbo.[DepartmentNotes] (NoteName,ParentNoteID) VALUES (N'" + Name + "'," + tag.ToString() + ")" +
                    "SELECT IDENT_CURRENT ('DepartmentNotes') AS Current_Identity;";
                using (SqlConnection sqlConn = new SqlConnection(conSTR))
                using (SqlCommand cmd = new SqlCommand(q, sqlConn))
                {
                    sqlConn.Open();
                    dt.Load(cmd.ExecuteReader());
                    rows = dt.Select();
                    row = rows[0];
                    lastindex = int.Parse(row["Current_Identity"].ToString());
                    sqlConn.Close();
                }
                switch (case_)
                {
                    case 0:
                        CreateEmployeeTable(Name, lastindex);
                        break;
                    case 1:
                        RenameTable(tag, lastindex);
                        break;
                    default:
                        //Console.WriteLine("Default case");
                        break;
                }
                return lastindex;
            }
            catch
            {
                MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                return 0;
            }
        }
        private  string GetTabeName(int NodeID)
        {
            DataTable dt = new DataTable();
            DataRow[] rows;
            DataRow row;
            string query = "SELECT NoteName FROM dbo.[DepartmentNotes] WHERE NoteID=" + NodeID.ToString();
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand cmd = new SqlCommand(query, sqlConn))
            {
                try {
                    sqlConn.Open();
                    dt.Load(cmd.ExecuteReader());
                    rows = dt.Select();
                    row = rows[0];
                    sqlConn.Close();
                    using (MD5 md5Hash = MD5.Create())
                    {
                        string hash = GetMd5Hash(md5Hash, row["NoteName"].ToString() + NodeID.ToString());
                        return hash;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                    return "void";
                }

            }
        }

        public DataTable GetEmployeeTable(int id)
        {

            dtList.Clear();
            dtUnion.Clear();
            rowStack = new Stack<string>();
            rowStack.Clear();
            return GetEmployeeTable_(id);
        }
        private DataTable GetEmployeeTable_(int id)
        {
            DataTable retval = null;
            try {
                dt.Clear();
                if (rows != null)
                {
                    Array.Clear(rows, 0, rows.Length);
                }
                string query1 = "SELECT NoteID FROM dbo.[DepartmentNotes] WHERE ParentNoteID=" + id.ToString();
                using (SqlConnection sqlConn = new SqlConnection(conSTR))
                using (SqlCommand cmd = new SqlCommand(query1, sqlConn))
                {
                    sqlConn.Open();
                    dt.Load(cmd.ExecuteReader());
                    rows = dt.Select();
                    sqlConn.Close();
                }
                if (rows.Length == 0)
                {
                    string tablename = GetTabeName(id);
                    string query = "if (OBJECT_ID('" + tablename + "') is not null) BEGIN SELECT * FROM dbo.[" + tablename + "] END";
                    using (SqlConnection sqlConn = new SqlConnection(conSTR))
                    using (SqlCommand cmd = new SqlCommand(query, sqlConn))
                    {
                        sqlConn.Open();
                        dtList.Push(new DataTable());
                        dtList.Peek().Load(cmd.ExecuteReader());
                        sqlConn.Close();
                        if (rowStack.Count != 0)
                        {
                            GetEmployeeTable_(int.Parse(rowStack.Pop()));
                        }
                    }
                }
                else
                {
                    foreach (DataRow dr in rows)
                    {
                        rowStack.Push(dr["NoteID"].ToString());
                    }
                    GetEmployeeTable_((int.Parse(rowStack.Pop())));


                }
                if (dtList.Count != 0)
                {
                    while (dtList.Count != 0)
                    {
                        dtUnion.Merge(dtList.Pop(), true);
                        dtUnion.AcceptChanges();
                    }
                }

                return dtUnion;
            }
            catch
            {
                MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                return retval;
            }

        }
        public  void CreateEmployeeTable(string RusName, int NodeID)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, RusName + NodeID.ToString());
                var commandStr = "If not exists (select name from sysobjects where name = '" + hash.ToString() + "')" +
                    "CREATE TABLE [dbo].[" + hash.ToString() + "]" +
                    "(" +
                        "[Id] INT NOT NULL PRIMARY KEY IDENTITY,"
                            + "[Name] NVARCHAR(50) NULL, "
                              + "[Surname] NVARCHAR(50) NULL, "
                               + "[MiddleName] NVARCHAR(50) NULL, "
                                + "[Age]"
                                + "INT NULL,"
                            + "[Profession] NVARCHAR(50) NULL, "
                            + "[BirthDay] Date NULL, "
                            + "[Sex]"
                            + "BIT NULL,"
                            + "[EmployeeNumber] INT NULL" +
                      ")";
                using (SqlConnection sqlConn = new SqlConnection(conSTR))
                using (SqlCommand command = new SqlCommand(commandStr, sqlConn))
                {
                    try
                    {
                        sqlConn.Open();
                        command.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                    }
                }

            }
        }
        private  string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public  void AddEmpoyee(Employee emp)
        {
            if (!IsAnyChild(int.Parse(emp.tag))){
                string tableName = GetTabeName(int.Parse(emp.tag));
                string commandStr = "start: if (OBJECT_ID('" + tableName + "') is not null)" +
                    "BEGIN " +
                    "INSERT INTO " + "[dbo].[" + tableName + "]" +
                    "(Name,Surname,MiddleName,Age,Sex,Profession,BirthDay,EmployeeNumber)" +
                    "VALUES(" + "N'" + emp.name + "'," + "N'" + emp.surname + "'," + "N'" + emp.mIddleName + "'," + emp.age + "," + emp.sex + "," + "N'" + emp.profession + "', CONVERT(date,'"+emp.birthday+"',105)," + emp.employeeNumber + ")" +
                    "END " +
                    "ELSE " +
                    "BEGIN " +
                    "CREATE TABLE [dbo].[" + tableName + "]" +
                        "(" +
                            "[Id] INT NOT NULL PRIMARY KEY IDENTITY,"
                                + "[Name] NVARCHAR(50) NULL, "
                                  + "[Surname] NVARCHAR(50) NULL, "
                                   + "[MiddleName] NVARCHAR(50) NULL, "
                                    + "[Age]"
                                    + "INT NULL,"
                                + "[Profession] NVARCHAR(50) NULL, "
                                + "[BirthDay] Date NULL, "
                                + "[Sex]"
                                + "BIT NULL,"
                                + "[EmployeeNumber] INT NULL" +
                          ") " + "GOTO start; " +
                    "END";

                //Нужно было использовать параметры для запроса, но уже поздно, слишком поздно
                using (SqlConnection sqlConn = new SqlConnection(conSTR))
                using (SqlCommand command = new SqlCommand(commandStr, sqlConn))
                {
                    try
                    {
                        sqlConn.Open();
                        command.ExecuteNonQuery();
                        sqlConn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                    }
                }
            }
        }
        public  void UpdateEmpoyee(Employee emp)
        {
            string tableName = GetTabeName(int.Parse(emp.tag));
            string commandStr = "if (OBJECT_ID('" + tableName + "') is not null)" +
                "BEGIN " +
                "UPDATE " + "[dbo].["+tableName+"]" + "SET "+
                "Name=N'" + emp.name + "',"+
                "Surname=N'" + emp.surname + "'," +
                "MiddleName=N'" + emp.mIddleName + "'," +
                "EmployeeNumber=" + emp.employeeNumber + "," +
                "Age="+emp.age+ "," +
                "Sex=" +emp.sex+ "," +
                "BirthDay='" + emp.birthday + "'," +
                "Profession=N'" + emp.profession + "'" +
                "WHERE ID="+emp.id.ToString()+
                " END";
            //Нужно было бы использовать параметры для запроса
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand command = new SqlCommand(commandStr, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    command.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                }
            }
        }
        public void DeleteEmpoyee(string tag, string id)
        {
            string tableName = GetTabeName(int.Parse(tag));
            string commandStr = "DELETE FROM dbo.["+ tableName+"] WHERE Id=" + id;
            using (SqlConnection sqlConn = new SqlConnection(conSTR))
            using (SqlCommand command = new SqlCommand(commandStr, sqlConn))
            {
                try
                {
                    sqlConn.Open();
                    command.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка на сервере"); // тут наверно нужно что-то похитрее
                }
            }
        }
    }
}
