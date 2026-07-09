using System.Reflection;
using System.Windows.Forms;

namespace MDD4All.EMOF.Apps.EaPlugin.Views
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            VersionLabel.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
