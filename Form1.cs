using CefSharp;
using CefSharp.WinForms;
using DevExpress.XtraTab;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }


        /// <summary>
        /// 定义字典对记录webb
        /// </summary>
        Dictionary<string, object[]> _Webb = new Dictionary<string, object[]>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //CefSharp.WinForms.ChromiumWebBrowser wb1 = new CefSharp.WinForms.ChromiumWebBrowser("https://ie.icoa.cn/");

            //wb1.Anchor = AnchorStyles.Left;
            //wb1.Anchor = AnchorStyles.Right;
            //wb1.Anchor = AnchorStyles.Top;
            //wb1.Anchor = AnchorStyles.Bottom;
           
        }



        static object[] obj_webb1 =new object[2];
        static object[] obj_webb2 = new object[2];
        static object[] obj_webb3 = new object[2];
        /// <summary>
        /// 关闭TAB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs EArg = (DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs)e;
            string name = EArg.Page.Text;//得到关闭的选项卡的text  
            int page_index = 0;
            foreach (XtraTabPage page in xtraTabControl1.TabPages)//遍历得到和关闭的选项卡一样的Text     
            {
                if (page.Text.Equals("首页"))
                    continue;

                if (page.Text == name)
                {
                    page_index = page.TabIndex;
                    xtraTabControl1.TabPages.Remove(page);
                    _Webb.Remove(page.Name);//从字典中移除
                    xtraTabControl1.SelectedTabPageIndex = page_index - 1;
                    page.Dispose(); return;
                }
            }
        }


        static int index = 0;
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                string s = e.Page.Tag.ToString();
                txt_url.Text = s;
                //index = xtraTabControl1.SelectedTabPageIndex;
                //if (xtraTabControl1.SelectedTabPageIndex == 1)
                //{
                //    index = 1;
                //}
                //if (xtraTabControl1.SelectedTabPageIndex == 2)
                //{
                //    index = 2;
                //}
                //if (xtraTabControl1.SelectedTabPageIndex == 3)
                //{
                //    index = 3;
                //}
                //if (e.Page.Name.Contains("首页"))
                //{
                //    index = 0;
                //}

            }
            catch (Exception)
            {

            }
           
        }

        //public Thread thread;
        //public delegate void MyDelegate(string _XtraTabPage_name, string _XtraTabPage_Text, string _XtraTabPage_Tag, _WEBB_TYPE _Bweb_Type, string _Bweb_NAME, string _Bweb_AIM_URL);
        //public void CREATEING(string _XtraTabPage_name, string _XtraTabPage_Text, string _XtraTabPage_Tag, _WEBB_TYPE _Bweb_Type, string _Bweb_NAME, string _Bweb_AIM_URL)
        //{
        //    this.Invoke(new MyDelegate(Init_XtraTabPage), _XtraTabPage_name, _XtraTabPage_Text, _XtraTabPage_Tag, _Bweb_Type, _Bweb_NAME, _Bweb_AIM_URL);
        //}
       

        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("这是刷新");
            if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("IE"))
            {
                System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                //wb.Navigate(txt_url.Text.Trim());
                wb.Refresh();
            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("谷歌"))
            {
                CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[xtraTabControl1.SelectedTabPage.Controls.Count-1];
                wb.Refresh();
            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("火狐"))
            {
                Gecko.Windows.WebView wb = (Gecko.Windows.WebView)xtraTabControl1.SelectedTabPage.Controls[0];
                wb.Refresh();
            }
            else { }
        }
        /// <summary>
        /// 转到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage.Tag = txt_url.Text.Trim();

            //MessageBox.Show("这是转到");
            if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("IE"))
            {
                System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                wb.Navigate(txt_url.Text.Trim());
                //wb.Refresh();
            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("谷歌"))
            {
                //CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                //wb.Load(txt_url.Text.Trim());
                //xtraTabControl1.SelectedTabPage.Controls[0].Visible = false;
                //DisXtab(xtraTabControl1.SelectedTabPage);
                //CefSharp.WinForms.ChromiumWebBrowser _WebKit_WEB = _WebKit_WEB_FACTORY("_Bweb_NAME3", txt_url.Text.Trim());
                //xtraTabControl1.SelectedTabPage.Controls.Add(_WebKit_WEB);
                //xtraTabControl1.SelectedTabPage = _XtraTabPage;

                DisXtab(xtraTabControl1.SelectedTabPage);
                CefSharp.WinForms.ChromiumWebBrowser newWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
                //newWebBrowser.OnBeforePopup += Browser_StartNewWindow;
                newWebBrowser.Load(txt_url.Text.Trim());         //转到网站
                newWebBrowser.Name = "谷歌_New_Tab";
                newWebBrowser.Dock = DockStyle.Fill;
                newWebBrowser.LifeSpanHandler = new OpenPageSelf();
                //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
                //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
                //Form1.xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
                //Form1.txt_url.Text = url;//地址栏显示地址
                newWebBrowser.Tag = txt_url.Text.Trim();
                xtraTabControl1.Invoke(new Action<string>((str) => { xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser); }), "");

            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("火狐"))
            {
                Gecko.Windows.WebView wb = (Gecko.Windows.WebView)xtraTabControl1.SelectedTabPage.Controls[0];
                wb.Navigate(txt_url.Text.Trim());
            }
            else { }
            
        }

        private void DisXtab(DevExpress.XtraTab.XtraTabPage tabPage)
        {
            foreach (Control con in tabPage.Controls)
            {
                con.Visible = false;
            }
        }




        /// <summary>
        /// 判断当前tab是否已经创建
        /// </summary>
        /// <param name="tabPageName"></param>
        /// <returns></returns>
        private bool IsXtraTabPageExsit(string tabPageName)
        {
            bool isExsit = false;//默认为不存在
            //Dictionary<string, object[]>
            foreach (KeyValuePair<string, object[]> kvp in _Webb)
            {
                if (kvp.Key == tabPageName)
                {
                    //若Page页存在，则设置为当前选中页
                    xtraTabControl1.SelectedTabPage = (DevExpress.XtraTab.XtraTabPage)kvp.Value[0];
                    return true;
                }
            }
            return isExsit;
        }
        /// <summary>
        /// 初始化XtraTabPage
        /// </summary>
        public static void Init_XtraTabPage(string _XtraTabPage_name, string _XtraTabPage_Text, string _XtraTabPage_Tag, _WEBB_TYPE _Bweb_Type, string _Bweb_NAME, string _Bweb_AIM_URL)
        {
            //bool isTabPageExsit = IsXtraTabPageExsit(_XtraTabPage_name);
            //if (isTabPageExsit)//判断新增的TabPage是否已经存在
            //{
            //    return;
            //}

            if (_Bweb_AIM_URL == "") return;

            //动态创建XtraTabPage
            DevExpress.XtraTab.XtraTabPage _XtraTabPage = new DevExpress.XtraTab.XtraTabPage();
            _XtraTabPage.Size = new System.Drawing.Size(200, 300);
            _XtraTabPage.Location = new System.Drawing.Point(200, 300);
            _XtraTabPage.BackColor = Color.Red;
            _XtraTabPage.Anchor = AnchorStyles.Left;
            _XtraTabPage.Anchor = AnchorStyles.Right;
            _XtraTabPage.Anchor = AnchorStyles.Top;
            _XtraTabPage.Anchor = AnchorStyles.Bottom;
            _XtraTabPage.Size = new System.Drawing.Size(xtraTabControl1.Width, xtraTabControl1.Height);
            _XtraTabPage.Width = xtraTabControl1.Width;
            _XtraTabPage.Height = xtraTabControl1.Height;

            _XtraTabPage.Name = _XtraTabPage_name;
            _XtraTabPage.Text = _XtraTabPage_Text;
            _XtraTabPage.Tag = _XtraTabPage_Tag;
            xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            _XtraTabPage});


            //动态创建WebBrowser
            System.Windows.Forms.WebBrowser _IE_WEB = null;
            //WebKit.WebKitBrowser _WebKit_WEB = null;
            CefSharp.WinForms.ChromiumWebBrowser _WebKit_WEB = null;
            Gecko.Windows.WebView _Gecko_WEB = null;
            switch (_Bweb_Type)
            {
                case _WEBB_TYPE.IE:
                    _IE_WEB = _IE_WEB_FACTORY(_Bweb_NAME, _Bweb_AIM_URL);
                    _IE_WEB.ScriptErrorsSuppressed = true;
                    obj_webb1[0] = _WEBB_TYPE.IE; obj_webb1[1] = _IE_WEB;
                    InsertHistory(_XtraTabPage_name, _Bweb_AIM_URL, "IE");
                    break;
                case _WEBB_TYPE.WebKit:
                    _WebKit_WEB = _WebKit_WEB_FACTORY(_Bweb_NAME, _Bweb_AIM_URL);
                    obj_webb2[0] = _WEBB_TYPE.WebKit; obj_webb2[1] = _WebKit_WEB;
                    InsertHistory(_XtraTabPage_name, _Bweb_AIM_URL, "谷歌");
                    break;
                case _WEBB_TYPE.Gecko:
                    _Gecko_WEB = _Gecko_WEB_FACTORY(_Bweb_NAME, _Bweb_AIM_URL);
                    obj_webb3[0] = _WEBB_TYPE.Gecko; obj_webb3[1] = _Gecko_WEB;
                    InsertHistory(_XtraTabPage_name, _Bweb_AIM_URL, "火狐");
                    break;

                default:
                    break;
            }

            if (_IE_WEB != null)
            {
                _XtraTabPage.Controls.Add(_IE_WEB);
                //_Webb.Add(_XtraTabPage_name, new object[] { _XtraTabPage, _WEBB_TYPE.IE.ToString(), _IE_WEB });
                xtraTabControl1.SelectedTabPage = _XtraTabPage;
            }

            if (_WebKit_WEB != null)
            {
                _XtraTabPage.Controls.Add(_WebKit_WEB);
                //_Webb.Add(_XtraTabPage_name, new object[] { _XtraTabPage, _WEBB_TYPE.WebKit.ToString(), _WebKit_WEB });
                xtraTabControl1.SelectedTabPage = _XtraTabPage;
                _XtraTabPage.Controls[0].Visible = false;
                //xtraTabControl1.SelectedTabPage.Dispose();
                _WebKit_WEB = _WebKit_WEB_FACTORY(_Bweb_NAME, _Bweb_AIM_URL);
                _XtraTabPage.Controls.Add(_WebKit_WEB);
                xtraTabControl1.SelectedTabPage = _XtraTabPage;
                //button2_Click(null, null);
            }

            if (_Gecko_WEB != null)
            {
                _XtraTabPage.Controls.Add(_Gecko_WEB);
                //_Webb.Add(_XtraTabPage_name, new object[] { _XtraTabPage, _WEBB_TYPE.Gecko.ToString(), _Gecko_WEB });
                xtraTabControl1.SelectedTabPage = _XtraTabPage;
            }

            
        }


        


        private void WebBrowser_DocumentCompleted(System.Windows.Forms.WebBrowser webBrowser)
        {
            ////将所有的链接的目标，指向本窗体
            //foreach (HtmlElement archor in webBrowser.Document.Links)
            //{
            //    archor.SetAttribute("target", "_self");
            //}
            ////将所有的FORM的提交目标，指向本窗体
            //foreach (HtmlElement form in webBrowser.Document.Forms)
            //{
            //    form.SetAttribute("target", "_self");
            //}

        }
        private void webBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private enum IeVersion
        {
            强制ie10,//10001 (0x2711) Internet Explorer 10。网页以IE 10的标准模式展现，页面!DOCTYPE无效
            标准ie10,//10000 (0x02710) Internet Explorer 10。在IE 10标准模式中按照网页上!DOCTYPE指令来显示网页。Internet Explorer 10 默认值。
            强制ie9,//9999 (0x270F) Windows Internet Explorer 9. 强制IE9显示，忽略!DOCTYPE指令
            标准ie9,//9000 (0x2328) Internet Explorer 9. Internet Explorer 9默认值，在IE9标准模式中按照网页上!DOCTYPE指令来显示网页。
            强制ie8,//8888 (0x22B8) Internet Explorer 8，强制IE8标准模式显示，忽略!DOCTYPE指令
            标准ie8,//8000 (0x1F40) Internet Explorer 8默认设置，在IE8标准模式中按照网页上!DOCTYPE指令展示网页
            标准ie7//7000 (0x1B58) 使用WebBrowser Control控件的应用程序所使用的默认值，在IE7标准模式中按照网页上!DOCTYPE指令来展示网页
        }
        /// <summary>
        /// 设置WebBrowser的默认版本
        /// </summary>
        /// <param name="ver">IE版本</param>
        private  static void SetIE(IeVersion ver)
        {
            string productName = AppDomain.CurrentDomain.SetupInformation.ApplicationName;//获取程序名称

            object version;
            switch (ver)
            {
                case IeVersion.标准ie7:
                    version = 0x1B58;
                    break;
                case IeVersion.标准ie8:
                    version = 0x1F40;
                    break;
                case IeVersion.强制ie8:
                    version = 0x22B8;
                    break;
                case IeVersion.标准ie9:
                    version = 0x2328;
                    break;
                case IeVersion.强制ie9:
                    version = 0x270F;
                    break;
                case IeVersion.标准ie10:
                    version = 0x02710;
                    break;
                case IeVersion.强制ie10:
                    version = 0x2711;
                    break;
                default:
                    version = 0x1F40;
                    break;
            }

            RegistryKey key = Registry.CurrentUser;
            RegistryKey software =
                key.CreateSubKey(
                    @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION\" + productName);
            if (software != null)
            {
                software.Close();
                software.Dispose();
            }
            RegistryKey wwui =
                key.OpenSubKey(
                    @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            //该项必须已存在
            if (wwui != null) wwui.SetValue(productName, version, RegistryValueKind.DWord);
        }
        /// <summary>
        /// IE内核 产生WebBrowser
        /// </summary>
        /// <param name="_IE_WEB_NAME"></param>
        /// <param name="_Aim_URL"></param>
        /// <returns></returns>
        private static System.Windows.Forms.WebBrowser _IE_WEB_FACTORY(string _IE_WEB_NAME, string _Aim_URL)
        {
            SetIE(IeVersion.强制ie8);

            System.Windows.Forms.WebBrowser _IE_WEB = new System.Windows.Forms.WebBrowser();
            _IE_WEB.Anchor = AnchorStyles.Left;
            _IE_WEB.Anchor = AnchorStyles.Right;
            _IE_WEB.Anchor = AnchorStyles.Top;
            _IE_WEB.Anchor = AnchorStyles.Bottom;
            _IE_WEB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            _IE_WEB.BackColor = System.Drawing.Color.Gray;

            _IE_WEB.ScriptErrorsSuppressed = true;
            _IE_WEB.Name = _IE_WEB_NAME;
            //_IE_WEB.TabIndex = xtraTabControl1.TabPages.Count + 1;
            if (_Aim_URL.StartsWith("www."))
                _Aim_URL = "http://" + _Aim_URL;
            try
            {
                _IE_WEB.Url = new Uri(_Aim_URL);
            }
            catch (Exception)
            {
                _Aim_URL = "https://" + _Aim_URL;
                _IE_WEB.Url = new Uri(_Aim_URL);
            }
          
            _IE_WEB.DocumentCompleted += _IE_WEB_DocumentCompleted;
            _IE_WEB.Width = xtraTabControl1.Width;
            _IE_WEB.Height = xtraTabControl1.Height;
            //WebBrowser_DocumentCompleted(_IE_WEB);
            _IE_WEB.NewWindow += _IE_WEB_NewWindow;
            //_IE_WEB.DocumentCompleted += _IE_WEB_DocumentCompleted1;
            return _IE_WEB;
        }

        private static void _IE_WEB_NewWindow(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.WebBrowser wb = sender as System.Windows.Forms.WebBrowser;
            //e.Cancel = true;
            //string newURL = wb.StatusText;
            e.Cancel = true;
            wb.Navigate(wb.StatusText);
        }
        private static void _IE_WEB_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser wb = sender as System.Windows.Forms.WebBrowser;
            //wb.DocumentText.Replace("target", "self");
            //wb.DocumentText.Replace("_blank", "self");
            xtraTabControl1.SelectedTabPage.Text = wb.Document.Title;
        }
        private void _IE_WEB_DocumentCompleted1(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //System.Windows.Forms.WebBrowser wb = sender as System.Windows.Forms.WebBrowser;
            //if (wb.DocumentText.IndexOf("window.open(") > -1 || wb.DocumentText.IndexOf("window.close()") > -1)
            //{
            //    wb.DocumentText = wb.DocumentText.Replace("window.open(", "window.external.open(").Replace("window.close()", "window.external.close()");
            //}
            //System.Windows.Forms.WebBrowser wb = sender as System.Windows.Forms.WebBrowser;
            //wb.DocumentText.Replace("target", "self");
            //wb.DocumentText.Replace("_blank", "self");
        }


        

        /// <summary>
        /// GOOGLE内核WebKit  产生WebBrowser
        /// </summary>
        /// <param name="_IE_WEB_NAME"></param>
        /// <param name="_Aim_URL"></param>
        /// <returns></returns>
        private static CefSharp.WinForms.ChromiumWebBrowser _WebKit_WEB_FACTORY(string _IE_WEB_NAME, string _Aim_URL)
        {
            CefSharp.WinForms.ChromiumWebBrowser _WebKit_WEB = new CefSharp.WinForms.ChromiumWebBrowser(_Aim_URL);
            //_WebKit_WEB.Anchor = AnchorStyles.Left;
            //_WebKit_WEB.Anchor = AnchorStyles.Right;
            //_WebKit_WEB.Anchor = AnchorStyles.Top;
            //_WebKit_WEB.Anchor = AnchorStyles.Bottom;
            _WebKit_WEB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            _WebKit_WEB.BackColor = System.Drawing.Color.Gray;
            _WebKit_WEB.FrameLoadEnd += _WebKit_WEB_FrameLoadEnd1;
            _WebKit_WEB.LifeSpanHandler = new OpenPageSelf();         
            //_WebKit_WEB.h
            //_WebKit_WEB.Text.Replace("target", "self");
            //_WebKit_WEB.Text.Replace("_blank", "self");
            _WebKit_WEB.Name = _IE_WEB_NAME;
            _WebKit_WEB.Tag = _Aim_URL;
            //_WebKit_WEB.TabIndex = xtraTabControl1.TabPages.Count + 1;
            ////_WebKit_WEB.Url = new Uri(_Aim_URL);
            //WebBrowser_DocumentCompleted(_WebKit_WEB);
            _WebKit_WEB.Width = xtraTabControl1.Width;
            _WebKit_WEB.Height = xtraTabControl1.Height;
            //_WebKit_WEB.MouseClick+= _WebKit_WEB_MouseDown;

            ////设置flash
            //string strMenu = System.Windows.Forms.Application.StartupPath;
            ////pepflashplayerDLL 地址
            //string flashPath = strMenu + "\\flashplayer\\x86\\pepflashplayer.dll";
            //CefSettings set = new CefSettings();
            //set.CachePath = "cache";
            ////开启ppapi-flash
            //set.CefCommandLineArgs["enable-system-flash"] = "1";
            //set.CefCommandLineArgs.Add("ppapi-flash-version", "28.0.0.137");
            ////插入地址
            //set.CefCommandLineArgs.Add("ppapi-flash-path", flashPath);
            ////启用配置
            //CefSharp.Cef.Initialize(set);

            return _WebKit_WEB;
        }

        private static void _WebKit_WEB_FrameLoadEnd1(object sender, FrameLoadEndEventArgs e)
        {
            CefSharp.WinForms.ChromiumWebBrowser newWebBrowser = sender as CefSharp.WinForms.ChromiumWebBrowser;
            //newWebBrowser.DocumentText.Replace("target", "self");
            //newWebBrowser.DocumentText.Replace("_blank", "self");
            if (newWebBrowser.Tag.ToString() != "")
                xtraTabControl1.Invoke(new Action<string>((str) =>
                {
                    if (newWebBrowser.Tag.ToString() == "主页") return;
                    if (newWebBrowser.Tag.ToString().Length > 15)
                        xtraTabControl1.SelectedTabPage.Text = newWebBrowser.Tag.ToString().Substring(0, 14);
                    else
                        xtraTabControl1.SelectedTabPage.Text = newWebBrowser.Tag.ToString();

                }), "");
        }

        //谷歌内核初始化flash
        public void InitBrowser()
        {
            //打开静态地址
            string strMenu = System.Windows.Forms.Application.StartupPath;
            //pepflashplayerDLL 地址
            string flashPath = strMenu + "\\flashplayer\\x86\\pepflashplayer32_32_0_0_223.dll";
            CefSettings set = new CefSettings();
            set.CachePath = "cache";
            //开启ppapi-flash
            set.CefCommandLineArgs["enable-system-flash"] = "1";
            set.CefCommandLineArgs.Add("ppapi-flash-version", "32.0.0.223");
            //插入地址
            set.CefCommandLineArgs.Add("ppapi-flash-path", flashPath);
            //启用配置
            CefSharp.Cef.Initialize(set);
            //var htmlDidr = "\\Files\\LargeScreen\\index.htm";
            //ChromiumWebBrowser browser = new ChromiumWebBrowser("");
            //BrowserSettings bset = new BrowserSettings();
            //bset.Plugins = CefState.Enabled;
            ////关于跨域限制
            //bset.WebSecurity = CefState.Disabled;
            //browser.BrowserSettings = bset;
            ////打开网页
            //browser.Load(strMenu + htmlDidr);
            ////绑定JS
            //browser.RegisterJsObject("callbackObj", new CallbackObjectForJs());
            //this.Controls.Add(browser);
            //browser.Dock = DockStyle.Fill;
            //browser.Update();

        }
        private void _WebKit_WEB_MouseDown(object sender, MouseEventArgs e)
        {
           
            //CefSharp.WinForms.ChromiumWebBrowser web1 = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];//获取当前活动选项卡上的WebBrowser
            string url = "www.baidu.com";//e.Location.;//获取鼠标点击的URL
            if (url.Contains("完成")) return;
            if (url.Contains("等待")) return;
            DevExpress.XtraTab.XtraTabPage _XtraTabPage = new DevExpress.XtraTab.XtraTabPage();
            _XtraTabPage.Size = new System.Drawing.Size(200, 300);
            _XtraTabPage.Location = new System.Drawing.Point(200, 300);
            _XtraTabPage.BackColor = Color.Red;
            _XtraTabPage.Anchor = AnchorStyles.Left;
            _XtraTabPage.Anchor = AnchorStyles.Right;
            _XtraTabPage.Anchor = AnchorStyles.Top;
            _XtraTabPage.Anchor = AnchorStyles.Bottom;
            _XtraTabPage.Size = new System.Drawing.Size(xtraTabControl1.Width, xtraTabControl1.Height);
            _XtraTabPage.Width = xtraTabControl1.Width;
            _XtraTabPage.Height = xtraTabControl1.Height;

            //_XtraTabPage.Name = _XtraTabPage_name;
            //_XtraTabPage.Text = web1.ac.TagName;


            _XtraTabPage.Tag = url;
            CefSharp.WinForms.ChromiumWebBrowser newWebBrowser =  new CefSharp.WinForms.ChromiumWebBrowser();
            //newWebBrowser.OnBeforePopup += Browser_StartNewWindow;
            newWebBrowser.Load(url);         //转到网站
            //newWebBrowser.DocumentCompleted += NewWebBrowser_DocumentCompleted;
            //newWebBrowser.ScriptErrorsSuppressed = true;
            newWebBrowser.Name = "测试tab";
            newWebBrowser.Dock = DockStyle.Fill;
            newWebBrowser.StatusMessage += NewWebBrowser_StatusMessage;
            //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
            _XtraTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
            xtraTabControl1.TabPages.Add((_XtraTabPage)); // 新选项卡添加到TabControl
            xtraTabControl1.SelectedTabPage = _XtraTabPage;//新选项卡位活动选项卡
            txt_url.Text = url;//地址栏显示地址
        }
        private void NewWebBrowser_StatusMessage(object sender, CefSharp.StatusMessageEventArgs e)
        {
            string s = e.Value;
            string sss = e.Browser.FocusedFrame.ToString();
        }
        private void _WebKit_WEB_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            //CefSharp.WinForms.ChromiumWebBrowser wb = sender as CefSharp.WinForms.ChromiumWebBrowser;
            ////throw new NotImplementedException();
            //wb.Text.Replace("target", "self");
            //wb.Text.Replace("_blank", "self");
        }



        /// <summary>
        /// 火狐内核Gecko  产生WebView[WebBrowser]
        /// </summary>
        /// <param name="_IE_WEB_NAME"></param>
        /// <param name="_Aim_URL"></param>
        /// <returns></returns>
        private static Gecko.Windows.WebView _Gecko_WEB_FACTORY(string _IE_WEB_NAME, string _Aim_URL)
        {
         
            Gecko.Windows.WebView _Gecko_WEB = new Gecko.Windows.WebView();
            _Gecko_WEB.Anchor = AnchorStyles.Left;
            _Gecko_WEB.Anchor = AnchorStyles.Right;
            _Gecko_WEB.Anchor = AnchorStyles.Top;
            _Gecko_WEB.Anchor = AnchorStyles.Bottom;
            _Gecko_WEB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            _Gecko_WEB.BackColor = System.Drawing.Color.Gray;

            _Gecko_WEB.Name = _IE_WEB_NAME;
            //_Gecko_WEB.TabIndex = xtraTabControl1.TabPages.Count + 1;
            _Gecko_WEB.Url = new Uri(_Aim_URL);
            _Gecko_WEB.DocumentCompleted += _Gecko_WEB_DocumentCompleted;
            _Gecko_WEB.CreateWindow += _Gecko_WEB_CreateWindow;
            _Gecko_WEB.Navigating += _Gecko_WEB_Navigating;
            //_Gecko_WEB.ProgressChanged += _Gecko_WEB_ProgressChanged; ;
            _Gecko_WEB.Width = xtraTabControl1.Width;
            _Gecko_WEB.Height = xtraTabControl1.Height;
            return _Gecko_WEB;
        }

        private static void _Gecko_WEB_Navigating(object sender, Gecko.GeckoNavigatingEventArgs e)
        {
            //MessageBox.Show(e.Request.Status.ToString());
        }

      

        private void _Gecko_WEB_ProgressChanged(object sender, Gecko.GeckoProgressEventArgs e)
        {
            //throw new NotImplementedException();
            //if (e.MaximumProgress == 0)
            //    return;

            //var value = (int)Math.Min(100, (e.CurrentProgress * 500) / e.MaximumProgress);
            //if (value == 1000)
            //    return;
            //progressBar1.Value = value;
          
        }

        private static void _Gecko_WEB_CreateWindow(object sender, Gecko.GeckoCreateWindowEventArgs e)
        {
            //Gecko.Windows.WebView wb = sender as Gecko.Windows.WebView;
            ////throw new NotImplementedException();
            //e.Cancel = true;
            //e.
            //wb.Navigate(wb.StatusText);//跳转网址
            //browser.Navigate(e.Uri);
            //e.Cancel = true;
            //MessageBox.Show(wb.StatusText);
        }


        
        

        private static void _Gecko_WEB_DocumentCompleted(object sender, Gecko.GeckoDocumentCompletedEventArgs e)
        {
            Gecko.Windows.WebView wb = sender as Gecko.Windows.WebView;
            //wb.Document.TextContent.Replace("target", "self");
            //wb.Document.TextContent.Replace("target", "self");
            //wb.Text.Replace("target", "self");
            //wb.Text.Replace("_blank", "self");

           
        }

        private void txt_url_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    xtraTabControl1.SelectedTabPage.Tag = txt_url.Text.Trim();
                    //MessageBox.Show("这是转到");
                    if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("IE"))
                    {
                        System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                        wb.Navigate(txt_url.Text.Trim());
                        //wb.Refresh();
                    }
                    else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("谷歌"))
                    {
                        //CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                        //wb.Load(txt_url.Text.Trim());
                        //xtraTabControl1.SelectedTabPage.Controls[0].Visible = false;
                        //DisXtab(xtraTabControl1.SelectedTabPage);
                        //CefSharp.WinForms.ChromiumWebBrowser _WebKit_WEB = _WebKit_WEB_FACTORY("_Bweb_NAME3", txt_url.Text.Trim());
                        //xtraTabControl1.SelectedTabPage.Controls.Add(_WebKit_WEB);
                        //xtraTabControl1.SelectedTabPage = _XtraTabPage;

                        DisXtab(xtraTabControl1.SelectedTabPage);
                        CefSharp.WinForms.ChromiumWebBrowser newWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
                        //newWebBrowser.OnBeforePopup += Browser_StartNewWindow;
                        newWebBrowser.Load(txt_url.Text.Trim());         //转到网站
                        newWebBrowser.Name = "谷歌_New_Tab";
                        newWebBrowser.Dock = DockStyle.Fill;
                        newWebBrowser.LifeSpanHandler = new OpenPageSelf();
                        newWebBrowser.Tag = txt_url.Text.Trim();
                        //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
                        //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
                        //Form1.xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
                        //Form1.txt_url.Text = url;//地址栏显示地址
                        xtraTabControl1.Invoke(new Action<string>((str) => { xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser); }), "");

                    }
                    else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("火狐"))
                    {
                        Gecko.Windows.WebView wb = (Gecko.Windows.WebView)xtraTabControl1.SelectedTabPage.Controls[0];
                        wb.Navigate(txt_url.Text.Trim());
                    }
                    else { }

                    #region
                    //MessageBox.Show(index.ToString());
                    //if (index == 0)
                    //{
                    //    //System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)obj_webb1[1];
                    //    webBrowser1.Url = new Uri(txt_url.Text);
                    //    webBrowser1.Refresh();
                    //}
                    //if (index==1)
                    //{

                    //    System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                    //    wb.Url = new Uri(txt_url.Text);
                    //    wb.Refresh();
                    //}
                    //if (index==2)
                    //{
                    //    CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                    //    wb.Load(txt_url.Text);
                    //}
                    //if (index==3)
                    //{
                    //    Gecko.Windows.WebView wb = (Gecko.Windows.WebView)xtraTabControl1.SelectedTabPage.Controls[0];
                    //    wb.Url = new Uri(txt_url.Text);
                    //    wb.Refresh();
                    //}
                    //if (obj_webb1[0].ToString() == "IE")
                    //{
                    //    System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)obj_webb1[1];
                    //    wb.Url = new Uri(txt_url.Text);
                    //    wb.Refresh();
                    //}
                    //if (obj_webb2[0].ToString() == "WebKit")
                    //{
                    //    CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)obj_webb2[1];
                    //    wb.Load(txt_url.Text);                      
                    //}
                    //if (obj_webb3[0].ToString() == "Gecko")
                    //{
                    //    Gecko.Windows.WebView wb = (Gecko.Windows.WebView)obj_webb3[1];
                    //    wb.Url = new Uri(txt_url.Text);
                    //    wb.Refresh();
                    //}
                    #endregion
                }
                catch (Exception)
                {

                }

            }
        }

        private void Wb_AddressChanged(object sender, CefSharp.AddressChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            WebBrowser web1 = (WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];//获取当前活动选项卡上的WebBrowser
            string url = web1.StatusText;//获取鼠标点击的URL
            if (url.Contains("完成")) return;
            if (url.Contains("等待")) return;
            DevExpress.XtraTab.XtraTabPage _XtraTabPage = new DevExpress.XtraTab.XtraTabPage();
            _XtraTabPage.Size = new System.Drawing.Size(200, 300);
            _XtraTabPage.Location = new System.Drawing.Point(200, 300);
            _XtraTabPage.BackColor = Color.Red;
            _XtraTabPage.Anchor = AnchorStyles.Left;
            _XtraTabPage.Anchor = AnchorStyles.Right;
            _XtraTabPage.Anchor = AnchorStyles.Top;
            _XtraTabPage.Anchor = AnchorStyles.Bottom;
            _XtraTabPage.Size = new System.Drawing.Size(xtraTabControl1.Width, xtraTabControl1.Height);
            _XtraTabPage.Width = xtraTabControl1.Width;
            _XtraTabPage.Height = xtraTabControl1.Height;

            //_XtraTabPage.Name = _XtraTabPage_name;
            //_XtraTabPage.Text = web1.ac.TagName;


            _XtraTabPage.Tag = url;
            System.Windows.Forms.WebBrowser newWebBrowser = new System.Windows.Forms.WebBrowser();
            
            newWebBrowser.Url = new Uri(url);          //转到网站
            newWebBrowser.DocumentCompleted += NewWebBrowser_DocumentCompleted;
            newWebBrowser.ScriptErrorsSuppressed = true;
            newWebBrowser.Name = "测试tab";
            newWebBrowser.Dock = DockStyle.Fill;
            //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
            //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
            _XtraTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
            xtraTabControl1.TabPages.Add((_XtraTabPage)); // 新选项卡添加到TabControl
            xtraTabControl1.SelectedTabPage= _XtraTabPage;//新选项卡位活动选项卡
          
            e.Cancel = true;//防止IE弹窗；
            txt_url.Text = url;//地址栏显示地址
        }


        private void NewWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            System.Windows.Forms.WebBrowser newWebBrowser = sender as System.Windows.Forms.WebBrowser;
            //throw new NotImplementedException();
            xtraTabControl1.SelectedTabPage.Text = newWebBrowser.Document.Title;
            ((WebBrowser)sender).Document.Window.Error +=new HtmlElementErrorEventHandler(Window_Error);
        }
        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {

        }

        ACCESS_HELPER acc = new ACCESS_HELPER();
        URL_HELPER url = new URL_HELPER();
        private void Form1_Load_1(object sender, EventArgs e)
        {
            try
            {
                listBoxControl1.Visible = false;
                GetXml();
                GetHisTory();
                //string main_url = GetMainPage();
                txt_url.Text= GetMainPage();
                //if (dtt.Rows.Count > 0)
                //{
                //    DataRow[] rows = dtt.Select(" IS_HOME=1 ");
                //    if (rows.Length > 0)
                //        txt_url.Text = rows[0]["URL_"].ToString();
                //}

                CefSharp.WinForms.ChromiumWebBrowser newWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
                //newWebBrowser.OnBeforePopup += Browser_StartNewWindow;
                     //转到网站
                newWebBrowser.Name = "谷歌_New_Tab";
                newWebBrowser.Load(txt_url.Text);
                newWebBrowser.Tag = txt_url.Text;
                //newWebBrowser.Tag = url.Get_First_Page();
                newWebBrowser.Dock = DockStyle.Fill;
                //txt_url.Text = url.Get_First_Page();
                newWebBrowser.LifeSpanHandler = new OpenPageSelf();
                //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
                //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
                //Form1.xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
                //Form1.txt_url.Text = url;//地址栏显示地址
                xtraTabControl1.Invoke(new Action<string>((str) => { xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser); xtraTabControl1.SelectedTabPage.Name = "谷歌内核"; }), "");
                //Set();

                //隐藏第一个 产生第二个
                DisXtab(xtraTabControl1.SelectedTabPage);
                CefSharp.WinForms.ChromiumWebBrowser newWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
                //newWebBrowser.OnBeforePopup += Browser_StartNewWindow;
                newWebBrowser1.Name = "谷歌_New_Tab";
                
                newWebBrowser1.Load(txt_url.Text);
                newWebBrowser1.Tag = txt_url.Text;
                newWebBrowser1.Dock = DockStyle.Fill;
                newWebBrowser1.LifeSpanHandler = new OpenPageSelf();
                //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
                //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
                //Form1.xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
                //Form1.txt_url.Text = url;//地址栏显示地址
                newWebBrowser1.Tag = txt_url.Text.Trim();
                xtraTabControl1.Invoke(new Action<string>((str) => { xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser1); }), "");

                //GetTypeData();
                //txt_url_KeyPress(null, null);
                //newWebBrowser.Refresh();
            }
            catch (Exception es)
            {

            }
          
        }

        /// <summary>
        /// 获得main——page
        /// </summary>
        /// <returns></returns>
        private string  GetMainPage()
        {
            XDocument document = XDocument.Load(Environment.CurrentDirectory + "/UrlSetMaster.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            IEnumerable<XElement> types = root.Elements();
            string url = "http://portal1.gs.sgcc.com.cn/";
            foreach (XElement item in types)
            {
                if (item.Value.ToString().Trim() != "")
                    url = item.Value.ToString().Trim().Split('|')[1];
                else
                    url = "http://portal1.gs.sgcc.com.cn/";
            }
            return url;
        }

        /// <summary>
        /// 获得历史记录
        /// </summary>
        /// 
        DataTable dt_his;
        private void  GetHisTory()
        {
            try
            {

                DataTable dtt = new DataTable();
                dtt.Columns.Add("NAME", typeof(string));
                dtt.Columns.Add("URL_", typeof(string));
                //dtt.Columns.Add("ID", typeof(string));
                dtt.Columns.Add("CREATE_TIME", typeof(string));
                dtt.Columns.Add("WEBKIT", typeof(string));
                //dtt.Columns.Add("IS_HOME", typeof(int));
                //dtt.Columns.Add("URL_TYPE", typeof(string));
                //将XML文件加载进来
                XDocument document1 = XDocument.Load(Environment.CurrentDirectory + "/UrlSet_History.xml");
                //获取到XML的根元素进行操作
                XElement root1 = document1.Root;
                IEnumerable<XElement> types1 = root1.Elements();
                int index1 = 1;


                //dt.Rows.Add(new object[] { index, item.Value, "", "" });
                //index++;
                foreach (XElement item1 in types1)
                {
                    IEnumerable<XElement> sys = item1.Elements();
                    foreach (XElement item2 in sys)
                    {
                        string s = item2.Value;
                        if (s != "")
                        {
                            if (s.StartsWith("||||")) continue;
                            string ss = s.Split('|')[0] + "    " + s.Split('|')[1];
                            //if (Convert.ToDateTime(s.Split('|')[4]) <= Convert.ToDateTime(dateEdit2.Text).AddDays(1) && Convert.ToDateTime(s.Split('|')[4]) >= Convert.ToDateTime(dateEdit1.Text))
                                //dtt.Rows.Add(new object[] { s.Split('|')[6], s.Split('|')[0], s.Split('|')[1], s.Split('|')[2], s.Split('|')[3], s.Split('|')[4], s.Split('|')[5] });
                                dtt.Rows.Add(new object[] { ss, s.Split('|')[1], s.Split('|')[4], s.Split('|')[2] });
                            index1++;
                        }

                    }
                }

                //DataTable dt = acc.GetData("select * from URL_LIST");
                dt_his = dtt;
            }
            catch (Exception)
            {

            }
        }
        // <name>百度|www.baidu.com|IE|0|2019-07-19 11:38:48|文件夹3|4309eb57-ad37-438b-898f-219a82615655</name>
        /// <summary>
        /// 插入历史
        /// </summary>
        public static void InsertHistory(string name, string url, string webkit)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Environment.CurrentDirectory + "/UrlSet_History.xml");
                XmlNode nodeList = xmlDoc.SelectSingleNode("URL");
                XmlNode nodeList1 = nodeList.SelectSingleNode("URL_TYPE");
                XmlElement xe1 = xmlDoc.CreateElement("name");//创建一个<name>节点 
                xe1.InnerText = name + "|" + url + "|" + webkit + "|0|" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "|收藏夹|" + Guid.NewGuid();
                nodeList1.AppendChild(xe1);
                xmlDoc.Save(Environment.CurrentDirectory + "/UrlSet_History.xml");
            }
            catch (Exception)
            {

            }
            
        }


        private void GetTypeData()
        {
            //DataTable dt = acc.GetData("select * from URL_TYPELIST");
            //foreach (DataRow row in dt.Rows)
            //{
            //    System.Windows.Forms.ToolStripMenuItem item_temp = new ToolStripMenuItem();
            //    item_temp.Name = row["TYPE_NAME"].ToString();
            //    item_temp.Text = row["TYPE_NAME"].ToString();
            //    this.收藏夹.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp });
            //    DataTable dtt = acc.GetData("select * from  URL_LIST where URL_TYPE_ID ='" + row["TYPE_NAME"].ToString() + "'");
            //    foreach (DataRow row_ in dtt.Rows)
            //    {
            //        System.Windows.Forms.ToolStripMenuItem item_temp1 = new ToolStripMenuItem();
            //        //item_temp1.Name = row["UTL"].ToString();
            //        item_temp1.Text = row_["URL_NAME"].ToString();
            //        item_temp1.ToolTipText = row_["URL_"].ToString();
            //        item_temp1.Tag = row_["URL_"].ToString();
            //        item_temp1.Click += Item_temp1_Click;
            //        item_temp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp1 });
            //    }
            //}
          
        }
        DataTable dtt;
        /// <summary>
        /// 加载收藏夹类型
        /// </summary>
        private void GetXml()
        {
            this.收藏夹.DropDownItems.Clear();

            dtt = new DataTable();
            dtt.Columns.Add("ID", typeof(string));
            dtt.Columns.Add("NAME", typeof(string));
            dtt.Columns.Add("URL_", typeof(string));
            dtt.Columns.Add("WEBKIT", typeof(string));
            dtt.Columns.Add("IS_HOME", typeof(int));
            dtt.Columns.Add("CREATE_TIME", typeof(string));
            dtt.Columns.Add("URL_TYPE", typeof(string));
            //将XML文件加载进来
            XDocument document1 = XDocument.Load(Environment.CurrentDirectory + "/UrlSet.xml");
            //获取到XML的根元素进行操作
            XElement root1 = document1.Root;
            IEnumerable<XElement> types1 = root1.Elements();
            int index1 = 1;


            //dt.Rows.Add(new object[] { index, item.Value, "", "" });
            //index++;
            foreach (XElement item1 in types1)
            {
                IEnumerable<XElement> sys = item1.Elements();
                foreach (XElement item2 in sys)
                {
                    string s = item2.Value;
                    if (s != "")
                    {
                        if (s.StartsWith("||||")) continue;
                        dtt.Rows.Add(new object[] { s.Split('|')[6], s.Split('|')[0], s.Split('|')[1], s.Split('|')[2], s.Split('|')[3], s.Split('|')[4], s.Split('|')[5] });
                        index1++;
                    }

                }
            }
            XDocument document = XDocument.Load(Environment.CurrentDirectory + "/UrlType_Set.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            IEnumerable<XElement> types = root.Elements();
            foreach (XElement item in types)
            {
                if (item.Value.ToString().Trim() != "")
                {

                    System.Windows.Forms.ToolStripMenuItem item_temp = new ToolStripMenuItem();
                    item_temp.Name = item.Value;
                    item_temp.Text = item.Value;
                    this.收藏夹.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp });
                    DataRow[] rows = dtt.Select(" URL_TYPE ='" + item.Value.ToString().Trim() + "'");
                    foreach (DataRow row in rows)
                    {
                       
                        System.Windows.Forms.ToolStripMenuItem item_temp1 = new ToolStripMenuItem();
                        //item_temp1.Name = row["UTL"].ToString();
                        item_temp1.Text = row["NAME"].ToString();
                        item_temp1.ToolTipText = row["WEBKIT"].ToString();
                        item_temp1.Tag = row["URL_"].ToString();
                        item_temp1.Click += Item_temp1_Click;
                        item_temp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp1 });
                    }

                }
            }
            //DataTable dt = acc.GetData("select * from URL_LIST");
            //dataGridView1.DataSource = dtt;
        }
        private void GetXml1()
        {
            #region
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(string));
            //dt.Columns.Add("TYPE", typeof(string));
            //dt.Columns.Add("UTL_NAME", typeof(string));
            //dt.Columns.Add("UTL", typeof(string));

            ////将XML文件加载进来
            //XDocument document = XDocument.Load(Environment.CurrentDirectory + "/UrlSet.xml");
            ////获取到XML的根元素进行操作
            //XElement root = document.Root;
            //XElement ele = root.Element("URL_TYPE");
            ////获取name标签的值
            //XElement shuxing = ele.Element("SYS");
            //Console.WriteLine(shuxing.Value);
            ////获取根元素下的所有子元素
            //IEnumerable<XElement> types = root.Elements();
            //int index = 1;
            //foreach (XElement item in types)
            //{

            //    System.Windows.Forms.ToolStripMenuItem item_temp = new ToolStripMenuItem();
            //    item_temp.Name = item.Attribute("id").Value;
            //    item_temp.Text = item.Attribute("id").Value;
            //    this.收藏夹.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp });
            //    IEnumerable<XElement> sys = item.Elements();
            //    foreach (XElement item1 in sys)
            //    {
            //        string s = item1.Value;
            //        System.Windows.Forms.ToolStripMenuItem item_temp1 = new ToolStripMenuItem();
            //        //item_temp1.Name = row["UTL"].ToString();
            //        item_temp1.Text = s.Split('|')[0];
            //        item_temp1.ToolTipText = s.Split('|')[1];
            //        item_temp1.Tag = s.Split('|')[1];
            //        item_temp1.Click += Item_temp1_Click;
            //        item_temp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp1 });
            //        //string s = item1.Value;
            //        //dt.Rows.Add(new object[] { index, item.Name, s.Split('|')[1], s.Split('|')[0] });
            //        //index++;
            //    }
            //}
            #endregion
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("TYPE", typeof(string));
            dt.Columns.Add("UTL_NAME", typeof(string));
            dt.Columns.Add("UTL", typeof(string));

            //将XML文件加载进来
            XDocument document = XDocument.Load(Environment.CurrentDirectory + "/UrlSet.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            XElement ele = root.Element("URL_TYPE");
            //获取name标签的值
            XElement shuxing = ele.Element("SYS");
            Console.WriteLine(shuxing.Value);
            //获取根元素下的所有子元素
            IEnumerable<XElement> types = root.Elements();
            int index = 1;
            foreach (XElement item in types)
            {

                System.Windows.Forms.ToolStripMenuItem item_temp = new ToolStripMenuItem();
                item_temp.Name = item.Attribute("id").Value;
                item_temp.Text = item.Attribute("id").Value;
                this.收藏夹.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp });
                IEnumerable<XElement> sys = item.Elements();
                foreach (XElement item1 in sys)
                {
                    string s = item1.Value;
                    System.Windows.Forms.ToolStripMenuItem item_temp1 = new ToolStripMenuItem();
                    //item_temp1.Name = row["UTL"].ToString();
                    item_temp1.Text = s.Split('|')[0];
                    item_temp1.ToolTipText = s.Split('|')[1];
                    item_temp1.Tag = s.Split('|')[1];
                    item_temp1.Click += Item_temp1_Click;
                    item_temp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp1 });
                    //string s = item1.Value;
                    //dt.Rows.Add(new object[] { index, item.Name, s.Split('|')[1], s.Split('|')[0] });
                    //index++;
                }
            }
        }
        private void Set()
        {
            //webBrowser1.Url = new Uri(url.Get_First_Page());
            string[] type = url.Get_URL_TYPE().Split(',');
            foreach (string item in type)
            {
                System.Windows.Forms.ToolStripMenuItem item_temp = new ToolStripMenuItem();
                item_temp.Name = item;
                item_temp.Text = item;
                this.收藏夹.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp});
                DataTable dt = url.Get_URL(item);
                foreach (DataRow row in dt.Rows)
                {
                    System.Windows.Forms.ToolStripMenuItem item_temp1 = new ToolStripMenuItem();
                    //item_temp1.Name = row["UTL"].ToString();
                    item_temp1.Text = row["UTL_NAME"].ToString();
                    item_temp1.ToolTipText = row["UTL"].ToString();
                    item_temp1.Tag = row["UTL"].ToString();
                    item_temp1.Click += Item_temp1_Click;
                    item_temp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { item_temp1 });
                }

            }
        }

        private void Item_temp1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolStripMenuItem item = sender as System.Windows.Forms.ToolStripMenuItem;
            if (item.ToolTipText.Contains("谷歌"))
            {
                Init_XtraTabPage("谷歌内核TAB", "谷歌内核TAB", item.Tag.ToString(), _WEBB_TYPE.WebKit, "_Bweb_NAME2", item.Tag.ToString());
               
            }
            else if (item.ToolTipText.Contains("IE"))
            {
                Init_XtraTabPage("IE内核TAB", "IE内核TAB", item.Tag.ToString(), _WEBB_TYPE.IE, "_Bweb_NAME1", item.Tag.ToString());
               
            }
            else if (item.ToolTipText.Contains("火狐"))
            {
                Init_XtraTabPage("火狐内核TAB", "火狐内核TAB", item.Tag.ToString(), _WEBB_TYPE.Gecko, "_Bweb_NAME3", item.Tag.ToString());
            }
            else
            { }

            //xtraTabControl1.SelectedTabPage.Tag = item.Tag.ToString();
            //txt_url.Text = item.Tag.ToString();
            ////MessageBox.Show("这是转到");
            //if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("IE"))
            //{
            //    System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
            //    wb.Navigate(item.Tag.ToString());
            //    //wb.Refresh();
            //}
            //else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("谷歌"))
            //{
            //    //CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
            //    //wb.Load(txt_url.Text.Trim());
            //    //xtraTabControl1.SelectedTabPage.Controls[0].Visible = false;
            //    //DisXtab(xtraTabControl1.SelectedTabPage);
            //    //CefSharp.WinForms.ChromiumWebBrowser _WebKit_WEB = _WebKit_WEB_FACTORY("_Bweb_NAME3", txt_url.Text.Trim());
            //    //xtraTabControl1.SelectedTabPage.Controls.Add(_WebKit_WEB);
            //    //xtraTabControl1.SelectedTabPage = _XtraTabPage;

                //    DisXtab(xtraTabControl1.SelectedTabPage);
                //    CefSharp.WinForms.ChromiumWebBrowser newWebBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
                //    //newWebBrowser.OnBeforePopup += Browser_StartNewWindow;
                //    newWebBrowser.Load(item.Tag.ToString());         //转到网站
                //    newWebBrowser.Name = "谷歌_New_Tab";
                //    newWebBrowser.Dock = DockStyle.Fill;
                //    newWebBrowser.LifeSpanHandler = new OpenPageSelf();
                //    //newWebBrowser.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
                //    //newWebBrowser.NewWindow += new CancelEventHandler(webBrowser1_NewWindow);
                //    //Form1.xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser);//新WebBrowser添加到新选项卡
                //    //Form1.txt_url.Text = url;//地址栏显示地址
                //    xtraTabControl1.Invoke(new Action<string>((str) => { xtraTabControl1.SelectedTabPage.Controls.Add(newWebBrowser); }), "");

                //}
                //else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("火狐"))
                //{
                //    Gecko.Windows.WebView wb = (Gecko.Windows.WebView)xtraTabControl1.SelectedTabPage.Controls[0];
                //    wb.Navigate(item.Tag.ToString());
                //}
                //else { }
        }


        /// <summary>
        /// 后退
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage.Tag = txt_url.Text.Trim();
            //MessageBox.Show("这是转到");
            if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("IE"))
            {
                System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                wb.GoBack();
            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("谷歌"))
            {
                CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[xtraTabControl1.SelectedTabPage.Controls.Count-1];
                wb.Back();
            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("火狐"))
            {
                Gecko.Windows.WebView wb = (Gecko.Windows.WebView)xtraTabControl1.SelectedTabPage.Controls[0];
                wb.GoBack();
            }
            else { }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPage.Tag = txt_url.Text.Trim();
            //MessageBox.Show("这是转到");
            if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("IE"))
            {
                System.Windows.Forms.WebBrowser wb = (System.Windows.Forms.WebBrowser)xtraTabControl1.SelectedTabPage.Controls[0];
                wb.GoForward();
            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("谷歌"))
            {
                CefSharp.WinForms.ChromiumWebBrowser wb = (CefSharp.WinForms.ChromiumWebBrowser)xtraTabControl1.SelectedTabPage.Controls[xtraTabControl1.SelectedTabPage.Controls.Count - 1];
                wb.Forward();
            }
            else if (xtraTabControl1.SelectedTabPage.Name.ToString().Contains("火狐"))
            {
                Gecko.Windows.WebView wb = (Gecko.Windows.WebView)xtraTabControl1.SelectedTabPage.Controls[0];
                wb.GoForward();
            }
            else { }
        }

        /// <summary>
        /// 展示主页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            xtraTabControl1.SelectedTabPageIndex = 0;
        }

        /// <summary>
        /// 收藏夹设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abort a = new Abort();
            a.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //if (thread.IsAlive)
            //    //    return;
            //    //Thread Hand1 = new Thread(delegate () { MethodName(参数1, 参数2); });
            //    //MyDelegate myDelegate = new MyDelegate(Init_XtraTabPage);
            //    //thread = new Thread(new MyDelegate { Init_XtraTabPage }));
            //    //thread = new Thread(new ThreadStart(Init_XtraTabPage));
            //    //thread.IsBackground = true;
            //    //thread.Start(new object[] { "IE内核测试", "IE内核测试", "http://wwww.baidu.com", _WEBB_TYPE.IE, "_Bweb_NAME1", "http://wwww.baidu.com" });
            //    thread = new Thread(delegate () { CREATEING("IE内核测试", "IE内核测试", "IE地址:https://ie.icoa.cn/", _WEBB_TYPE.IE, "_Bweb_NAME1", "https://ie.icoa.cn/"); });
            //    thread.IsBackground = true;
            //    thread.Start();
            //}
            //catch (Exception)
            //{
            //    thread.Abort();
            //}

            Init_XtraTabPage("IE内核TAB", "IE内核TAB", "http://news.baidu.com/", _WEBB_TYPE.IE, "_Bweb_NAME1", "http://news.baidu.com/");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //if (thread.IsAlive)
            //    //    return;
            //    thread = new Thread(delegate () { CREATEING("谷歌内核测试", "谷歌内核测试", "https://ie.icoa.cn/", _WEBB_TYPE.WebKit, "_Bweb_NAME2", "https://ie.icoa.cn/"); });
            //    thread.IsBackground = true;
            //    thread.Start();
            //}
            //catch (Exception)
            //{
            //    thread.Abort();
            //}
            Init_XtraTabPage("谷歌内核TAB", "谷歌内核TAB", "http://news.baidu.com/", _WEBB_TYPE.WebKit, "_Bweb_NAME2", "http://news.baidu.com/");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //if (thread.IsAlive)
            //    //    return;
            //    thread = new Thread(delegate () { CREATEING("火狐内核测试", "火狐内核测试", "火狐地址:https://ie.icoa.cn/", _WEBB_TYPE.Gecko, "_Bweb_NAME3", "https://ie.icoa.cn/"); });
            //    thread.IsBackground = true;
            //    thread.Start();
            //}
            //catch (Exception)
            //{
            //    thread.Abort();
            //}
            Init_XtraTabPage("火狐内核TAB", "火狐内核TAB", "http://news.baidu.com/", _WEBB_TYPE.Gecko, "_Bweb_NAME3", "http://news.baidu.com/");
        }

        
        private void 新建谷歌内核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = GetMainPage();
            if (url == "")
                url = "http://portal1.gs.sgcc.com.cn/";
            Init_XtraTabPage("谷歌内核TAB", "谷歌内核TAB", url, _WEBB_TYPE.WebKit, "_Bweb_NAME2", url);
        }

        private void 新建IE内核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = GetMainPage();
            if (url == "")
                url = "http://portal1.gs.sgcc.com.cn/";
            Init_XtraTabPage("IE内核TAB", "IE内核TAB", url, _WEBB_TYPE.IE, "_Bweb_NAME1", url);
        }

        private void 新建火狐内核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = GetMainPage();
            if (url == "")
                url = "http://portal1.gs.sgcc.com.cn/";
            Init_XtraTabPage("火狐内核TAB", "火狐内核TAB", url, _WEBB_TYPE.Gecko, "_Bweb_NAME3", url);
        }

        private void 自定义CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.ShowUpdate += Refresh_Method;
            f2.ShowDialog();

            //Form3 f = new Form3();
            //f.Show();
        }
        public void Refresh_Method()
        {
            GetXml();
        }

        private void 选项OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.textBox2.Text = txt_url.Text.Trim();
            f2.ShowUpdate += Refresh_Method;
            f2.ShowDialog();
        }


        private void 主页设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MASTER_PAGE master = new MASTER_PAGE();
            master.Show();
        }

        private void 历史记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HISTORY master = new HISTORY();
            //master.Parent = this;
            master.Show();
        }

        private void txt_url_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyValue == (int)Keys.Down)
            {
                if (listBoxControl1.Items.Count != 0)
                {
                    listBoxControl1.Focus();
                    listBoxControl1.SelectedIndex = 0;
                }
            }


        }
        public string columnName = "URL_";
        private void txt_url_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxControl1.SelectedItem != null)
            {
                this.txt_url.Text = listBoxControl1.SelectedItem.ToString();

                //this.Height = textBox1.Height;
                this.listBoxControl1.Visible = false;
                //this.SendToBack();
                pictureBox2_Click(null, null);

            }

        }

        private void txt_url_Leave(object sender, EventArgs e)
        {
            if (listBoxControl1.Focused == false)
            {
                //this.Height = textBox1.Height;
                this.listBoxControl1.Visible = false;
                //this.SendToBack();
            }

        }

        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_url_MouseEnter(object sender, EventArgs e)
        {
            GetHisTory();
        }

        private void txt_url_Enter(object sender, EventArgs e)
        {
            //GetHisTory();
        }

        private void txt_url_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txt_url.Text == "")
            {
                //this.Height = textBox1.Height;
                this.listBoxControl1.Visible = false;
                //this.SendToBack();
                return;
            }
            //这些情况下,不弹出选择框
            if (dt_his == null || columnName == "" || !dt_his.Columns.Contains(columnName))
                return;
            //根据用户当前输入的内容,筛选出与内容相符的记录,显示在列表框中
            this.listBoxControl1.Items.Clear();
            for (int i = 0; i < dt_his.Rows.Count; i++)
            {
                if (dt_his.Rows[i][columnName].ToString().Contains(txt_url.Text))
                {
                    listBoxControl1.Items.Add(dt_his.Rows[i][columnName].ToString());
                }
            }
            //如果记录数不为0,则将列表显示出来
            if (listBoxControl1.Items.Count == 0)
            {
                //this.Height = textBox1.Height;
                this.listBoxControl1.Visible = false;
                //this.SendToBack();
            }
            else
            {
                if (listBoxControl1.Items.Count == 1)
                {
                    //this.Height = textBox1.Height + 20 * listBox1.Items.Count;
                    this.listBoxControl1.Visible = true;
                    //this.BringToFront();
                }
                else if (listBoxControl1.Items.Count < 8)
                {
                    //this.Height = textBox1.Height + 14 * listBox1.Items.Count;
                    this.listBoxControl1.Visible = true;
                    //this.BringToFront();
                }
                else
                {
                    //this.Height = textBox1.Height + 108;
                    this.listBoxControl1.Visible = true;
                    //this.BringToFront();
                }
            }

        }

        private void listBoxControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (listBoxControl1.Focus())
            {
                if (e.KeyChar.ToString()=="\r")
                {
                    this.txt_url.Text = listBoxControl1.SelectedItem.ToString();
                    this.listBoxControl1.Visible = false;
                    pictureBox2_Click(null, null);
                }
            }
        }
    }
}
//定义枚举
public enum _WEBB_TYPE
{
    IE,
    WebKit,
    Gecko,
}

