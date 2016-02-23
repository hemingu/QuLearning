namespace QuLearning
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonQM = new System.Windows.Forms.Button();
            this.buttonTerms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonQM
            // 
            this.buttonQM.Location = new System.Drawing.Point(12, 12);
            this.buttonQM.Name = "buttonQM";
            this.buttonQM.Size = new System.Drawing.Size(111, 23);
            this.buttonQM.TabIndex = 0;
            this.buttonQM.Text = "量子力学の資料";
            this.buttonQM.UseVisualStyleBackColor = true;
            this.buttonQM.Click += new System.EventHandler(this.buttonQM_Click);
            // 
            // buttonTerms
            // 
            this.buttonTerms.Location = new System.Drawing.Point(12, 41);
            this.buttonTerms.Name = "buttonTerms";
            this.buttonTerms.Size = new System.Drawing.Size(75, 23);
            this.buttonTerms.TabIndex = 1;
            this.buttonTerms.Text = "検索";
            this.buttonTerms.UseVisualStyleBackColor = true;
            this.buttonTerms.Click += new System.EventHandler(this.buttonTerms_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 181);
            this.Controls.Add(this.buttonTerms);
            this.Controls.Add(this.buttonQM);
            this.Name = "FormMain";
            this.Text = "量子力学学習支援";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonQM;
        private System.Windows.Forms.Button buttonTerms;
    }
}

