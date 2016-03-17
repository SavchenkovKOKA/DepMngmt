using System;
using System.Collections.Generic;
using System.Text;

namespace Department
{
     public class Employee : EventArgs
    {
        public Employee(string Name, string Surname, string MIddleName, string Age,string Profession, string Birthday, string Sex, string EmployeeNumber, string tag, string id ="void")
        {
            this.Name = Name;
            this.Surname = Surname;
            this.MIddleName = MIddleName;
            this.Age = Age;
            this.Profession = Profession;
            this.Sex = Sex;
            this.EmployeeNumber = EmployeeNumber;
            this.tag = tag;
            this.ID = id;
            this.Birthday = Birthday;
        }
        private string Tag;
        private string ID;
        private string Name;
        private string Surname;
        private string MIddleName;
        private string Age;
        private string Profession;
        private string Sex;
        private string Birthday;
        private string EmployeeNumber;
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string surname
        {
            get { return Surname; }
            set { Surname = value; }
        }
        public string mIddleName
        {
            get { return MIddleName; }
            set { MIddleName = value; }
        }
        public string age
        {
            get { return Age; }
            set { Age = value; }
        }
        public string profession
        {
            get { return Profession; }
            set { Profession = value; }
        }
        public string sex
        {
            get { return Sex; }
            set { Sex = value; }
        }
        public string employeeNumber
        {
            get { return EmployeeNumber; }
            set { EmployeeNumber = value; }
        }
        public string tag
        {
            get { return Tag; }
            set { Tag = value; }
        }
        public string id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string birthday
        {
            get { return Birthday; }
            set { Birthday = value; }
        }
    }
}
