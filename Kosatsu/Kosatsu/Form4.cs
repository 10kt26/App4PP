using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Kosatsu
{
    public partial class Form4 : Form
    {
        Datacontent datacontent = new Datacontent();
        Form1 f1 = new Form1();
        public Form4(Datacontent datacontent, Form1 f1)
        {
            InitializeComponent();
            this.datacontent = datacontent;
            this.f1=f1;
            label1.Text="学生証番号は"+datacontent.student_number+"ですか？";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(datacontent, f1);
            f5.Owner = this.Owner;
            f5.Show();
            Owner.Visible=false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(datacontent, f1);
            f6.Owner = this.Owner;
            f6.Show();
            Owner.Visible=false;
            this.Close();
        }
    }
}
