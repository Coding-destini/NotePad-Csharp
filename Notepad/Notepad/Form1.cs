using System.Diagnostics;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // richTextBox1.Clear(); //clear the screen or allow us to create NEW file

                       DialogResult dr = MessageBox.Show("Do you want to save the file", "save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);           

            if (dr.Equals(DialogResult.Yes))//statement that execute when user click on yes button           

            {

                SaveFileDialog SaveFile = new SaveFileDialog();
                SaveFile.Title = "Save";
                SaveFile.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                if (SaveFile.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.LoadFile(SaveFile.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = SaveFile.FileName;
                };//calling user defined function SaveFile function               

                //richTextBox1.Clear();               

                //this.Text = "Untitled-Digital Diary";           

            }           

            else if (dr.Equals(DialogResult.No))//statament that execute when user click on no button of dialog           

            {               

                richTextBox1.Clear();               

                this.Text = "Untitled-Digital Diary";           

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (richTextBox1.Modified == true)//checking either richtext box have entered value or not     

            {
                DialogResult dr = MessageBox.Show("Do you want to save changes to the opened file", "unsaved document", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                {
                    richTextBox1.Modified = false;
                    //  OpenFile(); //calling OpenFile user defined function

                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Title = "Open";
                    openFile.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                    if (openFile.ShowDialog() == DialogResult.OK) // if somebody click on Open and choose
                                                                  // the text document and click on ok then notpad will load the file with filename
                    {
                        richTextBox1.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
                        //RichTextBoxStreamType.PlainText = > it opens only text file, not word or pdf any other 
                        this.Text = openFile.FileName; // => open file with file name 

                    }




                }
            }
            else
            {
                richTextBox1.Modified = false;
                //  OpenFile(); //calling OpenFile user defined function

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Title = "Open";
                openFile.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
                if (openFile.ShowDialog() == DialogResult.OK) // if somebody click on Open and choose
                                                              // the text document and click on ok then notpad will load the file with filename
                {
                    richTextBox1.LoadFile(openFile.FileName, RichTextBoxStreamType.PlainText);
                    //RichTextBoxStreamType.PlainText = > it opens only text file, not word or pdf any other 
                    this.Text = openFile.FileName; // => open file with file name 
                }
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFile = new SaveFileDialog();
            SaveFile.Title = "Save";
            SaveFile.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (SaveFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.LoadFile(SaveFile.FileName, RichTextBoxStreamType.PlainText);
                this.Text = SaveFile.FileName;
            }
        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();
            //means the date and time right now change it to string and store it 
            // on richTextBox . Text

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fnt = new FontDialog();
            if (fnt.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = fnt.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = color.Color;

        }
    }
}