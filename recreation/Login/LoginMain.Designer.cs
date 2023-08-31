
namespace recreation.Login
{
    partial class LoginMain
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
            this.loginChooseComboBox = new System.Windows.Forms.ComboBox();
            this.loginChooseLabel = new System.Windows.Forms.Label();
            this.sureButton = new System.Windows.Forms.Button();
            this.netEaseCloud = new Sunny.UI.UIPanel();
            this.necLoginbt = new Sunny.UI.UIButton();
            this.passwdTextBox = new Sunny.UI.UITextBox();
            this.passwdLabel = new Sunny.UI.UILabel();
            this.phoneNumTextBox = new Sunny.UI.UITextBox();
            this.phoneNumLabel = new Sunny.UI.UILabel();
            this.QQMuisc = new Sunny.UI.UIPanel();
            this.QQWebBrowser = new System.Windows.Forms.WebBrowser();
            this.netEaseCloud.SuspendLayout();
            this.QQMuisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginChooseComboBox
            // 
            this.loginChooseComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "网易云",
            "QQ音乐",
            "咪咕音乐"});
            this.loginChooseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.loginChooseComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginChooseComboBox.FormattingEnabled = true;
            this.loginChooseComboBox.Items.AddRange(new object[] {
            "网易云",
            "QQ音乐",
            "咪咕音乐"});
            this.loginChooseComboBox.Location = new System.Drawing.Point(135, 35);
            this.loginChooseComboBox.Name = "loginChooseComboBox";
            this.loginChooseComboBox.Size = new System.Drawing.Size(145, 23);
            this.loginChooseComboBox.TabIndex = 1;
            // 
            // loginChooseLabel
            // 
            this.loginChooseLabel.AutoSize = true;
            this.loginChooseLabel.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginChooseLabel.Location = new System.Drawing.Point(12, 36);
            this.loginChooseLabel.Name = "loginChooseLabel";
            this.loginChooseLabel.Size = new System.Drawing.Size(104, 19);
            this.loginChooseLabel.TabIndex = 4;
            this.loginChooseLabel.Text = "选择登录：";
            // 
            // sureButton
            // 
            this.sureButton.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sureButton.Location = new System.Drawing.Point(300, 31);
            this.sureButton.Name = "sureButton";
            this.sureButton.Size = new System.Drawing.Size(87, 30);
            this.sureButton.TabIndex = 7;
            this.sureButton.Text = "确定";
            this.sureButton.UseVisualStyleBackColor = true;
            this.sureButton.Click += new System.EventHandler(this.sureButton_Click);
            // 
            // netEaseCloud
            // 
            this.netEaseCloud.Controls.Add(this.necLoginbt);
            this.netEaseCloud.Controls.Add(this.passwdTextBox);
            this.netEaseCloud.Controls.Add(this.passwdLabel);
            this.netEaseCloud.Controls.Add(this.phoneNumTextBox);
            this.netEaseCloud.Controls.Add(this.phoneNumLabel);
            this.netEaseCloud.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.netEaseCloud.Location = new System.Drawing.Point(13, 78);
            this.netEaseCloud.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.netEaseCloud.MinimumSize = new System.Drawing.Size(1, 1);
            this.netEaseCloud.Name = "netEaseCloud";
            this.netEaseCloud.Size = new System.Drawing.Size(438, 310);
            this.netEaseCloud.TabIndex = 8;
            this.netEaseCloud.Text = null;
            this.netEaseCloud.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.netEaseCloud.Visible = false;
            this.netEaseCloud.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // necLoginbt
            // 
            this.necLoginbt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.necLoginbt.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.necLoginbt.Location = new System.Drawing.Point(110, 154);
            this.necLoginbt.MinimumSize = new System.Drawing.Size(1, 1);
            this.necLoginbt.Name = "necLoginbt";
            this.necLoginbt.Size = new System.Drawing.Size(100, 35);
            this.necLoginbt.TabIndex = 4;
            this.necLoginbt.Text = "确认登录";
            this.necLoginbt.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.necLoginbt.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.necLoginbt.Click += new System.EventHandler(this.necLoginbt_Click);
            // 
            // passwdTextBox
            // 
            this.passwdTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.passwdTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdTextBox.Location = new System.Drawing.Point(110, 98);
            this.passwdTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.passwdTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.passwdTextBox.Name = "passwdTextBox";
            this.passwdTextBox.PasswordChar = '*';
            this.passwdTextBox.ShowText = false;
            this.passwdTextBox.Size = new System.Drawing.Size(150, 29);
            this.passwdTextBox.TabIndex = 3;
            this.passwdTextBox.Text = "1013lohoz";
            this.passwdTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.passwdTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // passwdLabel
            // 
            this.passwdLabel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.passwdLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.passwdLabel.Location = new System.Drawing.Point(30, 98);
            this.passwdLabel.Name = "passwdLabel";
            this.passwdLabel.Size = new System.Drawing.Size(73, 29);
            this.passwdLabel.TabIndex = 2;
            this.passwdLabel.Text = "密码：";
            this.passwdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.passwdLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // phoneNumTextBox
            // 
            this.phoneNumTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.phoneNumTextBox.DoubleValue = 18374689219D;
            this.phoneNumTextBox.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneNumTextBox.Location = new System.Drawing.Point(110, 52);
            this.phoneNumTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.phoneNumTextBox.MinimumSize = new System.Drawing.Size(1, 16);
            this.phoneNumTextBox.Name = "phoneNumTextBox";
            this.phoneNumTextBox.ShowText = false;
            this.phoneNumTextBox.Size = new System.Drawing.Size(150, 29);
            this.phoneNumTextBox.TabIndex = 1;
            this.phoneNumTextBox.Text = "18374689219";
            this.phoneNumTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.phoneNumTextBox.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // phoneNumLabel
            // 
            this.phoneNumLabel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.phoneNumLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.phoneNumLabel.Location = new System.Drawing.Point(8, 52);
            this.phoneNumLabel.Name = "phoneNumLabel";
            this.phoneNumLabel.Size = new System.Drawing.Size(95, 29);
            this.phoneNumLabel.TabIndex = 0;
            this.phoneNumLabel.Text = "手机号：";
            this.phoneNumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.phoneNumLabel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // QQMuisc
            // 
            this.QQMuisc.Controls.Add(this.QQWebBrowser);
            this.QQMuisc.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QQMuisc.Location = new System.Drawing.Point(12, 78);
            this.QQMuisc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QQMuisc.MinimumSize = new System.Drawing.Size(1, 1);
            this.QQMuisc.Name = "QQMuisc";
            this.QQMuisc.Size = new System.Drawing.Size(439, 310);
            this.QQMuisc.TabIndex = 5;
            this.QQMuisc.Text = null;
            this.QQMuisc.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.QQMuisc.Visible = false;
            this.QQMuisc.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // QQWebBrowser
            // 
            this.QQWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QQWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.QQWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.QQWebBrowser.Name = "QQWebBrowser";
            this.QQWebBrowser.ScrollBarsEnabled = false;
            this.QQWebBrowser.Size = new System.Drawing.Size(439, 310);
            this.QQWebBrowser.TabIndex = 0;
            this.QQWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.QQWebBrowser_DocumentCompleted);
            // 
            // LoginMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 402);
            this.Controls.Add(this.QQMuisc);
            this.Controls.Add(this.netEaseCloud);
            this.Controls.Add(this.sureButton);
            this.Controls.Add(this.loginChooseLabel);
            this.Controls.Add(this.loginChooseComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.netEaseCloud.ResumeLayout(false);
            this.QQMuisc.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox loginChooseComboBox;
        private System.Windows.Forms.Label loginChooseLabel;
        private System.Windows.Forms.Button sureButton;
        private Sunny.UI.UIPanel netEaseCloud;
        private Sunny.UI.UITextBox phoneNumTextBox;
        private Sunny.UI.UILabel phoneNumLabel;
        private Sunny.UI.UILabel passwdLabel;
        private Sunny.UI.UIButton necLoginbt;
        private Sunny.UI.UITextBox passwdTextBox;
        private Sunny.UI.UIPanel QQMuisc;
        private System.Windows.Forms.WebBrowser QQWebBrowser;
    }
}