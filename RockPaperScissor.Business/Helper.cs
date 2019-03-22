namespace RockPaperScissor.Business
{
    /// <summary>
    ///  Helper class
    /// </summary>
    public static class Helper
    {

        #region Constants

        public const string USERFINALWINNER= "Final Winner is User";
        public const string COMPUTERFINALWINNER = "Final Winner is Computer";
        public const string DRAWGAME = "Draw the Game";
        public const string COMPUTERROCK = "Computer Selected ROCK";
        public const string COMPUTERPAPER = "Computer Selected PAPER";
        public const string COMPUTERSCISSORS = "Computer Selected SCISSORS";
        public const string USERWINNER = "User Win !!";
        public const string COMPUTERWINNER = "Computer Win !!";
        public const string DRAW = "Draw !!";

        #endregion

        #region Enum
        /// <summary>
        /// Enum for Rock ,Paper, Scissor selection
        /// </summary>
        public enum UserInput
        {
            Rock = 1, Paper = 2, Scissor = 3
        }

        #endregion
    }
}
