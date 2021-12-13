using System;
using System.Collections.Generic;
using BookLibrary.Res;
using BookLibrary.Controller;
using BookLibrary.Data.Models;

namespace BookLibrary.View
{
    /// <summary>
    /// This class is responsible for work with console.
    /// It reads and prints information on screen.
    /// </summary>
    public class ConsoleView
    {
        static ConsoleView instance;
        private CustomStrings _customStrings;
        private CustomErrors _customErrors;
        private LibraryController _libraryController;
        private ConstantNames _constantNames;

        /// <summary>
        /// Class constructor method.
        /// </summary>
        protected ConsoleView()
        {
            _customStrings = new CustomStrings();
            _customErrors = new CustomErrors();
            _libraryController = new LibraryController();
            _constantNames = new ConstantNames();
        }

        /// <summary>
        /// Method creates singleton instance.
        /// </summary>
        /// <returns>Instance</returns>
        public static ConsoleView Instance()
        {
            if (instance == null)
            {
                instance = new ConsoleView();
            }
            return instance;
        }

        /// <summary>
        /// Method starts all program.
        /// </summary>
        public void Start()
        {
            bool run = true;
            Console.WriteLine(_customStrings.HelloMessage);

            while(run)
            {
                string command = Console.ReadLine();

                if (command == "Exit") 
                    break;

                ApplyCommand(command);
            }
        }

        /// <summary>
        /// Method finds what command was used.
        /// </summary>
        /// <param name="command">command string</param>
        private void FindCommad(string command)
        {
            command = command.Replace(" ", "").ToUpper();

            if (command == _constantNames.Add())
            {
                AddDialogue();
                return;
            }

            if (command == _constantNames.Take())
            {
                TakeDialogue();
                return;
            }

            if (command == _constantNames.Return())
            {
                ReturnDialogue();
                return;
            }

            if (command == _constantNames.List())
            {
                ListDialogue();
                return;
            }

            if (command == _constantNames.Delete())
            {
                DeleteDialogue();
                return;
            }

            if (command == _constantNames.Help())
            {
                PrintCommandList();
                return;
            }
                
            throw new Exception(_customErrors.CommandNotFoundError);
        }

        /// <summary>
        /// Dialogue method for ADD command.
        /// </summary>
        private void AddDialogue()
        {
            string name = DialoguePartString(_customStrings.CommandAddBookName);

            string[] authors = DialoguePartStringArray(_customStrings.CommandAddBookAuthors);

            string[] categories = DialoguePartStringArray(_customStrings.CommandAddBookCategories);

            string language = DialoguePartString(_customStrings.CommandAddBookLanguage);

            string publicationDate = DialoguePartString(_customStrings.CommandAddBookPublicationDate);

            string isbn = DialoguePartString(_customStrings.CommandAddBookISBN);

            _libraryController.Add(name, authors, categories, language, publicationDate, isbn);
            Console.WriteLine(_customStrings.CommandAddSuccess);
        }

        /// <summary>
        /// Dialogue method for TAKE command.
        /// </summary>
        private void TakeDialogue()
        {
            string name = DialoguePartString(_customStrings.CommandTakeBookName);

            string userName = DialoguePartString(_customStrings.CommandTakeUserName);

            string days = DialoguePartString(_customStrings.CommandTakeDays);

            _libraryController.Take(name, userName, days);
            Console.WriteLine(_customStrings.CommandTakeSuccess);
        }

        /// <summary>
        /// Dialogue method for RETURN command.
        /// </summary>
        private void ReturnDialogue()
        {
            string name = DialoguePartString(_customStrings.CommandReturnBookName);

            _libraryController.Return(name);
            Console.Write(_customStrings.CommandReturnSuccess);
        }

        /// <summary>
        /// Dialogue method for DELETE command.
        /// </summary>
        private void DeleteDialogue()
        {
            string name = DialoguePartString(_customStrings.CommandDeleteBookName);

            string isbn = DialoguePartString(_customStrings.CommandDeleteBookISBN);

            _libraryController.Delete(name, isbn);
            Console.Write(_customStrings.CommandDeleteSuccess);
        }

        /// <summary>
        /// Dialogue method for LIST command.
        /// </summary>
        private void ListDialogue()
        {
            Console.Write(_customStrings.CommandListBookFilter);
            string filter = Console.ReadLine()
                .Replace(_customStrings.CommandListBookFilter, "")
                .Trim();

            string key = "";
            if (filter != "")
            {
                Console.Write(_customStrings.CommandListBookFilterKey);
                key = Console.ReadLine()
                    .Replace(_customStrings.CommandListBookFilterKey, "")
                    .Trim();
            }

            var bookList = _libraryController.List(filter, key);
            PrintList(bookList);
        }

        /// <summary>
        /// Method reads command line and extracts data.
        /// </summary>
        /// <param name="dialogue">Dialogue string</param>
        /// <returns>Data from string</returns>
        private string DialoguePartString(string dialogue)
        {
            Console.Write(dialogue);
            string data = Console.ReadLine()
                .Replace(dialogue, "")
                .Trim();
            CheckIfMissing(data);
            return data;
        }

        /// <summary>
        /// Method reads command line and extracts data.
        /// </summary>
        /// <param name="dialogue">Dialogue string</param>
        /// <returns>Data from string</returns>
        private string[] DialoguePartStringArray(string dialogue)
        {
            Console.Write(_customStrings.CommandAddBookAuthors);
            string[] data = Console.ReadLine()
                .Replace(_customStrings.CommandAddBookAuthors, "")
                .Trim()
                .Split(", ");
            CheckIfMissing(data);
            return data;
        }

        /// <summary>
        /// Method checks if input data is given
        /// </summary>
        /// <param name="data">input data</param>
        private void CheckIfMissing(string data)
        {
            if (data == "")
                throw new Exception(_customErrors.MissingArgumentMessage);
        }

        /// <summary>
        /// Method checks if input data is given
        /// </summary>
        /// <param name="data">input data</param>
        private void CheckIfMissing(string[] data)
        {
            if (data[0] == "")
                throw new Exception(_customErrors.MissingArgumentMessage);
        }

        /// <summary>
        /// Method prints all available commands and what they do.
        /// </summary>
        private void PrintCommandList()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(_customStrings.CommandListMessage);
            Console.WriteLine(_customStrings.CommandAdd);
            Console.WriteLine(_customStrings.CommandTake);
            Console.WriteLine(_customStrings.CommandReturn);
            Console.WriteLine(_customStrings.CommandList);
            Console.WriteLine(_customStrings.CommandDelete);
            Console.WriteLine(_customStrings.CommandHelp);
            Console.WriteLine(_customStrings.CommandExit);


            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Method calls find command and if nay problems occur, then it shows error.
        /// </summary>
        /// <param name="command">command string</param>
        private void ApplyCommand(string command)
        {
            try
            {
                FindCommad(command);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        /// <summary>
        /// Method prints given book list.
        /// </summary>
        /// <param name="bookList">library book list to print</param>
        public void PrintList(List<LibraryBook> bookList)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(_customStrings.TableHeader);
            Console.WriteLine(_customStrings.TableGuideLine);

            foreach(var book in bookList)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}
