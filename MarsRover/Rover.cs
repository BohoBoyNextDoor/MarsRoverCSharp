using System;
using System.Linq;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public double Position { get; set; }
        public double GeneratorWatts { get; set; }



        //edited to make pass test 8, side note, spent a million years trynna figure out why it wouldn't work
        //i had assigned position = Position thus making it always 0. Learning moment to bring up with class.
        public Rover(int position)
        {
            Position = position;
        }

        //created this constructor to accept the mode, as per assignment
        public Rover(string mode)
        {
            Mode = mode;
        }

        //created this constructor to accept the watts, as per assignment. Decidied it should never be negative.
        //made watts be a double so that it would work cause position is an int. Used a ternery cause I wented to.
        public Rover(double generatorwatts)
        {
            GeneratorWatts = generatorwatts >= 0 ? generatorwatts : throw new Exception("Can't be less than 0");
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts;
        }


        //creates new method to accept and execute a command. this will be tested in tests 11, 12, and 13.
        //I'll begin by creating a method which accepts a message as an argument. then it will assign the values
        //starting with mode. if the mode != assigned to "LOW-POWER" and the watts>0, it will then move. Prevents 
        //any other mode than "NORMAL" and LOW-POWER" and won't allow watts <0 cause I just don't think it's possible



        public static void RecieveCommand(Message message)
        {
            Rover arbRover = new Rover(0);
            Command[] commandArray = message.Commands;
            string tentativeMode;
            string tentativeCommandType;
            double tentativePosition;

            foreach (Command command in commandArray)
            {
                tentativeMode = command.NewMode;
                tentativePosition = command.NewPostion;
                tentativeCommandType = command.CommandType;


                // here begins branching. we have the initial split between the command types. First we branch down the 
                //invalid command path. then we move to the mode change path. finally we branch down the move path

                //invalid command path    
            if ((tentativeCommandType != "MOVE") || (tentativeCommandType != "MODE_CHANGE"))
                {
                    throw new Exception("Invalid Command.");
                }

                //mode change path    
            else if (tentativeCommandType == "MODE")
                {
                    arbRover.Mode = arbRover.Mode == "LOW-POWER" ? "NORMAL" : "LOW-POWER";
                    break;
                }

                //move path if watts are less <=0    
            else if (arbRover.GeneratorWatts <= 0)
                {
                    throw new Exception("Insufficient Power");
                }
            
            
            //move branch if in low-power mode    
            else if (arbRover.Mode == "LOW-POWER")
                {
                    throw new Exception ("In LOW-POWER mode. Try again later");            
                }

            //move branch where it actually moves
            else if ((arbRover.GeneratorWatts > 0) && (arbRover.Mode != "LOW-POWER"))
                {
                    arbRover.Position = tentativePosition;
                }
            }

            
            



        }
    }
}
