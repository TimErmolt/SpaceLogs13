using System.Text;
using System.Windows.Forms;

namespace SpaceLogs13
{
    public partial class GUI : Form
    {
        private const string filepath_prefix = "Current file: ";
        private const string filepath_default = "none";

        public string current_file_path = "";
        public string current_file_name = "";
        public GUI()
        {
            InitializeComponent();
            this.Select();

            FilePathBox.Text = filepath_prefix + filepath_default;
            AdjustFilePathDisplay();
        }
        private void GUI_DragDrop(object sender, DragEventArgs e)
        {
            LogDisplay.Text = "THE DRAG HAS BEEN DROPPED.";
        }
        private void GUI_DragEnter(object sender, DragEventArgs e)
        {
            LogDisplay.Text = "THE DRAG HAS ENTERED.";
            e.Effect = DragDropEffects.Copy; // Otherwise the drag&drop just doesn't work. Thank you Microsoft. ~01.09.2025
        }
        private void GUI_DragLeave(object sender, EventArgs e)
        {
            LogDisplay.Text = "THE DRAG HAS LEFT.";
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new();
            string filter_settings = "Log files|*.txt;*.log|All files|*.*";

            browser.InitialDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName; // this looks like ass ~02.09.2025
            browser.Title = "Select a log file";
            browser.Filter = filter_settings;
            browser.FilterIndex = 1;
            browser.RestoreDirectory = true;

            if (browser.ShowDialog() == DialogResult.OK)
            {
                string file_path = browser.FileName;
                AcquireFile(file_path);
            }
        }
    }
}
