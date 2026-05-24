
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
            ((System.ComponentModel.ISupportInitialize)(this.image_picture_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel3)).BeginInit();
            this.SuspendLayout();
            // 
            // image_picture_box
            // 
            this.image_picture_box.Location = new System.Drawing.Point(10, 20);
            this.image_picture_box.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.image_picture_box.Name = "image_picture_box";
            this.image_picture_box.Size = new System.Drawing.Size(339, 327);
            this.image_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image_picture_box.TabIndex = 1;
            this.image_picture_box.TabStop = false;
            this.image_picture_box.DragDrop += new System.Windows.Forms.DragEventHandler(this.image_picture_box_DragDrop);
            this.image_picture_box.DragEnter += new System.Windows.Forms.DragEventHandler(this.image_picture_box_DragEnter);
            // 
            // reset_button
            // 
            this.reset_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.reset_button.Location = new System.Drawing.Point(91, 389);
            this.reset_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(152, 50);
            this.reset_button.TabIndex = 2;
            this.reset_button.Text = "Reset";
            this.reset_button.UseVisualStyleBackColor = false;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // select_image_button
            // 
            this.select_image_button.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.select_image_button.Location = new System.Drawing.Point(310, 186);
            this.select_image_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.select_image_button.Name = "select_image_button";
            this.select_image_button.Size = new System.Drawing.Size(197, 82);
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
            this.color_systems.Location = new System.Drawing.Point(518, 38);
            this.color_systems.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.color_systems.Name = "color_systems";
            this.color_systems.Size = new System.Drawing.Size(177, 21);
            this.color_systems.TabIndex = 4;
            this.color_systems.SelectedIndexChanged += new System.EventHandler(this.color_systems_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(370, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "chooes a color system :";
            // 
            // channel1
            // 
            this.channel1.AutoSize = true;
            this.channel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel1.Location = new System.Drawing.Point(752, 44);
            this.channel1.Name = "channel1";
            this.channel1.Size = new System.Drawing.Size(50, 13);
            this.channel1.TabIndex = 6;
            this.channel1.Text = "channel1";
            this.channel1.Click += new System.EventHandler(this.channel1_Click);
            // 
            // channel2
            // 
            this.channel2.AutoSize = true;
            this.channel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel2.Location = new System.Drawing.Point(752, 87);
            this.channel2.Name = "channel2";
            this.channel2.Size = new System.Drawing.Size(50, 13);
            this.channel2.TabIndex = 7;
            this.channel2.Text = "channel2";
            // 
            // channel3
            // 
            this.channel3.AutoSize = true;
            this.channel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel3.Location = new System.Drawing.Point(752, 126);
            this.channel3.Name = "channel3";
            this.channel3.Size = new System.Drawing.Size(50, 13);
            this.channel3.TabIndex = 8;
            this.channel3.Text = "channel3";
            // 
            // channel4
            // 
            this.channel4.AutoSize = true;
            this.channel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.channel4.Location = new System.Drawing.Point(752, 176);
            this.channel4.Name = "channel4";
            this.channel4.Size = new System.Drawing.Size(50, 13);
            this.channel4.TabIndex = 9;
            this.channel4.Text = "channel4";
            // 
            // track_bar_channel1
            // 
            this.track_bar_channel1.Location = new System.Drawing.Point(839, 44);
            this.track_bar_channel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.track_bar_channel1.Name = "track_bar_channel1";
            this.track_bar_channel1.Size = new System.Drawing.Size(142, 45);
            this.track_bar_channel1.TabIndex = 10;
            this.track_bar_channel1.Scroll += new System.EventHandler(this.track_bar_channel1_Scroll_1);
            // 
            // track_bar_channel2
            // 
            this.track_bar_channel2.Location = new System.Drawing.Point(839, 87);
            this.track_bar_channel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.track_bar_channel2.Name = "track_bar_channel2";
            this.track_bar_channel2.Size = new System.Drawing.Size(142, 45);
            this.track_bar_channel2.TabIndex = 11;
            this.track_bar_channel2.Scroll += new System.EventHandler(this.track_bar_channel2_Scroll);
            // 
            // track_bar_channel4
            // 
            this.track_bar_channel4.Location = new System.Drawing.Point(839, 176);
            this.track_bar_channel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.track_bar_channel4.Name = "track_bar_channel4";
            this.track_bar_channel4.Size = new System.Drawing.Size(142, 45);
            this.track_bar_channel4.TabIndex = 12;
            this.track_bar_channel4.Scroll += new System.EventHandler(this.track_bar_channel4_Scroll);
            // 
            // track_bar_channel3
            // 
            this.track_bar_channel3.Location = new System.Drawing.Point(839, 126);
            this.track_bar_channel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.track_bar_channel3.Name = "track_bar_channel3";
            this.track_bar_channel3.Size = new System.Drawing.Size(142, 45);
            this.track_bar_channel3.TabIndex = 13;
            this.track_bar_channel3.Scroll += new System.EventHandler(this.track_bar_channel3_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1003, 44);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "disable";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1003, 87);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(59, 17);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "disable";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(1003, 126);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(59, 17);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "disable";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(1003, 173);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(59, 17);
            this.checkBox4.TabIndex = 17;
            this.checkBox4.Text = "disable";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1112, 622);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image_picture_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.track_bar_channel3)).EndInit();
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
    }
}