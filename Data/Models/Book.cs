using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Models
{
    /// <summary>
    /// Book model. Class holds basic information about book.
    /// </summary>
    public class Book
    {
        public string Name { get; set; }
        public string[] Author { get; set; }
        public string[] Category { get; set; }
        public string Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }

        public override string ToString()
        {
            return String.Format("{0, 70}|{1, 60}|{2, 30}|{3, 15}|{4, 20}|{5, 15}", Name, ArrayToString(Author), ArrayToString(Category), Language, PublicationDate.ToShortDateString(), ISBN);
        }

        private string ArrayToString(string[] dataArray)
        {
            string conectedArray = "";

            foreach (var data in dataArray)
            {
                conectedArray += data + ", ";
            }

            return conectedArray;
        }
    }
}
