using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Res
{
    /// <summary>
    /// Class that holds all necessary names.
    /// </summary>
    class ConstantNames
    {
        //Commands
        private const string ADD = nameof(ADD);
        private const string TAKE = nameof(TAKE);
        private const string RETURN = nameof(RETURN);
        private const string LIST = nameof(LIST);
        private const string DELETE = nameof(DELETE);
        private const string HELP = nameof(HELP);
        private const string EXIT = nameof(EXIT);

        //Fileters
        private const string AUTHOR = nameof(AUTHOR);
        private const string CATEGORY = nameof(CATEGORY);
        private const string LANGUAGE = nameof(LANGUAGE);
        private const string ISBN = nameof(ISBN);
        private const string NAME = nameof(NAME);
        private const string AVAILABLE = nameof(AVAILABLE);
        private const string TAKEN = nameof(TAKEN);

        //String returns
        public string Add() { return ADD; }
        public string Take() { return TAKE; }
        public string Return() { return RETURN; }
        public string List() { return LIST; }
        public string Delete() { return DELETE; }
        public string Help() { return HELP; }
        public string Exit() { return EXIT; }
        public string Author() { return AUTHOR; }
        public string Category() { return CATEGORY; }
        public string Isbn() { return ISBN; }
        public string Name() { return NAME; }
        public string Available() { return AVAILABLE; }
        public string Taken() { return TAKEN; }
        public string Language() { return LANGUAGE; }

    }
}
