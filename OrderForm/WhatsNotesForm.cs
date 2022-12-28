using sharedCode;
using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Forms;
namespace OrderForm
{
    public partial class WhatsNotesForm : Form
    {
        //public NotesForm()
        //{
        //    InitializeComponent();
        //}
        public WhatsNotesForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.AddNoteBTN.PerformClick();
            }
        }



        private void AddNoteBTN_Click_1(object sender, EventArgs e)
        {
            if (noteRB.Text.Replace(" ", "") != "" && shortTB.Text.Replace(" ","") != "")
            {
                WhatsAppShortCut whatsAppShortCut = new WhatsAppShortCut();
                whatsAppShortCut.Shortcut = shortTB.Text;
                whatsAppShortCut.Details = noteRB.Text;
                whatsAppShortCut.guid = Guid.NewGuid();
                this.noteList.Items.Add(whatsAppShortCut);
                this.noteRB.Text = "";
                this.shortTB.Text = "";

            }
            this.shortTB.Select();


        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (noteList.Items.Count > 0 && noteList.SelectedIndex != -1)
            {
                noteList.Items.Remove(noteList.SelectedItem);
                                            }
            this.shortTB.Select();

        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (noteList.Items.Count > 0)
            {
                var list = new List<WhatsAppShortCut>();
                foreach (WhatsAppShortCut item in noteList.Items)
                {
                    list.Add(item);
                }
                dbQ.SaveAllShortcuts(list);
                this.Close();


            }
        }

        private void NotesForm_Load(object sender, EventArgs e)
        {
            var list = dbQ.GetAllShortcuts();
            list.ForEach(x => noteList.Items.Add(x));

        }

        private void noteList_DoubleClick(object sender, EventArgs e)
        {
            if ((noteList.Items.Count > 0) && (noteList.SelectedIndex != -1))
            {
                if (repeatedBehavior.AreYouSure("Yes لتعديل الإختصار", "هل تريد تعديل الإختصار؟")){

                var edit = (WhatsAppShortCut)noteList.SelectedItem;
                shortTB.Text = edit.Shortcut ;
                noteRB.Text = edit.Details;
                noteList.Items.Remove(noteList.SelectedItem);
                }
            }
        }
    }
}
