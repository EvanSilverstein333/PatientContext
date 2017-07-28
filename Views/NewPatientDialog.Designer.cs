namespace Views
{
    partial class NewPatientDialog
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabHealthcard = new System.Windows.Forms.TabPage();
            this.healthcardControl1 = new Views.HealthcardControl();
            this.tabContactInfo = new System.Windows.Forms.TabPage();
            this.contactInfoControl1 = new Views.ContactInfoControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.identityControl1 = new Views.IdentityControl();
            this.tabIdentity = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1.SuspendLayout();
            this.tabHealthcard.SuspendLayout();
            this.tabContactInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIdentity.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 306);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(469, 33);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Location = new System.Drawing.Point(405, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 27);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Location = new System.Drawing.Point(349, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 27);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // tabHealthcard
            // 
            this.tabHealthcard.Controls.Add(this.healthcardControl1);
            this.tabHealthcard.Location = new System.Drawing.Point(4, 25);
            this.tabHealthcard.Name = "tabHealthcard";
            this.tabHealthcard.Padding = new System.Windows.Forms.Padding(3);
            this.tabHealthcard.Size = new System.Drawing.Size(461, 277);
            this.tabHealthcard.TabIndex = 1;
            this.tabHealthcard.Text = "Healthcard";
            this.tabHealthcard.UseVisualStyleBackColor = true;
            // 
            // healthcardControl1
            // 
            this.healthcardControl1.AutoScroll = true;
            this.healthcardControl1.AutoSize = true;
            this.healthcardControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.healthcardControl1.BackColor = System.Drawing.Color.White;
            this.healthcardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.healthcardControl1.Location = new System.Drawing.Point(3, 3);
            this.healthcardControl1.Name = "healthcardControl1";
            this.healthcardControl1.ReadOnly = false;
            this.healthcardControl1.Size = new System.Drawing.Size(455, 271);
            this.healthcardControl1.TabIndex = 0;
            // 
            // tabContactInfo
            // 
            this.tabContactInfo.Controls.Add(this.contactInfoControl1);
            this.tabContactInfo.Location = new System.Drawing.Point(4, 25);
            this.tabContactInfo.Name = "tabContactInfo";
            this.tabContactInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabContactInfo.Size = new System.Drawing.Size(461, 277);
            this.tabContactInfo.TabIndex = 0;
            this.tabContactInfo.Text = "ContactInfo";
            this.tabContactInfo.UseVisualStyleBackColor = true;
            // 
            // contactInfoControl1
            // 
            this.contactInfoControl1.AutoScroll = true;
            this.contactInfoControl1.AutoSize = true;
            this.contactInfoControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.contactInfoControl1.BackColor = System.Drawing.Color.White;
            this.contactInfoControl1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.None;
            this.contactInfoControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactInfoControl1.Location = new System.Drawing.Point(3, 3);
            this.contactInfoControl1.Name = "contactInfoControl1";
            this.contactInfoControl1.ReadOnly = false;
            this.contactInfoControl1.Size = new System.Drawing.Size(455, 271);
            this.contactInfoControl1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIdentity);
            this.tabControl1.Controls.Add(this.tabContactInfo);
            this.tabControl1.Controls.Add(this.tabHealthcard);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(469, 306);
            this.tabControl1.TabIndex = 1;
            // 
            // identityControl1
            // 
            this.identityControl1.AutoScroll = true;
            this.identityControl1.AutoSize = true;
            this.identityControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.identityControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.identityControl1.GenderOptions = Shared.ValueObjects.GenderOptions.MaleFemale;
            this.identityControl1.Location = new System.Drawing.Point(3, 3);
            this.identityControl1.Name = "identityControl1";
            this.identityControl1.ReadOnly = false;
            this.identityControl1.Size = new System.Drawing.Size(455, 271);
            this.identityControl1.TabIndex = 0;
            // 
            // tabIdentity
            // 
            this.tabIdentity.Controls.Add(this.identityControl1);
            this.tabIdentity.Location = new System.Drawing.Point(4, 25);
            this.tabIdentity.Name = "tabIdentity";
            this.tabIdentity.Padding = new System.Windows.Forms.Padding(3);
            this.tabIdentity.Size = new System.Drawing.Size(461, 277);
            this.tabIdentity.TabIndex = 4;
            this.tabIdentity.Text = "Identity";
            this.tabIdentity.UseVisualStyleBackColor = true;
            // 
            // NewPatientDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 339);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "NewPatientDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "NewPatientDialog";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tabHealthcard.ResumeLayout(false);
            this.tabHealthcard.PerformLayout();
            this.tabContactInfo.ResumeLayout(false);
            this.tabContactInfo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabIdentity.ResumeLayout(false);
            this.tabIdentity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabHealthcard;
        private HealthcardControl healthcardControl1;
        private System.Windows.Forms.TabPage tabContactInfo;
        private ContactInfoControl contactInfoControl1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIdentity;
        private IdentityControl identityControl1;
    }
}