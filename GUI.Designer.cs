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
            LogDisplay = new TextBox();
            SuspendLayout();
            // 
            // LogDisplay
            // 
            LogDisplay.AccessibleDescription = "Displays the contents of the currently loaded file with conditions as set by the user.";
            LogDisplay.AccessibleName = "Log Display";
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
            // 
            // GUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 461);
            Controls.Add(LogDisplay);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GUI";
            Text = "SpaceLogs13";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox LogDisplay;
    }
}
