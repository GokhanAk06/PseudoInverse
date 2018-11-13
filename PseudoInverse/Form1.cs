using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoInverse
{
    public partial class mainScreen: Form
    {

        Random rnd = new Random();

        public mainScreen()
        {
            InitializeComponent();
        }

        //--------------> M
        // |
        // |
        // |
        // |
        // |
        // \/
        // N

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public int MNValue()
        {
            // 1,2,3,4,5 değerlerini alabilir. MaxValue Not include.
            int rand = rnd.Next(1, 6);
            return rand;
        }

        public double MatrixValue()
        {
            double rand = rnd.NextDouble() * (9.00 - 1.00) + 1.00;

            //Virgülden sonra 1 basamak alabilmek için.
            rand = Math.Round(rand, 1);
            return rand;
        }

        private void rndmBttn_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Enabled = false;
            dgv.RowHeadersVisible = false;


            int M = MNValue();
            int N = MNValue();

            dgvColumn(M);

            for(int i = 0; i < N; i++)
            {
                dgv.Rows.Add();
                for(int j = 0; j < M; j++)
                {
                    dgv.Rows[i].Cells[j].Value = MatrixValue();
                }
            }
        }

        public void dgvColumn(int M)
        {
            dgv.ColumnCount = M;
        }

        private void handBttn_Click(object sender, EventArgs e)
        {
            int M = 0, N = 0;
            dgv.Rows.Clear();
            if(Convert.ToInt32(mValue.Text) >= 1 && Convert.ToInt32(mValue.Text) < 6 && Convert.ToInt32(nValue.Text) >= 1 && Convert.ToInt32(nValue.Text) < 6)
            {
                 M = Convert.ToInt32(mValue.Text);
                 N = Convert.ToInt32(nValue.Text);
            }
            else
            {
                MessageBox.Show("Girdiğiniz Sayı 1-5 aralığında değil.");
                mValue.Text = string.Empty;
                nValue.Text = string.Empty;
            }

            dgvColumn(M);
            for(int i = 0; i < N; i++)
            {
                dgv.Rows.Add();
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Enabled = true;
            dgv.RowHeadersVisible = false;
        }

        private void mValue_TextChanged(object sender, EventArgs e)
        {
            if(System.Text.RegularExpressions.Regex.IsMatch(mValue.Text, "[^1-5]"))
            {
                MessageBox.Show("Please enter only numbers.");
                mValue.Text = string.Empty;
            }
        }

        private void nValue_TextChanged(object sender, EventArgs e)
        {
            if(System.Text.RegularExpressions.Regex.IsMatch(nValue.Text, "[^1-5]"))
            {
                MessageBox.Show("Please enter only numbers.");
                nValue.Text = string.Empty;
            }
        }
    }
}
