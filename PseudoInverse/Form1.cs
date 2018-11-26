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
        double[,] firstMatris;
        double[,] E;
        int sayac = 0;

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
            sayac = 0;
            dgv.Rows.Clear();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Enabled = false;
            dgv.RowHeadersVisible = false;

            int M = MNValue();
            int N = MNValue();


            //Aynı ise?
            while(M == N)
            {
                N = MNValue();
            }


            firstMatris = new double[N, M];

            dgvColumn(M);

            for(int i = 0; i < N; i++)
            {
                dgv.Rows.Add();
                for(int j = 0; j < M; j++)
                {
                    dgv.Rows[i].Cells[j].Value = MatrixValue();
                    firstMatris[i, j] = Convert.ToDouble(dgv.Rows[i].Cells[j].Value);
                }
            }
           // MessageBox.Show("get0 değeri " + firstMatris.GetLength(0));

        }


        public void dgvColumn(int M)
        {
            dgv.ColumnCount = M;
        }


        private void handBttn_Click(object sender, EventArgs e)
        {
            sayac = 0;
            int M = 0, N = 0;
            dgv.Rows.Clear();
            if(Convert.ToInt32(mValue.Text) >= 1 && Convert.ToInt32(mValue.Text) < 6 && Convert.ToInt32(nValue.Text) >= 1 && Convert.ToInt32(nValue.Text) < 6)// && Convert.ToInt32(nValue.Text) != Convert.ToInt32(mValue.Text))
            {
                M = Convert.ToInt32(mValue.Text);
                N = Convert.ToInt32(nValue.Text);
                mValue.Enabled = false;
                nValue.Enabled = false;
            }
            else
            {
                MessageBox.Show("Girdiğiniz Sayı 1-5 aralığında değil ve/veya M=N ");
                mValue.Text = string.Empty;
                nValue.Text = string.Empty;
            }

            dgvColumn(N);
            for(int i = 0; i < M; i++)
            {
                dgv.Rows.Add();
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.Enabled = true;
            dgv.RowHeadersVisible = false;

            //first matrise atama işlemi yapılacaktır.
        }


        //Textboxlara sadece 1 ile 5 arası sayı kontrolü
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

        // M*MTranspose u hesaplıyor.
        public double[,] mxmTranspose(double[,] M, double[,] MTr)
        {
            int n = M.GetLength(0);
            int m = MTr.GetLength(1);
            double[,] mxmTranspose = new double[m, n];


            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    double toplam = 0;
                    for(int k = 0; k < M.GetLength(1); k++)
                    {
                        toplam += M[i, k] * MTr[k, j];
                    }
                    mxmTranspose[i, j] = toplam;
                }
            }
            return mxmTranspose;
        }

        int which = 0;
        double[,] result;
        private void nxtStepBttn_Click(object sender, EventArgs e)
        {
            if(sayac == 0)
            {
                //Mtranspose X M
                sayac += 1;
                label5.Text = "A^A";
                MessageBox.Show("A Transpose x A nın determinantı hesaplanacaktır.");
                mxmTransposeDgvWriter(firstMatris);
                which = 1;
                double determinant = DET(E.GetLength(0), E);
                if(determinant == 0)
                {
                    label5.Text = "AA^";
                    MessageBox.Show("A Transpose x A nın determinantı 0 olduğundan dolayı A x A Transpose hesaplanacaktır.");
                    mxmTransposeDgvWriter(mTranspose(firstMatris));
                    which = 2;
                    determinant = DET(E.GetLength(0), E);
                    if(determinant == 0)
                    {
                        MessageBox.Show("Her iki durumda da determinant 0 olduğundan dolayı matrisin tersi bulunamamaktadır.");
                        //Transpozu /(tüm sayıların karelerinin toplamı) bize pseudpinversini verecektir. Güncelle.
                        return;
                    }
                }
                MessageBox.Show("Determinant= " + determinant);
            }
            else if(sayac == 1)
            {
                sayac += 1;
                label5.Text = "(A^A|AA^)Inverse";
                MessageBox.Show("Bulduğumuz Çarpımın İnverse Edilmiş Hali.");
                nextDgvWriter(inverse(E));
            }
            else if(sayac == 2)
            {
                sayac += 1;
                result = new double[firstMatris.GetLength(1), firstMatris.GetLength(0)];
                if(which == 1)
                {
                    label5.Text = "(A^A)Inv * A^";
                    MessageBox.Show("(Atranspose.A)Inverse ü bulduk. Atranspose(sağdan) ile çarpımı hesaplanacaktır.");
                    result = multiplication(inverse(E), mTranspose(firstMatris));
                }
                else if(which == 2)
                {
                    label5.Text = "A^ * (AA^)Inv";
                    MessageBox.Show("(A.Atranspose)Inverse ü bulduk. Atranspose(soldan) ile çarpımı hesaplanacaktır.");
                    result = multiplication(mTranspose(firstMatris), inverse(E));
                }
                label5.Text += " = A'nın Pseudo İnversi ";
                MessageBox.Show("A Matrisimizin Pseudo İnverse Matrisi");
                nextDgvWriter(result);
            }
            else if(sayac == 3)
            {
                sayac += 1;
                label5.Text = "A x A'nın Pseudo İnversi = ";
                MessageBox.Show("A Matrisimizin Pseudo İnverse Matrisi ile Çarpımı");
                double[,] AxA = new double[firstMatris.GetLength(0), result.GetLength(1)];
                AxA = multiplication(firstMatris, result);
                nextDgvWriter(AxA);
            }

        }

        public double[,] multiplication(double[,] left, double[,] right)
        {
            double[,] result = new double[left.GetLength(0), right.GetLength(1)];

            for(int i = 0; i < result.GetLength(0); i++)
            {
                for(int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 0;
                    for(int k = 0; k < left.GetLength(1); k++)
                    {
                        result[i, j] = result[i, j] + (left[i, k] * right[k, j]);
                    }
                }
            }
            return result;
        }


        public double[,] mTranspose(double[,] matrix)
        {

            //GetLength(1) Satır
            double[,] matrixTranspose = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for(int c = 0; c < matrix.GetLength(1); c++)
            {
                for(int r = 0; r < matrix.GetLength(0); r++)
                {
                    matrixTranspose[c, r] = matrix[r, c];
                }
            }
            return matrixTranspose;
        }

        public void mxmTransposeDgvWriter(double[,] firstMatris)
        {
            double[,] t = mxmTranspose(mTranspose(firstMatris), firstMatris);
            E = new double[t.GetLength(1), t.GetLength(0)];

            for(int i = 0; i < t.GetLength(1); i++)
            {
                for(int j = 0; j < t.GetLength(0); j++)
                {
                    E[i, j] = t[i, j];
                }
            }
            nextDgvWriter(E);
        }


        public void nextDgvWriter(double[,] matrix)
        {

            MxMTransposeDgv.Rows.Clear();
            MxMTransposeDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            MxMTransposeDgv.Enabled = false;
            MxMTransposeDgv.RowHeadersVisible = false;
            MxMTransposeDgv.ColumnCount = matrix.GetLength(1);
            double rand;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                MxMTransposeDgv.Rows.Add();
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    //rand = Math.Round(matrix[i, j], 5);
                    MxMTransposeDgv.Rows[i].Cells[j].Value = matrix[i,j];
                }
            }
        }

        //////////////////////////////////////////////////////////////////////
        ///

        public static double DET(int n, double[,] Mat)
        {
            double d = 0;
            int k, i, j, subi, subj;
            double[,] SUBMat = new double[n, n];
            if(n == 1)
            {
                return Mat[0, 0];
            }
            else if(n == 2)
            {
                return ((Mat[0, 0] * Mat[1, 1]) - (Mat[1, 0] * Mat[0, 1]));
            }
            else
            {
                for(k = 0; k < n; k++)
                {
                    subi = 0;
                    for(i = 1; i < n; i++)
                    {
                        subj = 0;
                        for(j = 0; j < n; j++)
                        {
                            if(j == k)
                            {
                                continue;
                            }
                            SUBMat[subi, subj] = Mat[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * Mat[0, k] * DET(n - 1, SUBMat));
                }
            }
            return d;
        }


        //ADJ MATRİSİNİ BULUYOR. 
        public double[,] adjoint(double[,] A)
        {
            double[,] adj = new double[A.GetLength(0), A.GetLength(0)];
            if(A.GetLength(0) == 1)
            {
                adj[0, 0] = 1;
                return null;
            }
            int sign = 1;
            double[,] temp = new double[A.GetLength(0), A.GetLength(1)];

            for(int i = 0; i < A.GetLength(0); i++)
            {
                for(int j = 0; j < A.GetLength(0); j++)
                {
                    // Get cofactor of A[i][j] 
                    getCofactor(A, temp, i, j, A.GetLength(0));

                    // sign of adj[j][i] positive if sum of row 
                    // and column indexes is even. 
                    sign = ((i + j) % 2 == 0) ? 1 : -1;

                    // Interchanging rows and columns to get the 
                    // transpose of the cofactor matrix 
                    adj[j, i] = (sign) * (DET((A.GetLength(0) - 1), temp));
                }
            }

            return adj;
        }

        void getCofactor(double[,] A, double[,] temp, int p, int q, int n)
        {
            int i = 0, j = 0;

            for(int row = 0; row < n; row++)
            {
                for(int col = 0; col < n; col++)
                {
                    if(row != p && col != q)
                    {
                        temp[i, j++] = A[row, col];

                        if(j == n - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }

        }

        public double[,] inverse(double[,] A)
        {
            double determ = DET(A.GetLength(0), A);
            double[,] inverse = new double[A.GetLength(0), A.GetLength(0)];

            if(determ == 0)
            {
                MessageBox.Show("Determinant 0 olduğundan işlem yapılamamaktadır.");
                return null;
            }
            double[,] adj = new double[A.GetLength(0), A.GetLength(0)];
            adj = adjoint(A);

            if(adj != null)
            {
                for(int i = 0; i < A.GetLength(0); i++)
                {
                    for(int j = 0; j < A.GetLength(0); j++)
                    {
                        inverse[i, j] = adj[i, j] / determ;
                    }
                }
            }

            return inverse;
        }

        private void OkBttn_Click(object sender, EventArgs e)
        {
            int M = Convert.ToInt32(mValue.Text);
            int N = Convert.ToInt32(nValue.Text);
            firstMatris = new double[M, N];
            mValue.Enabled = true;
            nValue.Enabled = true;
            for(int i = 0; i < M; i++)
            {
                for(int j = 0; j < N; j++)
                {
                    if(dgv.Rows[i].Cells[j].Value != null)
                        firstMatris[i, j] = Convert.ToDouble(dgv.Rows[i].Cells[j].Value);
                    else
                        firstMatris[i, j] = 0;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}