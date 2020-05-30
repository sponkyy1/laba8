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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.Green;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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
            String Add = textBox1.Text;
            StorageAuto1 add = new StorageAuto1();
            Console.WriteLine("Enter the line you want to add: ");
            add.AppendAllText("dbase.txt", Add);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
