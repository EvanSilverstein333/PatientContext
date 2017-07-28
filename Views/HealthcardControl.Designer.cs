namespace Views
{
    partial class HealthcardControl
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inputVersionCode = new System.Windows.Forms.TextBox();
            this.inputHealthNumber = new System.Windows.Forms.TextBox();
            this.inputExpiryDate = new Views.NullableDateTimePicker();
            this.identityControl1 = new Views.IdentityControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.identityControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(739, 188);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.inputVersionCode, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.inputHealthNumber, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.inputExpiryDate, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(739, 73);
            this.tableLayoutPanel2.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(673, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Version";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Health Number";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 28);
            this.label8.TabIndex = 20;
            this.label8.Text = "Expiry Date:   ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inputVersionCode
            // 
            this.inputVersionCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputVersionCode.Location = new System.Drawing.Point(673, 20);
            this.inputVersionCode.Name = "inputVersionCode";
            this.inputVersionCode.Size = new System.Drawing.Size(63, 22);
            this.inputVersionCode.TabIndex = 16;
            this.inputVersionCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // inputHealthNumber
            // 
            this.inputHealthNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputHealthNumber.Location = new System.Drawing.Point(120, 20);
            this.inputHealthNumber.Name = "inputHealthNumber";
            this.inputHealthNumber.Size = new System.Drawing.Size(547, 22);
            this.inputHealthNumber.TabIndex = 15;
            // 
            // inputExpiryDate
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.inputExpiryDate, 2);
            this.inputExpiryDate.CustomFormat = " ";
            this.inputExpiryDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.inputExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inputExpiryDate.Location = new System.Drawing.Point(120, 48);
            this.inputExpiryDate.Name = "inputExpiryDate";
            this.inputExpiryDate.Size = new System.Drawing.Size(616, 22);
            this.inputExpiryDate.TabIndex = 27;
            this.inputExpiryDate.Value = null;
            // 
            // identityControl1
            // 
            this.identityControl1.AutoSize = true;
            this.identityControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.identityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.identityControl1.GenderOptions = Shared.ValueObjects.GenderOptions.MaleFemaleOther;
            this.identityControl1.Location = new System.Drawing.Point(0, 73);
            this.identityControl1.Margin = new System.Windows.Forms.Padding(0);
            this.identityControl1.Name = "identityControl1";
            this.identityControl1.ReadOnly = false;
            this.identityControl1.Size = new System.Drawing.Size(739, 115);
            this.identityControl1.TabIndex = 36;
            this.identityControl1.Visible = false;
            // 
            // HealthcardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HealthcardControl";
            this.Size = new System.Drawing.Size(739, 188);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inputVersionCode;
        private System.Windows.Forms.TextBox inputHealthNumber;
        private NullableDateTimePicker inputExpiryDate;
        private IdentityControl identityControl1;
    }
}
