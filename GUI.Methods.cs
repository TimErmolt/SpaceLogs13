/*
 * Methods for the primary form GUI class.
*/

using SpaceLogs13.Classes;

namespace SpaceLogs13;

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
        LogDisplay.Text = System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine
                          + System.Environment.NewLine + System.Environment.NewLine + text; // I'm bad at strings ~02.09.2025
    }

    private void ShowReport(string text)
    {
        ReportBox.Visible = true;
        ReportBox.Text = text;
    }

    private void ClearReport()
    {
        ReportBox.Visible = false;
        ReportBox.Text = "";
    }

    private bool AcquireFile(string path)
    {
        try
        {
            current_file = new LogFile(path);
        }
        catch (FileNotFoundException e)
        {
            MessageBox.Show("Failed to acquire the selected file!" + System.Environment.NewLine + System.Environment.NewLine + e);
            return false;
        }
        string filename = current_file.Filename();
        FilePathBox.Text = filepath_prefix + filename;
        AdjustFilePathDisplay();
        ClearReport();
        InfoToMainDisplay($"CURRENT FILE: {filename}");

        DeselectButton.Enabled = true;
        SearchButton.Enabled = true;
        return true;
    }

    private void UnacquireFile()
    {
        if(current_file == null)
        {
            return;
        }

        current_file = null;
        DeselectButton.Enabled= false;
        SearchButton.Enabled = false;
        FilePathBox.Text = filepath_prefix + filepath_default;
        AdjustFilePathDisplay();
        ClearReport();
        InfoToMainDisplay(display_default);
    }

    private void SearchByKeyword(string keyword, bool match_case = false)
    {
        if (current_file == null)
        {
            return;
        }
        string[] found_lines = current_file.Search(keyword, match_case);
        LogsToMainDisplay(string.Join(System.Environment.NewLine, found_lines));
        ShowReport($"{current_file.Lines().Length} total lines; {found_lines.Length} matched");
    }
}
