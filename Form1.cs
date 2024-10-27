using Databinding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Databinding
{
    public partial class Form1 : Form
    {
        private StudentModel studentModel = new StudentModel();
        private BindingSource bindingSource = new BindingSource();
        private int currentIndex = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource.DataSource = studentModel.Students.ToList();
            dataGridView1.DataSource = bindingSource;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       // private void Form1_Load(object sender, EventArgs e)
       // {

       // }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            var student = new Students
            {
                FullName = textBox1.Text,
                Age = int.Parse(textBox2.Text),
                Major = comboBox1.Text
            };
            studentModel.Students.Add(student);
            studentModel.SaveChanges();

            bindingSource.DataSource = studentModel.Students.ToList();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            if (bindingSource.Current is Students student)
            {
                student.FullName = textBox1.Text;
                student.Age = int.Parse(textBox2.Text);
                student.Major = comboBox1.Text;
                studentModel.SaveChanges();

                bindingSource.DataSource = studentModel.Students.ToList();
            }
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
           
                if (bindingSource.Current is Students student)
                {
                    studentModel.Students.Remove(student);
                    studentModel.SaveChanges();
                    bindingSource.DataSource = studentModel.Students.ToList();
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentIndex < bindingSource.Count - 1)
            {
                currentIndex++;
                bindingSource.Position = currentIndex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                bindingSource.Position = currentIndex;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current is Students student)
            {
                textBox1.Text = student.FullName;
                textBox2.Text = student.Age.ToString();
                comboBox1.Text = student.Major;
            }
        }
    }
}
