using System.Collections.Generic;
using NUnit.Framework;
using BookService;

namespace CollectionsManipulations.Tests
{
    public class BinarySearchTreeTests
    {
        [Test]
        public void AddMethod_IntWithDefaultComparer_BinaryTree()
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 6, 4, 7, 10, 3, 5 });
            List<int> actual = new List<int>();
            foreach (var item in tree)
            {
                actual.Add(item);
            }

            List<int> expected = new List<int>() { 3, 4, 5, 6, 7, 10 };
            Assert.AreEqual(expected, actual);
        }

        public class ComparingByNumberOfZeros : IComparer<int>
        {
            public int Compare(int first, int second)
            {
                int countOfZerosX = 0;
                int countOfZerosY = 0;

                while (first != 0)
                {
                    if (first % 10 == 0)
                    {
                        countOfZerosX++;
                    }

                    first = first / 10;
                }

                while (second != 0)
                {
                    if (second % 10 == 0)
                    {
                        countOfZerosY++;
                    }

                    second = second / 10;
                }

                if (countOfZerosX == countOfZerosY)
                {
                    return 0;
                }

                return countOfZerosX > countOfZerosY ? 1 : -1;
            }
        }

        public class LengthComparer : IComparer<string>
        {
            public int Compare(string first, string second)
            {
                if (first.Length == second.Length)
                {
                    return 0;
                }

                return first.Length > second.Length ? 1 : -1;
            }
        }

        [Test]
        public void AddMethod_IntWithCustomComparer_BinaryTree()
        {

            var comparer = new ComparingByNumberOfZeros();
            BinarySearchTree<int> tree = new BinarySearchTree<int>(new int[] { 50003, 200, 1, 100000, 10 }, comparer);
            List<int> actual = new List<int>();
            foreach (var item in tree)
            {
                actual.Add(item);
            }

            List<int> expected = new List<int>() { 1, 10, 200, 50003, 100000 };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddMethod_StringWithDefaultComparer_BinaryTree()
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "assert", "new", "know", "yes" });
            List<string> actual = new List<string>();
            foreach (var item in tree)
            {
                actual.Add(item);
            }

            List<string> expected = new List<string>() { "assert", "know", "new", "yes" };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddMethod_StringWithCustomComparer_BinaryTree()
        {
            var comparer = new LengthComparer();
            BinarySearchTree<string> tree = new BinarySearchTree<string>(new string[] { "assert", "new", "know", "knowledge", "yes" }, comparer);
            List<string> actual = new List<string>();
            foreach (var item in tree)
            {
                actual.Add(item);
            }

            List<string> expected = new List<string>() { "new", "yes", "know", "assert", "knowledge" };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddMethod_BookWithDefaultComparer_BinaryTree()
        {
            var book1 = new Book()
            {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 70,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
            };

            var book2 = new Book()
            {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 100,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
            };

            var book3 = new Book()
            {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 23,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
            };

            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(new Book[] { book1, book2, book3 });
            List<Book> actual = new List<Book>();
            foreach (var item in tree)
            {
                actual.Add(item);
            }

            List<Book> expected = new List<Book>() { book3, book1, book2 };
            Assert.AreEqual(expected, actual);
        }

        public class PriceComparer : IComparer<Book>
        {
            public int Compare(Book left, Book right)
            {
                if (left.Price == right.Price)
                {
                    return 0;
                }

                return left.Price > right.Price ? 1 : -1;
            }
        }

        [Test]
        public void AddMethod_BookWithComparer_BinaryTree()
        {
            var book1 = new Book()
            {
                Author = "Рихтер Джеффри",
                ISBN = "978-5-496-00-433-6",
                Title = "CLR via C#",
                PageCount = 896,
                Price = 100,
                PublicationYear = 2014,
                PublishingOffice = "Питер"
            };

            var book2 = new Book()
            {
                Author = "Тепляков Сергей",
                ISBN = "978-5-496-01649-0",
                Title = "Паттерны проектирования",
                PageCount = 320,
                Price = 23,
                PublicationYear = 2016,
                PublishingOffice = "Питер"
            };

            var book3 = new Book()
            {
                Author = "Албахари",
                ISBN = "978-5-496-00-433-6",
                Title = "C# 3.0 справочник",
                PageCount = 944,
                Price = 70,
                PublicationYear = 2012,
                PublishingOffice = "BHV"
            };


            var comparer = new PriceComparer();

            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(new Book[] { book1, book2, book3 }, comparer);
            List<Book> actual = new List<Book>();
            foreach (var item in tree)
            {
                actual.Add(item);
            }

            List<Book> expected = new List<Book>() { book2, book3, book1 };
            Assert.AreEqual(expected, actual);
        }

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public class PointComparer : IComparer<Point>
        {
            public int Compare(Point left, Point right)
            {
                if (left.X * left.Y == right.X * right.Y)
                {
                    return 0;
                }

                return left.X * left.Y > right.X * right.Y ? 1 : -1;
            }
        }

        [Test]
        public void AddMethod_PointWithComparer_BinaryTree()
        {
            var point1 = new Point(12, 10);
            var point2 = new Point(20, 10);
            var point3 = new Point(6, 8);
            var point4 = new Point(3, 5);
            var point5 = new Point(5, 1);
            var point6 = new Point(3, 10);

            var comparer = new PointComparer();

            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new Point[] 
            { point1, point2, point3, point4, point5, point6 }, 
            comparer);
            List<Point> actual = new List<Point>();
            foreach (var item in tree)
            {
                actual.Add(item);
            }

            List<Point> expected = new List<Point>() { point5, point4, point6, point3, point1, point2 };
            Assert.AreEqual(expected, actual);
        }
    }
}
