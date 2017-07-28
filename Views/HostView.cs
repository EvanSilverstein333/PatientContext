using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.ViewInterfaces;
using Controllers.Controllers;

namespace Views
{
    public partial class HostView : Form, IViewHostView
    {
        private ViewHostController _controller;
        //private IViewBase _masterView;
        //private IViewBase[] _detailViews;
        private Control _masterControl;
        private IEnumerable<Control> _detailControls;
        private IEnumerable<Control> _allControls
        {
            get
            {
                var controls = new List<Control>();
                if (_masterControl != null) { controls.Add(_masterControl); }
                if(_detailControls != null) { controls.AddRange(_detailControls); }
                
                return controls;
            }
        }

        public HostView()
        {
            InitializeComponent();
            btnFullScreenMaster.Click += BtnFullScreenMaster_Click;
            btnFullScreenDetails.Click += BtnFullScreenDetails_Click;
            FormatFullScreenBtn(btnFullScreenMaster, true);
            FormatFullScreenBtn(btnFullScreenDetails, true);

        }

        private void BtnFullScreenMaster_Click(object sender, EventArgs e)
        {
            var newScreenMode = splitContainer1.Panel2Collapsed;
            splitContainer1.Panel2Collapsed = !newScreenMode;
            FormatFullScreenBtn(btnFullScreenMaster, newScreenMode);

        }

        private void BtnFullScreenDetails_Click(object sender, EventArgs e)
        {
            var newScreenMode = splitContainer1.Panel1Collapsed;
            splitContainer1.Panel1Collapsed = !newScreenMode;
            FormatFullScreenBtn(btnFullScreenDetails, newScreenMode); 
        }

        private void FormatFullScreenBtn(ToolStripButton btn, bool fullScreen)
        {
            btn.Image = (fullScreen) ? imageList1.Images["imageFullScreen"] : imageList1.Images["imageSplitScreen"]; 
        }

        public void ComposeView(IViewBase masterView, params IViewBase[] detailViews)
        {
            ClearExistingControls();
            _masterControl = masterView as Control;
            _detailControls = ConvertViewCollectionToControls(detailViews);
            foreach(var control in _allControls)
            {
                if(control != null) // could be the case if only provide master or only details
                {
                    FormatAsSubcontrol(control);
                    DockControl(control);
                }
            }
            WindowStyle();
            ShowSubControls();
        }

        private void ShowSubControls()
        {
            foreach(var control in _allControls)
            {
                if(control != null)
                {
                    control.Show();
                }
            }
        }
        private void ClearExistingControls()
        {
            foreach (var control in _allControls)
            {
                control.Dispose();
                panelMaster.Controls.Clear();
                detailsTabCollection.TabPages.Clear();
            }
        }

        private IEnumerable<Control> ConvertViewCollectionToControls(IEnumerable<IViewBase> views)
        {
            var controls = new List<Control>();
            if(views != null)
            {
                foreach (var view in views) { controls.Add(view as Control); }
            }
            return controls;
        }

        private void FormatAsSubcontrol(Control control)
        {
            if(control is Form)
            {
                var form = control as Form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
            }
            control.Dock = DockStyle.Fill;
        }

        private void DockControl(Control control)
        {
            if(control == _masterControl)
            {
                _masterControl.Parent = panelMaster;
                lblMasterCaption.Text = control.Text;
            }
            else
            {
                var tab = new TabPage(control.Text);
                detailsTabCollection.TabPages.Add(tab);
                tab.Margin = new Padding(0);
                control.Parent = tab;
            }
        }


        private void WindowStyle()
        {
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel2Collapsed = false;
            if (_masterControl == null) { splitContainer1.Panel1Collapsed = true; }
            else if(_detailControls.Count() == 0) { splitContainer1.Panel2Collapsed = true; }
            FormatFullScreenBtn(btnFullScreenMaster, !splitContainer1.Panel2Collapsed);
            FormatFullScreenBtn(btnFullScreenDetails, !splitContainer1.Panel1Collapsed);
            btnFullScreenDetails.Visible =! ( _masterControl== null);
            btnFullScreenMaster.Visible = !(_detailControls.Count() == 0);


        }

        private void ResetWindowStyle()
        {
            
        }


        public void SetController(ViewHostController controller)
        {
            _controller = controller;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //foreach (var control in _allControls)
            //{
            //    if (control != null) { control.Show(); }
            //}
        }

        public void SetDetailTabCollectionVisible(bool visible)
        {
            detailsTabCollection.Visible = visible;
        }
    }
}
