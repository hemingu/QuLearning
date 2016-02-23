namespace QuLearning
{
    partial class ShowPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowPDF));
            this.PDFReader = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.PDFReader)).BeginInit();
            this.SuspendLayout();
            // 
            // PDFReader
            // 
            this.PDFReader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PDFReader.Enabled = true;
            this.PDFReader.Location = new System.Drawing.Point(0, 0);
            this.PDFReader.Name = "PDFReader";
            this.PDFReader.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFReader.OcxState")));
            this.PDFReader.Size = new System.Drawing.Size(784, 561);
            this.PDFReader.TabIndex = 0;
            // 
            // ShowPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.PDFReader);
            this.Name = "ShowPDF";
            this.Text = "ShowPDF";
            ((System.ComponentModel.ISupportInitialize)(this.PDFReader)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF PDFReader;



    }
}