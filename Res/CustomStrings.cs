using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Res
{
    /// <summary>
    /// Class used for custom created strings.
    /// You get easier access when you need to fix a string.
    /// </summary>
    class CustomStrings
    {
        // First message resource
        public readonly string HelloMessage = "Welcome to Visma library!";

        // Command examples
        public readonly string CommandListMessage = "Here are all commands, that you can use:";

        // Add command dialogue strings
        public readonly string CommandAdd = "Add - command adds book to library.";
        public readonly string CommandAddBookName = "Book name: ";
        public readonly string CommandAddBookAuthors = "Book author or authors (add , and space to seperate authors): ";
        public readonly string CommandAddBookCategories = "Book category or categories (add , and space to seperate categories): ";
        public readonly string CommandAddBookLanguage = "Book language: ";
        public readonly string CommandAddBookPublicationDate = "Book publication date (yyyy-mm-dd): ";
        public readonly string CommandAddBookISBN = "Book ISBN: ";
        public readonly string CommandAddSuccess= "Book was added";

        // Take command dialogue strings
        public readonly string CommandTake = "Take - takes book from library.";
        public readonly string CommandTakeBookName = "Book name: ";
        public readonly string CommandTakeUserName = "Your name: ";
        public readonly string CommandTakeDays = "How long will you have it (days): ";
        public readonly string CommandTakeSuccess = "Book is yours!";

        // Return command dialogue strings
        public readonly string CommandReturn = "Return - returns book back to library";
        public readonly string CommandReturnBookName = "Book name: ";
        public readonly string CommandReturnSuccess = "Book retuned!";

        //"List ?<FilterType = Author | Category | Language | ISBN | Name | Available | Taken> ?<Filter Keyword>";
        public readonly string CommandList = "List - returns all books unless you use filter. Then it returns only filter matching books";
        public readonly string CommandListBookFilter = "Book filter:\n Author | Category | Language | ISBN | Name | Available | Taken (can be empty):";
        public readonly string CommandListBookFilterKey = "Book filetr keyword: ";
        
        //Delete command dialogue strings
        public readonly string CommandDelete = "Delete - deletes book from library";
        public readonly string CommandDeleteBookName = "Book name: ";
        public readonly string CommandDeleteBookISBN = "Book ISBN: ";
        public readonly string CommandDeleteSuccess = "Book was deleted.";


        public readonly string CommandHelp= "Help - outputs all possible commands.";
        public readonly string CommandExit = "Exit - exits console app.";

        //Messages
        public readonly string MissingBookMessage = "We don't not have this book.";

        public readonly string AngryMessage = "Library grandma is angry at you!";

        //Table
        public readonly string TableHeader = String.Format("{0, 70}|{1, 60}|{2, 30}|{3, 15}|{4, 20}|{5, 15}", "Name", "Author", "Category", "Language", "Publication Date", "ISBN");
        public readonly string TableGuideLine = string.Concat(Enumerable.Repeat("-", 215));
    }
}
