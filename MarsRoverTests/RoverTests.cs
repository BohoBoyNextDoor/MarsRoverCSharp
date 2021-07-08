using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
    
        
        
        //verifies the constructor sets default position, as per book. also changed code in rover constructor
        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover test_rover = new Rover(1);
            Assert.AreEqual(test_rover.Position, 1, .1);
        }

        
        
        //verifies the constructor sets default positio, as per book. also added in new rover constructor
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover test_rover = new Rover("NORMAL");
            Assert.AreEqual(test_rover.Mode, "NORMAL");
        }


        //verifies the constructor sets default watts, as per book. added in new rover constructor
        [TestMethod]
        public void ConstructorSetsDefaultWatts()
        {
            Rover test_rover = new Rover(75.8);
            Assert.AreEqual(test_rover.GeneratorWatts, 75.8, .001);
        }



        //verifies the mode changes using recievecommand method i wrote
        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover test_rover = new Rover(250);
            Command cmdOne = new Command("MODE",25,"LOW_POWER");
            Command[] cmdArry = new Command[]
                {
                cmdOne
                };
            Message msg = new Message("MODE", cmdArry);
            Rover.RecieveCommand(msg, test_rover);
            Assert.AreNotEqual("NORMAL", test_rover.Mode);
        }
        
        
        
        //this test uses the newly created constructor to start at LOW_POWER, then attempts to move the rover
        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Rover test_rover = new Rover("LOW_POWER", 75, 100);
            Command cmd = new Command("MOVE", 0);
            Command[] cmdArry = new Command[]
                {
                cmd
                };
            Message msg = new Message("MOVE",cmdArry);
            
            try
            {
                Rover.RecieveCommand(msg, test_rover);
            }
            catch (SystemException ex)
            {
                Assert.AreEqual("In LOW_POWER mode. Try again later", ex.InnerException);
            }
        }




        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover test_rover = new Rover("NORMAL", 100, 100);
            Command cmd = new Command("MOVE", 25, "NORMAL");
            Command[] cmdArry = new Command[]
            {
            cmd
            };
            Message msg = new Message("MOVE", cmdArry);
            Rover.RecieveCommand(msg, test_rover);
            Assert.AreEqual(25, test_rover.Position);
        }
    
    
    
    
    }
}
