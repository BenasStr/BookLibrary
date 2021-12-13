using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Res
{
    /// <summary>
    /// Class that holds all custom errors.
    /// </summary>
    class CustomErrors
    {
        public readonly string CommandMissingArrayError = "Missing array element!";

        public readonly string CommandAdditionalArrayError = "Too many arrays in command!";

        public readonly string CommandTooManyArgumentsError = "Too many arguments passed!";

        public readonly string CommandNotEnoughArgumentsError = "Not enough arguments!";

        public readonly string CommandNotFoundError = "Couldn't find command!";

        public readonly string CommmandNumberError = "There shouldn't be letters in number column!";

        public readonly string CouldNotFind = "Could not find!";

        public readonly string WasNotTaken = "This book wasn't taken!";

        public readonly string UserReachedLimit = "You have taken 3 books already!";

        public readonly string MissingArgumentMessage = "Missing argument!";

        public readonly string CouldNotFindFilter = "Couldn't find filter!";
    }
}
