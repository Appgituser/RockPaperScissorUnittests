using RockPaperScissor.Business.Interfaces;
using System;
using System.Linq;
using System.Web;

namespace RockPaperScissor.Business.Implementation
{
    /// <summary>
    /// Class contains methods for Gamer interface.
    /// </summary>
    public class Gamer : IGamer
    {
        #region DisplayResult
        /// <summary>
        /// Methid display the final result.
        /// </summary>
        /// <param name="userCount"></param>
        /// <param name="computerCount"></param>
        /// <returns></returns>
        public string DisplayResult(int userCount, int computerCount)
        {
            string result = string.Empty;
            if (HttpContext.Current.Session["TOTAL_SCORE"] != null)
            {
                if (Convert.ToUInt32(HttpContext.Current.Session["TOTAL_SCORE"]) == 3)
                {
                    if (userCount > computerCount)
                    {

                        result = Helper.USERFINALWINNER;
                    }
                    else if (computerCount > userCount)
                    {

                        result = Helper.COMPUTERFINALWINNER;
                    }
                    if (new[] { userCount, computerCount }.All(x => x == 0))
                    {

                        result = Helper.DRAWGAME;
                    }
                }
            }

            return result;
        }

        #endregion

        #region CompulterSelectedString
        /// <summary>
        /// Method to return computer selected string.
        /// </summary>
        /// <param name="comChoice"></param>
        /// <returns></returns>
        public string CompulterSelectedString(int comChoice)
        {
            string computerSelected = string.Empty;
            switch (comChoice)
            {
                case 1:
                    computerSelected =Helper.COMPUTERROCK;
                    break;
                case 2:
                    computerSelected = Helper.COMPUTERPAPER;
                    break;
                case 3:
                    computerSelected = Helper.COMPUTERSCISSORS;
                    break;
            }
            return computerSelected;
        }

        #endregion

        #region SelectWinner
        /// <summary>
        /// Method compare user choice and computer choice.
        /// </summary>
        /// <param name="comChoice"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public int SelectWinner(int comChoice, int input)
        {
            int flagNum = 0;
            switch (comChoice)
            {
                case 1:
                    if (input == (int)Helper.UserInput.Rock)
                    {
                        flagNum = 3;
                    }
                    else if (input == (int)Helper.UserInput.Paper)
                    {
                        flagNum = 1;
                    }
                    else if (input == (int)Helper.UserInput.Scissor)
                    {
                        flagNum = 2;
                    }
                    break;
                case 2:

                    if (input == (int)Helper.UserInput.Rock)
                    {
                        flagNum = 2;
                    }
                    else if (input == (int)Helper.UserInput.Paper)
                    {
                        flagNum = 3;

                    }
                    else if (input == (int)Helper.UserInput.Scissor)
                    {
                        flagNum = 1;
                    }
                    break;
                case 3:

                    if (input == (int)Helper.UserInput.Rock)
                    {
                        flagNum = 1;
                    }
                    else if (input == (int)Helper.UserInput.Paper)
                    {
                        flagNum = 2;
                    }
                    else if (input == (int)Helper.UserInput.Scissor)
                    {
                        flagNum = 3;
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            return flagNum;

        }

        #endregion

        #region Game Result

        /// <summary>
        /// Method return current game winner.
        /// </summary>
        /// <param name="flagNum"></param>
        /// <returns></returns>
        public string GameResult(int flagNum)
        {

            int userScore;
            int comScore;
            int totalScore;
            string result = string.Empty;

            userScore = HttpContext.Current.Session["USER_COUNR"] != null ?
                userScore = Convert.ToInt32(HttpContext.Current.Session["USER_COUNR"]) : 0;

            comScore = HttpContext.Current.Session["COMPUTER_COUNT"] != null ?
                Convert.ToInt32(HttpContext.Current.Session["COMPUTER_COUNT"]) : 0;

            totalScore = HttpContext.Current.Session["TOTAL_SCORE"] != null ?
                Convert.ToInt32(HttpContext.Current.Session["TOTAL_SCORE"]) : 0;

            switch (flagNum)
            {
                case 1:
                    result = Helper.USERWINNER;
                    userScore++;
                    HttpContext.Current.Session["USER_COUNR"] = userScore;
                    totalScore++;
                    HttpContext.Current.Session["TOTAL_SCORE"] = totalScore;
                    break;
                case 2:
                    result = Helper.COMPUTERWINNER;
                    comScore++;
                    HttpContext.Current.Session["COMPUTER_COUNT"] = comScore;
                    totalScore++;
                    HttpContext.Current.Session["TOTAL_SCORE"] = totalScore;
                    break;
                case 3:
                    result = Helper.DRAW;
                    break;
                default:
                    break;
            }
            return result;

        }

        #endregion

        #region Computer Selection
        /// <summary>
        /// Method returns computer selected input.
        /// </summary>
        /// <returns></returns>
        public int ComputerSelection()
        {
            //Random number for Computer choice.
            Random rnd = new Random(DateTime.Now.Millisecond);
            int comChoice;
            comChoice = rnd.Next(1, 4);

            return comChoice;
        }

        #endregion
    }
}
