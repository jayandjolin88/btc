using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MyChromiumWebBrowser : ChromiumWebBrowser
    {
        public MyChromiumWebBrowser()
            : base(null)
        {
            this.LifeSpanHandler = new CefLifeSpanHandler1();
            //this.DownloadHandler = new DownloadHandler(this);
        }

        public MyChromiumWebBrowser(string url) : base(url)
        {
            this.LifeSpanHandler = new CefLifeSpanHandler1();
        }

        public event EventHandler<NewWindowEventArgs> StartNewWindow;

        public void OnNewWindow(NewWindowEventArgs e)
        {
            if (StartNewWindow != null)
            {
                StartNewWindow(this, e);
            }
        }
    }
}
public class NewWindowEventArgs : EventArgs
{
    private IWindowInfo _windowInfo;
    public IWindowInfo WindowInfo
    {
        get { return _windowInfo; }
        set { value = _windowInfo; }
    }
    public string url { get; set; }
    public NewWindowEventArgs(IWindowInfo windowInfo, string url)
    {
        _windowInfo = windowInfo;
        this.url = url;
    }
}