using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Department.DAL;

namespace Department.UI
{
    public partial class AddNodeFrm : Form
    {
        public event EventHandler<SetMessage> AddNodeEvent;
        int tag;
        public AddNodeFrm(int tag)
        {
            this.tag = tag;
            InitializeComponent();
        }
        private void AddNode(string name, int tag)
        {
            int case_;
            if (tag == -1 || RepositoryContext.Active.IsAnyChild(tag)) case_ = 0; else case_ = 1;
            this.OnRaiseAddNodeEvent(new SetMessage(name, RepositoryContext.Active.AddNode(tag, name, case_)));
            this.Close();
        }
        protected virtual void OnRaiseAddNodeEvent(SetMessage e)
        {

            EventHandler<SetMessage> handler = AddNodeEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnRaiseAddEmpEvent(SetMessage e)
        {

            EventHandler<SetMessage> handler = AddNodeEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (tb_node.Text.Length != 0)
                AddNode(tb_node.Text, this.tag);
            else
                MessageBox.Show("Форма не заполнена");
        }

        private void AddNodeFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.OnRaiseAddEmpEvent(new SetMessage("0k"));
        }
    }
}
