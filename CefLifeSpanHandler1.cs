using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class CefLifeSpanHandler1: CefSharp.ILifeSpanHandler
    {
        public CefLifeSpanHandler1()
        {

        }

        public bool DoClose(IWebBrowser browserControl, CefSharp.IBrowser browser)
        {
            if (browser.IsDisposed || browser.IsPopup)
            {
                return false;
            }

            return true;
        }

        public void OnAfterCreated(IWebBrowser browserControl, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser browserControl, IBrowser browser)
        {
        }


        public bool OnBeforePopup(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            var chromiumWebBrowser = (MyChromiumWebBrowser)browserControl;
            chromiumWebBrowser.Invoke(new Action(() =>
            {
                NewWindowEventArgs e = new NewWindowEventArgs(windowInfo, targetUrl);
                chromiumWebBrowser.OnNewWindow(e);
            }));
            newBrowser = null;
            return true;
        }
    }
}
