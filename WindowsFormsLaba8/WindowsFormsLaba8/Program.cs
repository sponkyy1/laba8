using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsLaba8
{
    class StorageAuto1
    {
        const int f_name = 10;
        private int code;
        private string name;
        private string marka;
        private float price;
        private double quantity;
        public StorageAuto1()
        {
            code = 0;
            name = "Anonimous";
            marka = "";
            price = 0;
            quantity = 0;
        }
        public StorageAuto1(string s)
        {
            code = Convert.ToInt32(s.Substring(0, f_name));
            name = s.Substring(f_name, 9);
            marka = s.Substring(f_name + 9, 10);
            price = Convert.ToInt32(s.Substring(f_name + 19, 7));
            quantity = Convert.ToInt32(s.Substring(f_name + 26));
            if (code < 0) throw new FormatException();
            if (price < 0) throw new FormatException();
            if (quantity < 0) throw new FormatException();
        }
        public void AppendAllText(string path, string contents)
        {
            if (!File.Exists(path))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            string append = "\n";
            File.AppendAllText(path, append);
            File.AppendAllText(path, contents);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
            Console.WriteLine("Text add to file");
        }
        public void Delete(string path, int line)
        {
            if (!File.Exists(path))
            {
                string createText = "Hello and Welcome" + Environment.NewLine;
                File.WriteAllText(path, createText);
            }
            string[] fileLines = File.ReadAllLines(path);
            fileLines[line] = String.Empty; // deleting
            File.WriteAllLines(path, fileLines);
            string readText = File.ReadAllText(path);
            Console.WriteLine(readText);
            Console.WriteLine("Text delete to file");
        }
        public override string ToString()
        {
            return string.Format("Code: {0,10} Name: {1:19,29} Marka: {2:29,36} Price: {3} Quantity: {4}", code, name, marka, price, quantity);
        }
        public int Code
        {
            get { return code; }
            set
            {
                if (value > 0) code = value;
                else throw new FormatException();
            }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }
        public float Price
        {
            get { return price; }
            set
            {
                if (value > 0) price = value;
                else throw new FormatException();
            }
        }
        public double Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0) quantity = value;
                else throw new FormatException();
            }
        }
        // ------------------  операції класу ---------------------------  
        public class SortByCode : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto1 p1 = (StorageAuto1)ob1;
                StorageAuto1 p2 = (StorageAuto1)ob2;
                if (p1.Code > p2.Code) return 1;
                if (p1.Code < p2.Code) return -1;
                return 0;
            }
        }
        public class SortByPrice : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto1 p1 = (StorageAuto1)ob1;
                StorageAuto1 p2 = (StorageAuto1)ob2;
                if (p1.Price > p2.Price) return 1;
                if (p1.Price < p2.Price) return -1;
                return 0;
            }
        }
        public class SortByQuantity : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto1 p1 = (StorageAuto1)ob1;
                StorageAuto1 p2 = (StorageAuto1)ob2;
                if (p1.Quantity > p2.Quantity) return 1;
                if (p1.Quantity < p2.Quantity) return -1;
                return 0;
            }
        }
        public class SortByMarka : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto1 p1 = (StorageAuto1)ob1;
                StorageAuto1 p2 = (StorageAuto1)ob2;
                if (p1.Marka.Length > p2.Marka.Length) return 1;
                if (p1.Marka.Length < p2.Marka.Length) return -1;
                return 0;
            }
        }
        public class SortByName : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto1 p1 = (StorageAuto1)ob1;
                StorageAuto1 p2 = (StorageAuto1)ob2;
                if (p1.Name.Length > p2.Name.Length) return 1;
                if (p1.Name.Length < p2.Name.Length) return -1;
                return 0;
            }
        }
    };
static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StorageAuto());
            Application.Run(new Input());
            Application.Run(new Add());
            Application.Run(new Edit());
        }
    }
}
