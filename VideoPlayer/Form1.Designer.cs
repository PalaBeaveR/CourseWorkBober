using PlantUmlClassDiagramGenerator.Attributes;

namespace App
{
    [PlantUmlDiagram]
    partial class Form1
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
            videoPlayer = new VideoPlayer();
            openItem = new MenuStrip();
            openToolStripMenuItem = new ToolStripMenuItem();
            videoFileToolStripMenuItem = new ToolStripMenuItem();
            viewDetailsButton = new ToolStripMenuItem();
            openItem.SuspendLayout();
            SuspendLayout();
            // 
            // videoPlayer
            // 
            videoPlayer.Dock = DockStyle.Fill;
            videoPlayer.Location = new Point(0, 24);
            videoPlayer.Name = "videoPlayer";
            videoPlayer.Size = new Size(800, 426);
            videoPlayer.TabIndex = 0;
            videoPlayer.VideoPath = null;
            // 
            // openItem
            // 
            openItem.Items.AddRange(new ToolStripItem[] { openToolStripMenuItem, viewDetailsButton });
            openItem.Location = new Point(0, 0);
            openItem.Name = "openItem";
            openItem.Size = new Size(800, 24);
            openItem.TabIndex = 1;
            openItem.Text = "Open";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { videoFileToolStripMenuItem });
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(48, 20);
            openToolStripMenuItem.Text = "Open";
            // 
            // videoFileToolStripMenuItem
            // 
            videoFileToolStripMenuItem.Name = "videoFileToolStripMenuItem";
            videoFileToolStripMenuItem.Size = new Size(125, 22);
            videoFileToolStripMenuItem.Text = "Video File";
            videoFileToolStripMenuItem.Click += videoFileToolStripMenuItem_Click;
            // 
            // viewDetailsButton
            // 
            viewDetailsButton.Name = "viewDetailsButton";
            viewDetailsButton.Size = new Size(82, 20);
            viewDetailsButton.Text = "View Details";
            viewDetailsButton.Click += viewDetailsButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(videoPlayer);
            Controls.Add(openItem);
            MainMenuStrip = openItem;
            Name = "Form1";
            Text = "Video Player";
            openItem.ResumeLayout(false);
            openItem.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private VideoPlayer videoPlayer;
        [PlantUmlIgnoreAssociation]
        private MenuStrip openItem;
        [PlantUmlIgnoreAssociation]
        private ToolStripMenuItem openToolStripMenuItem;
        [PlantUmlIgnoreAssociation]
        private ToolStripMenuItem videoFileToolStripMenuItem;
        [PlantUmlIgnoreAssociation]
        private ToolStripMenuItem viewDetailsButton;
    }
}
