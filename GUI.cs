namespace SpaceLogs13
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            this.Select();
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
    }
}
