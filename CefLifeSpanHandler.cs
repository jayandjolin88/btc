using CefSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class OpenPageSelf : ILifeSpanHandler
    {

        public bool DoClose(IWebBrowser browserControl, IBrowser browser)
        {
            return false;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {
            CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser = (CefSharp.WinForms.ChromiumWebBrowser)browserControl;
            //chromiumWebBrowser.Invoke(new Action<string>((str) => { chromiumWebBrowser.Refresh(); }), "");
            chromiumWebBrowser.FrameLoadEnd += NewWebBrowser_FrameLoadEnd;

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl,
        string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
        IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser = (CefSharp.WinForms.ChromiumWebBrowser)browserControl;
            //chromiumWebBrowser.Load(targetUrl);
            //chromiumWebBrowser.GetMainFrame();
            productweb(targetUrl);
            return true; //Return true to cancel the popup creation copyright by codebye.com.
        }



        public void productweb(string url)
        {
            if (url.Contains("about:blank#blocked"))
                return;
             DevExpress.XtraTab.XtraTabPage _XtraTabPage = new DevExpress.XtraTab.XtraTabPage();
            _XtraTabPage.Size = new System.Drawing.Size(200, 300);
            _XtraTabPage.Location = new System.Drawing.Point(200, 300);
            _XtraTabPage.BackColor = Color.Red;
            _XtraTabPage.Anchor = AnchorStyles.Left;
            _XtraTabPage.Anchor = AnchorStyles.Right;
            _XtraTabPage.Anchor = AnchorStyles.Top;
            _XtraTabPage.Anchor = AnchorStyles.Bottom;
            _XtraTabPage.Size = new System.Drawing.Size(Form1.xtraTabControl1.Width, Form1.xtraTabControl1.Height);
            _XtraTabPage.Width = Form1.xtraTabControl1.Width;
            _XtraTabPage.Height = Form1.xtraTabControl1.Height;

            _XtraTabPage.Name = "谷歌_New_Tab";
            _XtraTabPage.Text = url.Substring(0, 20);


            _XtraTabPage.Tag = url;
            CefSharp.WinForms.ChromiumWebBrowser newWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            //newWebBrowser.OnBeforePopup += Browser_StartNewWindow;
            newWebBrowser.Load(url);         //转到网站
            //newWebBrowser.DocumentCompleted += NewWebBrowser_DocumentCompleted;
            //newWebBrowser.ScriptErrorsSuppressed = true;
            newWebBrowser.Name = "谷歌_New_Tab";
            newWebBrowser.Tag = url;
            newWebBrowser.Dock = DockStyle.Fill;
            newWebBrowser.LifeSpanHandler = new OpenPageSelf();
            newWebBrowser.FrameLoadEnd += NewWebBrowser_FrameLoadEnd;
            //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
            _XtraTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
            //Form1.xtraTabControl1.TabPages.Add((_XtraTabPage)); // 新选项卡添加到TabControl
            //Form1.xtraTabControl1.SelectedTabPage = _XtraTabPage;//新选项卡位活动选项卡
            //Form1.txt_url.Text = url;//地址栏显示地址
            Form1.xtraTabControl1.Invoke(new Action<string>((str) => { Form1.xtraTabControl1.TabPages.Add((_XtraTabPage)); }), "");
            Form1.xtraTabControl1.Invoke(new Action<string>((str) => { Form1.xtraTabControl1.SelectedTabPage = _XtraTabPage; }), "");
            
        }

        private void NewWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            try
            {
                string url1 = "http://ids1.gs.sgcc.com.cn:8080/nidp/images/gs_login2.jsp";
                string url2 = "http://i6000.gs.sgcc.com.cn:25600/i6000/portal/main/index.jsp";
                CefSharp.WinForms.ChromiumWebBrowser newWebBrowser = sender as CefSharp.WinForms.ChromiumWebBrowser;
                if (newWebBrowser.Tag.ToString().Equals(url1))
                {
                    productweb(url2);
                }
                else
                {
                   
                }
            }
            catch (Exception)
            {

            }
           
        }
    }
}