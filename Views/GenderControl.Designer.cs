namespace Views
{
    partial class GenderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOther = new System.Windows.Forms.RadioButton();
            this.btnMale = new System.Windows.Forms.RadioButton();
            this.btnFemale = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnOther, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnMale, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFemale, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(323, 24);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnOther
            // 
            this.btnOther.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOther.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOther.Location = new System.Drawing.Point(140, 0);
            this.btnOther.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnOther.Name = "btnOther";
            this.btnOther.Size = new System.Drawing.Size(183, 24);
            this.btnOther.TabIndex = 14;
            this.btnOther.Text = "Other";
            this.btnOther.UseVisualStyleBackColor = true;
            // 
            // btnMale
            // 
            this.btnMale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMale.Location = new System.Drawing.Point(2, 0);
            this.btnMale.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnMale.Name = "btnMale";
            this.btnMale.Size = new System.Drawing.Size(59, 24);
            this.btnMale.TabIndex = 13;
            this.btnMale.Text = "Male";
            this.btnMale.UseVisualStyleBackColor = true;
            // 
            // btnFemale
            // 
            this.btnFemale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFemale.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFemale.Location = new System.Drawing.Point(63, 0);
            this.btnFemale.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnFemale.Name = "btnFemale";
            this.btnFemale.Size = new System.Drawing.Size(75, 24);
            this.btnFemale.TabIndex = 12;
            this.btnFemale.Text = "Female";
            this.btnFemale.UseVisualStyleBackColor = true;
            // 
            // GenderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GenderControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(323, 24);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton btnOther;
        private System.Windows.Forms.RadioButton btnMale;
        private System.Windows.Forms.RadioButton btnFemale;
    }
}
