namespace App
{
    partial class VideoDetailsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label6 = new Label();
            framerateLabel = new Label();
            label4 = new Label();
            pixelFormatLabel = new Label();
            resolutionLabel = new Label();
            label3 = new Label();
            fileNameLabel = new Label();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(framerateLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(label4, 0, 2);
            tableLayoutPanel1.Controls.Add(pixelFormatLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(resolutionLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 1);
            tableLayoutPanel1.Controls.Add(fileNameLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(151, 65);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(4, 49);
            label6.Name = "label6";
            label6.Size = new Size(60, 15);
            label6.TabIndex = 7;
            label6.Text = "Framerate";
            // 
            // framerateLabel
            // 
            framerateLabel.AutoSize = true;
            framerateLabel.Location = new Point(84, 49);
            framerateLabel.Name = "framerateLabel";
            framerateLabel.Size = new Size(63, 15);
            framerateLabel.TabIndex = 6;
            framerateLabel.Text = "Resolution";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 33);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 5;
            label4.Text = "Pixel Format";
            // 
            // pixelFormatLabel
            // 
            pixelFormatLabel.AutoSize = true;
            pixelFormatLabel.Location = new Point(84, 33);
            pixelFormatLabel.Name = "pixelFormatLabel";
            pixelFormatLabel.Size = new Size(63, 15);
            pixelFormatLabel.TabIndex = 4;
            pixelFormatLabel.Text = "Resolution";
            // 
            // resolutionLabel
            // 
            resolutionLabel.AutoSize = true;
            resolutionLabel.Location = new Point(84, 17);
            resolutionLabel.Name = "resolutionLabel";
            resolutionLabel.Size = new Size(38, 15);
            resolutionLabel.TabIndex = 3;
            resolutionLabel.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 17);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 2;
            label3.Text = "Resolution";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new Point(84, 1);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(38, 15);
            fileNameLabel.TabIndex = 1;
            fileNameLabel.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 1);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "File Name";
            // 
            // VideoDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(379, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "VideoDetailsForm";
            Text = "Video Details";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label resolutionLabel;
        private Label label3;
        private Label fileNameLabel;
        private Label label6;
        private Label framerateLabel;
        private Label label4;
        private Label pixelFormatLabel;
    }
}