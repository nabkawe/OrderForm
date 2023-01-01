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
        /// <summary>
        /// Move Item in a listbox, pass -1 to move up, pass 1 to move down,
        /// pass ListBox Name to set the target listbox.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="listBox1"></param>
        public void MoveItem(int direction, ListBox listBox1)
        {
            // Checking selected item
            if (listBox1.SelectedItem == null || listBox1.SelectedIndex < 0)
                return; // No selected item - nothing to do

            // Calculate new index using move direction
            int newIndex = listBox1.SelectedIndex + direction;

            // Checking bounds of the range
            if (newIndex < 0 || newIndex >= listBox1.Items.Count)
                return; // Index out of range - nothing to do

            object selected = listBox1.SelectedItem;

            // Removing removable element
            listBox1.Items.Remove(selected);
            // Insert it in new position
            listBox1.Items.Insert(newIndex, selected);
            // Restore selection
            listBox1.SetSelected(newIndex, true);
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
                if (repeatedBehavior.AreYouSure("سوف يتم حذف الرسالة و إعادة إضافتها بعد أن تقوم بتعديلها.", "هل تريد تعديل الإختصار؟")){

                var edit = (WhatsAppShortCut)noteList.SelectedItem;
                shortTB.Text = edit.Shortcut ;
                noteRB.Text = edit.Details;
                noteList.Items.Remove(noteList.SelectedItem);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveItem(-1, noteList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveItem(1, noteList);
        }

        private void noteList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
