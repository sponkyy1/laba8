using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace testlaba8
{
    class StorageAuto
    {             // 1         
        const int f_name = 10;
        private int code;
        private string name;
        private string marka;
        private float price;
        private double quantity;
        public StorageAuto()
        {
            code = 0;
            name = "Anonimous";
            marka = "";
            price = 0;
            quantity = 0;
        }
        public StorageAuto(string s)
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
                StorageAuto p1 = (StorageAuto)ob1;
                StorageAuto p2 = (StorageAuto)ob2;
                if (p1.Code > p2.Code) return 1;
                if (p1.Code < p2.Code) return -1;
                return 0;
            }
        }
        public class SortByPrice : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto p1 = (StorageAuto)ob1;
                StorageAuto p2 = (StorageAuto)ob2;
                if (p1.Price > p2.Price) return 1;
                if (p1.Price < p2.Price) return -1;
                return 0;
            }
        }
        public class SortByQuantity : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto p1 = (StorageAuto)ob1;
                StorageAuto p2 = (StorageAuto)ob2;
                if (p1.Quantity > p2.Quantity) return 1;
                if (p1.Quantity < p2.Quantity) return -1;
                return 0;
            }
        }
        public class SortByMarka : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                StorageAuto p1 = (StorageAuto)ob1;
                StorageAuto p2 = (StorageAuto)ob2;
                if (p1.Marka != " " && p2.Marka != " ")
                {
                    if (p1.Marka.Length > p2.Marka.Length) return 1;
                    if (p1.Marka.Length < p2.Marka.Length) return -1;
                }
                return 0;
            }
        }
        public class SortByName : IComparer
        {
            int i = 0;
            int IComparer.Compare(object ob1, object ob2)
            {
                
                StorageAuto p1 = (StorageAuto)ob1;
                StorageAuto p2 = (StorageAuto)ob2;
                if (p1.Name != " " && p2.Name != " ")
                {
                    i++;
                    Console.WriteLine(i);
                    if (p1.Name.Length > p2.Name.Length) return 1;
                    if (p1.Name.Length < p2.Name.Length) return -1;
                }
                return 0;
            }
        }
    };



    class Program
    {
        static void Main(string[] args)
        {

            List<StorageAuto> list = new List<StorageAuto>();
            int n = 0;
            StreamReader f = new StreamReader("dbase.txt");
            string s;
            int i = 0;
            int j = 0;
            try
            {
                while ((s = f.ReadLine()) != null)
                {
                    list.Add(new StorageAuto(s));
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
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Check the correct name and path to the file!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Very large file!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); return;
            }
            StorageAuto[] group = new StorageAuto[10];
            for (int ij = 0;ij < j;ij++) group[ij] = list[ij];
            string namesse;
            Console.WriteLine("Enter it function next, write it is sort: ");
            while ((namesse = Console.ReadLine()) != "")
            {
                Console.WriteLine("Write word(code, price, quantity, name, marka) you want to sort:");
                string sortt = Console.ReadLine();
                if (sortt == "code")
                {
                    Console.WriteLine("sort is Code:");
                    Array.Sort(group, new StorageAuto.SortByCode());
                    foreach (StorageAuto elem in group) elem.ToString();
                    foreach (var element in group)
                    {
                        Console.WriteLine(element);
                    }
                }
                else if (sortt == "name")
                {
                    Console.WriteLine("sort is Name:");
                    Array.Sort(group, new StorageAuto.SortByName());
                    foreach (StorageAuto elem in group) elem.ToString();
                    foreach (var element in group)
                    {
                        Console.WriteLine(element);
                    }
                }
                else if (sortt == "marka")
                {
                    Console.WriteLine("sort is Marka:");
                    Array.Sort(group, new StorageAuto.SortByMarka());
                    foreach (StorageAuto elem in group) elem.ToString();
                    foreach (var element in group)
                    {
                        Console.WriteLine(element);
                    }
                }
                else if (sortt == "price")
                {
                    Console.WriteLine("sort is Price:");
                    Array.Sort(group, new StorageAuto.SortByPrice());
                    foreach (StorageAuto elem in group) elem.ToString();
                    foreach (var element in group)
                    {
                        Console.WriteLine(element);
                    }
                }
                else if(sortt == "quantity")
                {
                    Console.WriteLine("sort is Quantity:");
                    Array.Sort(group, new StorageAuto.SortByQuantity());
                    foreach (StorageAuto elem in group) elem.ToString();
                    foreach (var element in group)
                    {
                        Console.WriteLine(element);
                    }
                }
            }

            Console.WriteLine("Enter the text if you want play in remote in list: ");
            string nama;
            while ((nama = Console.ReadLine()) != "")
            {
                Console.WriteLine("Write remote if you want remote in list: ");
                string m = Console.ReadLine();
                if (m == "remote")
                {
                    Console.WriteLine("Enter number if you want to delete a line in LIST");
                    int number = Convert.ToInt32(Console.ReadLine());
                    list.Remove(list[number]);
                    j--;
                    foreach (var element in list)
                    {
                        Console.WriteLine(element);
                    }
                }
            }

            Console.WriteLine("Enter text if you want to add a line in database: ");
            string names;
            while ((names = Console.ReadLine()) != "")
            {
                StorageAuto add = new StorageAuto();
                Console.WriteLine("Enter the line you want to add: ");
                string numberOfLineToAdd = Console.ReadLine();
                add.AppendAllText("dbase.txt", numberOfLineToAdd);
            }

            Console.WriteLine("Enter text if you want to delete a line in database: ");
            string nam;
            while ((nam = Console.ReadLine()) != "")
            {
                StorageAuto del = new StorageAuto();
                Console.WriteLine("Enter the line you want to delete: ");
                int numberOfLineToDelete = Convert.ToInt32(Console.ReadLine());
                del.Delete("dbase.txt", numberOfLineToDelete);
            }
            Console.WriteLine("Enter text if you want redahuvaty line in database(file): ");
            string namess;
            while ((namess = Console.ReadLine()) != "")
            {
                StorageAuto del = new StorageAuto();
                Console.WriteLine("Enter the line you want to delete in file: ");
                int numberOfLineToDelete = Convert.ToInt32(Console.ReadLine());
                del.Delete("dbase.txt", numberOfLineToDelete);
                Console.WriteLine("-------------redahuvannya-----------------------");
                StorageAuto add = new StorageAuto();
                Console.WriteLine("Enter the line you want to add in file: ");
                string numberOfLineToAdd = Console.ReadLine();
                add.AppendAllText("dbase.txt", numberOfLineToAdd);
            }
        }

    }
}
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace testlaba8
{
    class StorageAuto : IComparable<StorageAuto>
    {             // 1         
        const int f_name = 10;
        private string code;
        private string name;
        private string marka;
        private int price;
        private int quantity;
        public StorageAuto()
        {
            code = "";
            name = "Anonimous";
            marka = "";
            price = 0;
            quantity = 0;
        }
        public StorageAuto(string s)
        {
            code = s.Substring(0, f_name);
            name = s.Substring(f_name, 9);
            marka = s.Substring(f_name + 9, 6);
            price = Convert.ToInt32(s.Substring(f_name + 15, 7));
            quantity = Convert.ToInt32(s.Substring(f_name + 22));
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
            return string.Format("Code: {0,10} Name: {1:10,16} Marka: {2:16,22} Price: {3} Quantity: {4}", code, name, marka, price, quantity);
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
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
        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0) price = value;
                else throw new FormatException();
            }
        }
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0) price = quantity;
                else throw new FormatException();
            }
        }
        // ------------------  операції класу ---------------------------         
        public int CompareTo(StorageAuto other)
        {

            if (this.Price == other.Price)
            {

                return this.Price.CompareTo(other.Price);
            }

            return other.Price.CompareTo(this.Price);
        }
    };



    class Program
    {
        static void Main(string[] args)
        {
            List<StorageAuto> list = new List<StorageAuto>();
            int n = 0;
            StreamReader f = new StreamReader("dbase.txt");
            string s;
            int i = 0;
            try
            {
                while ((s = f.ReadLine()) != null)
                {
                    list.Add(new StorageAuto(s));
                    ++i;
                }
                n = i - 1;

                list.Sort();



                foreach (var element in list)
                {
                    Console.WriteLine(element);
                }
                f.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Check the correct name and path to the file!");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Very large file!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message); return;
            }



            Console.WriteLine("Work with files");
            //-----------------------------------------------------------------
            Console.WriteLine("Enter text if you want to add a line in database(file): ");
            string names;
            while ((names = Console.ReadLine()) != "")
            {
                StorageAuto add = new StorageAuto();
                Console.WriteLine("Enter the line you want to add(file) in file: ");
                string numberOfLineToAdd = Console.ReadLine();
                add.AppendAllText("dbase.txt", numberOfLineToAdd);
            }

            Console.WriteLine("Enter text if you want to delete a line in database(file): ");
            string nam;
            while ((nam = Console.ReadLine()) != "")
            {
                StorageAuto del = new StorageAuto();
                Console.WriteLine("Enter the line you want to delete in file: ");
                int numberOfLineToDelete = Convert.ToInt32(Console.ReadLine());
                del.Delete("dbase.txt", numberOfLineToDelete);
            }

            Console.WriteLine("Enter text if you want redahuvaty line in database(file): ");
            string namess;
            while ((namess = Console.ReadLine()) != "")
            {
                StorageAuto del = new StorageAuto();
                Console.WriteLine("Enter the line you want to delete in file: ");
                int numberOfLineToDelete = Convert.ToInt32(Console.ReadLine());
                del.Delete("dbase.txt", numberOfLineToDelete);
                Console.WriteLine("-------------redahuvannya-----------------------");
                StorageAuto add = new StorageAuto();
                Console.WriteLine("Enter the line you want to add in file: ");
                string numberOfLineToAdd = Console.ReadLine();
                add.AppendAllText("dbase.txt", numberOfLineToAdd);
            }
        }
        //-----------------------------------------------------------------------------

    }
}
*/
