using sharedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace OrderForm
{
    public partial class Headers : Form
    {
        BindingList<headerObject> headers = new BindingList<headerObject>();
        string sectionName;
        public Headers(string sectionNames)
        {
            InitializeComponent();
            sectionName = sectionNames;


        }

        private void Save_Click(object sender, EventArgs e)
        {
            MenuDB.UpdateSectionHeaders(headers.ToList(), MenuTitle.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BackColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {


                this.BackColor.BackColor = MyDialog.Color;

            }
        }

        private void Fonts_Click(object sender, EventArgs e)
        {
            // pick the font and size
            var MyDialog = new FontDialog();
            MyDialog.ShowColor = true;
            MyDialog.Color = this.Fonts.ForeColor;
            MyDialog.Font = this.Fonts.Font;

            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                this.Fonts.Font = MyDialog.Font;
                this.Fonts.ForeColor = MyDialog.Color;
                this.Fonts.BackColor = this.BackColor.BackColor;
            }
        }


        private void AddHeader_Click(object sender, EventArgs e)
        {
            // only add if there's not a similar title in headers already, if it exists update.

            if (headers.Count > 0)
            {
                if (headers.Any(x => x.HeaderName == titleBox.Text))
                {
                    headers.First(headers => headers.HeaderName == titleBox.Text).FontFamily = Fonts.Font.FontFamily.Name;
                    headers.First(headers => headers.HeaderName == titleBox.Text).FontSize = (int)Fonts.Font.Size;
                    headers.First(headers => headers.HeaderName == titleBox.Text).ForegroundColor = Fonts.ForeColor.A.ToString() + "," + Fonts.ForeColor.R.ToString() + "," + Fonts.ForeColor.G.ToString() + "," + Fonts.ForeColor.B.ToString();
                    headers.First(headers => headers.HeaderName == titleBox.Text).BackgroundColor = Fonts.BackColor.A.ToString() + "," + Fonts.BackColor.R.ToString() + "," + Fonts.BackColor.G.ToString() + "," + Fonts.BackColor.B.ToString();
                    headers.First(headers => headers.HeaderName == titleBox.Text).height = (int)headerHeight.Value;
                    headers.First(headers => headers.HeaderName == titleBox.Text).initialHeight = (int)headerLocation.Value;


                }
                else
                {
                    headers.Add(createNewHeader());
                }

            }
            else
            {
                headers.Add(createNewHeader());


            }

        }

        private headerObject createNewHeader()
        {
            var h = new headerObject();
            h.HeaderName = titleBox.Text;
            h.FontFamily = Fonts.Font.FontFamily.Name;
            h.FontSize = (int)Fonts.Font.Size;
            h.ForegroundColor = Fonts.ForeColor.A.ToString() + "," + Fonts.ForeColor.R.ToString() + "," + Fonts.ForeColor.G.ToString() + "," + Fonts.ForeColor.B.ToString();
            h.BackgroundColor = Fonts.BackColor.A.ToString() + "," + Fonts.BackColor.R.ToString() + "," + Fonts.BackColor.G.ToString() + "," + Fonts.BackColor.B.ToString();
            h.height = (int)headerHeight.Value;
            h.initialHeight = (int)headerLocation.Value;
            return h;
        }



        private void MoveUp_Click(object sender, EventArgs e)
        {
            // rewrite this to target DataGridView1 rows instead of headerlist



            if (dataGridView1.SelectedRows.Count == 1 && dataGridView1.SelectedRows[0].Index > 0)
            {
                // move row up
                int index = dataGridView1.SelectedRows[0].Index;
                DataGridViewRowCollection rows = dataGridView1.Rows;
                DataGridViewRow row = rows[index];
                rows.Remove(row);
                rows.Insert(index - 1, row);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[index - 1].Selected = true;
                dataGridView1.Update();

            }



        }

        private void MoveDown_Click(object sender, EventArgs e)
        {
            // move down in datagridview
            



            if (dataGridView1.SelectedRows.Count == 1 && dataGridView1.SelectedRows[0].Index < dataGridView1.Rows.Count - 1)
            {

                // move row up
                int index = dataGridView1.SelectedRows[0].Index;
                DataGridViewRowCollection rows = dataGridView1.Rows;
                DataGridViewRow row = rows[index];
                rows.Remove(row);
                rows.Insert(index + 1, row);
                dataGridView1.ClearSelection();
                dataGridView1.Rows[index + 1].Selected = true;
                dataGridView1.Update();

            }

        }

        private void Headers_Load(object sender, EventArgs e)
        {

            MenuDB.GetMenuHeaders(sectionName).ForEach(x => headers.Add(x));
            MenuTitle.Text = sectionName;
            this.dataGridView1.DataSource = headers;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            // rewrite this to get data from bound item instead of cells values.
            // 
            if (dataGridView1.SelectedRows.Count == 1)
            {
                // rewrite this to get data from headers bound item instead of cells values.
                var row = dataGridView1.SelectedRows[0].DataBoundItem as headerObject;
                titleBox.Text = row.HeaderName;
                Fonts.Font = new Font(row.FontFamily, (float)row.FontSize);
                Fonts.ForeColor = Color.FromArgb(Convert.ToByte(row.ForegroundColor.Split(',')[0]), Convert.ToByte(row.ForegroundColor.Split(',')[1]), Convert.ToByte(row.ForegroundColor.Split(',')[2]), Convert.ToByte(row.ForegroundColor.Split(',')[3]));
                Fonts.BackColor = Color.FromArgb(Convert.ToByte(row.BackgroundColor.Split(',')[0]), Convert.ToByte(row.BackgroundColor.Split(',')[1]), Convert.ToByte(row.BackgroundColor.Split(',')[2]), Convert.ToByte(row.BackgroundColor.Split(',')[3]));

                headerHeight.Value = Convert.ToInt32(row.height);
                headerLocation.Value = Convert.ToInt32(row.initialHeight);




            }

        }
    }
}
