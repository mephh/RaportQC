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

namespace RaportQC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    if (Directory.Exists(textBox1.Text))
                    {
                        string[] folderContents = Directory.GetFiles(textBox1.Text);
                        GenerateReport(textBox1.Text, folderContents);
                        label2.Text = "Udało się. " + DateTime.Now;
                        label2.ForeColor = Color.Green;
                        label2.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("FOLDER NIE ISTNIEJE!");
                    }
                }
                catch
                {
                    MessageBox.Show("Wystąpił błąd!");
                    label2.Text = "Nie udało się. Skontaktuj się z Adrianem :)" + DateTime.Now;
                    label2.ForeColor = Color.Red;
                }
            }
        }

        private void GenerateReport(string path, string[] filenames)
        {
            string[] headerText = { "Raport QC po weryfikacji",
                "Wygenerowany dnia:" + DateTime.Now.ToShortDateString() + " o godz:" + DateTime.Now.ToShortTimeString(),
                "\n", "\n"};
            string fullReportPath = path + "\\RaportQC.txt";

            File.WriteAllLines(fullReportPath, headerText);  //overwrite old file everytime

            using (StreamWriter sw = new StreamWriter(fullReportPath, true))
            {
                for (int i = 0; i < filenames.Length; i++)
                {
                    sw.WriteLine(filenames[i].Substring(filenames[i].LastIndexOf('\\')+1));
                }
            }
        }
    }
}
