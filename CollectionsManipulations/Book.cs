using System;

namespace BookService
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string PublishingOffice { get; set; }
        public int PublicationYear { get; set; }
        public decimal Price { get; set; }
        public uint PageCount { get; set; }

        public override int GetHashCode()
        {
            return int.Parse(this.ISBN.Replace("-", "").Substring(0, Math.Min(8, this.ISBN.Length)));
        }

        public override string ToString()
        {
            return $"Author: {this.Author}, Title: {this.Title}, Price: {this.Price}";
        }

        public int CompareTo(Book other)
        {
            if (this.Equals(other))
            {
                return 0;
            }

            if (this.Author.CompareTo(other.Author) != 0)
            {
                return this.Author.CompareTo(other.Author);
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }

        public bool Equals(Book other)
        {
            if (!(this.GetHashCode() == other.GetHashCode()))
            {
                return false;
            }

            return (this.Author == other.Author) && (this.Title == other.Title);
        }
    }
}
