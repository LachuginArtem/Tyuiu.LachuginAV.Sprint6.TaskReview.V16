using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.LachuginAV.Sprint6.TaskReview.V16.Lib;

namespace Tyuiu.LachuginAV.Sprint6.TaskReview.V16
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        DataService ds = new DataService();

        private void buttonDone_LAV_Click(object sender, EventArgs e)
        {
            //
        }

        private void buttonPushMatrix_LAV_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBoxColumns_LAV.Text, out int rows) && int.TryParse(textBoxColumns_LAV.Text, out int columns))
            {
                dataGridViewMatrix_LAV.Columns.Clear();
                dataGridViewMatrix_LAV.Rows.Clear();
                dataGridViewMatrix_LAV.RowCount = rows;
                dataGridViewMatrix_LAV.ColumnCount = columns;

                int[,] array = new int[rows, columns];
                Random random = new Random();
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        array[i, j] = random.Next(Convert.ToInt32(textBoxDiapN1_LAV.Text), Convert.ToInt32(textBoxDiapN2_LAV.Text) + 1);
                        dataGridViewMatrix_LAV.Rows[i].Cells[j].Value = array[i, j];
                        if (j > 1)
                        {
                            array[i, j] = array[i, j - 2] * array[i, j - 1];
                            dataGridViewMatrix_LAV.Rows[i].Cells[j].Value = array[i, j];
                        }
                        dataGridViewMatrix_LAV.Columns[j].Width = 45;
                        dataGridViewMatrix_LAV.Rows[i].Height = 45;
                    }
                }
                DataService ds = new DataService();
                try
                {
                    textBoxResult_LAV.Text = Convert.ToString(ds.GetMatrix(array, Convert.ToInt32(textBoxDiapN1_LAV.Text),
                        Convert.ToInt32(textBoxDiapN2_LAV.Text), Convert.ToInt32(textBoxValueC_LAV.Text), Convert.ToInt32(textBoxValueK_LAV.Text),
                        Convert.ToInt32(textBoxValueL_LAV.Text)));
                }
                catch
                {
                    MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Введены неверные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonInfo_LAV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Таск Ревью выполнил студент группы АСОиУб-23-3 Лачугин Артем Викторович", "Вам пришло новое сообщение", MessageBoxButtons.OK);
        }
    }
}
