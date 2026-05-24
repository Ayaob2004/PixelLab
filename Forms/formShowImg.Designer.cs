
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
            this.ColorCount = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.grpImageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // picImg
            // 
            this.picImg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.picImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picImg.BackgroundImage")));
            this.picImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImg.Location = new System.Drawing.Point(16, 12);
            this.picImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(601, 411);
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
            this.btnImg.Location = new System.Drawing.Point(1159, 284);
            this.btnImg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(179, 43);
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
            this.grpImageInfo.Location = new System.Drawing.Point(1197, 12);
            this.grpImageInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpImageInfo.Name = "grpImageInfo";
            this.grpImageInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpImageInfo.Size = new System.Drawing.Size(300, 217);
            this.grpImageInfo.TabIndex = 4;
            this.grpImageInfo.TabStop = false;
            // 
            // lblAspectRatioValue
            // 
            this.lblAspectRatioValue.AutoSize = true;
            this.lblAspectRatioValue.Location = new System.Drawing.Point(139, 66);
            this.lblAspectRatioValue.Name = "lblAspectRatioValue";
            this.lblAspectRatioValue.Size = new System.Drawing.Size(11, 16);
            this.lblAspectRatioValue.TabIndex = 21;
            this.lblAspectRatioValue.Text = "-";
            // 
            // lblLastModifiedValue
            // 
            this.lblLastModifiedValue.AutoSize = true;
            this.lblLastModifiedValue.Location = new System.Drawing.Point(139, 178);
            this.lblLastModifiedValue.Name = "lblLastModifiedValue";
            this.lblLastModifiedValue.Size = new System.Drawing.Size(11, 16);
            this.lblLastModifiedValue.TabIndex = 19;
            this.lblLastModifiedValue.Text = "-";
            // 
            // lblColorDepthValue
            // 
            this.lblColorDepthValue.AutoSize = true;
            this.lblColorDepthValue.Location = new System.Drawing.Point(139, 162);
            this.lblColorDepthValue.Name = "lblColorDepthValue";
            this.lblColorDepthValue.Size = new System.Drawing.Size(11, 16);
            this.lblColorDepthValue.TabIndex = 18;
            this.lblColorDepthValue.Text = "-";
            // 
            // aspectRatio
            // 
            this.aspectRatio.AutoSize = true;
            this.aspectRatio.Location = new System.Drawing.Point(5, 66);
            this.aspectRatio.Name = "aspectRatio";
            this.aspectRatio.Size = new System.Drawing.Size(90, 16);
            this.aspectRatio.TabIndex = 20;
            this.aspectRatio.Text = "Aspect Ratio :";
            // 
            // lblPixelFormatValue
            // 
            this.lblPixelFormatValue.AutoSize = true;
            this.lblPixelFormatValue.Location = new System.Drawing.Point(139, 146);
            this.lblPixelFormatValue.Name = "lblPixelFormatValue";
            this.lblPixelFormatValue.Size = new System.Drawing.Size(11, 16);
            this.lblPixelFormatValue.TabIndex = 17;
            this.lblPixelFormatValue.Text = "-";
            // 
            // lblDpiValue
            // 
            this.lblDpiValue.AutoSize = true;
            this.lblDpiValue.Location = new System.Drawing.Point(139, 130);
            this.lblDpiValue.Name = "lblDpiValue";
            this.lblDpiValue.Size = new System.Drawing.Size(11, 16);
            this.lblDpiValue.TabIndex = 16;
            this.lblDpiValue.Text = "-";
            // 
            // lblPixelCountValue
            // 
            this.lblPixelCountValue.AutoSize = true;
            this.lblPixelCountValue.Location = new System.Drawing.Point(139, 114);
            this.lblPixelCountValue.Name = "lblPixelCountValue";
            this.lblPixelCountValue.Size = new System.Drawing.Size(11, 16);
            this.lblPixelCountValue.TabIndex = 15;
            this.lblPixelCountValue.Text = "-";
            // 
            // lblFileSizeValue
            // 
            this.lblFileSizeValue.AutoSize = true;
            this.lblFileSizeValue.Location = new System.Drawing.Point(139, 97);
            this.lblFileSizeValue.Name = "lblFileSizeValue";
            this.lblFileSizeValue.Size = new System.Drawing.Size(11, 16);
            this.lblFileSizeValue.TabIndex = 14;
            this.lblFileSizeValue.Text = "-";
            // 
            // lblDimensionsValue
            // 
            this.lblDimensionsValue.AutoSize = true;
            this.lblDimensionsValue.Location = new System.Drawing.Point(139, 81);
            this.lblDimensionsValue.Name = "lblDimensionsValue";
            this.lblDimensionsValue.Size = new System.Drawing.Size(11, 16);
            this.lblDimensionsValue.TabIndex = 13;
            this.lblDimensionsValue.Text = "-";
            // 
            // lblFormatValue
            // 
            this.lblFormatValue.AutoSize = true;
            this.lblFormatValue.Location = new System.Drawing.Point(139, 52);
            this.lblFormatValue.Name = "lblFormatValue";
            this.lblFormatValue.Size = new System.Drawing.Size(11, 16);
            this.lblFormatValue.TabIndex = 12;
            this.lblFormatValue.Text = "-";
            // 
            // lblPathValue
            // 
            this.lblPathValue.AutoEllipsis = true;
            this.lblPathValue.Location = new System.Drawing.Point(139, 36);
            this.lblPathValue.Name = "lblPathValue";
            this.lblPathValue.Size = new System.Drawing.Size(156, 16);
            this.lblPathValue.TabIndex = 11;
            this.lblPathValue.Text = "-";
            // 
            // lblFileNameValue
            // 
            this.lblFileNameValue.AutoEllipsis = true;
            this.lblFileNameValue.Location = new System.Drawing.Point(139, 20);
            this.lblFileNameValue.Name = "lblFileNameValue";
            this.lblFileNameValue.Size = new System.Drawing.Size(156, 16);
            this.lblFileNameValue.TabIndex = 10;
            this.lblFileNameValue.Text = "-";
            // 
            // lastModified
            // 
            this.lastModified.AutoSize = true;
            this.lastModified.Location = new System.Drawing.Point(5, 178);
            this.lastModified.Name = "lastModified";
            this.lastModified.Size = new System.Drawing.Size(93, 16);
            this.lastModified.TabIndex = 9;
            this.lastModified.Text = "Last Modified :";
            // 
            // colorDepth
            // 
            this.colorDepth.AutoSize = true;
            this.colorDepth.Location = new System.Drawing.Point(5, 162);
            this.colorDepth.Name = "colorDepth";
            this.colorDepth.Size = new System.Drawing.Size(84, 16);
            this.colorDepth.TabIndex = 8;
            this.colorDepth.Text = "Color Depth :";
            // 
            // pixelFormat
            // 
            this.pixelFormat.AutoSize = true;
            this.pixelFormat.Location = new System.Drawing.Point(5, 146);
            this.pixelFormat.Name = "pixelFormat";
            this.pixelFormat.Size = new System.Drawing.Size(87, 16);
            this.pixelFormat.TabIndex = 7;
            this.pixelFormat.Text = "Pixel Format :";
            // 
            // dpi
            // 
            this.dpi.AutoSize = true;
            this.dpi.Location = new System.Drawing.Point(5, 130);
            this.dpi.Name = "dpi";
            this.dpi.Size = new System.Drawing.Size(35, 16);
            this.dpi.TabIndex = 6;
            this.dpi.Text = "DPI :";
            // 
            // pixelCount
            // 
            this.pixelCount.AutoSize = true;
            this.pixelCount.Location = new System.Drawing.Point(5, 114);
            this.pixelCount.Name = "pixelCount";
            this.pixelCount.Size = new System.Drawing.Size(79, 16);
            this.pixelCount.TabIndex = 5;
            this.pixelCount.Text = "Pixel Count :";
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Location = new System.Drawing.Point(5, 98);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(64, 16);
            this.fileSize.TabIndex = 4;
            this.fileSize.Text = "File Size :";
            // 
            // dimensions
            // 
            this.dimensions.AutoSize = true;
            this.dimensions.Location = new System.Drawing.Point(5, 82);
            this.dimensions.Name = "dimensions";
            this.dimensions.Size = new System.Drawing.Size(84, 16);
            this.dimensions.TabIndex = 3;
            this.dimensions.Text = "Dimensions :";
            // 
            // format
            // 
            this.format.AutoSize = true;
            this.format.Location = new System.Drawing.Point(5, 50);
            this.format.Name = "format";
            this.format.Size = new System.Drawing.Size(55, 16);
            this.format.TabIndex = 2;
            this.format.Text = "Format :";
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(5, 34);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(40, 16);
            this.path.TabIndex = 1;
            this.path.Text = "Path :";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.fileName.Location = new System.Drawing.Point(5, 18);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(75, 16);
            this.fileName.TabIndex = 0;
            this.fileName.Text = "File Name :";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSaveImage.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.Location = new System.Drawing.Point(209, 486);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(179, 43);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = false;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // ColorCount
            // 
            this.ColorCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorCount.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorCount.FormattingEnabled = true;
            this.ColorCount.Items.AddRange(new object[] {
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256"});
            this.ColorCount.Location = new System.Drawing.Point(1197, 389);
            this.ColorCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ColorCount.Name = "ColorCount";
            this.ColorCount.Size = new System.Drawing.Size(95, 33);
            this.ColorCount.TabIndex = 6;
            this.ColorCount.SelectedIndexChanged += new System.EventHandler(this.ColorCount_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1143, 354);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Select Count Colors";
            // 
            // formShowImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorCount);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.grpImageInfo);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.picImg);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formShowImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Image";
            this.Load += new System.EventHandler(this.formShowImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.grpImageInfo.ResumeLayout(false);
            this.grpImageInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
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
        private System.Windows.Forms.ComboBox ColorCount;
        private System.Windows.Forms.Label label1;
    }
}

