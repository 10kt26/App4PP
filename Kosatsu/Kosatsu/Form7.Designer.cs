﻿namespace Kosatsu
{
    partial class Form7
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
            label1=new Label();
            button1=new Button();
            button2=new Button();
            printDocument1=new System.Drawing.Printing.PrintDocument();
            button3=new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font=new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location=new Point(0, 10);
            label1.Name="label1";
            label1.Size=new Size(800, 100);
            label1.TabIndex=0;
            label1.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Font=new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location=new Point(100, 110);
            button1.Name="button1";
            button1.Size=new Size(600, 100);
            button1.TabIndex=1;
            button1.Text="違う";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=button1_Click;
            // 
            // button2
            // 
            button2.Font=new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location=new Point(100, 230);
            button2.Name="button2";
            button2.Size=new Size(600, 100);
            button2.TabIndex=2;
            button2.Text="あっている";
            button2.UseVisualStyleBackColor=true;
            button2.Click+=button2_Click;
            // 
            // printDocument1
            // 
            printDocument1.PrintPage+=printDocument1_PrintPage;
            // 
            // button3
            // 
            button3.Font=new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location=new Point(313, 350);
            button3.Name="button3";
            button3.Size=new Size(200, 60);
            button3.TabIndex=3;
            button3.Text="戻る";
            button3.UseVisualStyleBackColor=true;
            button3.Click+=button3_Click;
            // 
            // Form7
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            ControlBox=false;
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name="Form7";
            Text="学生証番号確認！";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Button button3;
    }
}