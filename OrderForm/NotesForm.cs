using sharedCode;
using System;
using System.Windows.Forms;
namespace OrderForm
{
    public partial class NotesForm : Form
    {
        //public NotesForm()
        //{
        //    InitializeComponent();
        //}
        public NotesForm(POSsections str)
        {
            InitializeComponent();
            this.saveBTN.Tag = str;
            this.noteTB.Select();
            this.Text += str.Name;
            if (str.NotesList.Count > 0)
            {
                foreach (var item in str.NotesList)
                {
                    this.noteList.Items.Add(item);
                }

            }

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
            if (!string.IsNullOrWhiteSpace( noteTB.Text))
            {
                string note = noteTB.Text;
                this.noteList.Items.Add(note);
                this.noteTB.Text = "";

            }
            this.noteTB.Select();


        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (noteList.Items.Count > 0 && noteList.SelectedIndex != -1)
            {
                noteList.Items.Remove(noteList.SelectedItem);


            }
            this.noteTB.Select();

        }

        private void cancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            if (noteList.Items.Count > 0)
            {
                var sect = saveBTN.Tag as POSsections;
                sect.NotesList.Clear();
                foreach (string item in noteList.Items)
                {
                    sect.NotesList.Add(item);
                }
                this.Close();
                dbQ.UpdateSectionNotes(sect);
            }
        }

        private void NotesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
