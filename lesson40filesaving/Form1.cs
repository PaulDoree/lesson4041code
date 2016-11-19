using System;
using System.Drawing;
using System.Windows.Forms;

namespace lesson40filesaving
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)//runs when we save a file
        {
            //code below allows us to save a file to the hard drive
            //file is saved in the location selected in the file save dialog
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SaveFile(saveFileDialog1.FileName);//runs and saves the file text to an actual file
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) //runs when we open a file
        {
            openFileDialog1.FileName = "";//load dialog box with no filename in the text box
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName);//load file from drive into rich text box
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);//shows the message from the exception object
                }

            }
        }

        private void txtOld_DoubleClick(object sender, EventArgs e) //this runs when we find and highlight the old word
        {
            if (txtOld.Text.Length > 0)//make sure there is an entry in the box
            {
                //search for the location of the old text in the rich text box
                int start = richTextBox1.Find(txtOld.Text);

                //select the found text in the rich text box
                richTextBox1.Select(start, txtOld.Text.Length);

                //changes the background color of the selection to yellow
                richTextBox1.SelectionBackColor = Color.Yellow;

            }
        }

        private void txtNew_DoubleClick(object sender, EventArgs e)//runs when we enter the new word
        {
            //!= means "not equal to"
            //ensuring that there is an entry in the second box
            if (txtNew.Text != "")
            {
                //line below replaces the old text with the new text 
                richTextBox1.Text = richTextBox1.Text.Replace(txtOld.Text, txtNew.Text);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e) //runs when choosing a new font
        {
            fontDialog1.ShowDialog();//show a box so a new font can be chosen
            richTextBox1.Font = fontDialog1.Font;//set rich text box font to the one chosen

        }

        private void printPreviewPrintToolStripMenuItem_Click(object sender, EventArgs e)//runs when previewing
        {
            printPreviewDialog1.Document = printDocument1;//choose document to be displayed in the preview panel
            printPreviewDialog1.ShowDialog();//bring up a little window to actually show a preview
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            //code runs when a page is about to be previewed or a page is about to be printed
            //in the video you saw StringFormat.GenericTypographic as the last argument, you can also remove it
            //Note: this code is very basic. It has to be improved in order to print pages of text when the text
            //is very long inside the richtextbox. 
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, e.MarginBounds);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e) //runs when printing
        {
            //first show a dialog
            //compare value returned against the OK value in the DialogResult enumeration
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();//call the print method to actually print the document
        }
    }
}
