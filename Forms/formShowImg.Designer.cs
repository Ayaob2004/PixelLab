
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
            this.picImg = new System.Windows.Forms.PictureBox();
            this.btnImg = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnQuantize = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // picImg
            // 
            this.picImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg.Location = new System.Drawing.Point(0, 0);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(1132, 624);
            this.picImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            this.picImg.Click += new System.EventHandler(this.picImg_Click);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formShowImg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1132, 624);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnQuantize);
            this.Controls.Add(this.btnImg);
            this.Controls.Add(this.picImg);
            this.Name = "formShowImg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Image";
            this.Load += new System.EventHandler(this.formShowImg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Button btnImg;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnQuantize;
        private System.Windows.Forms.Button button1;
    }
}

