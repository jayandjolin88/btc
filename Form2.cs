using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //int qq = SETIE_VERSION.GetBrowserVersion();
            //SETIE_VERSION.SetWebBrowserFeatures(SETIE_VERSION.GetBrowserVersion());
            InitializeComponent();

        }
        CefSharp.WinForms.ChromiumWebBrowser _WebKit_WEB;
        private void Form2_Load(object sender, EventArgs e)
        {
            _WebKit_WEB = new CefSharp.WinForms.ChromiumWebBrowser(textBox1.Text);
            _WebKit_WEB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            _WebKit_WEB.BackColor = System.Drawing.Color.Gray;
            _WebKit_WEB.LifeSpanHandler = new OpenPageSelf();
            _WebKit_WEB.Width = panel1.Width;
            _WebKit_WEB.Height = panel1.Height;
            _WebKit_WEB.FrameLoadEnd += _WebKit_WEB_FrameLoadEnd;
            this.panel1.Controls.Add(_WebKit_WEB);
           
        }

        private void _WebKit_WEB_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser = sender as CefSharp.WinForms.ChromiumWebBrowser;
            //chromiumWebBrowser.Controls.Find()
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _WebKit_WEB.Load(textBox1.Text);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            MessageBox.Show(webBrowser1.Version.ToString());
        }
    }
}
