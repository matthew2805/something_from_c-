using System;

namespace lab6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book("Ясос Биба", "Философия", 1000, 1000);
            Console.WriteLine($"кол-во знаков за час: {book.CharPerHour()}");
            Console.WriteLine($"времени на прочтение книги уйдет: {book.AmountOfTime()} часов");
            Book book2 = new Book("s","s",1,1);
            Book book3 = new Book("s", "s", 1, 1);
            Book book4 = new Book("s", "s", 1, 1);
            Book book5 = new Book("s", "s", 1, 1);
            Book.BooksRead();
        }
        class Book
        {
            static int countofbooks = 0;
            private string titleofthebook;
            private string author;
            private int pages;
            private int numofchar;//кол-во знаков которое вы способны прочитать за минуту 
            private int authorsheet = 40000;
            

            public string Title
            {
                get
                {
                    return titleofthebook;
                }
                private set
                {
                    titleofthebook = value;
                }
            }
            public string Author
            {
                get
                {
                    return author;
                }
                private set
                {
                    author = value;
                }
            }
            public int Pages
            {
                get
                {
                    return pages;
                }
                private set
                {
                    if(value <= 0)
                    {
                        Console.WriteLine("неверные данные");
                    }
                    else
                    {
                        pages = value;
                    }
                   
                }
            }
            public int NumChar
            {
                get
                {
                    return numofchar;
                }
                private set
                {
                    if (value <= 0)
                    {
                        Console.WriteLine("неверные данные");
                    }
                    else
                    {
                        numofchar = value;
                    }

                }
            }
            public int Authorsheet
            {
                set
                {
                    if(value< 0)
                    {
                        Console.WriteLine("неверные данные");
                    }
                    else
                    {
                        authorsheet = value;
                    }
                }
                get
                {
                    return authorsheet;
                }
            }
            public Book(string titleofthebook, string author, int pages, int numofchar)
            {
                Title = titleofthebook;
                Author = author;
                Pages = pages;
                NumChar=numofchar;
                countofbooks++;
            }
            public double CharPerHour()
            {
                double numofcharhour = numofchar * 60;
                return numofcharhour;
            }
            public double AmountOfTime()
            {
                double numofcharhour = numofchar * 60;
                double amountofchar = pages * authorsheet;
                double time = Math.Round(amountofchar / numofcharhour,2);
                return time;
            }
            static public void BooksRead()
            {
                Console.WriteLine($"за все время вы прочитали {countofbooks} книг") ;
            }







        }

    }
}
