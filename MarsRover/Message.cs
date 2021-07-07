using System;
namespace MarsRover
{
    public class Message
    {
        
        //I created this constructor using the autocreate feature native to VS. It checks to see if the arguments
        //are null, and throws exceptions if they are
        public Message(string name, Command[] commands)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public string Name { get; set; }
        public Command[] Commands { get; set; }

        
    }
}
