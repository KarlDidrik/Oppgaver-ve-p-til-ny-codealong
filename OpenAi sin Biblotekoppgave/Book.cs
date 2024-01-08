using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAi_sin_Biblotekoppgave
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool Availible { get; set; } = true;

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} ({(Availible ? "Available" : "Not Available")})";
        }
    }
}
