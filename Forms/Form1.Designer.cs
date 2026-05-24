
namespace PixelLab.Forms
{
    partial class Form1
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
            this.image_picture_box = new System.Windows.Forms.PictureBox();
            this.reset_button = new System.Windows.Forms.Button();
            this.select_image_button = new System.Windows.Forms.Button();
            this.color_systems = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.channel1 = new System.Windows.Forms.Label();
            this.channel2 = new System.Windows.Forms.Label();
            this.channel3 = new System.Windows.Forms.Label();
            this.channel4 = new System.Windows.Forms.Label();
            this.track_bar_channel1 = new System.Windows.Forms.TrackBar();
            this.track_bar_channel2 = new System.Windows.Forms.TrackBar();
            this.track_bar_channel4 = new System.Windows.Forms.TrackBar();
            this.track_bar_channel3 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
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
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.image_picture_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel3)).BeginInit();
            this.grpImageInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // image_picture_box
            // 
            this.image_picture_box.Location = new System.Drawing.Point(13, 11);
            this.image_picture_box.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.image_picture_box.Name = "image_picture_box";
            this.image_picture_box.Size = new System.Drawing.Size(452, 402);
            this.image_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image_picture_box.TabIndex = 1;
            this.image_picture_box.TabStop = false;
            this.image_picture_box.Click += new System.EventHandler(this.image_picture_box_Click);
            this.image_picture_box.DragDrop += new System.Windows.Forms.DragEventHandler(this.image_picture_box_DragDrop);
            this.image_picture_box.DragEnter += new System.Windows.Forms.DragEventHandler(this.image_picture_box_DragEnter);
            // 
            // reset_button
            // 
            this.reset_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reset_button.Location = new System.Drawing.Point(13, 554);
            this.reset_button.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(203, 62);
            this.reset_button.TabIndex = 2;
            this.reset_button.Text = "Reset";
            this.reset_button.UseVisualStyleBackColor = false;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // select_image_button
            // 
            this.select_image_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.select_image_button.Location = new System.Drawing.Point(13, 436);
            this.select_image_button.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.select_image_button.Name = "select_image_button";
            this.select_image_button.Size = new System.Drawing.Size(452, 101);
            this.select_image_button.TabIndex = 3;
            this.select_image_button.Text = "Setect an image to start";
            this.select_image_button.UseVisualStyleBackColor = false;
            this.select_image_button.Click += new System.EventHandler(this.select_image_button_Click);
            // 
            // color_systems
            // 
            this.color_systems.FormattingEnabled = true;
            this.color_systems.Items.AddRange(new object[] {
            "RGB",
            "CMY",
            "HSV",
            "YCbCr",
            "YUV",
            "LAB",
            "CMYK"});
            this.color_systems.Location = new System.Drawing.Point(691, 47);
            this.color_systems.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.color_systems.Name = "color_systems";
            this.color_systems.Size = new System.Drawing.Size(235, 24);
            this.color_systems.TabIndex = 4;
            this.color_systems.SelectedIndexChanged += new System.EventHandler(this.color_systems_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(493, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "chooes a color system :";
            // 
            // channel1
            // 
            this.channel1.AutoSize = true;
            this.channel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel1.Location = new System.Drawing.Point(1003, 54);
            this.channel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.channel1.Name = "channel1";
            this.channel1.Size = new System.Drawing.Size(61, 16);
            this.channel1.TabIndex = 6;
            this.channel1.Text = "channel1";
            this.channel1.Click += new System.EventHandler(this.channel1_Click);
            // 
            // channel2
            // 
            this.channel2.AutoSize = true;
            this.channel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel2.Location = new System.Drawing.Point(1003, 107);
            this.channel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.channel2.Name = "channel2";
            this.channel2.Size = new System.Drawing.Size(61, 16);
            this.channel2.TabIndex = 7;
            this.channel2.Text = "channel2";
            // 
            // channel3
            // 
            this.channel3.AutoSize = true;
            this.channel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel3.Location = new System.Drawing.Point(1003, 155);
            this.channel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.channel3.Name = "channel3";
            this.channel3.Size = new System.Drawing.Size(61, 16);
            this.channel3.TabIndex = 8;
            this.channel3.Text = "channel3";
            // 
            // channel4
            // 
            this.channel4.AutoSize = true;
            this.channel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel4.Location = new System.Drawing.Point(1003, 217);
            this.channel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.channel4.Name = "channel4";
            this.channel4.Size = new System.Drawing.Size(61, 16);
            this.channel4.TabIndex = 9;
            this.channel4.Text = "channel4";
            // 
            // track_bar_channel1
            // 
            this.track_bar_channel1.Location = new System.Drawing.Point(1119, 54);
            this.track_bar_channel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.track_bar_channel1.Name = "track_bar_channel1";
            this.track_bar_channel1.Size = new System.Drawing.Size(189, 56);
            this.track_bar_channel1.TabIndex = 10;
            this.track_bar_channel1.Scroll += new System.EventHandler(this.track_bar_channel1_Scroll_1);
            // 
            // track_bar_channel2
            // 
            this.track_bar_channel2.Location = new System.Drawing.Point(1119, 107);
            this.track_bar_channel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.track_bar_channel2.Name = "track_bar_channel2";
            this.track_bar_channel2.Size = new System.Drawing.Size(189, 56);
            this.track_bar_channel2.TabIndex = 11;
            this.track_bar_channel2.Scroll += new System.EventHandler(this.track_bar_channel2_Scroll);
            // 
            // track_bar_channel4
            // 
            this.track_bar_channel4.Location = new System.Drawing.Point(1119, 217);
            this.track_bar_channel4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.track_bar_channel4.Name = "track_bar_channel4";
            this.track_bar_channel4.Size = new System.Drawing.Size(189, 56);
            this.track_bar_channel4.TabIndex = 12;
            this.track_bar_channel4.Scroll += new System.EventHandler(this.track_bar_channel4_Scroll);
            // 
            // track_bar_channel3
            // 
            this.track_bar_channel3.Location = new System.Drawing.Point(1119, 155);
            this.track_bar_channel3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.track_bar_channel3.Name = "track_bar_channel3";
            this.track_bar_channel3.Size = new System.Drawing.Size(189, 56);
            this.track_bar_channel3.TabIndex = 13;
            this.track_bar_channel3.Scroll += new System.EventHandler(this.track_bar_channel3_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1337, 54);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 20);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "disable";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1337, 107);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 20);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "disable";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(1337, 155);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(74, 20);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "disable";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(1337, 213);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(74, 20);
            this.checkBox4.TabIndex = 17;
            this.checkBox4.Text = "disable";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
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
            this.grpImageInfo.Location = new System.Drawing.Point(1111, 495);
            this.grpImageInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpImageInfo.Name = "grpImageInfo";
            this.grpImageInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpImageInfo.Size = new System.Drawing.Size(300, 217);
            this.grpImageInfo.TabIndex = 18;
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
            this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.Location = new System.Drawing.Point(239, 554);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(226, 62);
            this.btnSaveImage.TabIndex = 19;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = false;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1483, 766);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.grpImageInfo);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.track_bar_channel3);
            this.Controls.Add(this.track_bar_channel4);
            this.Controls.Add(this.track_bar_channel2);
            this.Controls.Add(this.track_bar_channel1);
            this.Controls.Add(this.channel4);
            this.Controls.Add(this.channel3);
            this.Controls.Add(this.channel2);
            this.Controls.Add(this.channel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.color_systems);
            this.Controls.Add(this.select_image_button);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.image_picture_box);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image_picture_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel3)).EndInit();
            this.grpImageInfo.ResumeLayout(false);
            this.grpImageInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox image_picture_box;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Button select_image_button;
        private System.Windows.Forms.ComboBox color_systems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label channel1;
        private System.Windows.Forms.Label channel2;
        private System.Windows.Forms.Label channel3;
        private System.Windows.Forms.Label channel4;
        private System.Windows.Forms.TrackBar track_bar_channel1;
        private System.Windows.Forms.TrackBar track_bar_channel2;
        private System.Windows.Forms.TrackBar track_bar_channel4;
        private System.Windows.Forms.TrackBar track_bar_channel3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.GroupBox grpImageInfo;
        private System.Windows.Forms.Label lblAspectRatioValue;
        private System.Windows.Forms.Label lblLastModifiedValue;
        private System.Windows.Forms.Label lblColorDepthValue;
        private System.Windows.Forms.Label aspectRatio;
        private System.Windows.Forms.Label lblPixelFormatValue;
        private System.Windows.Forms.Label lblDpiValue;
        private System.Windows.Forms.Label lblPixelCountValue;
        private System.Windows.Forms.Label lblFileSizeValue;
        private System.Windows.Forms.Label lblDimensionsValue;
        private System.Windows.Forms.Label lblFormatValue;
        private System.Windows.Forms.Label lblPathValue;
        private System.Windows.Forms.Label lblFileNameValue;
        private System.Windows.Forms.Label lastModified;
        private System.Windows.Forms.Label colorDepth;
        private System.Windows.Forms.Label pixelFormat;
        private System.Windows.Forms.Label dpi;
        private System.Windows.Forms.Label pixelCount;
        private System.Windows.Forms.Label fileSize;
        private System.Windows.Forms.Label dimensions;
        private System.Windows.Forms.Label format;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}