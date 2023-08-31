
namespace recreation
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.loginButton = new System.Windows.Forms.Button();
            this.musicButton = new System.Windows.Forms.Button();
            this.novelButton = new System.Windows.Forms.Button();
            this.videaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(76, 101);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(105, 54);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // musicButton
            // 
            this.musicButton.Location = new System.Drawing.Point(267, 101);
            this.musicButton.Name = "musicButton";
            this.musicButton.Size = new System.Drawing.Size(105, 54);
            this.musicButton.TabIndex = 1;
            this.musicButton.Text = "音乐";
            this.musicButton.UseVisualStyleBackColor = true;
            this.musicButton.Click += new System.EventHandler(this.musicButton_Click);
            // 
            // novelButton
            // 
            this.novelButton.Location = new System.Drawing.Point(456, 101);
            this.novelButton.Name = "novelButton";
            this.novelButton.Size = new System.Drawing.Size(105, 54);
            this.novelButton.TabIndex = 2;
            this.novelButton.Text = "小说";
            this.novelButton.UseVisualStyleBackColor = true;
            this.novelButton.Click += new System.EventHandler(this.novelButton_Click);
            // 
            // videaButton
            // 
            this.videaButton.Location = new System.Drawing.Point(627, 101);
            this.videaButton.Name = "videaButton";
            this.videaButton.Size = new System.Drawing.Size(105, 54);
            this.videaButton.TabIndex = 3;
            this.videaButton.Text = "视频";
            this.videaButton.UseVisualStyleBackColor = true;
            this.videaButton.Click += new System.EventHandler(this.videaButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.videaButton);
            this.Controls.Add(this.novelButton);
            this.Controls.Add(this.musicButton);
            this.Controls.Add(this.loginButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button musicButton;
        private System.Windows.Forms.Button novelButton;
        private System.Windows.Forms.Button videaButton;
    }
}

