namespace PseudoInverse
{
    partial class mainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.rndmBttn = new System.Windows.Forms.Button();
            this.mValue = new System.Windows.Forms.TextBox();
            this.nValue = new System.Windows.Forms.TextBox();
            this.handBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MxMTransposeDgv = new System.Windows.Forms.DataGridView();
            this.nxtStepBttn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.OkBttn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MxMTransposeDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(21, 21);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(125, 129);
            this.dgv.TabIndex = 1;
            // 
            // rndmBttn
            // 
            this.rndmBttn.Location = new System.Drawing.Point(152, 18);
            this.rndmBttn.Name = "rndmBttn";
            this.rndmBttn.Size = new System.Drawing.Size(75, 23);
            this.rndmBttn.TabIndex = 2;
            this.rndmBttn.Text = "Random";
            this.rndmBttn.UseVisualStyleBackColor = true;
            this.rndmBttn.Click += new System.EventHandler(this.rndmBttn_Click);
            // 
            // mValue
            // 
            this.mValue.Location = new System.Drawing.Point(21, 169);
            this.mValue.Name = "mValue";
            this.mValue.Size = new System.Drawing.Size(36, 20);
            this.mValue.TabIndex = 3;
            this.mValue.TextChanged += new System.EventHandler(this.mValue_TextChanged);
            // 
            // nValue
            // 
            this.nValue.Location = new System.Drawing.Point(63, 169);
            this.nValue.Name = "nValue";
            this.nValue.Size = new System.Drawing.Size(36, 20);
            this.nValue.TabIndex = 4;
            this.nValue.TextChanged += new System.EventHandler(this.nValue_TextChanged);
            // 
            // handBttn
            // 
            this.handBttn.Location = new System.Drawing.Point(105, 167);
            this.handBttn.Name = "handBttn";
            this.handBttn.Size = new System.Drawing.Size(59, 23);
            this.handBttn.TabIndex = 5;
            this.handBttn.Text = "Manuel";
            this.handBttn.UseVisualStyleBackColor = true;
            this.handBttn.Click += new System.EventHandler(this.handBttn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sütun";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Satır";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // MxMTransposeDgv
            // 
            this.MxMTransposeDgv.AllowUserToAddRows = false;
            this.MxMTransposeDgv.AllowUserToDeleteRows = false;
            this.MxMTransposeDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MxMTransposeDgv.Location = new System.Drawing.Point(233, 21);
            this.MxMTransposeDgv.Name = "MxMTransposeDgv";
            this.MxMTransposeDgv.ReadOnly = true;
            this.MxMTransposeDgv.Size = new System.Drawing.Size(509, 168);
            this.MxMTransposeDgv.TabIndex = 10;
            // 
            // nxtStepBttn
            // 
            this.nxtStepBttn.Location = new System.Drawing.Point(152, 47);
            this.nxtStepBttn.Name = "nxtStepBttn";
            this.nxtStepBttn.Size = new System.Drawing.Size(75, 23);
            this.nxtStepBttn.TabIndex = 11;
            this.nxtStepBttn.Text = "Next Step";
            this.nxtStepBttn.UseVisualStyleBackColor = true;
            this.nxtStepBttn.Click += new System.EventHandler(this.nxtStepBttn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 12;
            // 
            // OkBttn
            // 
            this.OkBttn.Location = new System.Drawing.Point(170, 166);
            this.OkBttn.Name = "OkBttn";
            this.OkBttn.Size = new System.Drawing.Size(57, 23);
            this.OkBttn.TabIndex = 13;
            this.OkBttn.Text = "Accept";
            this.OkBttn.UseVisualStyleBackColor = true;
            this.OkBttn.Click += new System.EventHandler(this.OkBttn_Click);
            // 
            // mainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 202);
            this.Controls.Add(this.OkBttn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nxtStepBttn);
            this.Controls.Add(this.MxMTransposeDgv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.handBttn);
            this.Controls.Add(this.nValue);
            this.Controls.Add(this.mValue);
            this.Controls.Add(this.rndmBttn);
            this.Controls.Add(this.dgv);
            this.Name = "mainScreen";
            this.Text = "mainScreen";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MxMTransposeDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button rndmBttn;
        private System.Windows.Forms.TextBox mValue;
        private System.Windows.Forms.TextBox nValue;
        private System.Windows.Forms.Button handBttn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView MxMTransposeDgv;
        private System.Windows.Forms.Button nxtStepBttn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button OkBttn;
    }
}

