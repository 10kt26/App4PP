using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using static System.Windows.Forms.DataFormats;

namespace Kosatsu
{
    public partial class Form2 : Form
    {
        public string output = "";
        public string input = "";
        public bool notyet = true;
        public List<Datacontent> datalist = new List<Datacontent>();
        public Form1 f1;
        public Form2(string input, Form1 f1, Form8 f8)
        {
            InitializeComponent();
            button1.Enabled = false;
            listView1.FullRowSelect=true;
            this.input = input;
            this.f1=f1;
            load_sheet();
            f8.Close();
        }

        public void load_sheet()
        {
            string key = input;
            label2.Text=input+"の検索結果";
            using var fileStream = new FileStream("./key.json", FileMode.Open, FileAccess.Read);
            var googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(SheetsService.Scope.Spreadsheets);
            var sheetsService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = googleCredential });
            var spreadsheetId = Setting1.spreadsheetid;
            var yoyaku_alphabet = Convert.ToChar(Setting1.yoyaku_number+64);
            var yoyaku_range = Setting1.sheetname+"!"+yoyaku_alphabet+":"+yoyaku_alphabet;
            var yoyaku_values = sheetsService.Spreadsheets.Values.Get(spreadsheetId, yoyaku_range).Execute().Values;
            int i = 0;
            foreach (var item in yoyaku_values)
            {
                i++;
                if ((string)item[0]==key)
                {
                    var datavalues = sheetsService.Spreadsheets.Values.Get(spreadsheetId, Setting1.sheetname+"!"+i.ToString("D")+":"+i.ToString("D")).Execute().Values;
                    key = (string)datavalues[0][Setting1.student_number-1];
                }
            }
            i=0;
            var student_alphabet2 = Convert.ToChar(Setting2.student_number+64);
            var student_range2 = Setting2.sheetname+"!"+student_alphabet2+":"+student_alphabet2;
            var student_values2 = sheetsService.Spreadsheets.Values.Get(spreadsheetId, student_range2).Execute().Values;
            var picture_num_alphabet2 = Convert.ToChar(Setting2.picture_number+64);
            var picture_num_range2 = Setting2.sheetname+"!"+picture_num_alphabet2+":"+picture_num_alphabet2;
            var picture_num_values2 = sheetsService.Spreadsheets.Values.Get(spreadsheetId, picture_num_range2).Execute().Values;
            bool notyet = true;
            i=0;
            for (i=0; i<student_values2.Count; i++)
            {
                if ((string)student_values2[i][0]==key)
                {
                    notyet = false;
                }
            }
            if (notyet==false)
            {
                label1.Text="撮影済";
            }
            int picture_num = 0;
            if (int.TryParse((string)picture_num_values2[picture_num_values2.Count-1][0], out picture_num))
            {
                picture_num+=1;
            }
            else
            {
                picture_num=Setting2.kiten;
            }
            var student_alphabet1 = Convert.ToChar(Setting1.student_number+64);
            var student_range1 = Setting1.sheetname+"!"+student_alphabet1+":"+student_alphabet1;
            var student_values1 = sheetsService.Spreadsheets.Values.Get(spreadsheetId, student_range1).Execute().Values;

            i=0;
            foreach (var item in student_values1)
            {
                i++;
                if ((string)item[0]==key)
                {
                    var datavalues = sheetsService.Spreadsheets.Values.Get(spreadsheetId, Setting1.sheetname+"!"+i.ToString("D")+":"+i.ToString("D")).Execute().Values;
                    var datacontent = new Datacontent();
                    if (Setting1.yoyaku_number-1<datavalues[0].Count)
                    {
                        datacontent.yoyaku_num=(string)datavalues[0][Setting1.yoyaku_number-1];
                    }
                    else
                    {
                        datacontent.yoyaku_num="";
                    }
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
                    if (Setting1.student_number-1<datavalues[0].Count)
                    {
                        datacontent.student_number=(string)datavalues[0][Setting1.student_number-1];
                    }
                    else
                    {
                        datacontent.student_number="";
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
                    datacontent.RowNum1=i.ToString("D");
                    datacontent.RowNum2=(student_values2.Count+1).ToString("D");
                    datacontent.picture_num=picture_num.ToString();
                    datalist.Add(datacontent);
                }
            }
            i=0;
            for (i=datalist.Count-1; i>-1; i--)
            {
                string[] item = new string[4];
                item[0]=datalist[i].yoyaku_num;
                item[1]=datalist[i].student_number;
                item[2]=datalist[i].myouji;
                item[3]=datalist[i].namae;
                listView1.Items.Add(new ListViewItem(item));
            }
            i=0;
            if (datalist.Count==0)
            {
                label1.Text="検索結果0件";
            }
            else
            {
                listView1.Items[0].Selected = true;
                listView1.Select();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count==0)
            {
                return;
            }
            else if(label1.Text == "撮影済"){
                return;
            }
            else
            {
                int selectedindex = listView1.SelectedItems[0].Index;
                System.Diagnostics.Debug.WriteLine(selectedindex);
                Form3 f3 = new Form3(datalist[datalist.Count-1-selectedindex], f1);
                f3.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count==0)
            {
                button1.Enabled = false;
            }
            else if (label1.Text == "撮影済")
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled=true;
            }
        }
    }
}
