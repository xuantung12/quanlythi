﻿namespace asm2
{
    partial class Form5
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
            if (disposing && (components != null))
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExamSJID = new System.Windows.Forms.TextBox();
            this.txtExamSJNAME = new System.Windows.Forms.TextBox();
            this.txtExamSJDATE = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ExamSJID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamSJNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamSJDATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exam subject Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Exam subject Date";
            // 
            // txtExamSJID
            // 
            this.txtExamSJID.Location = new System.Drawing.Point(178, 40);
            this.txtExamSJID.Name = "txtExamSJID";
            this.txtExamSJID.Size = new System.Drawing.Size(100, 22);
            this.txtExamSJID.TabIndex = 3;
            // 
            // txtExamSJNAME
            // 
            this.txtExamSJNAME.Location = new System.Drawing.Point(178, 110);
            this.txtExamSJNAME.Name = "txtExamSJNAME";
            this.txtExamSJNAME.Size = new System.Drawing.Size(100, 22);
            this.txtExamSJNAME.TabIndex = 4;
            // 
            // txtExamSJDATE
            // 
            this.txtExamSJDATE.Location = new System.Drawing.Point(537, 39);
            this.txtExamSJDATE.Name = "txtExamSJDATE";
            this.txtExamSJDATE.Size = new System.Drawing.Size(100, 22);
            this.txtExamSJDATE.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "ADD";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(482, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(597, 114);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Edit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(713, 114);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Exit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExamSJID,
            this.ExamSJNAME,
            this.ExamSJDATE});
            this.dataGridView1.Location = new System.Drawing.Point(35, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(741, 268);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ExamSJID
            // 
            this.ExamSJID.DataPropertyName = "ExamSJID";
            this.ExamSJID.HeaderText = "Exam subject ID";
            this.ExamSJID.MinimumWidth = 6;
            this.ExamSJID.Name = "ExamSJID";
            // 
            // ExamSJNAME
            // 
            this.ExamSJNAME.DataPropertyName = "ExamSJNAME";
            this.ExamSJNAME.HeaderText = "Exam Subject Name";
            this.ExamSJNAME.MinimumWidth = 6;
            this.ExamSJNAME.Name = "ExamSJNAME";
            // 
            // ExamSJDATE
            // 
            this.ExamSJDATE.DataPropertyName = "ExamSJDATE";
            this.ExamSJDATE.HeaderText = "Exam subject Date";
            this.ExamSJDATE.MinimumWidth = 6;
            this.ExamSJDATE.Name = "ExamSJDATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Exam subject ID";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chocolate;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtExamSJDATE);
            this.Controls.Add(this.txtExamSJNAME);
            this.Controls.Add(this.txtExamSJID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExamSJID;
        private System.Windows.Forms.TextBox txtExamSJNAME;
        private System.Windows.Forms.TextBox txtExamSJDATE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamSJID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamSJNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamSJDATE;
    }
}