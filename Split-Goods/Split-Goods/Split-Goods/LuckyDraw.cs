using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Split_Goods
{
    public partial class LuckyDraw : Form
    {
        private static string path = "namelist.txt";
        string[] content = File.ReadAllLines(path);
        int index;
        int total = 5;
        int save = 0;
        string winner = "";

        public LuckyDraw()
        {
            InitializeComponent();
        }

        private void LuckyDraw_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                timer1.Start();
                
            }
            else
            {
                button1.Text = "Start";
                timer1.Stop();

                //label1.Text = content[0];
                StreamWriter sw = null;
                try
                {
                    sw = new StreamWriter("result.txt", true);
                    sw.WriteLine(DateTime.Now.ToString() + ": " + content[index].ToString());
                    sw.Flush();
                    sw.Close();
                }
                catch
                {
                    sw.Close();
                }
                content = content.Where(w => w != content[index]).ToArray();
                total--;

                string result = File.ReadAllText("result.txt");
                richTextBox1.Text = result;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            
            if (total > 0)
            {
                index = r.Next(0, total);
                label1.Text = content[index];
                
            //for (int i = 0; i < total; i++)
            //    {
            //        System.Threading.Thread.Sleep(100);
            //        label1.Text = content[i];
            //    }
            
            }
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                button1_Click(sender,e);
                //System.Threading.Thread.Sleep(200);
                

            }
        }
    }
}
