/*
 * Methods for the primary form GUI class.
*/

namespace SpaceLogs13
{
    partial class GUI
    {

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

        private bool AcquireFile(string path)
        {
            try
            {
                current_file = new LogFile(path);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("Failed to acquire the selected file as it does not exist!" + System.Environment.NewLine + e);
                return false;
            }
            string filename = current_file.Filename();
            FilePathBox.Text = filepath_prefix + filename;
            AdjustFilePathDisplay();
            InfoToMainDisplay($"CURRENT FILE: {filename}");
            return true;
        }
    }
}
