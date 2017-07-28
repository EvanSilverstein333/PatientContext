namespace Views
{
    partial class PatientInfoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientInfoView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contactInfoControl1 = new Views.ContactInfoControl();
            this.healthcardControl1 = new Views.HealthcardControl();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 321);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(465, 27);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnEdit
            // 
            this.btnEdit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(39, 24);
            this.btnEdit.Text = "Edit";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.contactInfoControl1);
            this.panel1.Controls.Add(this.healthcardControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 321);
            this.panel1.TabIndex = 13;
            // 
            // contactInfoControl1
            // 
            this.contactInfoControl1.AutoSize = true;
            this.contactInfoControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contactInfoControl1.BackColor = System.Drawing.Color.White;
            this.contactInfoControl1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.contactInfoControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactInfoControl1.Location = new System.Drawing.Point(0, 70);
            this.contactInfoControl1.Name = "contactInfoControl1";
            this.contactInfoControl1.ReadOnly = true;
            this.contactInfoControl1.Size = new System.Drawing.Size(465, 200);
            this.contactInfoControl1.TabIndex = 14;
            // 
            // healthcardControl1
            // 
            this.healthcardControl1.AutoSize = true;
            this.healthcardControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.healthcardControl1.BackColor = System.Drawing.Color.White;
            this.healthcardControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.healthcardControl1.Location = new System.Drawing.Point(0, 0);
            this.healthcardControl1.Name = "healthcardControl1";
            this.healthcardControl1.ReadOnly = true;
            this.healthcardControl1.Size = new System.Drawing.Size(465, 70);
            this.healthcardControl1.TabIndex = 15;
            // 
            // PatientInfoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(465, 348);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PatientInfoView";
            this.Text = "PatientInfoView";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.Panel panel1;
        private ContactInfoControl contactInfoControl1;
        private HealthcardControl healthcardControl1;
    }
}