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
                MyDbEntities.Details.Add(MyDetail);
                MyDbEntities.SaveChanges();
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
           
        }
    }
}
