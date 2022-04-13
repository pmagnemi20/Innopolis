namespace Homework2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ValueBox = new System.Windows.Forms.TextBox();
            this.value = new System.Windows.Forms.Label();
            this.ChoseBox = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PriceBox = new System.Windows.Forms.Label();
            this.Convert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ValueBox
            // 
            this.ValueBox.Location = new System.Drawing.Point(53, 117);
            this.ValueBox.Name = "ValueBox";
            this.ValueBox.Size = new System.Drawing.Size(100, 23);
            this.ValueBox.TabIndex = 0;
            this.ValueBox.TextChanged += new System.EventHandler(this.ValueBox_TextChanged);
            // 
            // value
            // 
            this.value.AutoSize = true;
            this.value.Location = new System.Drawing.Point(12, 120);
            this.value.Name = "value";
            this.value.Size = new System.Drawing.Size(35, 15);
            this.value.TabIndex = 1;
            this.value.Text = "Value";
            this.value.Click += new System.EventHandler(this.label1_Click);
            // 
            // ChoseBox
            // 
            this.ChoseBox.FormattingEnabled = true;
            this.ChoseBox.Items.AddRange(new object[] {
            "USD",
            "EUR"});
            this.ChoseBox.Location = new System.Drawing.Point(12, 29);
            this.ChoseBox.Name = "ChoseBox";
            this.ChoseBox.Size = new System.Drawing.Size(121, 23);
            this.ChoseBox.TabIndex = 2;
            this.ChoseBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(53, 160);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // PriceBox
            // 
            this.PriceBox.AutoSize = true;
            this.PriceBox.Location = new System.Drawing.Point(9, 168);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(33, 15);
            this.PriceBox.TabIndex = 4;
            this.PriceBox.Text = "Price";
            // 
            // Convert
            // 
            this.Convert.Location = new System.Drawing.Point(58, 209);
            this.Convert.Name = "Convert";
            this.Convert.Size = new System.Drawing.Size(75, 23);
            this.Convert.TabIndex = 5;
            this.Convert.Text = "Convert";
            this.Convert.UseVisualStyleBackColor = true;
            this.Convert.Click += new System.EventHandler(this.Convert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Convert);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.ChoseBox);
            this.Controls.Add(this.value);
            this.Controls.Add(this.ValueBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox ValueBox;
        private Label value;
        private ComboBox ChoseBox;
        private TextBox textBox2;
        private Label PriceBox;
        private Button Convert;
    }
}