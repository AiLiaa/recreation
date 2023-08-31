
namespace recreation
{
    partial class Playing
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Playing));
            this.picture_main = new Sunny.UI.UIImageButton();
            this.Title_label = new Sunny.UI.UILabel();
            this.author = new Sunny.UI.UILabel();
            this.uiTextBox1 = new Sunny.UI.UITextBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.picture_main)).BeginInit();
            this.SuspendLayout();
            // 
            // picture_main
            // 
            this.picture_main.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picture_main.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.picture_main.Image = ((System.Drawing.Image)(resources.GetObject("picture_main.Image")));
            this.picture_main.Location = new System.Drawing.Point(238, 27);
            this.picture_main.Name = "picture_main";
            this.picture_main.Size = new System.Drawing.Size(267, 189);
            this.picture_main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture_main.TabIndex = 1;
            this.picture_main.TabStop = false;
            this.picture_main.Text = null;
            this.picture_main.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.picture_main.Click += new System.EventHandler(this.picture_main_Click);
            // 
            // Title_label
            // 
            this.Title_label.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.Title_label.Location = new System.Drawing.Point(63, 27);
            this.Title_label.Name = "Title_label";
            this.Title_label.Size = new System.Drawing.Size(149, 56);
            this.Title_label.TabIndex = 2;
            this.Title_label.Text = "Title";
            this.Title_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Title_label.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // author
            // 
            this.author.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.author.Location = new System.Drawing.Point(64, 99);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(100, 23);
            this.author.TabIndex = 5;
            this.author.Text = "author";
            this.author.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.author.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBox1
            // 
            this.uiTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox1.FillDisableColor = System.Drawing.Color.White;
            this.uiTextBox1.FillReadOnlyColor = System.Drawing.Color.White;
            this.uiTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox1.Location = new System.Drawing.Point(69, 276);
            this.uiTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox1.Multiline = true;
            this.uiTextBox1.Name = "uiTextBox1";
            this.uiTextBox1.ReadOnly = true;
            this.uiTextBox1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.uiTextBox1.RectDisableColor = System.Drawing.Color.White;
            this.uiTextBox1.RectReadOnlyColor = System.Drawing.Color.MediumPurple;
            this.uiTextBox1.ScrollBarColor = System.Drawing.Color.Thistle;
            this.uiTextBox1.ShowScrollBar = true;
            this.uiTextBox1.ShowText = false;
            this.uiTextBox1.Size = new System.Drawing.Size(436, 279);
            this.uiTextBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBox1.TabIndex = 6;
            this.uiTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox1.WatermarkColor = System.Drawing.Color.White;
            this.uiTextBox1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(64, 237);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 34);
            this.uiLabel1.TabIndex = 7;
            this.uiLabel1.Text = "评论";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabel1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // Playing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.uiTextBox1);
            this.Controls.Add(this.author);
            this.Controls.Add(this.Title_label);
            this.Controls.Add(this.picture_main);
            this.Name = "Playing";
            this.Size = new System.Drawing.Size(1006, 658);
            ((System.ComponentModel.ISupportInitialize)(this.picture_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIImageButton picture_main;
        public Sunny.UI.UILabel Title_label;
        public Sunny.UI.UILabel author;
        private Sunny.UI.UILabel uiLabel1;
        public Sunny.UI.UITextBox uiTextBox1;
    }
}
