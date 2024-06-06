using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class VideoDetailsForm : Form
    {
        public VideoDetailsForm(ref FFMVideo video)
        {
            InitializeComponent();

            this.fileNameLabel.Text = video.Info.FilePath;
            this.resolutionLabel.Text = $@"{video.VideoInfo.FrameSize.Width}x{video.VideoInfo.FrameSize.Height}";
            this.pixelFormatLabel.Text = video.VideoInfo.PixelFormat;
            this.framerateLabel.Text = video.VideoInfo.AvgFrameRate.ToString(CultureInfo.CurrentCulture);
        }
    }
}
