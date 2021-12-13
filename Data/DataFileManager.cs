using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using BookLibrary.Data.Models;
using Newtonsoft.Json;

namespace BookLibrary.Data
{
    /// <summary>
    /// This interface describes file manager class.
    /// </summary>
    public interface IDataFileManager
    {
        public List<LibraryBook> ReadDataFile();
        public void UpdateFileContent(List<LibraryBook> bookList);
    }

    /// <summary>
    /// This class is responsible for json file reading and updating.
    /// </summary>
    class DataFileManager : IDataFileManager
    {
        public readonly string _dataFilePath;

        /// <summary>
        /// Constructor sets data path to file.
        /// </summary>
        public DataFileManager()
        {
            _dataFilePath = @"../../../Data/LibraryBookData.json";
        }

        /// <summary>
        /// Method reads json file and deserializes it to library book list
        /// </summary>
        /// <returns>List of LibraryBooks</returns>
        public List<LibraryBook> ReadDataFile()
        {
            List<LibraryBook> booksList = new List<LibraryBook>();

            string jsonResult = File.ReadAllText(_dataFilePath);
            booksList = JsonConvert.DeserializeObject<List<LibraryBook>>(jsonResult);

            return booksList;
        }

        /// <summary>
        /// Method serializes given data to update json fiel information.
        /// </summary>
        /// <param name="bookList">Book list to serialize</param>
        public void UpdateFileContent(List<LibraryBook> bookList)
        {
            File.WriteAllText(_dataFilePath, JsonConvert.SerializeObject(bookList));
        }
    }
}
