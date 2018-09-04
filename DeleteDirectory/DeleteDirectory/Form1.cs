using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeleteDirectory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Delete_Full_Directory(String dir)
        {

            try
            {
                string[] files = Directory.GetFiles(dir);
                string[] dirs = Directory.GetDirectories(dir);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir_2 in dirs)
                {
                    Delete_Full_Directory(dir_2);
                }

                Directory.Delete(dir, false);
            }
            catch
            {

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDirectoryPath.Text.Length == 0)
            {
                MessageBox.Show("Please Enter Path to be Deleted!");
                return;
            }

            if (Directory.Exists(txtDirectoryPath.Text))
            {
                Delete_Full_Directory(txtDirectoryPath.Text);
            }
            else
            {
                MessageBox.Show("Directory Does Not Exist!!");
                return;
            }


            //re-confirmation
            if (!File.Exists(txtDirectoryPath.Text))
            {
                MessageBox.Show("Directory Fully Deleted!");
            }

        }
    }
}
