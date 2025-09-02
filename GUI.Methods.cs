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
    }
}
