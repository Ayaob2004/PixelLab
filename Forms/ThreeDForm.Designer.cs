
namespace PixelLab
{
    partial class ThreeDForm
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
            this.panel3D = new System.Windows.Forms.Panel();
            this.Reset_view = new System.Windows.Forms.Button();
            this.change_color_space = new System.Windows.Forms.ComboBox();
            this.trackBarBlack = new System.Windows.Forms.TrackBar();
            this.BlackValue = new System.Windows.Forms.Label();
            this.trackBarLuma = new System.Windows.Forms.TrackBar();
            this.LumaValue = new System.Windows.Forms.Label();
            this.trackBarLabLightness = new System.Windows.Forms.TrackBar();
            this.LabLightnessValue = new System.Windows.Forms.Label();
            this.trackBarLabChroma = new System.Windows.Forms.TrackBar();
            this.LabChromaValue = new System.Windows.Forms.Label();
            this.selectedColorPreview = new System.Windows.Forms.Panel();
            this.colorValuesBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLabLightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLabChroma)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3D
            // 
            this.panel3D.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3D.Location = new System.Drawing.Point(73, 12);
            this.panel3D.Name = "panel3D";
            this.panel3D.Size = new System.Drawing.Size(625, 544);
            this.panel3D.TabIndex = 2;
            // 
            // Reset_view
            // 
            this.Reset_view.Location = new System.Drawing.Point(438, 578);
            this.Reset_view.Name = "Reset_view";
            this.Reset_view.Size = new System.Drawing.Size(144, 48);
            this.Reset_view.TabIndex = 3;
            this.Reset_view.Text = "Reset view";
            this.Reset_view.UseVisualStyleBackColor = true;
            this.Reset_view.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // change_color_space
            // 
            this.change_color_space.FormattingEnabled = true;
            this.change_color_space.Location = new System.Drawing.Point(162, 602);
            this.change_color_space.Name = "change_color_space";
            this.change_color_space.Size = new System.Drawing.Size(158, 24);
            this.change_color_space.TabIndex = 4;
            // 
            // trackBarBlack
            // 
            this.trackBarBlack.Location = new System.Drawing.Point(1213, 57);
            this.trackBarBlack.Maximum = 100;
            this.trackBarBlack.Name = "trackBarBlack";
            this.trackBarBlack.Size = new System.Drawing.Size(157, 56);
            this.trackBarBlack.TabIndex = 5;
            this.trackBarBlack.TickFrequency = 10;
            // 
            // BlackValue
            // 
            this.BlackValue.AutoSize = true;
            this.BlackValue.Location = new System.Drawing.Point(1266, 107);
            this.BlackValue.Name = "BlackValue";
            this.BlackValue.Size = new System.Drawing.Size(53, 17);
            this.BlackValue.TabIndex = 6;
            this.BlackValue.Text = "K = 0%";
            // 
            // trackBarLuma
            // 
            this.trackBarLuma.Location = new System.Drawing.Point(1213, 162);
            this.trackBarLuma.Maximum = 255;
            this.trackBarLuma.Name = "trackBarLuma";
            this.trackBarLuma.Size = new System.Drawing.Size(157, 56);
            this.trackBarLuma.TabIndex = 7;
            this.trackBarLuma.TickFrequency = 32;
            // 
            // LumaValue
            // 
            this.LumaValue.AutoSize = true;
            this.LumaValue.Location = new System.Drawing.Point(1266, 201);
            this.LumaValue.Name = "LumaValue";
            this.LumaValue.Size = new System.Drawing.Size(57, 17);
            this.LumaValue.TabIndex = 8;
            this.LumaValue.Text = "Y = 128";
            // 
            // trackBarLabLightness
            // 
            this.trackBarLabLightness.Location = new System.Drawing.Point(1213, 271);
            this.trackBarLabLightness.Maximum = 100;
            this.trackBarLabLightness.Name = "trackBarLabLightness";
            this.trackBarLabLightness.Size = new System.Drawing.Size(157, 56);
            this.trackBarLabLightness.TabIndex = 9;
            this.trackBarLabLightness.TickFrequency = 10;
            this.trackBarLabLightness.Value = 50;
            // 
            // LabLightnessValue
            // 
            this.LabLightnessValue.AutoSize = true;
            this.LabLightnessValue.Location = new System.Drawing.Point(1269, 310);
            this.LabLightnessValue.Name = "LabLightnessValue";
            this.LabLightnessValue.Size = new System.Drawing.Size(53, 17);
            this.LabLightnessValue.TabIndex = 10;
            this.LabLightnessValue.Text = "L* = 50";
            // 
            // trackBarLabChroma
            // 
            this.trackBarLabChroma.Location = new System.Drawing.Point(1213, 380);
            this.trackBarLabChroma.Maximum = 128;
            this.trackBarLabChroma.Name = "trackBarLabChroma";
            this.trackBarLabChroma.Size = new System.Drawing.Size(157, 56);
            this.trackBarLabChroma.TabIndex = 11;
            this.trackBarLabChroma.TickFrequency = 16;
            this.trackBarLabChroma.Value = 80;
            // 
            // LabChromaValue
            // 
            this.LabChromaValue.AutoSize = true;
            this.LabChromaValue.Location = new System.Drawing.Point(1269, 419);
            this.LabChromaValue.Name = "LabChromaValue";
            this.LabChromaValue.Size = new System.Drawing.Size(54, 17);
            this.LabChromaValue.TabIndex = 12;
            this.LabChromaValue.Text = "C* = 80";
            // 
            // selectedColorPreview
            // 
            this.selectedColorPreview.BackColor = System.Drawing.SystemColors.WindowText;
            this.selectedColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedColorPreview.Location = new System.Drawing.Point(723, 57);
            this.selectedColorPreview.Name = "selectedColorPreview";
            this.selectedColorPreview.Size = new System.Drawing.Size(190, 77);
            this.selectedColorPreview.TabIndex = 13;
            // 
            // colorValuesBox
            // 
            this.colorValuesBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorValuesBox.Location = new System.Drawing.Point(723, 162);
            this.colorValuesBox.Multiline = true;
            this.colorValuesBox.Name = "colorValuesBox";
            this.colorValuesBox.ReadOnly = true;
            this.colorValuesBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.colorValuesBox.Size = new System.Drawing.Size(470, 304);
            this.colorValuesBox.TabIndex = 14;
            this.colorValuesBox.Text = "Click on the color space...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 723);
            this.Controls.Add(this.colorValuesBox);
            this.Controls.Add(this.selectedColorPreview);
            this.Controls.Add(this.LabChromaValue);
            this.Controls.Add(this.trackBarLabChroma);
            this.Controls.Add(this.LabLightnessValue);
            this.Controls.Add(this.trackBarLabLightness);
            this.Controls.Add(this.LumaValue);
            this.Controls.Add(this.trackBarLuma);
            this.Controls.Add(this.BlackValue);
            this.Controls.Add(this.trackBarBlack);
            this.Controls.Add(this.change_color_space);
            this.Controls.Add(this.Reset_view);
            this.Controls.Add(this.panel3D);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLuma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLabLightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLabChroma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel3D;
        private System.Windows.Forms.Button Reset_view;
        private System.Windows.Forms.ComboBox change_color_space;
        private System.Windows.Forms.TrackBar trackBarBlack;
        private System.Windows.Forms.Label BlackValue;
        private System.Windows.Forms.TrackBar trackBarLuma;
        private System.Windows.Forms.Label LumaValue;
        private System.Windows.Forms.TrackBar trackBarLabLightness;
        private System.Windows.Forms.Label LabLightnessValue;
        private System.Windows.Forms.TrackBar trackBarLabChroma;
        private System.Windows.Forms.Label LabChromaValue;
        private System.Windows.Forms.Panel selectedColorPreview;
        private System.Windows.Forms.TextBox colorValuesBox;
    }
}

