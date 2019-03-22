#region Namespaces
using RockPaperScissor.Business;
using RockPaperScissor.Business.Implementation;
using RockPaperScissor.Business.Interfaces;
using System;
using System.Web;
using Unity;
#endregion
public partial class RockPaperScissiorUI : System.Web.UI.Page
{
    #region Global Variables
    private Gamer gamer;
    #endregion
   
    #region Page Events
    /// <summary>
    /// Page Load.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    ///
    protected void Page_Load(object sender, EventArgs e)
    {

        ////Register Unity container
        IUnityContainer unitycontainer = new UnityContainer();

        unitycontainer.RegisterType<IGamer, Gamer>();

        //Resolve dependency
        gamer = unitycontainer.Resolve<Gamer>();

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void StartGame_Click(object sender, EventArgs e)
    {
        if (RadioRock.Checked || RadioPaper.Checked || RadioScissor.Checked)
        {
            GetResults();

            lblfinalresult.Text = DisplayResult();
           
        }
    }

    #endregion
   
    #region Page Methods

    /// <summary>
    /// Method will matches with user input request.
    /// </summary>
    private void GetResults(){

        int userinput = UserSelection();
        int computerinput = gamer.ComputerSelection();
        string selectedResult = gamer.CompulterSelectedString(computerinput);
        int finalId = gamer.SelectWinner(computerinput, userinput);
        string result = gamer.GameResult(finalId);
        lblSelectedResult.Visible = true;
        lblSelectedResult.Text = selectedResult;
        lblResult.Text = result;
        lblResult.Visible = true;
        lblfinalresult.Visible = true;
    }
    private int UserSelection()
    {
        int userinput = 0;
        if (RadioRock.Checked)
        {
            userinput = (int)Helper.UserInput.Rock;
        }
        else if (RadioPaper.Checked)
        {
            userinput = (int)Helper.UserInput.Paper;
        }
        else
        {
            userinput = (int)Helper.UserInput.Scissor;
        }
        return userinput;

    }
    /// <summary>
    /// Display the Final Result.
    /// </summary>
    private string DisplayResult()
    {
        int userCount = HttpContext.Current.Session["USER_COUNR"] != null ? Convert.ToInt32(HttpContext.Current.Session["USER_COUNR"]) : 0;
        int computerCount = HttpContext.Current.Session["COMPUTER_COUNT"] != null ? Convert.ToInt32(HttpContext.Current.Session["COMPUTER_COUNT"]) : 0;
        lblComScoreText.Visible = true;
        lblUserScoreTxt.Visible = true;
        lblComScoreText.Visible = true;
        lblComputer.Visible = true;
        lblUserScore.Visible = true;
        lblUserScore.Text = userCount.ToString();
        lblComputer.Text = computerCount.ToString();
        string result = gamer.DisplayResult(userCount, computerCount);

        if (HttpContext.Current.Session["TOTAL_SCORE"] != null)
        {
            if (Convert.ToUInt32(HttpContext.Current.Session["TOTAL_SCORE"]) == 3)
            {
                //clear session and input request.
                RadioScissor.Checked = false;
                RadioPaper.Checked = false;
                RadioRock.Checked = false;
                HttpContext.Current.Session["TOTAL_SCORE"] = 0;
                HttpContext.Current.Session["USER_COUNR"] = 0;
                HttpContext.Current.Session["COMPUTER_COUNT"] = 0;
            }
        }

        return result;
    }

    #endregion
}