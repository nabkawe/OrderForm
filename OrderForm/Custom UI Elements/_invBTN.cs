using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using sharedCode;
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
            }else if (order.Status == InvStat.Draft)
            {
                this.BackColor = Color.LightYellow;
            }
            
        }


        protected override void OnPaintBackground(PaintEventArgs e)
        {
   
        }


        protected override void OnPaint(PaintEventArgs e)
        {

            base.OnPaint(e);
            float x = 0;
            float y = 5;
            float width = 230.0F; // max width I found through trial and error
            float height = 0F;

            if (order.Status == InvStat.Printed )
            {
                if (order.TimeinArabic == "الآن")
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                           Color.FromArgb(244, 254, 255),
                                                                           Color.White,
                                                                           90F))
                    {
                        e.Graphics.FillRectangle(brush, this.ClientRectangle);
                    }
                }
                else
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                                           Color.FromArgb(255, 242, 242),
                                                                           Color.White,
                                                                           90F))
                    {
                        e.Graphics.FillRectangle(brush, this.ClientRectangle);
                    }
                }
                
            }
            // الخطوط الافتراضية
            string FntName = "Arial";
            Font fnt = new Font(FntName, 15, FontStyle.Bold);
            Font tfnt = new Font(FntName, 7, FontStyle.Bold);
            Font stfnt = new Font(FntName, 7, FontStyle.Bold);
            Font sfnt = new Font(FntName, 11, FontStyle.Bold);
            Font xfnt = new Font(FntName, 14, FontStyle.Bold);
            Font mfnt = new Font(FntName, 15, FontStyle.Bold);
            Font lfnt = new Font(FntName, 15, FontStyle.Bold);
            Font cfnt = new Font(FntName, 15, FontStyle.Regular);
            // لون الخط
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            SolidBrush drawColor = new SolidBrush(Color.DarkGreen);
            SolidBrush drawBlue = new SolidBrush(Color.SteelBlue);

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
            e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x-10, y, width, height), drawFormatRight);
            text = order.ID.ToString();
            e.Graphics.DrawString(text, fnt, drawBrush, new RectangleF(x+2, y, width, height), drawFormatCenter);
            text = order.InvoicePrice + " ";
            e.Graphics.DrawString(text, xfnt, drawColor, new RectangleF(x, y, width, height), drawFormatLeft);
            e.Graphics.DrawString("SAR", stfnt, drawColor, new RectangleF(e.Graphics.MeasureString(text,xfnt).Width, y+7, width, height), drawFormatLeft);
                 y += e.Graphics.MeasureString(text, lfnt).Height;
            if (order.POSInvoiceNumber != null)
            {
                if (order.POSInvoiceNumber != "")
                {
                    e.Graphics.DrawString(order.POSInvoiceNumber, sfnt, drawBlue, new RectangleF(x, y, width, height), drawFormatCenter);
                }
            }
            y += 1;
            text = Orders.GetDayName((int)order.InvoiceDay);
            e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
            text = order.TimeinArabic;
            e.Graphics.DrawString(text, lfnt, drawBrush, new RectangleF(x, y, width, height), rtlFormat);
            y += e.Graphics.MeasureString(Orders.GetDayName((int)order.InvoiceDay), lfnt).Height;
            y += 5;

            // Draw string to screen.
            if (order.CustomerName != null)
            {
                //y += 5;
                //e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                //y += 5;
                text = order.CustomerName;
                e.Graphics.DrawString(text, mfnt, drawColor, new RectangleF(x - 5, y, width, height), drawFormatRight);
                if (order.CustomerNumber != "" && order.CustomerNumber != null)
                {
                    y += 30;
                    text = order.CustomerNumber;
                    e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x, y-4, width, height), drawFormatLeft);
                    //y += e.Graphics.MeasureString(text, fnt).Height;
                }
                else
                {
                    text = " ";
                    e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x, y, width, height), drawFormatLeft);
                    y += e.Graphics.MeasureString(text, fnt).Height;

                }
            }

            if (order.Comment != null)
            {
                if (order.Comment.Replace(" ", "") != "")
                {
                    y += 13;
                    e.Graphics.DrawLine(new Pen(Color.Black), new Point(0, Convert.ToInt32(y)), new Point(270, Convert.ToInt32(y)));
                    y += 7;

                    text = "ملاحظة:  " + order.Comment;
                    e.Graphics.DrawString(text, sfnt, drawBrush, new RectangleF(x-4, y-2, width, height), drawFormatRight);
                    y += e.Graphics.MeasureString(text, fnt).Height;
                }
            }
        
            GraphicsPath p = new GraphicsPath();
            Point[] border = {
                         new Point(0            , 0         ),
                         new Point(Width-1  , 0         ),
                         new Point(Width-1  , Height-1  ),
                         new Point(0            , Height-1  )
                     };


            p.AddPolygon(border);
            e.Graphics.DrawPath(new Pen(Color.SteelBlue, 3), p);


        }
    }
}
