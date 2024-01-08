using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosatsu
{
    public partial class Form6 : Form
    {
        Datacontent datacontent = new Datacontent();
        Form1 f1 = new Form1();
        public Form6(Datacontent datacontent, Form1 f1)
        {
            InitializeComponent();
            this.datacontent = datacontent;
            this.f1= f1;
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
            label26.Text=datacontent.mail;
            textBox1.Text=datacontent.student_number;
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

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datacontent.student_number=textBox1.Text;
            Form8 f8 = new Form8();
            f8.Show();
            this.Visible = false;
            update_cell();
            Form2 f2 = new Form2(datacontent.student_number, f1, f8);
            f2.Show();
            this.Close();
        }
        private void update_cell()
        {
            using var fileStream = new FileStream("./key.json", FileMode.Open, FileAccess.Read);
            var googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(SheetsService.Scope.Spreadsheets);
            var sheetsService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = googleCredential });
            var spreadsheetId = Setting1.spreadsheetid;
            var student_alphabet = Convert.ToChar(Setting1.student_number+64);
            var body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'"+datacontent.student_number } } };
            var request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname+"!"+student_alphabet+datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text,out int output))
            {
                button1.Enabled=true;
            }
            else
            {
                button1.Enabled=false;
            }
        }
    }
}
