


namespace SpaceLogs13
{
    partial class GUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            LogDisplay = new TextBox();
            FilePathBox = new TextBox();
            BrowseButton = new Button();
            KeywordBox = new TextBox();
            SearchButton = new Button();
            CaseSensitiveCheck = new CheckBox();
            DeselectButton = new Button();
            ReportBox = new TextBox();
            StatDisplay = new TextBox();
            RoundSelector = new ComboBox();
            SuspendLayout();
            // 
            // LogDisplay
            // 
            LogDisplay.AccessibleDescription = "Displays the contents of the currently loaded file with conditions as set by the user.";
            LogDisplay.AccessibleName = "Log Display";
            LogDisplay.AllowDrop = true;
            LogDisplay.BackColor = SystemColors.ControlLightLight;
            LogDisplay.BorderStyle = BorderStyle.FixedSingle;
            LogDisplay.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LogDisplay.Location = new Point(12, 209);
            LogDisplay.MaxLength = 16777216;
            LogDisplay.Multiline = true;
            LogDisplay.Name = "LogDisplay";
            LogDisplay.ReadOnly = true;
            LogDisplay.ScrollBars = ScrollBars.Both;
            LogDisplay.Size = new Size(780, 240);
            LogDisplay.TabIndex = 0;
            LogDisplay.Text = "\r\n\r\n\r\n\r\n\r\nNO LOG FILE LOADED";
            LogDisplay.TextAlign = HorizontalAlignment.Center;
            LogDisplay.DragDrop += GUI_DragDrop;
            LogDisplay.DragEnter += GUI_DragEnter;
            LogDisplay.DragLeave += GUI_DragLeave;
            // 
            // FilePathBox
            // 
            FilePathBox.BackColor = SystemColors.Control;
            FilePathBox.BorderStyle = BorderStyle.None;
            FilePathBox.Location = new Point(12, 12);
            FilePathBox.Name = "FilePathBox";
            FilePathBox.ReadOnly = true;
            FilePathBox.Size = new Size(146, 16);
            FilePathBox.TabIndex = 1;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(164, 8);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(66, 23);
            BrowseButton.TabIndex = 2;
            BrowseButton.Text = "Browse...";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // KeywordBox
            // 
            KeywordBox.Location = new Point(12, 94);
            KeywordBox.MaxLength = 1024;
            KeywordBox.Name = "KeywordBox";
            KeywordBox.Size = new Size(146, 23);
            KeywordBox.TabIndex = 3;
            KeywordBox.KeyPress += Enter;
            // 
            // SearchButton
            // 
            SearchButton.Enabled = false;
            SearchButton.Location = new Point(164, 94);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(68, 23);
            SearchButton.TabIndex = 4;
            SearchButton.Text = "Search...";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // CaseSensitiveCheck
            // 
            CaseSensitiveCheck.AutoSize = true;
            CaseSensitiveCheck.Location = new Point(12, 123);
            CaseSensitiveCheck.Name = "CaseSensitiveCheck";
            CaseSensitiveCheck.Size = new Size(86, 19);
            CaseSensitiveCheck.TabIndex = 5;
            CaseSensitiveCheck.Text = "Match case";
            CaseSensitiveCheck.UseVisualStyleBackColor = true;
            // 
            // DeselectButton
            // 
            DeselectButton.Enabled = false;
            DeselectButton.Location = new Point(12, 34);
            DeselectButton.Name = "DeselectButton";
            DeselectButton.Size = new Size(99, 23);
            DeselectButton.TabIndex = 6;
            DeselectButton.Text = "Deselect file";
            DeselectButton.UseVisualStyleBackColor = true;
            DeselectButton.Click += DeselectButton_Click;
            // 
            // ReportBox
            // 
            ReportBox.BackColor = SystemColors.Control;
            ReportBox.BorderStyle = BorderStyle.None;
            ReportBox.Location = new Point(12, 187);
            ReportBox.Name = "ReportBox";
            ReportBox.ReadOnly = true;
            ReportBox.Size = new Size(220, 16);
            ReportBox.TabIndex = 7;
            ReportBox.Visible = false;
            // 
            // StatDisplay
            // 
            StatDisplay.AccessibleDescription = "Displays the contents of the currently loaded file with conditions as set by the user.";
            StatDisplay.AccessibleName = "Log Display";
            StatDisplay.AllowDrop = true;
            StatDisplay.BackColor = SystemColors.ControlLightLight;
            StatDisplay.BorderStyle = BorderStyle.FixedSingle;
            StatDisplay.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            StatDisplay.Location = new Point(471, 7);
            StatDisplay.MaxLength = 16777216;
            StatDisplay.Multiline = true;
            StatDisplay.Name = "StatDisplay";
            StatDisplay.ReadOnly = true;
            StatDisplay.ScrollBars = ScrollBars.Vertical;
            StatDisplay.Size = new Size(321, 196);
            StatDisplay.TabIndex = 8;
            // 
            // RoundSelector
            // 
            RoundSelector.Enabled = false;
            RoundSelector.Font = new Font("Arial", 12F, FontStyle.Bold);
            RoundSelector.FormattingEnabled = true;
            RoundSelector.Location = new Point(363, 7);
            RoundSelector.Name = "RoundSelector";
            RoundSelector.Size = new Size(102, 27);
            RoundSelector.TabIndex = 9;
            RoundSelector.Text = "ROUND";
            RoundSelector.SelectionChangeCommitted += RoundSelector_SelectionChangeCommitted;
            // 
            // GUI
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 461);
            Controls.Add(RoundSelector);
            Controls.Add(StatDisplay);
            Controls.Add(ReportBox);
            Controls.Add(DeselectButton);
            Controls.Add(CaseSensitiveCheck);
            Controls.Add(SearchButton);
            Controls.Add(KeywordBox);
            Controls.Add(BrowseButton);
            Controls.Add(FilePathBox);
            Controls.Add(LogDisplay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "GUI";
            Text = "SpaceLogs13";
            DragDrop += GUI_DragDrop;
            DragEnter += GUI_DragEnter;
            DragLeave += GUI_DragLeave;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LogDisplay;
        private TextBox FilePathBox;
        private Button BrowseButton;
        private TextBox KeywordBox;
        private Button SearchButton;
        private CheckBox CaseSensitiveCheck;
        private Button DeselectButton;
        private TextBox ReportBox;
        private TextBox StatDisplay;
        private ComboBox RoundSelector;
    }
}
