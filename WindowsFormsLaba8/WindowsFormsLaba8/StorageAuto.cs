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

    public partial class StorageAuto : Form
    {

        public StorageAuto()
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
            StorageAuto1[] group = new StorageAuto1[10];
            for (int ij = 0; ij < j; ij++) group[ij] = list[ij];
            Console.WriteLine("sort is Code:");
            Array.Sort(group, new StorageAuto1.SortByCode());
            foreach (StorageAuto1 elem in group) elem.ToString();
            foreach (var element in group)
            {
                Console.WriteLine(element);
            }
            MessageBox.Show("Vse good proyshlo");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
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
            StorageAuto1[] group = new StorageAuto1[10];
            for (int ij = 0; ij < j; ij++) group[ij] = list[ij];
            Console.WriteLine("sort is Marka:");
            Array.Sort(group, new StorageAuto1.SortByMarka());
            foreach (StorageAuto1 elem in group) elem.ToString();
            foreach (var element in group)
            {
                Console.WriteLine(element);
            }
            MessageBox.Show("Vse good proyshlo");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
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
            StorageAuto1[] group = new StorageAuto1[10];
            for (int ij = 0; ij < j; ij++) group[ij] = list[ij];
            Console.WriteLine("sort is Price:");
            Array.Sort(group, new StorageAuto1.SortByPrice());
            foreach (StorageAuto1 elem in group) elem.ToString();
            foreach (var element in group)
            {
                Console.WriteLine(element);
            }
            MessageBox.Show("Vse good proyshlo");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
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
            StorageAuto1[] group = new StorageAuto1[10];
            for (int ij = 0; ij < j; ij++) group[ij] = list[ij];
            Console.WriteLine("sort is Name:");
            Array.Sort(group, new StorageAuto1.SortByName());
            foreach (StorageAuto1 elem in group) elem.ToString();
            foreach (var element in group)
            {
                Console.WriteLine(element);
            }
            MessageBox.Show("Vse good proyshlo");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
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
            StorageAuto1[] group = new StorageAuto1[10];
            for (int ij = 0; ij < j; ij++) group[ij] = list[ij];
            Console.WriteLine("sort is Quantity:");
            Array.Sort(group, new StorageAuto1.SortByQuantity());
            foreach (StorageAuto1 elem in group) elem.ToString();
            foreach (var element in group)
            {
                Console.WriteLine(element);
            }
            MessageBox.Show("Vse good proyshlo");
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

