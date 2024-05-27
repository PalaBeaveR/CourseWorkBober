using PlantUmlClassDiagramGenerator.Attributes;

namespace App
{
    
    partial class VideoPlayer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fpsLabel = new Label();
            playButton = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            timeline = new TrackBar();
            frame = new Controls.OpenGLDisplay();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeline).BeginInit();
            SuspendLayout();
            // 
            // fpsLabel
            // 
            fpsLabel.AutoSize = true;
            fpsLabel.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fpsLabel.ForeColor = Color.Green;
            fpsLabel.Location = new Point(573, 0);
            fpsLabel.Name = "fpsLabel";
            fpsLabel.Size = new Size(25, 13);
            fpsLabel.TabIndex = 12;
            fpsLabel.Text = "FPS";
            // 
            // playButton
            // 
            playButton.BackColor = Color.FromArgb(27, 36, 30);
            playButton.Dock = DockStyle.Fill;
            playButton.Enabled = false;
            playButton.FlatAppearance.BorderSize = 0;
            playButton.FlatStyle = FlatStyle.Flat;
            playButton.Font = new Font("Arial", 32F, FontStyle.Regular, GraphicsUnit.Pixel);
            playButton.ForeColor = SystemColors.ControlLight;
            playButton.Location = new Point(0, 0);
            playButton.Margin = new Padding(0);
            playButton.Name = "playButton";
            playButton.Size = new Size(60, 38);
            playButton.TabIndex = 10;
            playButton.Text = "⏵";
            playButton.UseVisualStyleBackColor = false;
            playButton.Click += playButton_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlText;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(frame, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(601, 380);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.FromArgb(27, 36, 30);
            tableLayoutPanel2.ColumnCount = 6;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel2.Controls.Add(playButton, 0, 0);
            tableLayoutPanel2.Controls.Add(button1, 2, 0);
            tableLayoutPanel2.Controls.Add(button2, 3, 0);
            tableLayoutPanel2.Controls.Add(fpsLabel, 5, 0);
            tableLayoutPanel2.Controls.Add(button3, 4, 0);
            tableLayoutPanel2.Controls.Add(timeline, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            tableLayoutPanel2.Location = new Point(0, 342);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(601, 38);
            tableLayoutPanel2.TabIndex = 11;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(27, 36, 30);
            button1.Dock = DockStyle.Fill;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F);
            button1.ForeColor = SystemColors.ControlLight;
            button1.Location = new Point(480, 0);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(30, 38);
            button1.TabIndex = 13;
            button1.Text = "x.5";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(27, 36, 30);
            button2.Dock = DockStyle.Fill;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F);
            button2.ForeColor = SystemColors.ControlLight;
            button2.Location = new Point(510, 0);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(30, 38);
            button2.TabIndex = 16;
            button2.Text = "x1";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(27, 36, 30);
            button3.Dock = DockStyle.Fill;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = SystemColors.ControlLight;
            button3.Location = new Point(540, 0);
            button3.Margin = new Padding(0);
            button3.Name = "button3";
            button3.Size = new Size(30, 38);
            button3.TabIndex = 17;
            button3.Text = "x2";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // timeline
            // 
            timeline.BackColor = Color.FromArgb(27, 36, 30);
            timeline.Dock = DockStyle.Fill;
            timeline.Location = new Point(63, 3);
            timeline.Name = "timeline";
            timeline.Size = new Size(414, 32);
            timeline.TabIndex = 18;
            timeline.TickFrequency = 10;
            timeline.Scroll += timeline_OnScroll;
            // 
            // frame
            // 
            frame.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            frame.APIVersion = new Version(3, 3, 0, 0);
            frame.BackColor = SystemColors.Desktop;
            frame.Dock = DockStyle.Fill;
            frame.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            frame.Image = null;
            frame.ImageSize = new Size(512, 512);
            frame.IsEventDriven = true;
            frame.Location = new Point(0, 0);
            frame.Margin = new Padding(0);
            frame.Name = "frame";
            frame.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
            frame.Size = new Size(601, 342);
            frame.TabIndex = 12;
            frame.Text = "openglDisplay1";
            frame.Visible = true;
            // 
            // VideoPlayer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlText;
            Controls.Add(tableLayoutPanel1);
            Name = "VideoPlayer";
            Size = new Size(601, 380);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeline).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button playButton;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label fpsLabel;
        private Button button1;
        private Button button2;
        private Button button3;
        private Controls.OpenGLDisplay frame;
        private TrackBar timeline;
    }
}
