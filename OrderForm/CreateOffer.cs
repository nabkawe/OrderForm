using sharedCode;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace OrderForm.Custom_Classes
{
    internal static class CreateOffer
    {
        private static bool clip;
        private static Invoice order;
        public static Image CreateOfferNow(Invoice inv, bool clipboard)
        {
            order = inv;
            clip = clipboard;
            return FormatPage();
        }
        const string RtlMark = "\u200F";

        private static int CommentSpace()
        {

            
                if (!string.IsNullOrEmpty(order.Comment))
                    return 105;
                else return 0;
            
        }
        private static int NumbersSpace()
        {
            
                if (!string.IsNullOrEmpty(order.CustomerName) || !string.IsNullOrEmpty(order.CustomerNumber))
                    return 75;
                else return 0;

        }
        private static Image FormatPage()
        {
            string FntName = "Arial";
            Font fnt = new Font(FntName, 34, FontStyle.Bold);
            Font Rfnt = new Font(FntName, 25, FontStyle.Regular);
            Font Hugefnt = new Font(FntName, 45, FontStyle.Bold);


            Bitmap offerInit = new Bitmap(800, 1); //initial
            var e = Graphics.FromImage(offerInit);
            int ItemSpace = 70;
            var commentCount = order.InvoiceItems.Where(Com => (!string.IsNullOrEmpty(Com.Comment))).Count();
            int LogoSpace = 550;
            int footer = 440;

            int h = LogoSpace + CommentSpace() + NumbersSpace() + ((order.InvoiceItems.Count + commentCount) * ItemSpace) + footer;
            var realH = h;
            Bitmap offer = new Bitmap(800, realH);
            e = Graphics.FromImage(offer);
            SolidBrush sb = new SolidBrush(Color.White);
            e.FillRectangle(sb, new Rectangle() { Width = 800, Height = realH }); //it was suggested to be done before antialiases inorder to get effects

            e.TextRenderingHint = TextRenderingHint.AntiAlias; //I also tried ClearTypeGridFit
            e.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.CompositingQuality = CompositingQuality.HighQuality;
            e.CompositingMode = CompositingMode.SourceOver;




            float x = 10;
            float y = 20;
            float width = 750.0F; // max width I found through trial and error
            float height = 0F;
            string text;

            // الخطوط الافتراضية
            Font tfnt = new Font(FntName, 17, FontStyle.Bold);
            Font sfnt = new Font(FntName, 21, FontStyle.Bold);
            Font mfnt = new Font(FntName, 25, FontStyle.Bold);
            Font lfnt = new Font(FntName, 30, FontStyle.Bold);
            Font hfnt = new Font(FntName, 40, FontStyle.Bold);
            Font cfnt = new Font(FntName, 26, FontStyle.Regular);
            // لون الخط
            // SolidBrush drawBrush = new SolidBrush(Color.Black);
            SolidBrush drawBrush = new SolidBrush(Color.FromArgb(81, 52, 23));
            SolidBrush drawBrushAccent = new SolidBrush(Color.FromArgb(169, 107, 40));
            SolidBrush drawBrushAccents = new SolidBrush(Color.Green);
            Pen pen = new Pen(Color.FromArgb(81, 52, 23), 1);
            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat rtlFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);



            /// Picture Logic ///
            /// 

            try
            {
                var logo = Bitmap.FromFile(Properties.Settings.Default.Logo).GetThumbnailImage(300, 300, null, IntPtr.Zero) ;
                
                e.DrawImage(logo, (offer.Width - (logo.Width )) / 2, y, logo.Width , logo.Height );
                e.DrawString(DateTime.Now.ToString("hh:mmtt- dd/MM/yy") + Environment.NewLine + "السعر صالح لغاية هذا التاريخ ", tfnt, drawBrush, new RectangleF(x, y, width + 40, height), drawFormatRight);
                e.DrawString("عرض سعر", fnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);

                y += logo.Height;
                e.DrawString(Properties.Settings.Default.BranchName, lfnt, drawBrush, new RectangleF(x, y- e.MeasureString("Hello",fnt).Height, width, height), drawFormatLeft); ;


            }
            catch (Exception)
            {


            }
            text = "رقم الطلب: " + order.ID.ToString();
            e.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.MeasureString(text, lfnt).Height;
            y += 5;


      
            //Order Day + Time
            text = "يوم الطلب: " + Orders.GetDayName((int)order.InvoiceDay);
            e.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            text = "وقت التنفيذ: " + order.TimeinArabic;
            e.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), rtlFormat);
            y += e.MeasureString(text, lfnt).Height;

            // Customer Name Check and print
            if (!string.IsNullOrEmpty(order.CustomerName))
            {
                y += 5;
                e.DrawLine(pen, new Point(10, Convert.ToInt32(y)), new Point(750, Convert.ToInt32(y)));
                y += 5;

                text = order.CustomerName;
                e.DrawString(text, mfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                // Customer Number Check and print

                if (!string.IsNullOrEmpty(order.CustomerNumber))
                {
                    text = order.CustomerNumber;
                    e.DrawString(text, mfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    //y += e.MeasureString(text, fnt).Height;
                }

                y += e.MeasureString(text, fnt).Height;
                y += 5;
                e.DrawLine(pen, new Point(0, Convert.ToInt32(y)), new Point(750, Convert.ToInt32(y)));
                y += 5;
            }


            // Order Notes Check and print
            
                if (!string.IsNullOrEmpty(order.Comment))
                {
                    text = order.Comment;
                    e.DrawString("ملاحظة الفاتورة", tfnt, drawBrush, new RectangleF(x, y - 3, width, height), drawFormatRight);
                    y += e.MeasureString(text, sfnt).Height;
                    e.DrawString(text, mfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    y += e.MeasureString(text, fnt).Height;
                }

            text = ":المبلغ المطلوب";
            e.DrawString(text, Hugefnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            y += 100;
            text = RtlMark + order.InvoicePrice + "   ريال سعودي   ";
            e.DrawString(text, Hugefnt, drawBrushAccent, new RectangleF(x, y, width, height), drawFormatLeft);
            y += 50;

            y += 50;
            e.DrawLine(pen, new Point(10, Convert.ToInt32(y)), new Point(750, Convert.ToInt32(y)));
            y += 10;

            text = "السعر شامل لضريبة القيمة المضافة";
            e.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.MeasureString(text, fnt).Height;

            text = "نقبل الدفع عبر بطاقة مدى بشكل حصري";
            e.DrawString(text, fnt, drawBrushAccents, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.MeasureString(text, lfnt).Height;
            y += 10;


            text = "تفاصيل الطلب:";
            e.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), rtlFormat);
            y += e.MeasureString(text, lfnt).Height;

            //  Items Header Area
            y += 5;
            e.DrawLine(pen, new Point(5, Convert.ToInt32(y)), new Point(750, Convert.ToInt32(y)));
            y += 5;
            //printing time
            var rectangleH = new RectangleF(x, y, width, height);
            e.DrawString("المادة", sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            e.DrawString("  الكمية     |   ســـعـــر   |      إجمالي", sfnt, drawBrush, rectangleH, drawFormatLeft);
            y += e.MeasureString(text, tfnt).Height;
            //  Items Header Bottom

            //  Items List
            RectangleF rectangleF = new RectangleF(x, y, width, height * 2);
            foreach (var item in order.InvoiceItems)
            {
                // starting Top Line
                y += 5;
                e.DrawLine(pen, new Point(10, Convert.ToInt32(y)), new Point(750, Convert.ToInt32(y)));
                y += 5;
                // Writing Item Name
                text = RtlMark + item.Name;

                var Quant = RtlMark + item.Quantity.ToString();
                var Price = RtlMark + item.Price.ToString();
                var total = RtlMark + item.TotalPrice.ToString();


                // Checking and fixing long names
                if (e.MeasureString(text, fnt).Width > 450)
                {
                    rectangleF = new RectangleF(width - 400, y, 400, height * 2);
                    var rectangleN = new RectangleF(x + 10, y + 35, width, height * 2);
                    var rectangleP = new RectangleF(x + 150, y + 35, width, height * 2);
                    var rectangleQ = new RectangleF(x + 330, y + 35, width, height * 2);

                    e.DrawString(text, fnt, drawBrush, rectangleF, drawFormatRight);
                    e.DrawString(total, Rfnt, drawBrush, rectangleN, drawFormatLeft);
                    e.DrawString(Price, Rfnt, drawBrush, rectangleP, drawFormatLeft);
                    e.DrawString(Quant, fnt, drawBrush, rectangleQ, drawFormatLeft);
                    y += e.MeasureString(text, fnt).Height * 2;
                }
                else // regular sized names
                {
                    rectangleF = new RectangleF(x + 10, y, width, height);
                    var rectangleP = new RectangleF(x + 150, y, width, height);
                    var rectangleQ = new RectangleF(x + 330, y, width, height);
                    e.DrawString(text, fnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    e.DrawString(total, Rfnt, drawBrush, rectangleF, drawFormatLeft);
                    e.DrawString(Price, Rfnt, drawBrush, rectangleP, drawFormatLeft);
                    e.DrawString(Quant, fnt, drawBrush, rectangleQ, drawFormatLeft);
                    y += e.MeasureString(text, fnt).Height;
                }
                //checking for item comments.
                if (!string.IsNullOrEmpty(item.Comment))
                {
                    

                    
                        y += 1;
                        e.DrawLine(pen, new Point(500, Convert.ToInt32(y)), new Point(750, Convert.ToInt32(y)));
                        y += 1;
                        rectangleF = new RectangleF(x, y, width, height);
                        string comment = RtlMark + item.Comment;
                        e.DrawString(comment, cfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                        y += e.MeasureString(comment, cfnt).Height;
                    
                }
            }
            y += 10;
            e.DrawLine(pen, new Point(10, Convert.ToInt32(y)), new Point(750, Convert.ToInt32(y)));
            y += 10;

            //  Items List End

            //Total Items made
            text = " عدد المواد الكلي  " + $"[ {order.RealQuantity} ]مادة";
            e.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            y += 25;
           

            Bitmap Trimoffer = new Bitmap(800, Convert.ToInt32(y) + 50);
            Graphics Trimmer = Graphics.FromImage(Trimoffer);
            Trimmer.DrawImage(offer, 0, 0);

            Image a = (Image)Trimoffer;
            var p = new PictureBox();
            p.Image = a;
            if (clip) { System.Windows.Forms.Clipboard.SetImage(p.Image); }

            //Console.Beep(1000, 100);
            return a;
        }

    }
}
