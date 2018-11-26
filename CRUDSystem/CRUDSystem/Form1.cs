using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDSystem.Entities;

namespace CRUDSystem
{
    public partial class Form1 : Form
    {
        Details MyDetail = new Details();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopGridView();
        }

        private void PopGridView()
        {
            using (var MyModelEntities = new MyModel())
            {
                dataGridView1.DataSource = MyModelEntities.Details.ToList<Details>();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyDetail.Fname = txtFName.Text;
            MyDetail.Lname = txtLName.Text;
            MyDetail.Age = Convert.ToInt32(txtAge.Text);
            MyDetail.Address = txtAddres.Text;
            MyDetail.DOB = Convert.ToDateTime(dtDOB.Text);

            using (var MyDbEntities = new MyModel())
            {
                if (MyDetail.ID == 0)
                {
                    MyDbEntities.Details.Add(MyDetail);
                    MyDbEntities.SaveChanges();
                }

                else
                {
                    MyDbEntities.Entry(MyDetail).State = System.Data.Entity.EntityState.Modified;
                    MyDbEntities.SaveChanges();

                    btnSave.Text = "Save";
                }

                
            }

            PopGridView();
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //MyDetail.Fname = txtFName.Text;
            //MyDetail.Lname = txtLName.Text;
            //MyDetail.Age = Convert.ToInt32(txtAge.Text);
            //MyDetail.Address = txtAddres.Text;
            //MyDetail.DOB = Convert.ToDateTime(dtDOB.Text);

            //using (var MyDbEntities = new MyModel())
            //{
                
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*Usamos currentRow para referirnos a una sola fila */
            if (dataGridView1.CurrentRow.Index != -1)
            {
                MyDetail.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                using (var MyDBEntities = new MyModel())
                {
                    MyDetail = MyDBEntities.Details.Where(x => x.ID == MyDetail.ID).FirstOrDefault();
                    txtFName.Text = MyDetail.Fname;
                    txtLName.Text = MyDetail.Lname;
                    txtAge.Text = MyDetail.Age.ToString();
                    txtAddres.Text = MyDetail.Address;
                    dtDOB.Text = MyDetail.DOB.ToString();

                    btnSave.Text = "Update";

                }
            }
        }
    }
}
