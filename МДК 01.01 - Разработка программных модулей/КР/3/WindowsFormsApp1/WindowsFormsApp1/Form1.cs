using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int a, b, n;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ColumnCount = 1;
                dataGridView1.RowCount = n;
                dataGridView2.ColumnCount = 1;
                dataGridView2.RowCount = n;
                dataGridView3.ColumnCount = 1;
                dataGridView3.RowCount = n;
                int[] arrD = new int[n];
                int[] arrE = new int[n];
                double[] arrF = new double[n];
                int i, j;
                Random rand = new Random();
                for (i = 0; i < n; i++)
                {
                    arrD[i] = rand.Next(a, b);
                    arrE[i] = rand.Next(a, b);

                }
                double F = 0;
                j = 1;
                for (i = 0; i < n; i++)
                {
                    F = (2 * arrD[i] + Math.Sin(arrE[i])) / arrD[i];
                    if (1 < F && F < 3)
                        arrF[i] = F;

                }

                //Выводим матрицу в dataGridView1
                for (i = 0; i < n; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(arrD[i]);
                    dataGridView2.Rows[i].Cells[0].Value = Convert.ToString(arrE[i]);
                    dataGridView3.Rows[i].Cells[0].Value = Convert.ToString(arrF[i]);
                }
            }
            catch 
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception) 
            {
                label7.Text = "Пожалуйста, введите правильные данные(без букв, лишних символов и т.д.)";
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                b = Convert.ToInt32(textBox2.Text);
            }
            catch (Exception)
            {
                label7.Text = "Пожалуйста, введите правильные данные(без букв, лишних символов и т.д.)";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception)
            {
                label7.Text = "Пожалуйста, введите правильные данные(без букв, лишних символов и т.д.)";
            }
        }
    }
}
