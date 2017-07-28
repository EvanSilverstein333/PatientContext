namespace Views
{
    partial class PatientVisitView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientVisitView));
            this.dgvPatientVisits = new System.Windows.Forms.DataGridView();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddPatientVisit = new System.Windows.Forms.ToolStripButton();
            this.btnRemovePatientVisit = new System.Windows.Forms.ToolStripButton();
            this.btnUpdatePatientVisit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientVisits)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPatientVisits
            // 
            this.dgvPatientVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientVisits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatientVisits.Location = new System.Drawing.Point(0, 22);
            this.dgvPatientVisits.Name = "dgvPatientVisits";
            this.dgvPatientVisits.RowTemplate.Height = 24;
            this.dgvPatientVisits.Size = new System.Drawing.Size(571, 323);
            this.dgvPatientVisits.TabIndex = 11;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearchBox.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(571, 22);
            this.txtSearchBox.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddPatientVisit,
            this.btnRemovePatientVisit,
            this.btnUpdatePatientVisit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 318);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(571, 27);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddPatientVisit
            // 
            this.btnAddPatientVisit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddPatientVisit.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPatientVisit.Image")));
            this.btnAddPatientVisit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPatientVisit.Name = "btnAddPatientVisit";
            this.btnAddPatientVisit.Size = new System.Drawing.Size(41, 24);
            this.btnAddPatientVisit.Text = "Add";
            // 
            // btnRemovePatientVisit
            // 
            this.btnRemovePatientVisit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemovePatientVisit.Image = ((System.Drawing.Image)(resources.GetObject("btnRemovePatientVisit.Image")));
            this.btnRemovePatientVisit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemovePatientVisit.Name = "btnRemovePatientVisit";
            this.btnRemovePatientVisit.Size = new System.Drawing.Size(67, 24);
            this.btnRemovePatientVisit.Text = "Remove";
            // 
            // btnUpdatePatientVisit
            // 
            this.btnUpdatePatientVisit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdatePatientVisit.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdatePatientVisit.Image")));
            this.btnUpdatePatientVisit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdatePatientVisit.Name = "btnUpdatePatientVisit";
            this.btnUpdatePatientVisit.Size = new System.Drawing.Size(62, 24);
            this.btnUpdatePatientVisit.Text = "Update";
            // 
            // PatientVisitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 345);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvPatientVisits);
            this.Controls.Add(this.txtSearchBox);
            this.Name = "PatientVisitView";
            this.Text = "PatientVisitsView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientVisits)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatientVisits;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddPatientVisit;
        private System.Windows.Forms.ToolStripButton btnRemovePatientVisit;
        private System.Windows.Forms.ToolStripButton btnUpdatePatientVisit;
    }
}