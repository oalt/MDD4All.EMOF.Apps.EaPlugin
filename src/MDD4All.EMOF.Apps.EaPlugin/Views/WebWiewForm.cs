using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDD4All.EMOF.Apps.EaPlugin.Views
{
    public partial class WebWiewForm : Form
    {
        private WebView2 _webView;

        public WebWiewForm()
        {
            InitializeComponent();

            _webView = new WebView2
            {
                Dock = DockStyle.Fill
            };

            Controls.Add(_webView);

            string version = CoreWebView2Environment.GetAvailableBrowserVersionString();
        }

        private async void WebWiewForm_Load(object sender, EventArgs e)
        {
            try
            {
                string userDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                                        "MDD4All",
                                                        "WebView2");

                Directory.CreateDirectory(userDataFolder);

                CoreWebView2Environment coreWebView2Environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder);

                await _webView.EnsureCoreWebView2Async(coreWebView2Environment);
                _webView.Source = new Uri("https://localhost:7075/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "WebView2 Fehler");
            }
        }
    }
}
