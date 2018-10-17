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
            this.label1 = new System.Windows.Forms.Label();
            this.thicknessDegree = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.per2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.per1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thicknessDegree)).BeginInit();
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
            this.floor.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.floor.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.floor.Name = "floor";
            this.floor.ReadOnly = true;
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
            this.colors.Location = new System.Drawing.Point(296, 37);
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
            this.per2.Location = new System.Drawing.Point(153, 35);
            this.per2.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.per2.Name = "per2";
            this.per2.ReadOnly = true;
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
            this.per1.Location = new System.Drawing.Point(12, 35);
            this.per1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.per1.Name = "per1";
            this.per1.ReadOnly = true;
            this.per1.Size = new System.Drawing.Size(120, 25);
            this.per1.TabIndex = 4;
            this.per1.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 75);
            this.label1.TabIndex = 5;
            this.label1.Text = "角度随机\r\n\r\n子树位置随机\r\n\r\n左右子树先后顺序随机";
            // 
            // thicknessDegree
            // 
            this.thicknessDegree.DecimalPlaces = 1;
            this.thicknessDegree.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.thicknessDegree.Location = new System.Drawing.Point(432, 36);
            this.thicknessDegree.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.thicknessDegree.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.thicknessDegree.Name = "thicknessDegree";
            this.thicknessDegree.ReadOnly = true;
            this.thicknessDegree.Size = new System.Drawing.Size(76, 25);
            this.thicknessDegree.TabIndex = 6;
            this.thicknessDegree.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "右子树长度";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "左子树长度";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "树干颜色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(432, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "粗细";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(524, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "层数";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.thicknessDegree);
            this.Controls.Add(this.label1);
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
            ((System.ComponentModel.ISupportInitialize)(this.thicknessDegree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.NumericUpDown floor;
        private System.Windows.Forms.ComboBox colors;
        private System.Windows.Forms.NumericUpDown per2;
        private System.Windows.Forms.NumericUpDown per1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown thicknessDegree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

