using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CsharpAdvancedConcepts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Implicitly Typed Local Variables

        /// <summary>
        /// This method is used to describe the concept of Implicitly Typed Local Variables.
        /// The keyword "var" enables you to declare variables whose type will be implicity inferred.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdImplicitlyTypedLocalVariables_Click(object sender, EventArgs e)
        {
            //This creates an integer
            var i = 1;

            //This creates a string
            var s = "Test String";

            //This creates an integer array
            var intArr = new[] { 1, 2, 3, 4 };

            //Prove the types
            lblImplicityTyped.Text = "i is of type: " + i.GetType().ToString();
            lblImplicityTyped.Text += "     s is of type: " + s.GetType().ToString();
            lblImplicityTyped.Text += "     intArr is of type: " + intArr.GetType().ToString();
        }

        #endregion

        #region Anonymous Types

        /// <summary>
        /// This method is used to describe the concept of Anonymous Types.
        /// Anonymous Types allows you to create an instance of a class without having to write code for the class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAnonymousTypes_Click(object sender, EventArgs e)
        {
            //Create a class with attributes "color", "make", "bHasFourWheelDrive", and "iNumWheels"
            var car = new { color = "Red", make = "Ford", bHasFourWheelDrive = false, iNumWheels = 4 };
            
            //This is not valid because the properties are read-only
            //car.color = "Blue";

            //Show that C# creates a class for us.
            lblAnonymousTypes.Text = car.GetType().ToString();
        }

        #endregion

        #region Extension Methods

        /// <summary>
        /// Extension methods allow developers to add new methods to the public contract of an existing CLR type, 
        /// without having to sub-class it or recompile the original type.  
        /// Extension Methods help blend the flexibility of "duck typing" support popular within dynamic 
        /// languages today with the performance and compile-time validation of strongly-typed languages.
        /// 
        /// http://weblogs.asp.net/scottgu/archive/2007/03/13/new-orcas-language-feature-extension-methods.aspx
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExtensionMethods_Click(object sender, EventArgs e)
        {
            string s = "10";
            int k = 5;

            //Use the extension methods
            int i = s.AddOneToStringValue();
            int j = k.SubtractOneToIntValue();

            lblExtensionMethods.Text = "i = " + i.ToString() + "     j = " + j.ToString();
        }

        #endregion

        #region Anonymous Methods and Lambda Expressions

        /// <summary>
        /// Delegate that defines a method that returns an integer and takes an integer as a paramter.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        delegate int MyDelegate(int i);

        /// <summary>
        /// Although Lambda expressions may appear to be simply a more concise way of writing anonymous methods, 
        /// in reality they also are a functional superset of anonymous methods. 
        /// Specifically, Lambda expressions offer the following additional functionality:
        /// - They permit parameter types to be inferred. Anonymous methods will require you to 
        ///   explicitly state each and every type. 
        /// - They can hold either query expressions or C# statements. 
        /// - They can be treated as data using expression trees.  This cannot be done using Anonymous methods.
        /// 
        /// http://www.developer.com/net/csharp/article.php/10918_3561756_2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAnonymousMethods_Click(object sender, EventArgs e)
        {
            //This is how you had to do it in .NET 1.1 or earlier
            MyDelegate DelegateToHoldSquareMethod = new MyDelegate(Square);
            lblAnonymousMethods.Text = DelegateToHoldSquareMethod(5).ToString();

            //This is how you can do it with .NET 2.0 or above using anonymous methods
            //Since there is not much to the method you can just write it inline
            MyDelegate DelegateToHoldAnonymousMethod = delegate(int i)
                                                        {
                                                            return i * i;
                                                        };
            lblAnonymousMethods.Text += "     " + DelegateToHoldAnonymousMethod(6);


            //This is a lamda expression that allows you to write anonymous methods in a more concise manner.
            MyDelegate DelegateToHoldLamdaExpression = (int i) =>
                                                        {
                                                            int j = 2;
                                                            return i * j;
                                                        };

            lblAnonymousMethods.Text += "     " + DelegateToHoldLamdaExpression(7);
        }

        /// <summary>
        /// Square the number passed in.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        int Square(int i)
        {
            return i * i;
        }

        #endregion

        # region Auto Implemented Properties

        /// <summary>
        /// Example of a auto implemented property.  The compiler will generate a private variable for you.
        /// </summary>
        public string MyTestAutoImplementedProperty { get; set; }

        #endregion

    }
}
