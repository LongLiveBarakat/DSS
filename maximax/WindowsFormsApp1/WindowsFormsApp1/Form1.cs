using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();            
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            kryptonDataGridView1.Rows.Add(textBox2.Text, textBox3.Text, textBox4.Text);
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }


        private void MaxiMaxbtn(object sender, EventArgs e)
        {
            List<double> maxValues = new List<double>();

            for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
            {
                double max = double.MinValue;

                for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                {
                    double cellValue = Convert.ToDouble(kryptonDataGridView1.Rows[i].Cells[j].Value);
                    if (cellValue > max)
                    {
                        max = cellValue;
                    }
                }
                maxValues.Add(max);
            }
            double maximax = maxValues[0];

            foreach (double item in maxValues)
            {
                if (item > maximax)
                {
                    maximax = item;
                }
            }
            Maximax.Text = maximax.ToString();
        }

        private void Minmaxbtn_Click(object sender, EventArgs e)
        {
            List<double> maxValues = new List<double>();

            for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
            {
                double min = double.MaxValue;

                for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                {
                    double cellValue = Convert.ToDouble(kryptonDataGridView1.Rows[i].Cells[j].Value);
                    if (cellValue < min)
                    {
                        min = cellValue;
                    }
                }
                maxValues.Add(min);
            }
            double minimax = maxValues[0];
            foreach (double item in maxValues)
            {
                if (item > minimax)
                {
                    minimax = item;
                }
            }
            Minimax.Text = minimax.ToString();
        }

        private void Equallybtn_Click(object sender, EventArgs e)
        {
            List<int> rowSums = new List<int>();
            List<double> rowAverages = new List<double>();

            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                int sum = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString() != "")
                    {
                        sum += Convert.ToInt32(cell.Value);
                    }
                }
                rowSums.Add(sum);
                rowAverages.Add((double)sum / row.Cells.Count);
            }
            double maxAverage = rowAverages[0];
            foreach(double item in rowAverages)
            {
                if(item> maxAverage) {maxAverage= item; }
            }
            Equallylike.Text = maxAverage.ToString();
        }

        private void MinimaxRegretbtn_Click(object sender, EventArgs e)
        {
            int rowCount = kryptonDataGridView1.Rows.Count;
            int columnCount = kryptonDataGridView1.Columns.Count;
            double[,] newArray = new double[rowCount, columnCount];

            for (int j = 0; j < columnCount; j++)
            {
                double max = double.MinValue;
                for (int i = 0; i < rowCount; i++)
                {
                    double cellValue = Convert.ToDouble(kryptonDataGridView1.Rows[i].Cells[j].Value);
                    if (cellValue > max) max = cellValue;             
                }

                for (int i = 0; i < rowCount; i++)
                {
                    double cellValue = Convert.ToDouble(kryptonDataGridView1.Rows[i].Cells[j].Value);
                    newArray[i, j] = max-cellValue;
                }
            }

            List<double> maxValues = new List<double>();

            for (int i = 0; i < rowCount; i++)
            {
                double max = double.MinValue;
                for (int j = 0; j < columnCount; j++)
                {
                    double cellValue = newArray[i, j];

                    if (cellValue > max) max = cellValue;
                }
                maxValues.Add(max);
            }
            double Miniregret = maxValues[0];
            for(int i = 0; i<maxValues.Count; i++)
                if (maxValues[i]<Miniregret) Miniregret = maxValues[i];

            MinimaxRegert.Text= Miniregret.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonGroup1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
