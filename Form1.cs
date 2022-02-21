using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADS_PROJECT
{
    public partial class Form1 : Form
    {

        string CurrentFileLocation = "";

        public static Node current;
        bool redoformat = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Select File";            
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files |*.txt";
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                
                CurrentFileLocation = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }

            this.Text = CurrentFileLocation;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node temp = null;
            if (current != null)
            {
                if (current.backword != null)
                {
                    temp = current.backword;
                    redoformat = true;
                    richTextBox1.Text = temp.info;
                    current = temp;
                }
            }

        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node temp = null;
            if (current != null)
            {
                if (current.forward != null)
                {
                    temp = current.forward;
                    redoformat = true;
                    richTextBox1.Text = temp.info;
                    current = temp;
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (redoformat)
                redoformat = false;
            else
                push(richTextBox1.Text);

        }
        public class Node
        {

            public string info;
            public Node  backword,forward;

            public Node(string i)
            {
                info = i;
                forward = backword = null;
            }
        }
     
        public void push(string new_data)
        {
            Node new_node = new Node(new_data);
            new_node.forward = null;
            new_node.backword = current;
            if (current != null)
            {
                current.forward = new_node;
            }
            current = new_node;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
