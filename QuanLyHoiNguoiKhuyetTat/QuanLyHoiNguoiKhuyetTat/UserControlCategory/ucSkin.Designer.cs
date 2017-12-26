namespace DauThau.UserControlCategory
{
    partial class ucSkin
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
            this.glcSkins = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            ((System.ComponentModel.ISupportInitialize)(this.glcSkins)).BeginInit();
            this.glcSkins.SuspendLayout();
            this.SuspendLayout();
            // 
            // glcSkins
            // 
            this.glcSkins.Controls.Add(this.galleryControlClient1);
            this.glcSkins.DesignGalleryGroupIndex = 0;
            this.glcSkins.DesignGalleryItemIndex = 0;
            this.glcSkins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glcSkins.Location = new System.Drawing.Point(0, 0);
            this.glcSkins.Name = "glcSkins";
            this.glcSkins.Size = new System.Drawing.Size(737, 518);
            this.glcSkins.TabIndex = 1;
            this.glcSkins.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.glcSkins;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(716, 514);
            // 
            // ucSkin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.glcSkins);
            this.Name = "ucSkin";
            this.Size = new System.Drawing.Size(737, 518);
            this.Load += new System.EventHandler(this.ucSkin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.glcSkins)).EndInit();
            this.glcSkins.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.GalleryControl glcSkins;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}
