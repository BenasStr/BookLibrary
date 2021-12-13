using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Data.Models
{
    /// <summary>
    /// Object that inherits Book. It holds additional information about book.
    /// </summary>
    public class LibraryBook : Book
    {
        public string UserName { get; set; }
        public DateTime? CollectionDate { get; set; }
        public DateTime? ReturnDade { get; set; }
    }
}
