using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sharedCode
{
    public class kitem
    {
        enum kitemStatus
        {
            Created = 0,
            Opened = 1,
            Prepared = 2,
            Packed = 3,
            Canceled = 4
        }
        public Guid Guid { get; set; }
        public DateTime KItemCreation;
        public DateTime KItemOpened;
        public DateTime KItemPrepared;
        public DateTime KItemPacked;
        public DateTime KItemCanceled;


        kitemStatus kStatus { get; set; }
        public static kitem createNewkitem(POSItems POS)
        {
            // assing all attributes of POS to the newly made kitem
            kitem k = new kitem();
            k.ID = POS.ID;
            k.Name = POS.Name;
            k.Quantity = POS.Quantity;
            k.Barcode = POS.Barcode;
            k.Comment = POS.Comment;
            k.realquan = POS.realquan;
            k.PrinterName = POS.PrinterName;
            k.Available = POS.Available;
            k.SectionName = POS.SectionName;
            k.order = POS.order;
            k.Guid = Guid.NewGuid();
            k.KItemCreation = DateTime.Now.AddTicks(-(DateTime.Now.Ticks % TimeSpan.TicksPerSecond));
            k.kStatus = kitemStatus.Created;
            return k;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Barcode { get; set; }
        public string Comment { get; set; }
        public string PrinterName { get; set; }
        public bool Available { get; set; }
        public string SectionName { get; set; }
        public int order { get; set; }
        public int realquan { get; set; }
    }

    public class kinvoice
    {
        enum kinvoiceStatus
        {
            created = 0,
            schedualed = 1,
            preparing = 2,
            packing = 3,
            Packed = 4,
            handed = 5,
            Canceled = 6,
            Modified = 7
        }
        public Guid Guid { get; set; }
        public List<kitem> kInvoiceItems { get; set; }
        kinvoiceStatus kStatus { get; set; }

        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string OrderType { get; set; }
        public string TimeAMPM { get; set; }
        public InvStat Status { get; set; }
        public string Comment { get; set; }

        public string TimeOfPrinting { get; set; }
        public DateTime TimeOfSaving { get; set; }
        public bool InEditMode { get; set; }



        public static kinvoice createNewkinvoice(Invoice invoice)
        {
            kinvoice k = new kinvoice();
            k.Guid = Guid.NewGuid();
            k.ID = invoice.ID;
            k.Comment = invoice.Comment;
            k.CustomerName = invoice.CustomerName;
            if (invoice.CustomerNumber.Length > 8) { k.CustomerNumber = invoice.CustomerNumber.Substring(invoice.CustomerNumber.Length - 4); }
            k.OrderType = invoice.OrderType;
            k.TimeAMPM = invoice.TimeAMPM;
            k.Status = invoice.Status;
            k.TimeOfPrinting = invoice.TimeOfPrinting;
            k.TimeOfSaving = invoice.TimeOfSaving;
            k.InEditMode = invoice.InEditMode;
            k.kInvoiceItems = GetAllkitems(invoice.InvoiceItems);
            k.kStatus = kinvoiceStatus.created;
            return k;
        }


        static List<kitem> GetAllkitems(List<POSItems> POSItems_)
        {
            List<kitem> kitems_ = new List<kitem>();
            foreach (POSItems item in POSItems_)
            {
                kitems_.Add(kitem.createNewkitem(item));
            }
            return kitems_;
        }



    }

}
