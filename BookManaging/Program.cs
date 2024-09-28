using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BookManaging
{
    interface IBook
    {
        string this[int index]
        {
            get;
            set;
        }
        string Title { get; set; }
        string Author { get; set; }
        string Publicsher { get; set; }
        string ISBN { get; set; }
        int Year { get; set; }
        void Show();
    }
    public class Book : IBook, IComparable<Book>
    {
        private string isbn;
        private string title;
        private string author;
        private string publicsher;
        private int year;
        private ArrayList chapter = new ArrayList();
        public string this[int index]
        {
            get
            {
                if (index >= 0 && index < chapter.Count)
                    return (string)chapter[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < chapter.Count)
                    chapter[index] = value;
                else if (index == chapter.Count)
                    chapter.Add(value);
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publicsher { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public void Show()
        {
            Console.WriteLine("-------------------");
            Console.Write(" |Title: " + title);
            Console.Write(" |Author: " + author);
            Console.Write(" |Publicsher: " + publicsher);
            Console.Write(" |Year: " + year);
            Console.Write(" |ISBN: " + isbn);
            Console.WriteLine("\nChapter: ");
            for (int i = 0; i < chapter.Count; i++)
            {
                Console.WriteLine(i + 1+"--"+chapter[i]);
            }
            Console.WriteLine("---------------------------");
        }
        public void Input()
        {
            Console.Write("Title: ");
            title = Console.ReadLine();
            Console.Write(" |Author: ");
            author = Console.ReadLine();
            Console.Write(" |Publicsher: ");
            publicsher = Console.ReadLine();
            Console.Write(" |ISBN: ");
            isbn = Console.ReadLine();
            Console.Write(" |Year: ");
            year = int.Parse(Console.ReadLine());
            Console.WriteLine("Input chapter (finished with empty string)");
            string str;
            do
            {
                str = Console.ReadLine();
                if (str.Length > 0)
                {
                    chapter.Add(str);

                }
            } while (str.Length > 0);

        }
        public int CompareTo(Book other)
        {
            if (other == null) return 1; // Nếu đối tượng so sánh là null
            return this.year.CompareTo(other.year); // So sánh theo năm xuất bản
        }


    }
   
    public class BookTitleComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x == null) return -1;
            if (y == null) return 1;
            return string.Compare(x.Title, y.Title);
        }
    }
    internal class BookList
    {
        //public ArrayList list = new ArrayList();
        public List<Book> list = new List<Book>();
        public void AddBook()
        {
            Book b = new Book();
            b.Input();
            list.Add(b);

        }
        public void ShowList()
        {
           foreach (Book b in list)
            {
                b.Show();
            }

        }
        public void InputList()
        {
            int n;
            Console.Write("Amount of books: ");
            n = int.Parse(Console.ReadLine());
            while (n > 0)
            {
                AddBook();
                n--;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BookList bl = new BookList();
            bl.InputList();
            bl.list.Sort();
            bl.ShowList();
            bl.list.Sort(new BookTitleComparer());
            bl.ShowList();
            Console.ReadLine();
        }
    }
}
