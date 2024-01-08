using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Kosatsu
{
    public partial class Form3 : Form
    {
        Datacontent datacontent = new Datacontent();
        Form1 f1 = new Form1();
        public Form3(Datacontent datacontent, Form1 f1)
        {
            InitializeComponent();
            this.datacontent = datacontent;
            this.f1=f1;
            display();
        }
        public void display()
        {
            label19.Text=datacontent.yoyaku_num;
            label20.Text=datacontent.picture_select;
            label21.Text=datacontent.myouji;
            label22.Text=datacontent.namae;
            label23.Text=datacontent.myouji_kana;
            label24.Text=datacontent.namae_kana;
            label25.Text=datacontent.special_symbol;
            if (datacontent.special_symbol=="はい")
            {
                label25.BackColor = Color.Red;
                label25.ForeColor = Color.White;
            }
            label26.Text=datacontent.mail;
            label27.Text=datacontent.student_number;
            label28.Text=datacontent.gakubu;
            label29.Text=datacontent.gakka;
            label30.Text=datacontent.jitaku_yubin;
            label31.Text=datacontent.jitaku_jusyo;
            label32.Text=datacontent.hogosya_yubin;
            label33.Text=datacontent.hogosya_jusyo;
            label34.Text=datacontent.cell_phone;
            label35.Text=datacontent.jitaku_phone;
            label36.Text=datacontent.remark;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4(datacontent, f1);
            f4.Owner = this;
            f4.StartPosition = FormStartPosition.CenterScreen;
            f4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7(datacontent, f1);
            f7.Owner = this;
            f7.StartPosition = FormStartPosition.CenterScreen;
            f7.ShowDialog();
        }
    }
}
