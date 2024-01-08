namespace Kosatsu
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
            textBox1=new TextBox();
            button1=new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font=new Font("Yu Gothic UI", 100F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location=new Point(452, 194);
            textBox1.Name="textBox1";
            textBox1.PlaceholderText="予約番号";
            textBox1.Size=new Size(1000, 185);
            textBox1.TabIndex=0;
            textBox1.TextAlign=HorizontalAlignment.Center;
            textBox1.TextChanged+=textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Font=new Font("Yu Gothic UI", 100F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location=new Point(702, 491);
            button1.Name="button1";
            button1.Size=new Size(500, 200);
            button1.TabIndex=1;
            button1.Text="検索";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1904, 1041);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name="Form1";
            Text="入力画面";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
    }
}