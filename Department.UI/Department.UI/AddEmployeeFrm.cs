using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Department.DAL;

namespace Department.UI
{
    public partial class AddEmployeeFrm : Form
    {
        public event EventHandler<SetMessage> AddEmpEvent;
        int tag;
        string empid;
        bool IsEditing;
        string EmployeenumberBuffer;
        Employee tmpEmp;
        public AddEmployeeFrm(int tag)
        {
            IsEditing = false;
            this.tag = tag;
            InitializeComponent();
        }
        public AddEmployeeFrm(Employee emp)
        {
            tmpEmp = emp;
            InitializeComponent();
            IsEditing = true;
            tb_name.Text = emp.name;
            tb_surname.Text = emp.surname;
            tb_age.Text = emp.age;
            tb_middle.Text = emp.mIddleName;
            tb_prof.Text = emp.profession;
            tb_tH.Text = emp.employeeNumber;
            EmployeenumberBuffer = emp.employeeNumber;
            tb_bith.Text = emp.birthday;
            this.tag = int.Parse(emp.tag);
            this.empid = emp.id;
            if (emp.sex == "Мужской") rb_male.Checked = true; else { rb_female.Checked = true; }

        }
        protected virtual void OnRaiseAddEmpEvent(SetMessage e)
        {

            EventHandler<SetMessage> handler = AddEmpEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string format = "mm.dd.yyyy";
            if (tb_age.Text.Length!=0 && tb_bith.Text.Length!=0 &&tb_middle.Text.Length!=0 &&tb_name.Text.Length!=0 &&tb_surname.Text.Length!=0 && tb_prof.Text.Length!=0 
                && tb_tH.Text.Length!=0)
            if (RepositoryContext.Active.IsEmployeeNumberValid(tb_tH.Text)|| EmployeenumberBuffer==tb_tH.Text)
            {
                if (IsEditing)
                {
                    RepositoryContext.Active.UpdateEmpoyee(new Employee(tb_name.Text, tb_surname.Text, tb_middle.Text, tb_age.Text, tb_prof.Text, DateTime.Parse(tb_bith.Text).ToString(),
                    (rb_male.Checked) ? "1" : "0", tb_tH.Text, this.tag.ToString(), this.empid));

                }
                else {
                    RepositoryContext.Active.AddEmpoyee(new Employee(tb_name.Text, tb_surname.Text, tb_middle.Text, tb_age.Text, tb_prof.Text, DateTime.Parse(tb_bith.Text).ToString(),
                        (rb_male.Checked) ? "1" : "0", tb_tH.Text, this.tag.ToString()));
                }
                this.OnRaiseAddEmpEvent(new SetMessage("0k"));
                this.Close();
            }
            else { MessageBox.Show("Табельный номер занят"); }
            else
                MessageBox.Show("Форма не заполнена");

        }
    

        private void AddEmployeeFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.OnRaiseAddEmpEvent(new SetMessage("0k"));
        }

       

        private void tb_bith_Validating(object sender, CancelEventArgs e)
        {
            Regex rgx = new Regex(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");
            if (!tb_bith.MaskFull ||!rgx.IsMatch(tb_bith.Text))
            {
                MessageBox.Show("Некоректный формат даты");
                if (IsEditing)
                    tb_bith.Text = tmpEmp.birthday;
                else
                    tb_bith.Clear();
            }
        }

        private void tb_name_Validating(object sender, CancelEventArgs e)
        {
            Regex rgx = new Regex(@"^[а-яА-ЯёЁa]+$");
            if ( !rgx.IsMatch(tb_name.Text))
            {
                MessageBox.Show("Неверный формат ввода. Для имени разрешается использовать только русские буквы.");
                if (IsEditing)
                    tb_name.Text = tmpEmp.name;
                else
                    tb_name.Clear();
            }
        }

        private void tb_surname_Validating(object sender, CancelEventArgs e)
        {
            Regex rgx = new Regex(@"^[а-яА-ЯёЁa]+$");
            if ( !rgx.IsMatch(tb_surname.Text))
            {
                MessageBox.Show("Неверный формат ввода. Для фамилии разрешается использовать только русские буквы.");
                if (IsEditing)
                    tb_surname.Text = tmpEmp.surname;
                else
                    tb_surname.Clear();
            }
        }

        private void tb_middle_TextChanged(object sender, EventArgs e)
        {
            Regex rgx = new Regex(@"^[а-яА-ЯёЁa]+$");
            if (!rgx.IsMatch(tb_middle.Text))
            {
                MessageBox.Show("Неверный формат ввода. Для отчества разрешается использовать только русские буквы.");
                if (IsEditing)
                    tb_middle.Text = tmpEmp.mIddleName;
                else
                    tb_middle.Clear();
            }
        }

        private void tb_prof_Validating(object sender, CancelEventArgs e)
        {
            Regex rgx = new Regex(@"^[а-яА-ЯёЁa]+$");
            if (!rgx.IsMatch(tb_prof.Text))
            {
                MessageBox.Show("Неверный формат ввода. Для професии разрешается использовать только русские буквы.");
                if (IsEditing)
                    tb_prof.Text = tmpEmp.profession;
                else
                    tb_prof.Clear();
            }
        }

        private void tb_age_Validating(object sender, CancelEventArgs e)
        {
            Regex rgx = new Regex(@"^(?:100|[1-9]\d|[6-9])$");
            if (!rgx.IsMatch(tb_age.Text))
            {
                MessageBox.Show("Неверный формат возраста.");
                if (IsEditing)
                    tb_age.Text = tmpEmp.age;
                else
                    tb_age.Clear();
            }
        }

        private void tb_tH_Validating(object sender, CancelEventArgs e)
        {
            Regex rgx = new Regex(@"^\d+$");
            if (!rgx.IsMatch(tb_tH.Text))
            {
                MessageBox.Show("Неверный формат Табельного номера.");
                if (IsEditing)
                    tb_tH.Text = tmpEmp.employeeNumber;
                else
                    tb_tH.Clear();
            }
        }
    }
}
