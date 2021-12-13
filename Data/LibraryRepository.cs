using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BookLibrary.Data.Models;
using BookLibrary.Data;

namespace BookLibrary.Data
{
    /// <summary>
    /// Interface describes book repository class.
    /// </summary>
    public interface IBookRepository
    {
        List<LibraryBook> GetAll();
        List<LibraryBook> GetAll(string userName);
        LibraryBook GetBook(string name);
        LibraryBook GetBook(string name, string isbn);
        void Add(Book book);
        void Take(string bookName, string userName, DateTime collectionDate, DateTime returnDate);
        void Return(LibraryBook book);
        void Delete(LibraryBook book);
        List<LibraryBook> FilterByName(string bookName);
        List<LibraryBook> FilterByAuthor(string author);
        List<LibraryBook> FilterByCategory(string category);
        List<LibraryBook> FilterByLanguage(string language);
        List<LibraryBook> FilterByISBN(string isbn);
        List<LibraryBook> FilterByAvailable();
        List<LibraryBook> FilterByTaken();
    }
    
    /// <summary>
    /// This class is responsible for library data.
    /// </summary>
    public class LibraryRepository : IBookRepository
    {
        private List<LibraryBook> bookList;
        private DataFileManager _dataFileManager;
        IDataFileManager _manager;

        /// <summary>
        /// Class constructor method.
        /// </summary>
        public LibraryRepository()
        {
            _manager = new DataFileManager();
            bookList = _manager.ReadDataFile();
            _dataFileManager = new DataFileManager();
        }

        /// <summary>
        /// Method gets all books from list.
        /// </summary>
        /// <returns>book list</returns>
        public List<LibraryBook> GetAll()
        {
            return bookList;
        }

        /// <summary>
        /// Method gets all books that are taken by user.
        /// </summary>
        /// <param name="userName">user name</param>
        /// <returns>book list taken by user</returns>
        public List<LibraryBook> GetAll(string userName)
        {
            return bookList.FindAll(obj => obj.UserName.ToLower() == userName.ToLower());
        }

        /// <summary>
        /// Methods get one book by given book name.
        /// </summary>
        /// <param name="name">book name</param>
        /// <returns>book with given name</returns>
        public LibraryBook GetBook(string name)
        {
            return bookList.Find(obj => obj.Name.ToLower() == name.ToLower());
        }

        /// <summary>
        /// Method gets book by it name and isbn code.
        /// </summary>
        /// <param name="name">book name</param>
        /// <param name="isbn">isbn code</param>
        /// <returns>book with given name and isbn</returns>
        public LibraryBook GetBook(string name, string isbn)
        {
            return bookList.Find(
                obj => obj.Name.ToLower() == name.ToLower()
                && obj.ISBN == isbn);
        }

        /// <summary>
        /// Method adds book to list
        /// </summary>
        /// <param name="newBook">new book</param>
        public void Add(Book newBook)
        {
            LibraryBook book = new LibraryBook
            {
                Name = newBook.Name,
                Author = newBook.Author,
                Category = newBook.Category,
                PublicationDate = newBook.PublicationDate,
                Language = newBook.Language,
                ISBN = newBook.ISBN,
                CollectionDate = null,
                ReturnDade = null,
                UserName = null
            };


            bookList.Add(book);
            _manager.UpdateFileContent(bookList);
        }

        /// <summary>
        /// Method marks finds chosen book and marks it as taken.
        /// </summary>
        /// <param name="bookName">book name</param>
        /// <param name="userName">user name</param>
        /// <param name="collectionDate">date when book weas collected</param>
        /// <param name="returnDate">date when book will be returned</param>
        public void Take(string bookName, string userName, DateTime collectionDate, DateTime returnDate)
        {
            for(int i = 0; i < bookList.Count; i++)
            {
                LibraryBook book = bookList[i];
                if(book.Name.ToLower() == bookName.ToLower())
                {
                    if(book.UserName == "")
                    {
                        book.UserName = userName;
                        book.CollectionDate = collectionDate;
                        book.ReturnDade = returnDate;
                        _manager.UpdateFileContent(bookList);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Method marks books as returned.
        /// </summary>
        /// <param name="book">book that was returned</param>
        public void Return(LibraryBook book)
        {
            book.UserName = "";
            book.CollectionDate = null;
            _manager.UpdateFileContent(bookList);
        }

        /// <summary>
        /// Method deletes book from list.
        /// </summary>
        /// <param name="book">book to delete</param>
        public void Delete(LibraryBook book)
        {
            bookList.Remove(book);
            _manager.UpdateFileContent(bookList);
        }

        /// <summary>
        /// Method filters books by name.
        /// </summary>
        /// <param name="bookName">book name</param>
        /// <returns>filtered list</returns>
        public List<LibraryBook> FilterByName(string bookName)
        {
            return bookList.FindAll(obj => obj.Name.ToLower() == bookName.ToLower());
        }

        /// <summary>
        /// Method filters books by author.
        /// </summary>
        /// <param name="author">author to filter by</param>
        /// <returns>filtered list</returns>
        public List<LibraryBook> FilterByAuthor(string author)
        {
            List<LibraryBook> books = new List<LibraryBook>();

            foreach(var book in bookList)
            {
                foreach(var auth in book.Author)
                {
                    if (auth.ToLower() == author.ToLower())
                    {
                        books.Add(book);
                    }
                }
            }

            return books;
        }

        /// <summary>
        /// Method filters list by given category
        /// </summary>
        /// <param name="category">category to filter by</param>
        /// <returns>filtered list</returns>
        public List<LibraryBook> FilterByCategory(string category)
        {
            List<LibraryBook> books = new List<LibraryBook>();

            foreach (var book in bookList)
            {
                foreach (var cat in book.Category)
                {
                    if (cat.ToLower() == category.ToLower())
                    {
                        books.Add(book);
                    }
                }
            }

            return books;
        }

        /// <summary>
        /// Method filters list by ggiven language
        /// </summary>
        /// <param name="language">language to filter by</param>
        /// <returns>filtered list</returns>
        public List<LibraryBook> FilterByLanguage(string language)
        {
            var books = bookList.FindAll(obj => obj.Language == language);
            return books;
        }

        /// <summary>
        /// Method filters list by isbn code.
        /// </summary>
        /// <param name="isbn">isbn code to filter by</param>
        /// <returns>filtered list</returns>
        public List<LibraryBook> FilterByISBN(string isbn)
        {
            return bookList.FindAll(obj => obj.ISBN == isbn);
        }

        /// <summary>
        /// Method filters books by availability.
        /// </summary>
        /// <returns>list of available books</returns>
        public List<LibraryBook> FilterByAvailable()
        {
            var available = bookList.FindAll(obj => obj.UserName == "");
            return available;
        }

        /// <summary>
        /// Method filters list that are taken
        /// </summary>
        /// <returns>taken books list</returns>
        public List<LibraryBook> FilterByTaken()
        {
            return bookList.FindAll(obj => obj.UserName != "");
        }
    }
}
