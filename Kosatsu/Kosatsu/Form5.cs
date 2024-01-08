using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kosatsu
{
    public partial class Form5 : Form
    {
        Datacontent datacontent = new Datacontent();
        Form1 f1 = new Form1();
        public Form5(Datacontent datacontent, Form1 f1)
        {
            InitializeComponent();
            this.datacontent = datacontent;
            this.f1 = f1;

            comboBox1.Items.AddRange(new List<string> { "はい", "いいえ" }.ToArray());
            comboBox2.Items.AddRange(new List<string> { "はい", "いいえ" }.ToArray());
            comboBox3.Items.AddRange(Gakubu.gakubu.ToArray());
            comboBox4.Items.AddRange(Gakubu.gakka[datacontent.gakubu].ToArray());
            display();
        }
        public void display()
        {
            label19.Text = datacontent.yoyaku_num;
            comboBox1.Text = datacontent.picture_select;
            textBox1.Text = datacontent.myouji;
            textBox2.Text = datacontent.namae;
            textBox3.Text = datacontent.myouji_kana;
            textBox4.Text = datacontent.namae_kana;
            comboBox2.Text = datacontent.special_symbol;
            textBox5.Text = datacontent.mail;
            label20.Text = datacontent.student_number;
            comboBox3.Text = datacontent.gakubu;
            comboBox4.Text = datacontent.gakka;
            textBox6.Text = datacontent.jitaku_yubin;
            textBox7.Text = datacontent.jitaku_jusyo;
            textBox8.Text = datacontent.hogosya_yubin;
            textBox9.Text = datacontent.hogosya_jusyo;
            textBox10.Text = datacontent.cell_phone;
            textBox11.Text = datacontent.jitaku_phone;
            textBox12.Text = datacontent.remark;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(Gakubu.gakka[comboBox3.Text].ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            this.Visible = false;
            datacontent.picture_select = comboBox1.Text;
            datacontent.myouji = textBox1.Text;
            datacontent.namae = textBox2.Text;
            datacontent.myouji_kana = textBox3.Text;
            datacontent.namae_kana = textBox4.Text;
            datacontent.special_symbol = comboBox2.Text;
            datacontent.mail = textBox5.Text;
            datacontent.gakubu = comboBox3.Text;
            datacontent.gakka = comboBox4.Text;
            datacontent.jitaku_yubin = textBox6.Text;
            datacontent.jitaku_jusyo = textBox7.Text;
            datacontent.hogosya_yubin = textBox8.Text;
            datacontent.hogosya_jusyo = textBox9.Text;
            datacontent.cell_phone = textBox10.Text;
            datacontent.jitaku_phone = textBox11.Text;
            datacontent.remark = textBox12.Text;
            update_cell();

            Form3 f3 = new Form3(datacontent, f1);
            Owner.Close();
            f3.Show();
            f8.Close();
            this.Close();
        }
        public void update_cell()
        {
            using var fileStream = new FileStream("./key.json", FileMode.Open, FileAccess.Read);
            var googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(SheetsService.Scope.Spreadsheets);
            var sheetsService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = googleCredential });
            var spreadsheetId = Setting1.spreadsheetid;
            var alphabet = Convert.ToChar(Setting1.picture_select + 64);
            var body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.picture_select } } };
            var request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.myouji + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.myouji } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.namae + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.namae } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.myouji_kana + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.myouji_kana } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.namae_kana + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.namae_kana } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.special_symbol + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.special_symbol } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.mail + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.mail } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.gakubu + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.gakubu } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.gakka + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.gakka } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.jitaku_yubin + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.jitaku_yubin } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.jitaku_jusyo + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.jitaku_jusyo } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.hogosya_yubin + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.hogosya_yubin } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.hogosya_jusyo + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.hogosya_jusyo } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.cell_phone + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.cell_phone } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.jitaku_phone + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.jitaku_phone } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting1.remark + 64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'" + datacontent.remark } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting1.sheetname + "!" + alphabet + datacontent.RowNum1);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();

            var datavalues = sheetsService.Spreadsheets.Values.Get(spreadsheetId, Setting1.sheetname + "!" + datacontent.RowNum1 + ":" + datacontent.RowNum1).Execute().Values;
            if (Setting1.picture_select-1<datavalues[0].Count)
            {
                datacontent.picture_select=(string)datavalues[0][Setting1.picture_select-1];
            }
            else
            {
                datacontent.picture_select="";
            }
            if (Setting1.myouji-1<datavalues[0].Count)
            {
                datacontent.myouji=(string)datavalues[0][Setting1.myouji-1];
            }
            else
            {
                datacontent.myouji="";
            }
            if (Setting1.namae-1<datavalues[0].Count)
            {
                datacontent.namae=(string)datavalues[0][Setting1.namae-1];
            }
            else
            {
                datacontent.namae="";
            }
            if (Setting1.myouji_kana-1<datavalues[0].Count)
            {
                datacontent.myouji_kana=(string)datavalues[0][Setting1.myouji_kana-1];
            }
            else
            {
                datacontent.myouji_kana="";
            }
            if (Setting1.namae_kana-1<datavalues[0].Count)
            {
                datacontent.namae_kana=(string)datavalues[0][Setting1.namae_kana-1];
            }
            else
            {
                datacontent.namae_kana="";
            }
            if (Setting1.special_symbol-1<datavalues[0].Count)
            {
                datacontent.special_symbol=(string)datavalues[0][Setting1.special_symbol-1];
            }
            else
            {
                datacontent.special_symbol="";
            }
            if (Setting1.mail-1<datavalues[0].Count)
            {
                datacontent.mail=(string)datavalues[0][Setting1.mail-1];
            }
            else
            {
                datacontent.mail="";
            }
            if (Setting1.gakubu-1<datavalues[0].Count)
            {
                datacontent.gakubu=(string)datavalues[0][Setting1.gakubu-1];
            }
            else
            {
                datacontent.gakubu="";
            }
            if (Setting1.gakka-1<datavalues[0].Count)
            {
                datacontent.gakka=(string)datavalues[0][Setting1.gakka-1];
            }
            else
            {
                datacontent.gakka="";
            }
            if (Setting1.jitaku_yubin-1<datavalues[0].Count)
            {
                datacontent.jitaku_yubin=(string)datavalues[0][Setting1.jitaku_yubin-1];
            }
            else
            {
                datacontent.jitaku_yubin="";
            }
            if (Setting1.jitaku_jusyo-1<datavalues[0].Count)
            {
                datacontent.jitaku_jusyo=(string)datavalues[0][Setting1.jitaku_jusyo-1];
            }
            else
            {
                datacontent.jitaku_jusyo="";
            }
            if (Setting1.hogosya_yubin-1<datavalues[0].Count)
            {
                datacontent.hogosya_yubin=(string)datavalues[0][Setting1.hogosya_yubin-1];
            }
            else
            {
                datacontent.hogosya_yubin="";
            }
            if (Setting1.hogosya_jusyo-1<datavalues[0].Count)
            {
                datacontent.hogosya_jusyo=(string)datavalues[0][Setting1.hogosya_jusyo-1];
            }
            else
            {
                datacontent.hogosya_jusyo="";
            }
            if (Setting1.cell_phone-1<datavalues[0].Count)
            {
                datacontent.cell_phone=(string)datavalues[0][Setting1.cell_phone-1];
            }
            else
            {
                datacontent.cell_phone="";
            }
            if (Setting1.jitaku_phone-1<datavalues[0].Count)
            {
                datacontent.jitaku_phone=(string)datavalues[0][Setting1.jitaku_phone-1];
            }
            else
            {
                datacontent.jitaku_phone="";
            }
            if (Setting1.remark-1<datavalues[0].Count)
            {
                datacontent.remark=(string)datavalues[0][Setting1.remark-1];
            }
            else
            {
                datacontent.remark="";
            }
        }
    }
}
