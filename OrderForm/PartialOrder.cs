using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using sharedCode;

namespace OrderForm
{
    public partial class Orders : Form
    {


        #region Materials related logic

        #region loading materials

        public void CreateSectionBtns(FlowLayoutPanel FlowPanel, POSsections obj)
        {
            Button item = new UnfocusableButton()
            {
                Tag = obj,
                Text = obj.Name,
                Width = FlowPanel.Width - 5,
                Height = 40,
                Margin = new Padding(1),
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                TabIndex = 1000,
                BackColor = Color.White,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            };

            item.FlatAppearance.BorderSize = 1;
            item.Click += new EventHandler(Section_Clicked);
            item.MouseDown += new MouseEventHandler(SectionNotes);
            FlowPanel.Controls.Add(item);

        }
        public void CreateItemBtns(FlowLayoutPanel FlowPanel, POSItems obj)
        {
            UnfocusableButton item = new UnfocusableButton()
            {

                Tag = obj,
                Text = obj.Name,
                BackColor = Color.White,
                Height = 60,
                Width = 92,
                Margin = new Padding(2),
                FlatStyle = FlatStyle.Flat,
                TabStop = false,
                TabIndex = 1000,Font= new System.Drawing.Font("Segoe UI",10,System.Drawing.FontStyle.Bold)
            };
            obj.Comment = "";
            item.FlatAppearance.BorderSize = 1;
            item.Click += new EventHandler(Item_Clicked);
            item.MouseWheel += new MouseEventHandler(Item_MouseWheel);
            item.MouseDown += new MouseEventHandler(Item_MouseDown);
            FlowPanel.Controls.Add(item);
        }
        #endregion

        #region Mouse related logic for materials
        private void Item_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var btn = (Button)sender;
                var item = (POSItems)btn.Tag;
                if (Properties.Settings.Default.showMenu) { DM.FindByBarcode(item.Barcode); }

                    
                rightClickMenu.Show(Cursor.Position);
                rightClickMenu.Items[3].Text = btn.Text;
                rightClickMenu.Items[2].Visible = false;
                rightClickMenu.Tag = item;
            }else
            {
                var btn = (Button)sender;
                var item = (POSItems)btn.Tag;
                if (Properties.Settings.Default.showMenu) { DM.FindByBarcode(item.Barcode); }
            }
            //item.Name;
        }
        private void Item_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                var itembtn = (Button)sender;
                var item = (POSItems)itembtn.Tag;
                AddtoGrid(item);
            }
            else
            {
                var itembtn = (Button)sender;
                var item = (POSItems)itembtn.Tag;
                EditItemGrid(item);
            }


        }
        protected void Section_Clicked(object sender, EventArgs e)
        {
            var sectionbtn = (Button)sender;
            var section = (POSsections)sectionbtn.Tag;
            ItemsPanel1.Controls.Clear();
            dbQ.GetItemsForSection(section.Name).ForEach(x => CreateItemBtns(ItemsPanel1, x));

        }
        protected void Item_Clicked(object sender, EventArgs e)
        {
            var itembtn = (Button)sender;
            var item = (POSItems)itembtn.Tag;
            if (Properties.Settings.Default.showMenu) { DM.FindByBarcode(item.Barcode); }
            AddtoGrid(item);

        }
        #endregion


        bool StopEditing = false;
        #region material insertion 
        public void AddtoGrid(POSItems item)
        {

            if (!StopEditing)
            {
                if (InvoiceNumberID.Enabled == false)
                {
                    NewBTN_Click(null, null);
                }



                ItemsAddedToInvoice?.Invoke(this, item.Name);
                bool alreadyExists = POS.Any(x => x.ID == item.ID);
                if (alreadyExists == true)
                {
                    var found = POS.Single(x => x.ID == item.ID);
                    foreach (DataGridViewRow row in dvItems.Rows)
                    {
                        if (row.DataBoundItem.Equals(found)) row.Selected = true;

                    }
                    if (found.Quantity <= 0)
                    {
                        found.Quantity = 1;
                    }
                    else
                    {
                        found.Quantity++;
                        if (found.Quantity <= 0)
                        {
                            found.Quantity = 1;
                        }

                    }
                }
                else
                {
                    item.Quantity = 1;
                    POS.Add(item);
                    foreach (DataGridViewRow row in dvItems.Rows)
                    {
                        if (row.DataBoundItem.Equals(item)) row.Selected = true;

                    }
                }
                ItemsAddedToInvoice?.Invoke(this, item.Name); 
            }
        }
        public void EditItemGrid(POSItems item)
        {

            if (!StopEditing)
            {
                //UpdatedDraft?.Invoke(this, null);

                ItemsAddedToInvoice?.Invoke(this, item.Name);

                //  this.dvItems.AutoGenerateColumns = true;
                bool alreadyExists = POS.Any(x => x.ID == item.ID);
                if (alreadyExists == true)
                {
                    var found = POS.Single(x => x.ID == item.ID);
                    foreach (DataGridViewRow row in dvItems.Rows)
                    {
                        if (row.DataBoundItem.Equals(found)) row.Selected = true;

                    }
                    if (found.Quantity >= 1)
                    {
                        found.Quantity--;
                        if (found.Quantity == 0)
                        {
                            var MsgBox = new SureMsg();
                            if (MsgBox.ShowDialog(this) == DialogResult.OK)
                            {
                                POS.Remove(item);
                            }
                            else
                            {
                                if (found.Quantity == 0) found.Quantity = 1;
                            }

                        }

                    }

                }
                else
                {
                    //
                }
                ItemsAddedToInvoice?.Invoke(this, item.Name);
                //UpdatedDraft?.Invoke(this, null);



            }        }
        #endregion

        #endregion

        public void LoadMaterials()
        {
            try
            {
                List<POSsections> lists = dbQ.PopulateSections();
                SectionsPanel.Controls.Clear();
                lists.ForEach(l => CreateSectionBtns(SectionsPanel, l));
                List<POSItems> list = dbQ.PopulateItems() ;
                ItemsPanel1.Controls.Clear();
                list.ForEach(x => CreateItemBtns(ItemsPanel1, x));
                
            }
            catch (Exception)
            {

            }
        }




    }
}
