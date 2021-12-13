using BookLibrary.Data;
using System;
using System.Collections.Generic;
using BookLibrary.Res;
using BookLibrary.Data.Models;
using System.Text.RegularExpressions;

namespace BookLibrary.Controller
{
    /// <summary>
    /// This is controller for Library. It serves as a mediator between user and tasks.
    /// </summary>
    public class LibraryController
    {
        IBookRepository _bookRepository;
        CustomErrors _customErrors;
        CustomStrings _customStrings;
        ConstantNames _constantNames;

        /// <summary>
        /// Class constructor.
        /// </summary>
        public LibraryController()
        {
            _customErrors = new CustomErrors();
            _bookRepository = new LibraryRepository();
            _constantNames = new ConstantNames();
            _customStrings = new CustomStrings();
        }

        public LibraryController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _customErrors = new CustomErrors();
            _constantNames = new ConstantNames();
            _customStrings = new CustomStrings();
        }

        /// <summary>
        /// Method adds book to list
        /// </summary>
        /// <param name="name">book name</param>
        /// <param name="authors">book authors</param>
        /// <param name="categories">boook categories</param>
        /// <param name="language">book language</param>
        /// <param name="publicationDate">book publicationDate</param>
        /// <param name="isbn">book isbn</param>
        public void Add(string name, string[] authors, string[] categories,
            string language, string publicationDate, string isbn)
        {
            Book newBook = new Book {
                Name = name,
                Author = authors,
                Category = categories,
                Language = language,
                PublicationDate = DateTime.Parse(publicationDate),
                ISBN = isbn
            };

            _bookRepository.Add(newBook);
        }

        /// <summary>
        /// Method updates taken book information.
        /// </summary>
        /// <param name="bookName">book name</param>
        /// <param name="userName">user name</param>
        /// <param name="returnsInDays">days string format</param>
        public void Take(string bookName, string userName, string returnsInDays)
        {
            DateTime date = DateTime.Now;

            Regex regex = new Regex(@"([a-zA-Z])");
            MatchCollection matches = regex.Matches(returnsInDays);

            if (matches.Count > 0)
                throw new Exception(_customErrors.CommmandNumberError);

            var bookList = _bookRepository.GetAll(userName);

            if (bookList.Count == 3)
                throw new Exception(_customErrors.UserReachedLimit);

            if (_bookRepository.GetBook(bookName) == null)
                throw new Exception(_customErrors.CouldNotFind);

            date.AddDays(double.Parse(returnsInDays));

            _bookRepository.Take(bookName, userName, DateTime.Now, date);
        }

        /// <summary>
        /// Method allows user to return book.
        /// </summary>
        /// <param name="bookName">returned book name</param>
        public void Return(string bookName)
        {
            var book = _bookRepository.GetBook(bookName);

            if (book.UserName == null)
                throw new Exception(_customErrors.WasNotTaken);

            if (book == null)
                throw new Exception(_customStrings.MissingBookMessage);

            _bookRepository.Return(book);

            if (book.ReturnDade < DateTime.Now)
                throw new Exception(_customStrings.AngryMessage);
        }
        
        /// <summary>
        /// Method lists all books based on their filter.
        /// </summary>
        /// <param name="filter">Filter name</param>
        /// <param name="key">Key for filtering</param>
        /// <returns>List of filtered books</returns>
        public List<LibraryBook> List(string filter, string key)
        {
            filter = filter.ToUpper();

            if (filter == "")
                return _bookRepository.GetAll();

            if (filter == _constantNames.Author())
                return _bookRepository.FilterByAuthor(key);

            if (filter == _constantNames.Category())
                return _bookRepository.FilterByCategory(key);

            if (filter == _constantNames.Language())
                return _bookRepository.FilterByLanguage(key);

            if (filter == _constantNames.Isbn())
                return _bookRepository.FilterByISBN(key);

            if (filter == _constantNames.Name())
                return _bookRepository.FilterByName(key);

            if (filter == _constantNames.Available())
                return _bookRepository.FilterByAvailable();

            if (filter == _constantNames.Taken())
                return _bookRepository.FilterByTaken();

            if (filter == null)
                return _bookRepository.GetAll();

            throw new Exception(_customErrors.CouldNotFindFilter);
        }

        /// <summary>
        /// Method deletes book from library.
        /// </summary>
        /// <param name="bookName">book name</param>
        /// <param name="isbn">book isbn</param>
        public void Delete(string bookName, string isbn)
        {
            var book = _bookRepository.GetBook(bookName, isbn);

            if (book == null)
                throw new Exception(_customErrors.CouldNotFind);

            _bookRepository.Delete(book);
        }
    }
}
