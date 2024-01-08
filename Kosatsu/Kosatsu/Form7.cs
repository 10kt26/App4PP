using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosatsu
{
    public partial class Form7 : Form
    {
        Datacontent datacontent = new Datacontent();
        Form1 f1 = new Form1();
        public Form7(Datacontent datacontent, Form1 f1)
        {
            InitializeComponent();
            this.datacontent = datacontent;
            this.f1 = f1;
            label1.Text="学生証番号は"+datacontent.student_number+"ですか？";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(datacontent, f1);
            f6.Owner = this.Owner;
            f6.Show();
            Owner.Visible=false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Landscape = true;
            foreach (PaperSize ps in pd.PrinterSettings.PaperSizes)
            {
                if (ps.Kind == PaperKind.A5)
                {
                    pd.DefaultPageSettings.PaperSize = ps;
                    break;
                }
            }
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            PrintDialog pdl = new PrintDialog();
            pdl.Document = pd;
            if (pdl.ShowDialog() == DialogResult.OK)
            {
                Form8 f8 = new Form8();
                f8.Show();
                this.Visible = false;
                pd.Print();
                update_cell();
                Owner.Close();
                f1.Show();
                f8.Close();
                this.Close();
            }else{
                this.Close();
            }
        }
        private void update_cell()
        {
            string timestring = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
            using var fileStream = new FileStream("./key.json", FileMode.Open, FileAccess.Read);
            var googleCredential = GoogleCredential.FromStream(fileStream).CreateScoped(SheetsService.Scope.Spreadsheets);
            var sheetsService = new SheetsService(new BaseClientService.Initializer() { HttpClientInitializer = googleCredential });
            var spreadsheetId = Setting1.spreadsheetid;
            var alphabet = Convert.ToChar(Setting2.picture_number+64);
            var body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'"+datacontent.picture_num } } };
            var request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting2.sheetname+"!"+alphabet+datacontent.RowNum2);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting2.yoyaku_number+64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'"+datacontent.yoyaku_num } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting2.sheetname+"!"+alphabet+datacontent.RowNum2);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting2.student_number+64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'"+datacontent.student_number } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting2.sheetname+"!"+alphabet+datacontent.RowNum2);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting2.myouji+64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'"+datacontent.myouji } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting2.sheetname+"!"+alphabet+datacontent.RowNum2);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting2.namae+64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'"+datacontent.namae } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting2.sheetname+"!"+alphabet+datacontent.RowNum2);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
            alphabet = Convert.ToChar(Setting2.time+64);
            body = new ValueRange() { Values = new List<IList<object>>() { new List<object>() { "'"+timestring } } };
            request = sheetsService.Spreadsheets.Values.Update(body, spreadsheetId, Setting2.sheetname+"!"+alphabet+datacontent.RowNum2);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            request.Execute();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Brush brush = new SolidBrush(System.Drawing.Color.Black);
            Font font = new Font("メイリオ", 20f, FontStyle.Bold);
            Font font_under = new Font("メイリオ", 20f, FontStyle.Bold| FontStyle.Underline);
            Pen p = new Pen(System.Drawing.Color.Black);
            e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Black), new Rectangle(64, 89, (int)e.Graphics.MeasureString(datacontent.picture_num, font, 1000).Width-4, 30));
            e.Graphics.DrawString(datacontent.picture_num, font, new SolidBrush(System.Drawing.Color.White), new PointF(63, 85));
            e.Graphics.DrawString(datacontent.student_number, font, brush, new PointF(230, 85));
            e.Graphics.DrawString(datacontent.gakubu, font, brush, new PointF(470, 85));
            e.Graphics.DrawString(datacontent.yoyaku_num, font, brush, new PointF(670, 85));
            e.Graphics.DrawString(datacontent.gakka, font, brush, new PointF(63, 115));
            e.Graphics.DrawString(datacontent.myouji_kana+" "+datacontent.namae_kana, font, brush, new PointF(63, 145));
            string name = datacontent.myouji+" "+datacontent.namae;
            float fontsize = 100f;
            while (true)
            {
                Font font_big = new Font("メイリオ", fontsize, FontStyle.Bold);
                var size2 = e.Graphics.MeasureString(name, font_big, 1000);
                if (size2.Width>650)
                {
                    fontsize-=1f;
                }
                else
                {
                    e.Graphics.DrawString(name, font_big, brush, new PointF((413-size2.Width/2), (275-size2.Height/2)));
                    break;
                }
            }
            if (datacontent.picture_select=="はい")
            {
                e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Black), new Rectangle(63, 340, 350, 40));
                e.Graphics.DrawString("写真選択:はい", font, new SolidBrush(System.Drawing.Color.White), new PointF(70, 342));
            }
            else
            {
                e.Graphics.DrawString("写真選択:いいえ", font, brush, new PointF(70, 342));
                e.Graphics.DrawRectangle(p, new Rectangle(63, 340, 350, 40));
            }

            if (datacontent.special_symbol=="はい")
            {
                e.Graphics.FillRectangle(new SolidBrush(System.Drawing.Color.Black), new Rectangle(413, 340, 350, 40));
                e.Graphics.DrawString("特殊文字:有", font, Brushes.White, new PointF(420, 342));
            }
            else
            {
                e.Graphics.DrawString("特殊文字:無", font, brush, new PointF(420, 342));
                e.Graphics.DrawRectangle(p, new Rectangle(413, 340, 350, 40));
            }
            if (datacontent.picture_select=="はい"&&datacontent.special_symbol=="はい")
            {
                e.Graphics.DrawLine(Pens.White, 413, 340, 413, 380);
            }

            Font font_small = new Font("メイリオ", 8f, FontStyle.Bold);
            e.Graphics.DrawString("【重要】\n上の表記でそのままアルバムに掲載いたします。\n確認いただけましたら、左にチェックを付けてください。\n印刷の表記が異なる場合は係りの者にお申し付けください。\n特殊文字が有る場合は右の欄に書いてください。", font_small, brush, new PointF(105, 385));
            e.Graphics.DrawString("訂正欄(特殊文字はここに書く)", font_small, brush, new PointF(415, 385));

            e.Graphics.DrawRectangle(p, new Rectangle(63, 180, 700, 160));
            e.Graphics.DrawRectangle(p, new Rectangle(63, 380, 40, 100));
            e.Graphics.DrawRectangle(p, new Rectangle(73, 420, 20, 20));
            e.Graphics.DrawRectangle(p, new Rectangle(103, 380, 310, 100));
            e.Graphics.DrawRectangle(p, new Rectangle(413, 380, 350, 100));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
