using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class _InvBTN : Button
    {
        Invoice order = new Invoice();
        Font fnt = new Font("Arial", 20, FontStyle.Bold);

        public _InvBTN(Invoice item)
        {
            order = item;
            InitializeComponent();
            if (order.Status == InvStat.SavedToPOS)
            {
                this.BackColor = Color.LightGreen;
            }
            else if (order.Status == InvStat.Deleted)
            {
                this.BackColor = Color.PaleVioletRed;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            float x = 0;
            float y = 5;
            float width = 230.0F; // max width I found through trial and error
            float height = 0F;

            // الخطوط الافتراضية
            string FntName = "Arial";
            Font fnt = new Font(FntName, 15, FontStyle.Bold);
            Font tfnt = new Font(FntName, 7, FontStyle.Bold);
            Font sfnt = new Font(FntName, 11, FontStyle.Bold);
            Font mfnt = new Font(FntName, 15, FontStyle.Bold);
            Font lfnt = new Font(FntName, 15, FontStyle.Bold);
            Font cfnt = new Font(FntName, 15, FontStyle.Regular);
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
            StringFormat rtlFormatCenter = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            rtlFormatCenter.Alignment = StringAlignment.Center;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;



            string text = order.OrderType;
            e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
            text = order.ID.ToString();
            e.Graphics.DrawString(text, fnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
            y += e.Graphics.MeasureString(text, lfnt).Height;

            text = Orders.GetDayName((int)order.InvoiceDay);
            e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            text = order.TimeinArabic;
            e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), rtlFormat);
            y += e.Graphics.MeasureString(Orders.GetDayName((int)order.InvoiceDay), lfnt).Height;
            y += 10;
            
            // Draw string to screen.
            if (order.CustomerName != null)
            {
                //y += 5;
                //e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                //y += 5;
                y += 10;
                text = order.CustomerName;
                e.Graphics.DrawString(text, mfnt, drawBrush, new RectangleF(x-5, y, width, height), drawFormatRight);
                if (order.CustomerNumber != "" && order.CustomerNumber != null)
                {
                    text = order.CustomerNumber;
                    e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, fnt).Height;
                    //y += e.Graphics.MeasureString(text, fnt).Height;
                }
                else
                {
                    text = "0000000000";
                    e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, fnt).Height;

                }
                y += 5;
                e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                y += 5;
            }


            if (order.Comment != null)
            {
                if (order.Comment.Replace(" ", "") != "")
                {

                    text = order.Comment;
                    e.Graphics.DrawString("ملاحظة الفاتورة", tfnt, drawBrush, new RectangleF(x, y - 3, width, height), drawFormatRight);
                    y += e.Graphics.MeasureString(text, sfnt).Height;
                    e.Graphics.DrawString(text, mfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatRight);
                    y += e.Graphics.MeasureString(text, fnt).Height;
                }
            }
            if (order.POSInvoiceNumber != null)
            {
                if (order.POSInvoiceNumber != "")
                {
                    y += e.Graphics.MeasureString(text, fnt).Height;
                    e.Graphics.DrawString("مخزنة برقم: " + order.POSInvoiceNumber, mfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatCenter);
                    y += e.Graphics.MeasureString(text, fnt).Height;
                }
            }
            text = order.InvoicePrice + " " + "ريال";
            e.Graphics.DrawString(text, mfnt, drawBrush, new RectangleF(x, this.Height -10 - e.Graphics.MeasureString(text, fnt).Height, width, height), rtlFormatCenter);

            GraphicsPath p = new GraphicsPath();
            Point[] border = {
                         new Point(0            , 0         ),
                         new Point(Width-1  , 0         ),
                         new Point(Width-1  , Height-1  ),
                         new Point(0            , Height-1  )
                     };
            
            
            p.AddPolygon(border);
            e.Graphics.DrawPath(new Pen(Color.SteelBlue, 3), p);
            

            ////e.Graphics.DrawPath(new Pen(Color.FromArgb(200, Color.White), 1), p);
            //GraphicsPath t = new GraphicsPath();
            //var xxx = 19;
            //Point[] Tear = {
            //             new Point(1              , 180     ),
            //             new Point(xxx              , this.Height- 20      ),
            //             new Point(xxx *2             , this.Height -5      ),
            //             new Point(xxx *3             , this.Height- 20      ),
            //             new Point(xxx *4             , this.Height -5       ),
            //             new Point(xxx *5             , this.Height- 20      ),
            //             new Point(xxx *6             , this.Height -5        ),
            //             new Point(xxx *7             , this.Height- 20      ),
            //             new Point(xxx *8             , this.Height -5        ),
            //             new Point(xxx *9             , this.Height- 20      ),
            //             new Point(xxx *10             , this.Height -5       ),
            //             new Point(xxx *11             , this.Height -20       ),
            //             new Point(xxx *12             , this.Height -5       ),
            //             new Point(xxx *13             , this.Height -20       ),
            //             new Point(xxx *14+1             , 180       ),
            //             new Point(this.Width +10            , this.Height +10      ),
            //             new Point(-1            , this.Height +10      )

            //         };

            //e.Graphics.DrawLines(new Pen(Color.FromArgb(200, Color.Black), 1), Tear);
            //e.Graphics.FillPolygon(new SolidBrush(Color.Black), Tear);
        }
    }
}
