using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; }
        public double NewPostion { get; set; }
        public string NewMode { get; set; }


        public Command() { }

        public Command(string commandType)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
        }

        public Command(string commandType, double value)
        {
            CommandType = commandType;
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            NewPostion = value;
        }
        
        
        //this is the first bit I wrote per the assignment. The prompt wants the functionality of three arguements
        //specifically, so I included an exception for no command type, the NewPosition will auto default to 0, which
        //is valid, and throws exception for modeType void as well.
        public Command(string commandType, double value, string modeType)
        {
            if (String.IsNullOrEmpty(commandType) || (String.IsNullOrEmpty(modeType)))
            {
                throw new ArgumentNullException(commandType, "Invalid information.");
            }
            NewPostion = value;
            NewMode = modeType;
            CommandType = commandType;
        }

    }
}
