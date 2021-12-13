using System;
using BookLibrary.Data;
using BookLibrary.Data.Models;
using System.Collections.Generic;
using BookLibrary.Res;
using BookLibrary.View;

namespace BookLibrary
{
    class Program
    {
        static void Main(string[] args)
        { 
            ConsoleView program = ConsoleView.Instance();

            program.Start();
        }
    }
}
