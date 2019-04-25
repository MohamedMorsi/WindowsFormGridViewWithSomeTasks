using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main
{
    public partial class student : Form
    {
        main main;
        public student(main value)
        {
            InitializeComponent();
            main = value;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Add_Click(object sender, EventArgs e)
        {
          
            string[] row = { SID.Text, SNAme.Text, School.Text};
            int index = main.DGV.Rows.Count;
            main.DGV.Rows.Insert(index,row);
            main.DGV.NotifyCurrentCellDirty(true);


            Close();

        }

        private void student_Load(object sender, EventArgs e)
        {

        }

        private void SNAme_TextChanged(object sender, EventArgs e)
        {

        }

        private void School_TextChanged(object sender, EventArgs e)
        {

        }

        private void SID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Edit_Click(object sender, EventArgs e)
        {
            string[] row = { SID.Text, SNAme.Text, School.Text };
            int index = main.DGV.Rows.IndexOf(main.DGV.CurrentRow);
            main.DGV.Rows.RemoveAt(index);
            main.DGV.Rows.Insert(index, row);
            
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
