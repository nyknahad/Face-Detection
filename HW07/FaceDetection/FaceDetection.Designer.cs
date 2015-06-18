namespace CameraCapture
{
    partial class FaceDetection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceDetection));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.webCameraImageBoxRGB = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.cbDetectFaceFile = new System.Windows.Forms.CheckBox();
            this.cbDetectEyeFile = new System.Windows.Forms.CheckBox();
            this.cbDetectMouthFile = new System.Windows.Forms.CheckBox();
            this.openButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.fitButton = new System.Windows.Forms.Button();
            this.btnSkinDetection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.webCameraImageBoxRGB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image Files (*.bmp;*.gif;*.exif;*.jpg;*.png;*.tiff)|*.bmp;*.gif;*.exif;*.jpg;*.jp" +
    "eg;*.png;*.tiff|All Files (*.*)|*.*";
            // 
            // webCameraImageBoxRGB
            // 
            this.webCameraImageBoxRGB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.webCameraImageBoxRGB.Location = new System.Drawing.Point(28, 47);
            this.webCameraImageBoxRGB.Margin = new System.Windows.Forms.Padding(2);
            this.webCameraImageBoxRGB.Name = "webCameraImageBoxRGB";
            this.webCameraImageBoxRGB.Size = new System.Drawing.Size(769, 600);
            this.webCameraImageBoxRGB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.webCameraImageBoxRGB.TabIndex = 2;
            this.webCameraImageBoxRGB.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(28, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Webcam";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cbDetectFaceFile
            // 
            this.cbDetectFaceFile.AutoSize = true;
            this.cbDetectFaceFile.Location = new System.Drawing.Point(166, 18);
            this.cbDetectFaceFile.Name = "cbDetectFaceFile";
            this.cbDetectFaceFile.Size = new System.Drawing.Size(85, 17);
            this.cbDetectFaceFile.TabIndex = 7;
            this.cbDetectFaceFile.Text = "Detect Face";
            this.cbDetectFaceFile.UseVisualStyleBackColor = true;
            // 
            // cbDetectEyeFile
            // 
            this.cbDetectEyeFile.AutoSize = true;
            this.cbDetectEyeFile.Location = new System.Drawing.Point(257, 18);
            this.cbDetectEyeFile.Name = "cbDetectEyeFile";
            this.cbDetectEyeFile.Size = new System.Drawing.Size(79, 17);
            this.cbDetectEyeFile.TabIndex = 8;
            this.cbDetectEyeFile.Text = "Detect Eye";
            this.cbDetectEyeFile.UseVisualStyleBackColor = true;
            // 
            // cbDetectMouthFile
            // 
            this.cbDetectMouthFile.AutoSize = true;
            this.cbDetectMouthFile.Location = new System.Drawing.Point(342, 18);
            this.cbDetectMouthFile.Name = "cbDetectMouthFile";
            this.cbDetectMouthFile.Size = new System.Drawing.Size(91, 17);
            this.cbDetectMouthFile.TabIndex = 9;
            this.cbDetectMouthFile.Text = "Detect Mouth";
            this.cbDetectMouthFile.UseVisualStyleBackColor = true;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(802, 12);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(87, 23);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Image for Skin";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(802, 48);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(225, 340);
            this.pictureBox.TabIndex = 11;
            this.pictureBox.TabStop = false;
            // 
            // fitButton
            // 
            this.fitButton.Location = new System.Drawing.Point(895, 12);
            this.fitButton.Name = "fitButton";
            this.fitButton.Size = new System.Drawing.Size(86, 23);
            this.fitButton.TabIndex = 12;
            this.fitButton.Text = "Fit the Image";
            this.fitButton.UseVisualStyleBackColor = true;
            this.fitButton.Click += new System.EventHandler(this.fitButton_Click);
            // 
            // btnSkinDetection
            // 
            this.btnSkinDetection.Location = new System.Drawing.Point(987, 12);
            this.btnSkinDetection.Name = "btnSkinDetection";
            this.btnSkinDetection.Size = new System.Drawing.Size(97, 23);
            this.btnSkinDetection.TabIndex = 13;
            this.btnSkinDetection.Text = "Detect the Skin";
            this.btnSkinDetection.UseVisualStyleBackColor = true;
            this.btnSkinDetection.Click += new System.EventHandler(this.btnSkinDetection_Click);
            // 
            // FaceDetection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 527);
            this.Controls.Add(this.btnSkinDetection);
            this.Controls.Add(this.fitButton);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.cbDetectMouthFile);
            this.Controls.Add(this.cbDetectEyeFile);
            this.Controls.Add(this.cbDetectFaceFile);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.webCameraImageBoxRGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FaceDetection";
            this.Text = "Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CameraCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webCameraImageBoxRGB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private Emgu.CV.UI.ImageBox webCameraImageBoxRGB;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckBox cbDetectFaceFile;
        private System.Windows.Forms.CheckBox cbDetectEyeFile;
        private System.Windows.Forms.CheckBox cbDetectMouthFile;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button fitButton;
        private System.Windows.Forms.Button btnSkinDetection;
    }
}

