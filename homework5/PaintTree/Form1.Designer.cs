namespace PaintTree {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.draw = new System.Windows.Forms.Button();
            this.floor = new System.Windows.Forms.NumericUpDown();
            this.colors = new System.Windows.Forms.ComboBox();
            this.per2 = new System.Windows.Forms.NumericUpDown();
            this.per1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.per2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.per1)).BeginInit();
            this.SuspendLayout();
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(661, 22);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(127, 47);
            this.draw.TabIndex = 0;
            this.draw.Text = "Draw";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.draw_Click);
            // 
            // floor
            // 
            this.floor.Location = new System.Drawing.Point(524, 35);
            this.floor.Name = "floor";
            this.floor.Size = new System.Drawing.Size(120, 25);
            this.floor.TabIndex = 1;
            this.floor.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // colors
            // 
            this.colors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colors.FormattingEnabled = true;
            this.colors.Items.AddRange(new object[] {
            "Blue",
            "Red",
            "Purple",
            "Green",
            "Brown"});
            this.colors.Location = new System.Drawing.Point(373, 35);
            this.colors.Name = "colors";
            this.colors.Size = new System.Drawing.Size(121, 23);
            this.colors.TabIndex = 2;
            this.colors.SelectedIndexChanged += new System.EventHandler(this.colors_SelectedIndexChanged);
            // 
            // per2
            // 
            this.per2.DecimalPlaces = 1;
            this.per2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.per2.Location = new System.Drawing.Point(237, 35);
            this.per2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.per2.Name = "per2";
            this.per2.Size = new System.Drawing.Size(120, 25);
            this.per2.TabIndex = 3;
            this.per2.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // per1
            // 
            this.per1.DecimalPlaces = 1;
            this.per1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.per1.Location = new System.Drawing.Point(97, 36);
            this.per1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.per1.Name = "per1";
            this.per1.Size = new System.Drawing.Size(120, 25);
            this.per1.TabIndex = 4;
            this.per1.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.per1);
            this.Controls.Add(this.per2);
            this.Controls.Add(this.colors);
            this.Controls.Add(this.floor);
            this.Controls.Add(this.draw);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.per2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.per1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.NumericUpDown floor;
        private System.Windows.Forms.ComboBox colors;
        private System.Windows.Forms.NumericUpDown per2;
        private System.Windows.Forms.NumericUpDown per1;
    }
}

