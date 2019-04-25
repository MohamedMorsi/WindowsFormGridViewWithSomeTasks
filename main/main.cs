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
    public partial class main : Form
    {
      
        public main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want Delete This Student ? "
                    , "Messege", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DGV.Rows.Remove(DGV.CurrentRow);
                }
            }
            else if (DGV.Columns[e.ColumnIndex].Name == "Edit")
            {
                student Edit = new student(this);
                Edit.SID.Text = this.DGV.CurrentRow.Cells[0].Value.ToString();
                Edit.SNAme.Text = this.DGV.CurrentRow.Cells[1].Value.ToString();
                Edit.School.Text = this.DGV.CurrentRow.Cells[2].Value.ToString();
                Edit.label1.Text = "Edit Student";
                Edit.Add.Hide();
                Edit.SID.Enabled = false;
                Edit.ShowDialog(this);
            }
            else
            {
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            student view = new student(this);
            view.label1.Text = "Add Student";
            view.Edit.Hide();
            view.SID.Enabled = true;
            view.ShowDialog(this);
        }

        private void Searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
         
        }

        private void Searchbox_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

        private void Searchbox_TextChanged(object sender, EventArgs e)
        {
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            rows = null;

            for (int i = 0; i<=DGV.Rows.Count-1;i++)
            {
                DGV.Rows[i].Selected = false;
            }

            if (Searchbox.Text != "" || Searchbox.Text==" ")
            {
                int rowIndex = -1;
                rows = DGV.Rows
               .Cast<DataGridViewRow>()
               .Where(
                    r => r.Cells["ID"].Value.ToString().Equals(Searchbox.Text)
                    ||
                    r.Cells["StudentName"].Value.ToString().Equals(Searchbox.Text)
                    ||
                    r.Cells["SchoolName"].Value.ToString().Equals(Searchbox.Text)
                    ).ToList();
                if (rows != null)
                {
                    foreach (var item in rows)
                    {
                        rowIndex = item.Index;
                        if (item != null)
                        {
                            DGV.Rows[rowIndex].Selected = true;
                        }
                        else
                        {
                        }
                    }
                }
            } 
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void Download_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
 
            app.Visible = true;

            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
 
            worksheet.Name = "Exported from gridview";

            for (int i = 1; i < DGV.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = DGV.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < DGV.Rows.Count - 1; i++)
            {
                for (int j = 0; j < DGV.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = DGV.Rows[i].Cells[j].Value.ToString();
                }
            }

            workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            app.Quit();
        }
    }
}
