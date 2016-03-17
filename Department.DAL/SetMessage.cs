using System;
using System.Collections.Generic;
using System.Text;

namespace Department.DAL
{
     public class SetMessage : EventArgs
    {
        public SetMessage(string s, int t = -100)
        {
            message = s;
            tag = t;
        }
        private string message;
        private int tag;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public int Tag
        {
            get { return tag; }
            set { tag = value; }
        }
    }
}
