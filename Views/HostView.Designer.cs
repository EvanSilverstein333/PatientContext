namespace Views
{
    partial class HostView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostView));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelMaster = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMasterCaption = new System.Windows.Forms.Label();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnFullScreenMaster = new System.Windows.Forms.ToolStripButton();
            this.detailsTabCollection = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFullScreenDetails = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.detailsTabCollection.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.splitContainer1.Panel1.Controls.Add(this.panelMaster);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.detailsTabCollection);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(618, 308);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.SplitterWidth = 10;
            this.splitContainer1.TabIndex = 1;
            // 
            // panelMaster
            // 
            this.panelMaster.BackColor = System.Drawing.Color.White;
            this.panelMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMaster.Location = new System.Drawing.Point(0, 25);
            this.panelMaster.Name = "panelMaster";
            this.panelMaster.Padding = new System.Windows.Forms.Padding(3);
            this.panelMaster.Size = new System.Drawing.Size(215, 256);
            this.panelMaster.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblMasterCaption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 25);
            this.panel1.TabIndex = 0;
            // 
            // lblMasterCaption
            // 
            this.lblMasterCaption.AutoEllipsis = true;
            this.lblMasterCaption.AutoSize = true;
            this.lblMasterCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMasterCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMasterCaption.Location = new System.Drawing.Point(0, 0);
            this.lblMasterCaption.Name = "lblMasterCaption";
            this.lblMasterCaption.Size = new System.Drawing.Size(145, 25);
            this.lblMasterCaption.TabIndex = 1;
            this.lblMasterCaption.Text = "Master Caption";
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFullScreenMaster});
            this.toolStrip2.Location = new System.Drawing.Point(0, 281);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(215, 27);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnFullScreenMaster
            // 
            this.btnFullScreenMaster.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFullScreenMaster.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullScreenMaster.Image = ((System.Drawing.Image)(resources.GetObject("btnFullScreenMaster.Image")));
            this.btnFullScreenMaster.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreenMaster.Name = "btnFullScreenMaster";
            this.btnFullScreenMaster.Size = new System.Drawing.Size(24, 24);
            this.btnFullScreenMaster.Text = "toolStripButton1";
            this.btnFullScreenMaster.ToolTipText = "Full screen";
            // 
            // detailsTabCollection
            // 
            this.detailsTabCollection.Controls.Add(this.tabPage1);
            this.detailsTabCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsTabCollection.Location = new System.Drawing.Point(0, 0);
            this.detailsTabCollection.Margin = new System.Windows.Forms.Padding(0);
            this.detailsTabCollection.Name = "detailsTabCollection";
            this.detailsTabCollection.SelectedIndex = 0;
            this.detailsTabCollection.Size = new System.Drawing.Size(393, 281);
            this.detailsTabCollection.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(385, 252);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFullScreenDetails});
            this.toolStrip1.Location = new System.Drawing.Point(0, 281);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(393, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnFullScreenDetails
            // 
            this.btnFullScreenDetails.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFullScreenDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullScreenDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnFullScreenDetails.Image")));
            this.btnFullScreenDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreenDetails.Name = "btnFullScreenDetails";
            this.btnFullScreenDetails.Size = new System.Drawing.Size(24, 24);
            this.btnFullScreenDetails.Text = "toolStripButton1";
            this.btnFullScreenDetails.ToolTipText = "Full screen";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "125_FullView_48x48_72.png");
            this.imageList1.Images.SetKeyName(1, "SelectCurrentRegion.png");
            this.imageList1.Images.SetKeyName(2, "imageSplitScreen");
            this.imageList1.Images.SetKeyName(3, "imageFullScreen");
            // 
            // HostView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(618, 308);
            this.Controls.Add(this.splitContainer1);
            this.Name = "HostView";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.detailsTabCollection.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl detailsTabCollection;
        private System.Windows.Forms.Panel panelMaster;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnFullScreenMaster;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnFullScreenDetails;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMasterCaption;
        private System.Windows.Forms.TabPage tabPage1;
    }
}