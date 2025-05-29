using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Рандомайзер
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        

        private void generate_Click(object sender, EventArgs e)
        {
            GenerateNumbers();
        }
        private void GenerateNumbers()
        {
            Result.Clear();
            swo.Items.Clear();

            if (!int.TryParse(from1.Text, out int min))
            {
                MessageBox.Show("Неверное значение в поле 'from'");
                return;
            }

            if (!int.TryParse(to1.Text, out int max))
            {
                MessageBox.Show("Неверное значение в поле 'to'");
                return;
            }

            if (min > max)
            {
                MessageBox.Show("'from' должно быть меньше или равно 'to'");
                return;
            }

            int count = (int)numericUpDown1.Value;
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int number = rnd.Next(min, max + 1);
                numbers.Add(number);
                swo.Items.Add(number);
            }

            // Вывод через запятую
            Result.Text = string.Join(", ", numbers);

            if (swo.Items.Count > 0)
                swo.SelectedIndex = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            GenerateNumbers();
        }

        private void from1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void from1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void to1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Result.Clear();
        }
    }
}
