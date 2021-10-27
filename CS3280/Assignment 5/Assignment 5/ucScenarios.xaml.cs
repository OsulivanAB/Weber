using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace Assignment_5
{
    /// <summary>
    /// Interaction logic for ucScenarios.xaml
    /// </summary>
    public partial class ucScenarios : UserControl
    {
        public clsScenario ScenarioLogic { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public ucScenarios()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Updats all pictures related to the scenario
        /// </summary>
        /// <param name="scenario">Scenario ID</param>
        /// <param name="option">1: New Question, 2: Correct Answer, 3: Incorrect Answer</param>
        /// <param name="gameType">Add, Sub, Mul, Div</param>
        public void updateFriendPicture(int scenario, int option, string gameType, bool bResult)
        {
            try
            {
                BitmapImage FriendImage = ScenarioLogic.getFriendImage(scenario, option, gameType, bResult);
                imgAnimalFriend.Source = FriendImage;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Updates any pictures associated with the scenario
        /// </summary>
        /// <param name="scenario">Scenario ID</param>
        /// <param name="getFirstNumber">First number in formula</param>
        /// <param name="getSecondNumber">Second Number in formula</param>
        /// <param name="option">1- New Question, 2- Correct Answer, 3- Incorrect Answer</param>
        internal void updatePictures(int scenario, int questionStatus, string Gametype, clsMathProblem CurrentProblem, bool bResult)
        {
            try
            {
                // Update the Friend Picture
                updateFriendPicture(scenario, questionStatus, Gametype, bResult);
                // Update Item Pictures
                updateItemPictures(scenario, questionStatus, Gametype, CurrentProblem);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Updates any item pictures associated with the scenario
        /// </summary>
        /// <param name="scenario"></param>
        /// <param name="option"></param>
        /// <param name="gameType"></param>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        private void updateItemPictures(int scenario, int questionStatus, string gametype, clsMathProblem currentProblem)
        {
            try
            {
                // Clear out any existing item pictures
                wpScenarioObjects.Children.Clear(); 
                // Generate Item Pictures
                ScenarioLogic.getDisctinctItemImages(scenario, questionStatus, gametype, wpScenarioObjects, currentProblem); 
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
