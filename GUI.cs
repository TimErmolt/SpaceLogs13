using System.Text;
using System.Windows.Forms;

namespace SpaceLogs13
{
    public partial class GUI : Form
    {
        private const string filepath_prefix = "Current file: ";
        private const string filepath_default = "none";
        private const string display_default = "NO LOG FILE LOADED";

        public LogFile? current_file;

        public GUI()
        {
            InitializeComponent();
            this.Select();

            FilePathBox.Text = filepath_prefix + filepath_default;
            AdjustFilePathDisplay();
        }
        private void GUI_DragDrop(object sender, DragEventArgs e)
        {
            string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (data == null || !AcquireFile(data[0]))
            {
                InfoToMainDisplay("Could not select that file!");
            }
        }
        private void GUI_DragEnter(object sender, DragEventArgs e)
        {
            InfoToMainDisplay("Drop the log file to select it");
            e.Effect = DragDropEffects.Copy; // Otherwise the drag&drop just doesn't work. Thank you Microsoft. ~01.09.2025
        }
        private void GUI_DragLeave(object sender, EventArgs e)
        {
            InfoToMainDisplay(display_default);
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
                AcquireFile(browser.FileName);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchByKeyword(KeywordBox.Text, CaseSensitiveCheck.Checked);
        }

        private void DeselectButton_Click(object sender, EventArgs e)
        {
            UnacquireFile();
        }

        private void Enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                SearchByKeyword(KeywordBox.Text, CaseSensitiveCheck.Checked);
            }
        }
    }
}
