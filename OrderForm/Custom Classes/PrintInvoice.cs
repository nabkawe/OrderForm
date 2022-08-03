using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public static class PrintInvoice
    {
        private static PrintDocument PrintDocument;
        public static Invoice order = Orders.globalInvoice;

        //private static void AdjustHeight()
        //{
        //    var capacity = 25 * Orders.globalInvoice.InvoiceItems.Count();
        //    InitialHeight += capacity;

        //}
        const string RtlMark = "\u200F";

        public static void Print(string printername)
        {
            order = Orders.globalInvoice;
            PrintDocument = new PrintDocument();
            PrintDocument.PrinterSettings.PrinterName = printername;

            PrintDocument.PrintPage += new PrintPageEventHandler(FormatPage);
            PrintDocument.EndPrint += (sender, e) =>
            {
                clearlist();
            };
            try
            {
                PrintDocument.Print();
            }
            catch (Exception)
            {

                MessageBox.Show("لم يتم العثور على إسم الطابعة");
                MessageBox.Show("قم بإضافة طابعة إفتراضية في الخيارات");

            }



        }
        private static void clearlist()
        {
            Orders.PrintingList.Clear();
        }


        private static void FormatPage(object sender, PrintPageEventArgs e)
        {
            float x = 0;
            float y = 50;
            float width = 270.0F; // max width I found through trial and error
            float height = 0F;

            // الخطوط الافتراضية
            string FntName = "Arial";
            Font fnt = new Font(FntName, 17, FontStyle.Bold);
            Font tfnt = new Font(FntName, 7, FontStyle.Bold);
            Font sfnt = new Font(FntName, 11, FontStyle.Bold);
            Font mfnt = new Font(FntName, 15, FontStyle.Bold);
            Font lfnt = new Font(FntName, 25, FontStyle.Bold);
            Font hfnt = new Font(FntName, 20, FontStyle.Bold);
            Font cfnt = new Font(FntName, 16, FontStyle.Regular);
            // لون الخط
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat rtlFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            y += 10;

            // Order Department
            if (Orders.IsItPrinted)
            {
                e.Graphics.DrawString("إعادة طباعة", hfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                y += e.Graphics.MeasureString("إعادة طباعة", lfnt).Height;
                y += 5;
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                y += 5;

            }
            string text;


             text = order.OrderType;
            e.Graphics.DrawString(text, hfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            text = Environment.NewLine + order.InvoicePrice + " SAR ";
            e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += e.Graphics.MeasureString(text, hfnt).Height;
            y += 10;
            e.Graphics.DrawString(Orders.CurrentDep, hfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += 30;
            text = order.ID.ToString();
            e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.Graphics.MeasureString(text, lfnt).Height;



            // Order Department
            // Order Type + ID 
            //text = order.ID.ToString();
            //e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            y += e.Graphics.MeasureString(text, lfnt).Height;

            //Order Day + Time
            text = Orders.GetDayName((int)order.InvoiceDay);
            e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            text = order.TimeinArabic;
            e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), rtlFormat);
            y += e.Graphics.MeasureString(text, lfnt).Height;

            // Customer Name Check and print
            if (order.CustomerName != "")
            {
                y += 5;
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                y += 5;

                text = order.CustomerName;
                e.Graphics.DrawString(text, hfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                // Customer Number Check and print

                if (order.CustomerNumber != "")
                {
                    text = order.CustomerNumber;
                    e.Graphics.DrawString(text, mfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    //y += e.Graphics.MeasureString(text, fnt).Height;
                }

                y += e.Graphics.MeasureString(text, hfnt).Height;
                y += 5;
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                y += 5;
            }


            // Order Notes Check and print
            if (order.Comment != null)
            {
                if (order.Comment != "")
                {
                    text = order.Comment;
                    e.Graphics.DrawString("ملاحظة الفاتورة", tfnt, drawBrush, new RectangleF(x, y - 3, width, height), drawFormatRight);
                    y += e.Graphics.MeasureString(text, sfnt).Height;
                    e.Graphics.DrawString(text, mfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    y += e.Graphics.MeasureString(text, fnt).Height;
                }
            }

            //  Items Header Area
            y += 5;
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
            y += 5;
            //printing time
            var rectangleH = new RectangleF(x, y, width, height);
            e.Graphics.DrawString(DateTime.Now.ToString("hh:mmtt- dd/MM/yy"), tfnt, drawBrush, rectangleH, drawFormatCenter);
            e.Graphics.DrawString("المادة", sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            e.Graphics.DrawString("الكمية", sfnt, drawBrush, rectangleH, drawFormatLeft);
            y += e.Graphics.MeasureString(text, tfnt).Height;
            //  Items Header Bottom

            //  Items List
            RectangleF rectangleF = new RectangleF(x, y, width, height * 2);
            foreach (var item in Orders.CurrentList)
            {
                // starting Top Line
                y += 5;
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                y += 5;
                // Writing Item Name
                text = RtlMark + item.Name;

                string quan;
                if (item.realquan == 1)
                {
                    quan = item.Quantity.ToString();
                }
                else quan = item.Quantity.ToString() + $" ({item.RealQuantity})";

                // Checking and fixing long names
                if (e.Graphics.MeasureString(text, fnt).Width > width)
                {
                    rectangleF = new RectangleF(x, y, width, height * 2);
                    var rectangleN = new RectangleF(x, y + 35, width, height * 2);
                    e.Graphics.DrawString(text, fnt, drawBrush, rectangleF, rtlFormat);
                    e.Graphics.DrawString(quan, fnt, drawBrush, rectangleN, drawFormatLeft);
                    y += e.Graphics.MeasureString(text, fnt).Height * 2;
                }
                else // regular sized names
                {
                    rectangleF = new RectangleF(x, y, width, height);
                    e.Graphics.DrawString(text, fnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    e.Graphics.DrawString(quan, fnt, drawBrush, rectangleF, drawFormatLeft);
                    y += e.Graphics.MeasureString(text, fnt).Height;
                }
                //checking for item comments.
                if (item.Comment != null)
                {
                    if (item.Comment.Replace(" ", "") != "")

                    {
                        y += 1;
                        e.Graphics.DrawLine(new Pen(Color.Black), new Point(150, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                        y += 1;
                        rectangleF = new RectangleF(x, y, width, height);
                        string comment = item.Comment;
                        e.Graphics.DrawString(comment, cfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                        y += e.Graphics.MeasureString(comment, cfnt).Height;
                    }
                }
            }
            y += 1;
            e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
            y += 5;

            //  Items List End

            //Total Items made
            if (Orders.CurrentDep == "ورقة التحضير")
            {
                text = " عدد المواد المحضرة  " + $"[ {order.RealQuantity} ]مادة";
                e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            }
            y += 70;
            e.Graphics.DrawString("مطعم سحائب طيبة  " + Properties.Settings.Default.BranchName, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
        }
    }
}
