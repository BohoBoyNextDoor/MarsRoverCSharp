using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        static Command[] commands = { new Command("MOVE", 36), new Command("MOVE", 36, "NORMAL") };
        Message test_message = new Message("test_message", commands);
        


        //this test validates that the name argument isn't null, as per the assignment
        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("",commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Name Required.", ex.Message);
            }


        }
        //this test validates that the name argument is correctly assigned to name, as per the assignment
        [TestMethod]
        public void ConstructorSetsName()
        {
            Assert.AreEqual(test_message.Name, "test_message");
        }


        //this test validates that the commands property passed in the argument correctly assigns data, as per task
        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Assert.AreEqual(test_message.Commands, commands);
        }



    }
}
