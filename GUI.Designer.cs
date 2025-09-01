


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
            LogDisplay.Location = new Point(12, 286);
            LogDisplay.MaxLength = 16777216;
            LogDisplay.Multiline = true;
            LogDisplay.Name = "LogDisplay";
            LogDisplay.ReadOnly = true;
            LogDisplay.ScrollBars = ScrollBars.Both;
            LogDisplay.Size = new Size(780, 163);
            LogDisplay.TabIndex = 0;
            LogDisplay.Text = "\r\n\r\n\r\nNO LOG FILE LOADED\r\n";
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
            FilePathBox.Size = new Size(220, 16);
            FilePathBox.TabIndex = 1;
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(238, 8);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(66, 23);
            BrowseButton.TabIndex = 2;
            BrowseButton.Text = "Browse...";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // GUI
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 461);
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
    }
}
