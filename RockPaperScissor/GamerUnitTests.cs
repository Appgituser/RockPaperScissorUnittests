using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RockPaperScissor.Business.Implementation;
using RockPaperScissor.Business.Interfaces;

namespace RockPaperScissor
{
    [TestClass]
    public class GamerUnitTests
    {
        Gamer gamer = new Gamer();

        /// <summary>
        /// Test method computer selected rock.
        /// </summary>
        [TestMethod]
        public void ComputerSelected_Rock()
        {
            //Arrange
            int selectdValue = gamer.ComputerSelection();
            string expected = "Computer Selected ROCK";
            //Act
            string actual = gamer.CompulterSelectedString(1);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test method computer selected Paper.
        /// </summary>
        [TestMethod]
        public void ComputerSelected_Paper()
        {
            //Arrange
            int selectdValue = gamer.ComputerSelection();
            string expected = "Computer Selected PAPER";
            //Act
            string actual = gamer.CompulterSelectedString(2);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test method computer selected Scissor.
        /// </summary>
        [TestMethod]
        public void ComputerSelected_Scissor()
        {
            //Arrange
            int selectdValue = gamer.ComputerSelection();
            string expected = "Computer Selected SCISSORS";
            //Act
            string actual = gamer.CompulterSelectedString(3);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test method computer selected Value.
        /// </summary>
        [TestMethod]
        public void ComputerSelected_Value()
        {
            //Arrange
            //Act
            int result = gamer.ComputerSelection();
            //Assert
            Assert.IsNotNull(result);
        }



        /// <summary>
        /// Method user selected rock computer selected paper.
        /// </summary>
        [TestMethod]
        public void CompuerSelectedRock_UserPaper()
        {
            //Arrange

            int expected = 1;

            //Act
            int actual = gamer.SelectWinner(1, 2);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Method Computer Selected Rock user selected scissor.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedRock_UserScissor()
        {
            //Arrange

            int expected = 2;

            //Act
            int actual = gamer.SelectWinner(1, 3);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Method Computer Selected Rock user selected Rock.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedRock_UserRock()
        {
            //Arrange

            int expected = 3;

            //Act
            int actual = gamer.SelectWinner(1, 1);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Method Computer Selected paper user selected scissor.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedPaper_UserRock()
        {
            //Arrange

            int expected = 2;

            //Act
            int actual = gamer.SelectWinner(2, 1);
            //Assert
            Assert.AreEqual(actual, expected);
        }


        /// <summary>
        /// Method Computer Selected paper user selected scissor.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedPaper_UserScissor()
        {
            //Arrange

            int expected = 1;

            //Act
            int actual = gamer.SelectWinner(2, 3);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Method Computer Selected paper user selected scissor.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedPaper_UserPaper()
        {
            //Arrange

            int expected = 3;

            //Act
            int actual = gamer.SelectWinner(2, 2);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Method Computer Selected Scissor user selected Rock.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedScissor_UserRock()
        {
            //Arrange

            int expected = 1;

            //Act
            int actual = gamer.SelectWinner(3, 1);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// Method Computer Selected Scissor user selected Paper.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedScissor_UserPaper()
        {
            //Arrange

            int expected = 2;

            //Act
            int actual = gamer.SelectWinner(3, 2);
            //Assert
            Assert.AreEqual(actual, expected);
        }
        /// <summary>
        /// Method Computer Selected Scissor user selected Paper.
        /// </summary>
        [TestMethod]
        public void ComputerSelectedScissor_UserScissor()
        {
            //Arrange
            int expected = 3;

            //Act
            int actual = gamer.SelectWinner(3, 3);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test method user win the Game
        /// </summary>
        [TestMethod]
        public void User_Win_Game()
        {
            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameResult(1)).Returns("User Win !!");
            //Act
            string result = mockObject.Object.GameResult(1);
            //Assert
            Assert.AreEqual(result, "User Win !!");
        }

        /// <summary>
        /// Test method Computer win the Game
        /// </summary>
        [TestMethod]
        public void Computer_Win_Game()
        {
            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameResult(2)).Returns("Computer Win !!");
            //Act
            string result = mockObject.Object.GameResult(2);
            //Assert
            Assert.AreEqual(result, "Computer Win !!");
        }

        /// <summary>
        /// Test method Draw the Game
        /// </summary>
        [TestMethod]
        public void Draw_The_Game()
        {
            //Arrange
            var mockObject = new Mock<IGamer>();
            mockObject.Setup(x => x.GameResult(2)).Returns("Draw !!");
            //Act
            string result = mockObject.Object.GameResult(2);
            //Assert
            Assert.AreEqual(result, "Draw !!");
        }

    }
}
