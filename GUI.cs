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

        private void AdjustFilePathDisplay()
        {
            int new_length = FilePathBox.Text.Length * 6;
            int bb_new_x = new_length;

            FilePathBox.Size = new Size(new_length, FilePathBox.Size.Height);
            BrowseButton.Location = new Point(bb_new_x, BrowseButton.Location.Y);
        }

        private void LogsToMainDisplay(string text)
        {
            LogDisplay.TextAlign = HorizontalAlignment.Left;
            LogDisplay.Text = text;
        }

        private void InfoToMainDisplay(string text)
        {
            LogDisplay.TextAlign = HorizontalAlignment.Center;
            LogDisplay.Text = System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine + text;
        }

        private void AcquireFile(string path)
        {
            current_file_path = path;
            current_file_name = Path.GetFileName(current_file_path);

            if (!File.Exists(current_file_path))
            {
                MessageBox.Show("Failed to acquire the selected file as it does not exist!");
                return;
            }
            /*
            try
            {
                LogsToMainDisplay(File.ReadAllText(current_file_path));
            }
            catch(Exception e)
            {
                MessageBox.Show("Failed to acquire the selected file!\n\n" + e);
                return;
            }
            */
            FilePathBox.Text = filepath_prefix + current_file_name;
            AdjustFilePathDisplay();
            InfoToMainDisplay($"CURRENT FILE: {current_file_name}");
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
