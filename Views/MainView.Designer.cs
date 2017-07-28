namespace Views
{
    partial class MainView
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnViewPatients = new System.Windows.Forms.Button();
            this.btnPatientVisitView = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnViewPatients);
            this.flowLayoutPanel1.Controls.Add(this.btnPatientVisitView);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(577, 375);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btnViewPatients
            // 
            this.btnViewPatients.Location = new System.Drawing.Point(13, 13);
            this.btnViewPatients.Name = "btnViewPatients";
            this.btnViewPatients.Size = new System.Drawing.Size(88, 71);
            this.btnViewPatients.TabIndex = 0;
            this.btnViewPatients.Text = "Patients";
            this.btnViewPatients.UseVisualStyleBackColor = true;
            // 
            // btnPatientVisitView
            // 
            this.btnPatientVisitView.Location = new System.Drawing.Point(107, 13);
            this.btnPatientVisitView.Name = "btnPatientVisitView";
            this.btnPatientVisitView.Size = new System.Drawing.Size(88, 71);
            this.btnPatientVisitView.TabIndex = 1;
            this.btnPatientVisitView.Text = "Visits";
            this.btnPatientVisitView.UseVisualStyleBackColor = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 375);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MainView";
            this.Text = "MainView";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnViewPatients;
        private System.Windows.Forms.Button btnPatientVisitView;
    }
}