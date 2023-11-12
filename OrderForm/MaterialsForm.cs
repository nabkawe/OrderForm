using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Storage.Provider;

namespace OrderForm
{
    public partial class MaterialsForm : Form
    {
        public MaterialsForm()
        {
            InitializeComponent();
            LoadMaterials();
            UpdateUI();
        }
        private BindingList<POSItems> Mat = new BindingList<POSItems>();

  
        private void LoadMaterials()
        {
            dbQ.LoadMaterialItems().ForEach(x => Mat.Add(x));
            
            MDG.DataSource = Mat;

        }

        private void UpdateUI()
        {
            MDG.Columns["Name"].HeaderText = "اسم المادة";

            MDG.Columns["Quantity"].HeaderText = "العدد";
            // make the quantity column center aligned
            MDG.Columns["Quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            MDG.Columns["Price"].HeaderText = "السعر";
            MDG.Columns["Price"].DefaultCellStyle.Format = "N2";
            MDG.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            MDG.Columns["TotalPrice"].Visible = false;
            MDG.Columns["Comment"].Visible = false;

            // my POSitems has a property called Barcode but it's set as Browsable(false) so it won't show up in the datagridview
            // I use it to store the barcode of the item so I can use it later to search for the item
            // Add a new column to the datagridview and set it's name to Barcode and let it show the bound row property Barcode 
            // so I can use it later to search for the item
            DataGridViewTextBoxColumn Barcode = new DataGridViewTextBoxColumn();
            Barcode.Name = "Barcode";
            Barcode.HeaderText = "االباركود";
            Barcode.Visible = true;
            if (MDG.Columns["Barcode"] == null) MDG.Columns.Add(Barcode);
            DataGridViewTextBoxColumn PrinterName = new DataGridViewTextBoxColumn();
            PrinterName.Name = "PrinterName";
            PrinterName.HeaderText = "اسم الطابعة";
            PrinterName.Visible = true;
            if (MDG.Columns["PrinterName"] == null) MDG.Columns.Add(PrinterName);
            DataGridViewTextBoxColumn SectionColumn = new DataGridViewTextBoxColumn();
            SectionColumn.Name = "Section";
            SectionColumn.HeaderText = "اسم القسم";
            SectionColumn.Visible = true;
            if (MDG.Columns["Section"] == null) MDG.Columns.Add(SectionColumn);



        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadMaterials();
        }

        private void MDG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            var model = this.MDG.Rows[e.RowIndex].DataBoundItem as POSItems;
            if (model != null && e.ColumnIndex == this.MDG.Columns["Barcode"].Index)
            {
                e.Value = model.Barcode;
                
            }
            if (model != null && e.ColumnIndex == this.MDG.Columns["PrinterName"].Index)
            {
                e.Value = model.PrinterName;
            }
            if (model != null && e.ColumnIndex == this.MDG.Columns["Section"].Index)
            {
                e.Value = model.SectionName;
            }
        }

        private void MDG_DoubleClick(object sender, EventArgs e)
        {
            bindingSource1.Clear();  
            bindingSource1.Add(MDG.CurrentRow.DataBoundItem);

        }
    }
}
