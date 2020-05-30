using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsLaba8
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Yellow;
        }
        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<StorageAuto1> list = new List<StorageAuto1>();
            int n = 0;
            StreamReader f = new StreamReader("dbase.txt");
            string s;
            int i = 0;
            int j = 0;
            try
            {
                while ((s = f.ReadLine()) != null)
                {
                    list.Add(new StorageAuto1(s));
                    ++i;
                }
                n = i - 1;
                foreach (var element in list)
                {
                    Console.WriteLine(element);
                    j++;
                }
                f.Close();
            }
            catch (FileNotFoundException d)
            {
                Console.WriteLine(d.Message);
                Console.WriteLine("Check the correct name and path to the file!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Very large file!");
                return;
            }
            catch (Exception d)
            {
                Console.WriteLine("Error: " + d.Message); return;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
