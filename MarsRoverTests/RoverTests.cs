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
            Command command = new Command { "MOVE",25,"NORMAL" };
            
            
            
            Message message = new Message("Hello", command);
            Rover test_rover = new Rover(222);
            test_rover.RecieveCommand(message);
        }
    }
}
