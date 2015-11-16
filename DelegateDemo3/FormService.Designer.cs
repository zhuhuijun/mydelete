namespace DelegateDemo3
{
    partial class FormService
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTB = new System.Windows.Forms.Button();
            this.tbTB = new System.Windows.Forms.TextBox();
            this.tbYB = new System.Windows.Forms.TextBox();
            this.btnYB = new System.Windows.Forms.Button();
            this.tbYB2 = new System.Windows.Forms.TextBox();
            this.btnyb2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTB
            // 
            this.btnTB.Location = new System.Drawing.Point(13, 12);
            this.btnTB.Name = "btnTB";
            this.btnTB.Size = new System.Drawing.Size(114, 29);
            this.btnTB.TabIndex = 0;
            this.btnTB.Text = "同步调用";
            this.btnTB.UseVisualStyleBackColor = true;
            this.btnTB.Click += new System.EventHandler(this.btnTB_Click);
            // 
            // tbTB
            // 
            this.tbTB.Location = new System.Drawing.Point(15, 47);
            this.tbTB.Multiline = true;
            this.tbTB.Name = "tbTB";
            this.tbTB.Size = new System.Drawing.Size(539, 73);
            this.tbTB.TabIndex = 1;
            // 
            // tbYB
            // 
            this.tbYB.Location = new System.Drawing.Point(17, 170);
            this.tbYB.Multiline = true;
            this.tbYB.Name = "tbYB";
            this.tbYB.Size = new System.Drawing.Size(278, 204);
            this.tbYB.TabIndex = 3;
            // 
            // btnYB
            // 
            this.btnYB.Location = new System.Drawing.Point(15, 135);
            this.btnYB.Name = "btnYB";
            this.btnYB.Size = new System.Drawing.Size(114, 29);
            this.btnYB.TabIndex = 2;
            this.btnYB.Text = "异步调用";
            this.btnYB.UseVisualStyleBackColor = true;
            this.btnYB.Click += new System.EventHandler(this.btnYB_Click);
            // 
            // tbYB2
            // 
            this.tbYB2.Location = new System.Drawing.Point(301, 170);
            this.tbYB2.Multiline = true;
            this.tbYB2.Name = "tbYB2";
            this.tbYB2.Size = new System.Drawing.Size(253, 204);
            this.tbYB2.TabIndex = 5;
            // 
            // btnyb2
            // 
            this.btnyb2.Location = new System.Drawing.Point(299, 135);
            this.btnyb2.Name = "btnyb2";
            this.btnyb2.Size = new System.Drawing.Size(145, 29);
            this.btnyb2.TabIndex = 4;
            this.btnyb2.Text = "异步调用2";
            this.btnyb2.UseVisualStyleBackColor = true;
            this.btnyb2.Click += new System.EventHandler(this.btnyb2_Click);
            // 
            // FormService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 415);
            this.Controls.Add(this.tbYB2);
            this.Controls.Add(this.btnyb2);
            this.Controls.Add(this.tbYB);
            this.Controls.Add(this.btnYB);
            this.Controls.Add(this.tbTB);
            this.Controls.Add(this.btnTB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "异步调用";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTB;
        private System.Windows.Forms.TextBox tbTB;
        private System.Windows.Forms.TextBox tbYB;
        private System.Windows.Forms.Button btnYB;
        private System.Windows.Forms.TextBox tbYB2;
        private System.Windows.Forms.Button btnyb2;
    }
}

