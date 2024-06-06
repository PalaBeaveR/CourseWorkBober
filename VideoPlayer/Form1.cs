
namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void videoFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog? selectFileDialog = new OpenFileDialog())
            {
                selectFileDialog.Multiselect = false;
                DialogResult result = selectFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.videoPlayer.VideoPath = Path.Combine(selectFileDialog.InitialDirectory, selectFileDialog.FileName);
                }
            }
        }

        private void viewDetailsButton_Click(object sender, EventArgs e) {
            FFMVideo videoPlayerVideo = this.videoPlayer.Video;

            if (videoPlayerVideo != null) {
                VideoDetailsForm details
                    = new VideoDetailsForm(ref videoPlayerVideo);
                details.Show();
            }
        }
    }
}