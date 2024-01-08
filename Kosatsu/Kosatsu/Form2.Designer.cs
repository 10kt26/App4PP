namespace Kosatsu
{
    partial class Form2
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
            button1=new Button();
            button2=new Button();
            listView1=new ListView();
            columnHeader1=new ColumnHeader();
            columnHeader2=new ColumnHeader();
            columnHeader3=new ColumnHeader();
            columnHeader4=new ColumnHeader();
            label1=new Label();
            label2=new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font=new Font("Yu Gothic UI", 50F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location=new Point(1320, 230);
            button1.Name="button1";
            button1.Size=new Size(500, 200);
            button1.TabIndex=0;
            button1.Text="次へ";
            button1.UseVisualStyleBackColor=true;
            button1.Click+=button1_Click;
            // 
            // button2
            // 
            button2.Font=new Font("Yu Gothic UI", 50F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location=new Point(1320, 498);
            button2.Name="button2";
            button2.Size=new Size(500, 200);
            button2.TabIndex=1;
            button2.Text="戻る";
            button2.UseVisualStyleBackColor=true;
            button2.Click+=button2_Click;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            listView1.Font=new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            listView1.GridLines=true;
            listView1.Location=new Point(30, 100);
            listView1.MultiSelect=false;
            listView1.Name="listView1";
            listView1.Size=new Size(1205, 850);
            listView1.TabIndex=2;
            listView1.UseCompatibleStateImageBehavior=false;
            listView1.View=View.Details;
            listView1.SelectedIndexChanged+=listView1_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text="予約番号";
            columnHeader1.Width=300;
            // 
            // columnHeader2
            // 
            columnHeader2.Text="学生証番号";
            columnHeader2.Width=300;
            // 
            // columnHeader3
            // 
            columnHeader3.Text="姓";
            columnHeader3.Width=300;
            // 
            // columnHeader4
            // 
            columnHeader4.Text="名";
            columnHeader4.Width=300;
            // 
            // label1
            // 
            label1.Font=new Font("Yu Gothic UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor=SystemColors.ControlText;
            label1.Location=new Point(1282, 113);
            label1.Name="label1";
            label1.Size=new Size(568, 50);
            label1.TabIndex=0;
            label1.Text="できるだけ上を選択して次へを押す";
            label1.TextAlign=ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font=new Font("Yu Gothic UI", 50F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor=SystemColors.ControlText;
            label2.Location=new Point(30, 5);
            label2.Name="label2";
            label2.Size=new Size(1205, 90);
            label2.TabIndex=3;
            label2.Text="検索結果";
            label2.TextAlign=ContentAlignment.MiddleLeft;
            // 
            // Form2
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(1904, 1041);
            ControlBox=false;
            Controls.Add(label2);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name="Form2";
            Text="データ選択画面";
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label1;
        private Label label2;
    }
}