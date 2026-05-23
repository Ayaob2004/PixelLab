
namespace PixelLab
{
    partial class formShowImg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formShowImg));
            this.picImg = new System.Windows.Forms.PictureBox();
            this.btnImg = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnQuantize = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpImageInfo = new System.Windows.Forms.GroupBox();
            this.lblAspectRatioValue = new System.Windows.Forms.Label();
            this.lblLastModifiedValue = new System.Windows.Forms.Label();
            this.lblColorDepthValue = new System.Windows.Forms.Label();
            this.aspectRatio = new System.Windows.Forms.Label();
            this.lblPixelFormatValue = new System.Windows.Forms.Label();
            this.lblDpiValue = new System.Windows.Forms.Label();
            this.lblPixelCountValue = new System.Windows.Forms.Label();
            this.lblFileSizeValue = new System.Windows.Forms.Label();
            this.lblDimensionsValue = new System.Windows.Forms.Label();
            this.lblFormatValue = new System.Windows.Forms.Label();
            this.lblPathValue = new System.Windows.Forms.Label();
            this.lblFileNameValue = new System.Windows.Forms.Label();
            this.lastModified = new System.Windows.Forms.Label();
            this.colorDepth = new System.Windows.Forms.Label();
            this.pixelFormat = new System.Windows.Forms.Label();
            this.dpi = new System.Windows.Forms.Label();
            this.pixelCount = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.Label();
            this.dimensions = new System.Windows.Forms.Label();
            this.format = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.grpImageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImg
            // 
            this.picImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picImg.BackgroundImage")));
            this.picImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg.Location = new System.Drawing.Point(0, 0);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(1028, 609);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            this.picImg.Click += new System.EventHandler(this.picImg_Click_1);
            this.picImg.DragDrop += new System.Windows.Forms.DragEventHandler(this.picImg_DragDrop);
            this.picImg.DragEnter += new System.Windows.Forms.DragEventHandler(this.picImg_DragEnter);
            // 
            // btnImg
            // 
            this.btnImg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImg.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImg.Location = new System.Drawing.Point(12, 12);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(134, 35);
            this.btnImg.TabIndex = 1;
            this.btnImg.Text = "Select Image";
            this.btnImg.UseVisualStyleBackColor = false;
            this.btnImg.Click += new System.EventHandler(this.btnImg_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnQuantize
            // 
            this.btnQuantize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnQuantize.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuantize.Location = new System.Drawing.Point(174, 12);
            this.btnQuantize.Name = "btnQuantize";
            this.btnQuantize.Size = new System.Drawing.Size(134, 35);
            this.btnQuantize.TabIndex = 2;
            this.btnQuantize.Text = "Qunatize";
            this.btnQuantize.UseVisualStyleBackColor = false;
            this.btnQuantize.Click += new System.EventHandler(this.btnQuantize_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // grpImageInfo
            // 
            this.grpImageInfo.Controls.Add(this.lblAspectRatioValue);
            this.grpImageInfo.Controls.Add(this.lblLastModifiedValue);
            this.grpImageInfo.Controls.Add(this.lblColorDepthValue);
            this.grpImageInfo.Controls.Add(this.aspectRatio);
            this.grpImageInfo.Controls.Add(this.lblPixelFormatValue);
            this.grpImageInfo.Controls.Add(this.lblDpiValue);
            this.grpImageInfo.Controls.Add(this.lblPixelCountValue);
            this.grpImageInfo.Controls.Add(this.lblFileSizeValue);
            this.grpImageInfo.Controls.Add(this.lblDimensionsValue);
            this.grpImageInfo.Controls.Add(this.lblFormatValue);
            this.grpImageInfo.Controls.Add(this.lblPathValue);
            this.grpImageInfo.Controls.Add(this.lblFileNameValue);
            this.grpImageInfo.Controls.Add(this.lastModified);
            this.grpImageInfo.Controls.Add(this.colorDepth);
            this.grpImageInfo.Controls.Add(this.pixelFormat);
            this.grpImageInfo.Controls.Add(this.dpi);
            this.grpImageInfo.Controls.Add(this.pixelCount);
            this.grpImageInfo.Controls.Add(this.fileSize);
            this.grpImageInfo.Controls.Add(this.dimensions);
            this.grpImageInfo.Controls.Add(this.format);
            this.grpImageInfo.Controls.Add(this.path);
            this.grpImageInfo.Controls.Add(this.fileName);
            this.grpImageInfo.Location = new System.Drawing.Point(898, 10);
            this.grpImageInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpImageInfo.Name = "grpImageInfo";
            this.grpImageInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpImageInfo.Size = new System.Drawing.Size(225, 176);
            this.grpImageInfo.TabIndex = 4;
            this.grpImageInfo.TabStop = false;
            // 
            // lblAspectRatioValue
            // 
            this.lblAspectRatioValue.AutoSize = true;
            this.lblAspectRatioValue.Location = new System.Drawing.Point(104, 54);
            this.lblAspectRatioValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAspectRatioValue.Name = "lblAspectRatioValue";
            this.lblAspectRatioValue.Size = new System.Drawing.Size(11, 13);
            this.lblAspectRatioValue.TabIndex = 21;
            this.lblAspectRatioValue.Text = "-";
            // 
            // lblLastModifiedValue
            // 
            this.lblLastModifiedValue.AutoSize = true;
            this.lblLastModifiedValue.Location = new System.Drawing.Point(104, 145);
            this.lblLastModifiedValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLastModifiedValue.Name = "lblLastModifiedValue";
            this.lblLastModifiedValue.Size = new System.Drawing.Size(11, 13);
            this.lblLastModifiedValue.TabIndex = 19;
            this.lblLastModifiedValue.Text = "-";
            // 
            // lblColorDepthValue
            // 
            this.lblColorDepthValue.AutoSize = true;
            this.lblColorDepthValue.Location = new System.Drawing.Point(104, 132);
            this.lblColorDepthValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblColorDepthValue.Name = "lblColorDepthValue";
            this.lblColorDepthValue.Size = new System.Drawing.Size(11, 13);
            this.lblColorDepthValue.TabIndex = 18;
            this.lblColorDepthValue.Text = "-";
            // 
            // aspectRatio
            // 
            this.aspectRatio.AutoSize = true;
            this.aspectRatio.Location = new System.Drawing.Point(4, 54);
            this.aspectRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.aspectRatio.Name = "aspectRatio";
            this.aspectRatio.Size = new System.Drawing.Size(75, 13);
            this.aspectRatio.TabIndex = 20;
            this.aspectRatio.Text = "Aspect Ratio :";
            // 
            // lblPixelFormatValue
            // 
            this.lblPixelFormatValue.AutoSize = true;
            this.lblPixelFormatValue.Location = new System.Drawing.Point(104, 119);
            this.lblPixelFormatValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPixelFormatValue.Name = "lblPixelFormatValue";
            this.lblPixelFormatValue.Size = new System.Drawing.Size(11, 13);
            this.lblPixelFormatValue.TabIndex = 17;
            this.lblPixelFormatValue.Text = "-";
            // 
            // lblDpiValue
            // 
            this.lblDpiValue.AutoSize = true;
            this.lblDpiValue.Location = new System.Drawing.Point(104, 106);
            this.lblDpiValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDpiValue.Name = "lblDpiValue";
            this.lblDpiValue.Size = new System.Drawing.Size(11, 13);
            this.lblDpiValue.TabIndex = 16;
            this.lblDpiValue.Text = "-";
            // 
            // lblPixelCountValue
            // 
            this.lblPixelCountValue.AutoSize = true;
            this.lblPixelCountValue.Location = new System.Drawing.Point(104, 93);
            this.lblPixelCountValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPixelCountValue.Name = "lblPixelCountValue";
            this.lblPixelCountValue.Size = new System.Drawing.Size(11, 13);
            this.lblPixelCountValue.TabIndex = 15;
            this.lblPixelCountValue.Text = "-";
            // 
            // lblFileSizeValue
            // 
            this.lblFileSizeValue.AutoSize = true;
            this.lblFileSizeValue.Location = new System.Drawing.Point(104, 79);
            this.lblFileSizeValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileSizeValue.Name = "lblFileSizeValue";
            this.lblFileSizeValue.Size = new System.Drawing.Size(11, 13);
            this.lblFileSizeValue.TabIndex = 14;
            this.lblFileSizeValue.Text = "-";
            // 
            // lblDimensionsValue
            // 
            this.lblDimensionsValue.AutoSize = true;
            this.lblDimensionsValue.Location = new System.Drawing.Point(104, 66);
            this.lblDimensionsValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDimensionsValue.Name = "lblDimensionsValue";
            this.lblDimensionsValue.Size = new System.Drawing.Size(11, 13);
            this.lblDimensionsValue.TabIndex = 13;
            this.lblDimensionsValue.Text = "-";
            // 
            // lblFormatValue
            // 
            this.lblFormatValue.AutoSize = true;
            this.lblFormatValue.Location = new System.Drawing.Point(104, 42);
            this.lblFormatValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormatValue.Name = "lblFormatValue";
            this.lblFormatValue.Size = new System.Drawing.Size(11, 13);
            this.lblFormatValue.TabIndex = 12;
            this.lblFormatValue.Text = "-";
            // 
            // lblPathValue
            // 
            this.lblPathValue.AutoEllipsis = true;
            this.lblPathValue.Location = new System.Drawing.Point(104, 29);
            this.lblPathValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPathValue.Name = "lblPathValue";
            this.lblPathValue.Size = new System.Drawing.Size(117, 13);
            this.lblPathValue.TabIndex = 11;
            this.lblPathValue.Text = "-";
            // 
            // lblFileNameValue
            // 
            this.lblFileNameValue.AutoEllipsis = true;
            this.lblFileNameValue.Location = new System.Drawing.Point(104, 16);
            this.lblFileNameValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFileNameValue.Name = "lblFileNameValue";
            this.lblFileNameValue.Size = new System.Drawing.Size(117, 13);
            this.lblFileNameValue.TabIndex = 10;
            this.lblFileNameValue.Text = "-";
            // 
            // lastModified
            // 
            this.lastModified.AutoSize = true;
            this.lastModified.Location = new System.Drawing.Point(4, 145);
            this.lastModified.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lastModified.Name = "lastModified";
            this.lastModified.Size = new System.Drawing.Size(77, 13);
            this.lastModified.TabIndex = 9;
            this.lastModified.Text = "Last Modified :";
            // 
            // colorDepth
            // 
            this.colorDepth.AutoSize = true;
            this.colorDepth.Location = new System.Drawing.Point(4, 132);
            this.colorDepth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.colorDepth.Name = "colorDepth";
            this.colorDepth.Size = new System.Drawing.Size(71, 13);
            this.colorDepth.TabIndex = 8;
            this.colorDepth.Text = "Color Depth :";
            // 
            // pixelFormat
            // 
            this.pixelFormat.AutoSize = true;
            this.pixelFormat.Location = new System.Drawing.Point(4, 119);
            this.pixelFormat.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pixelFormat.Name = "pixelFormat";
            this.pixelFormat.Size = new System.Drawing.Size(73, 13);
            this.pixelFormat.TabIndex = 7;
            this.pixelFormat.Text = "Pixel Format :";
            // 
            // dpi
            // 
            this.dpi.AutoSize = true;
            this.dpi.Location = new System.Drawing.Point(4, 106);
            this.dpi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dpi.Name = "dpi";
            this.dpi.Size = new System.Drawing.Size(31, 13);
            this.dpi.TabIndex = 6;
            this.dpi.Text = "DPI :";
            // 
            // pixelCount
            // 
            this.pixelCount.AutoSize = true;
            this.pixelCount.Location = new System.Drawing.Point(4, 93);
            this.pixelCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pixelCount.Name = "pixelCount";
            this.pixelCount.Size = new System.Drawing.Size(68, 13);
            this.pixelCount.TabIndex = 5;
            this.pixelCount.Text = "Pixel Count :";
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Location = new System.Drawing.Point(4, 80);
            this.fileSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(52, 13);
            this.fileSize.TabIndex = 4;
            this.fileSize.Text = "File Size :";
            // 
            // dimensions
            // 
            this.dimensions.AutoSize = true;
            this.dimensions.Location = new System.Drawing.Point(4, 67);
            this.dimensions.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dimensions.Name = "dimensions";
            this.dimensions.Size = new System.Drawing.Size(67, 13);
            this.dimensions.TabIndex = 3;
            this.dimensions.Text = "Dimensions :";
            // 
            // format
            // 
            this.format.AutoSize = true;
            this.format.Location = new System.Drawing.Point(4, 41);
            this.format.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(48, 13);
            this.format.TabIndex = 2;
            this.format.Text = "Format :";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(4, 28);
            this.path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(36, 13);
            this.path.TabIndex = 1;
            this.path.Text = "Path :";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fileName.Location = new System.Drawing.Point(4, 15);
            this.fileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(60, 13);
            this.fileName.TabIndex = 0;
            this.fileName.Text = "File Name :";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveImage.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.Location = new System.Drawing.Point(338, 12);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(134, 35);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = false;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // formShowImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.grpImageInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnQuantize);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.picImg);
            this.Name = "formShowImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Image";
            this.Load += new System.EventHandler(this.formShowImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.grpImageInfo.ResumeLayout(false);
            this.grpImageInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnQuantize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox grpImageInfo;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label fileSize;
        private System.Windows.Forms.Label dimensions;
        private System.Windows.Forms.Label format;
        private System.Windows.Forms.Label pixelCount;
        private System.Windows.Forms.Label lastModified;
        private System.Windows.Forms.Label colorDepth;
        private System.Windows.Forms.Label pixelFormat;
        private System.Windows.Forms.Label dpi;
        private System.Windows.Forms.Label lblFileNameValue;
        private System.Windows.Forms.Label lblPathValue;
        private System.Windows.Forms.Label lblLastModifiedValue;
        private System.Windows.Forms.Label lblColorDepthValue;
        private System.Windows.Forms.Label lblPixelFormatValue;
        private System.Windows.Forms.Label lblDpiValue;
        private System.Windows.Forms.Label lblPixelCountValue;
        private System.Windows.Forms.Label lblFileSizeValue;
        private System.Windows.Forms.Label lblDimensionsValue;
        private System.Windows.Forms.Label lblFormatValue;
        private System.Windows.Forms.Label lblAspectRatioValue;
        private System.Windows.Forms.Label aspectRatio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Button btnSaveImage;
    }
}

