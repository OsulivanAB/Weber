using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Media.Imaging;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Resources;

namespace Assignment_5
{
    public class clsScenario
    {

        /// <summary>
        /// Manages Access to database
        /// </summary>
        public clsDataAccess MyDataManager { get; set; }
        /// <summary>
        /// Random number generator.
        /// </summary>
        public Random myRandomGenerator { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public clsScenario()
        {
        }

        /// <summary>
        /// Generates a random scenario that is applicable to the current game type
        /// </summary>
        /// <param name="gameType"></param>
        /// <returns></returns>
        public int getRandomScenario(string gameType)
        {
            try
            {
                int maximumID;  // Variable to hold the maximum ID from the table
                string sSQL;    // Variable to hold the sql statement
                string Result;  // Variable to hold the result of the SQL Statement
                int randomScenario; // Variable to hold the random scenario
                do
                {
                    sSQL = "Select MAX(ScenarioID) FROM tblScenarios";   // SQL Statement
                    Result = MyDataManager.ExecuteScalarSQL(sSQL);   // Execute the sql statement
                    Int32.TryParse(Result, out maximumID);  // Attempt to parse the string to an int value
                    randomScenario = myRandomGenerator.Next(1, maximumID + 1);  // Id of the random Scenario
                } while (!testValidScenario(gameType, randomScenario));

                return randomScenario;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Tests to see if a scenario and game type are compatible.
        /// </summary>
        /// <param name="gameType">3 Letter abreviation for game type</param>
        /// <param name="randomScenario">Scenario ID</param>
        /// <returns></returns>
        private bool testValidScenario(string gameType, int randomScenario)
        {
            try
            {
                string sSQL = String.Format("Select Count(*) FROM tblScenarios WHERE {0} = true AND ScenarioID = {1}", gameType, randomScenario);    // SQL Query
                string Result = MyDataManager.ExecuteScalarSQL(sSQL);   // Execute the sql statement
                return Result == "1" ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Gets a friend Image for the given scenario
        /// </summary>
        /// <param name="scenario">Scenario ID</param>
        /// <returns>BitmapImage of the friend.</returns>
        internal BitmapImage getFriendImage(int scenario, int option, string gameType, bool bResult)
        {
            try
            {
                int imageType = 1; // Friend Picture
                int QuestionStatusID;   // Holds Question Status variable
                switch (option)
                {
                    // New Question
                    case 1:
                        QuestionStatusID = 1;
                        break;
                    // Not new question
                    default:
                        switch (bResult)
                        {
                            // Correct Answer
                            case true:
                                QuestionStatusID = 2;
                                break;
                            // Incorrect Answer
                            default:
                                QuestionStatusID = 3;
                                break;
                        }
                        break;
                }
                string sSQL = String.Format("Select Path FROM tblImages WHERE ScenarioID = {0} AND GameTypeCode = '{1}' AND QuestionStatusID = {2} AND ImageTypeID = {3}", scenario, gameType, QuestionStatusID, imageType);    // SQL Query
                string Result = MyDataManager.ExecuteScalarSQL(sSQL);   // Execute the sql statement
                return new BitmapImage(new Uri(Result, UriKind.Relative));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Set the background of the window depending on the scenario.
        /// </summary>
        /// <param name="scenario">Scenario ID</param>
        /// <returns>Brush that can be applied as the background</returns>
        internal Brush getScenarioBackground(int scenario)
        {
            try
            {
                string imageType = "3"; // Background
                string sSQL = String.Format("SELECT Path FROM tblImages WHERE ScenarioID = {0} and ImageTypeID = {1}", scenario, imageType);    // Prepare Query
                string sResults = MyDataManager.ExecuteScalarSQL(sSQL); // Execute Query
                Uri resourceUri = new Uri(sResults, UriKind.Relative);  // Create Uri with Path
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri); //Create StreamResourceInfo to hold information for Background
                BitmapFrame myBitMap = BitmapFrame.Create(streamInfo.Stream); // Create bitmapframe from streamresource  
                var myBrush = new ImageBrush(); // Create a brush
                myBrush.ImageSource = myBitMap; // Turn the Bitmap Frame into a brush
                return myBrush;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Figures out which images we need to do, how many we need to do, and populates them into the wrap panel.
        /// </summary>
        /// <param name="scenario">Scenario ID</param>
        /// <param name="questionStatus">Question Satus ID</param>
        /// <param name="gameType">Game Type Code</param>
        /// <param name="wpScenarioObjects">Reference to Wrap Panel Object</param>
        /// <param name="currentProblem">Current Math Problem</param>
        internal void getDisctinctItemImages(int scenario, int questionStatus, string gameType, WrapPanel wpScenarioObjects, clsMathProblem currentProblem)
        {
            try
            {
                string ImageType = "2"; // Item Image
                int iRet = -1; // Will Hold Return Row Count

                // Create SQL Statement
                string sSql = String.Format(
                    "SELECT BasedonVariable, Path, Opacity, Width " +
                    "FROM tblImages " +
                    "WHERE ScenarioID = {0} AND GameTypeCode = '{1}' AND QuestionStatusID = {2} AND ImageTypeID = {3}"
                    , scenario, gameType, questionStatus, ImageType);

                DataSet dData = MyDataManager.ExecuteSQLStatement(sSql, ref iRet);  // Execute SQL

                // Create and populate images
                foreach (DataRow row in dData.Tables[0].Rows)
                {
                    // The number of item images is always based on a variable, but not always the same variable
                    switch (row.ItemArray[0].ToString())
                    {
                        // if image is based on the first number
                        case "FirstNumber":
                            for (int i = 0; i < currentProblem.iFirstNumber; i++)
                            {
                                // Get Items from Row
                                string path = row.ItemArray[1].ToString(); // Path to image
                                string sOpacity = row.ItemArray[2].ToString(); // Opacity
                                string sWidth = row.ItemArray[3].ToString(); // Width
                                Image myImage = createImage(path, sOpacity, sWidth);
                                wpScenarioObjects.Children.Add(myImage);
                            }
                            break;
                        // if image is based on the second number
                        case "SecondNumber":
                            for (int i = 0; i < currentProblem.iSecondNumber; i++)
                            {
                                // Get Items from Row
                                string path = row.ItemArray[1].ToString(); // Path to image
                                string sOpacity = row.ItemArray[2].ToString(); // Opacity
                                string sWidth = row.ItemArray[3].ToString(); // Width
                                Image myImage = createImage(path, sOpacity, sWidth);
                                wpScenarioObjects.Children.Add(myImage);
                            }
                            break;
                        // if image is based on the Answer Number
                        case "AnswerNumber":
                            for (int i = 0; i < currentProblem.iAnswer; i++)
                            {
                                // Get Items from Row
                                string path = row.ItemArray[1].ToString(); // Path to image
                                string sOpacity = row.ItemArray[2].ToString(); // Opacity
                                string sWidth = row.ItemArray[3].ToString(); // Width
                                Image myImage = createImage(path, sOpacity, sWidth);
                                wpScenarioObjects.Children.Add(myImage);
                            }
                            break;
                        // There really shouldn't be any item pictures that aren't associated to either the first or second number
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Creates an image based on string inputs.
        /// </summary>
        /// <param name="path">Path to Image.</param>
        /// <param name="sOpacity">(string)Opacity</param>
        /// <param name="sWidth">(string)Width</param>
        /// <returns>Image.</returns>
        private Image createImage(string path, string sOpacity, string sWidth)
        {
            try
            {
                double dOpacity = -1;    // Variable to hold opacity after we convert it
                int iWidth = -1;    // Variable to hold width after we convert it
                Image myImage = new Image();    // Create new Image Object
                myImage.Source = new BitmapImage(new Uri(path, UriKind.Relative));  // Create a new Bitmap image and store it in the image object

                // Check if there is a value for opacity
                switch (sOpacity)
                {
                    // Opacity is blank
                    case "":
                        break;
                    // Opacity is not blank
                    default:
                        int iOpacity = -1;  // Variable to parse opacity into
                        Int32.TryParse(sOpacity, out iOpacity); // Attempt to parse
                        dOpacity = (double)iOpacity / 100;   // Convert Opacity to decimal
                        myImage.Opacity = dOpacity; // Set Opacity
                        break;
                }

                // Check if there is a value for width
                switch (sWidth)
                {
                    // Width is blank
                    case "":
                        break;
                    // Width is not blank
                    default:
                        Int32.TryParse(sWidth, out iWidth); // Attempt to parse
                        myImage.Width = iWidth; // Set Width
                        break;
                }
                return myImage;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Generates a string to populate the billboard data
        /// </summary>
        /// <param name="scenario"></param>
        /// <param name="getFirstNumber"></param>
        /// <param name="getSecondNumber"></param>
        /// <param name="getGametype"></param>
        /// <returns></returns>
        internal string getBillboardInfo(int scenario, string Gametype, clsMathProblem currentProblem)
        {
            try
            {
                string[] variables = getMessageVariables(scenario, Gametype, currentProblem); // Create an array to hold data variables
                string message = getMessage(scenario, Gametype);
                return string.Format(message, variables);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        private string getMessage(int scenario, string gametype)
        {
            try
            {
                string sSQL = String.Format("SELECT Message FROM tblMessages WHERE scenarioID = {0} AND  GameTypeCode = '{1}';", scenario.ToString(), gametype);
                return MyDataManager.ExecuteScalarSQL(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves Variables from the database
        /// </summary>
        /// <returns>Array of variables</returns>
        private string[] getMessageVariables(int scenario, string Gametype, clsMathProblem currentProblem)
        {
            try
            {
                int variableCount = getVariableCount(scenario, Gametype); // Number of variables for message
                string[] variables = new string[variableCount]; // Create an array to hold the variables
                string sSQL = String.Format("SELECT b.messageID, b.index, b.variable, b.basedOnVariable FROM tblMessages a INNER JOIN tblplMessageIndex b ON a.MessageID = b.MessageID WHERE a.ScenarioID = {0} AND GameTypeCode = '{1}' ORDER BY b.index ASC", scenario.ToString(), Gametype);  // SQL Statement
                int iRet = -1;  // Variable to hold the return row count
                DataSet dData = MyDataManager.ExecuteSQLStatement(sSQL, ref iRet);  // Execute SQL
                for (int i = 0; i < dData.Tables[0].Rows.Count; i++)
                {
                    int index = i;  // variable index
                    string messageID = dData.Tables[0].Rows[i].ItemArray[0].ToString(); // Message ID as string
                    string variable = dData.Tables[0].Rows[i].ItemArray[2].ToString(); // Variable
                    string basedOnVariable = dData.Tables[0].Rows[i].ItemArray[3].ToString();   // If it's a variable based on a number, this is which number
                    switch (variable)
                    {
                        case "FirstNumber":
                            variables[i] = currentProblem.iFirstNumber.ToString();
                            break;
                        case "SecondNumber":
                            variables[i] = currentProblem.iSecondNumber.ToString();
                            break;
                        case "NewLine":
                            variables[i] = Environment.NewLine;
                            break;
                        default:
                            variables[i] = getSepecificVariable(messageID, index, basedOnVariable, currentProblem);
                            break;
                    }
                }
                return variables;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Retrieves a specific custom variable from tblCustomWords
        /// </summary>
        /// <param name="messageID">Message ID formatted as a string</param>
        /// <param name="index">Desired variable index within message string</param>
        /// <param name="firstNumber">Firstnumber value</param>
        /// <param name="secondNumber">Secondnumber Value</param>
        /// <returns>Variable for requested index of the message.</returns>
        private string getSepecificVariable(string messageID, int index, string basedOnVariable, clsMathProblem currentProblem)
        {
            try
            {
                string plural;  // Holds whether the custom variable is plural or not
                string sSQL;    // Will hold the sql statement

                // Check Which variable (if any) that the custom variable is based on 
                switch (basedOnVariable)
                {
                    // If it is based on the First number, check if the first number is plural
                    case "FirstNumber":
                        // if the first number is 1, then set plural to False, otherwise set it to true
                        plural = currentProblem.iFirstNumber == 1 ? "False" : "True";
                        sSQL = String.Format("SELECT word FROM tblCustomWords WHERE messageID = {0} AND index = {1} AND plural = {2}", messageID, index.ToString(), plural);
                        break;
                    // If it is based on the Second number, check if the second number is plural
                    case "SecondNumber":
                        plural = currentProblem.iSecondNumber == 1 ? "False" : "True";
                        sSQL = String.Format("SELECT word FROM tblCustomWords WHERE messageID = {0} AND index = {1} AND plural = {2}", messageID, index.ToString(), plural);
                        break;
                    // If it isn't based on those two numbers, then we don't even need to use the plural variable
                    default:
                        sSQL = String.Format("SELECT word FROM tblCustomWords WHERE messageID = {0} AND index = {1}", messageID, index.ToString());
                        break;
                }
                return MyDataManager.ExecuteScalarSQL(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Finds out what the maximum # of variables is for a billboard message
        /// </summary>
        /// <returns>The maximum number of variables needed in a Billboard message</returns>
        private int getVariableCount(int scenario, string GameType)
        {
            try
            {
                string sSQL = String.Format("SELECT COUNT(*) FROM tblMessages a INNER JOIN tblplMessageIndex b ON a.MessageID = b.MessageID WHERE a.ScenarioID = {0} AND GameTypeCode = '{1}'", scenario.ToString(), GameType);  // SQL Statement
                string Results = MyDataManager.ExecuteScalarSQL(sSQL);  // Execute the SQL
                int variableCount = -1;  // Variable to hold the results when we get them
                Int32.TryParse(Results, out variableCount);  // Parse Results
                return variableCount;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
