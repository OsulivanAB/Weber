using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingDataAround
{
    /// <summary>
    /// Class used to manage employee objects.
    /// </summary>
    public class clsEmployeeObjectManager
    {
        /// <summary>
        /// A list of employees.  This list is created then passed around between objects so that only one list of employees exists in the program.
        /// </summary>
        public List<clsEmployee> lstEmployees { get; set; }

        /// <summary>
        /// This is a list of employees that is created in a static object.  Since it is static, the employee list does not "belong" to one object, it exists for all objects to reference.
        /// You can think of it as a global type variable.
        /// </summary>
        public static List<clsEmployee> lstStaticEmplyees { get; set; }

        /// <summary>
        /// Constructor to create our employee lists.
        /// </summary>
        public clsEmployeeObjectManager()
        {
            lstEmployees = new List<clsEmployee>();
            lstStaticEmplyees = new List<clsEmployee>();

            lstEmployees.Add(new clsEmployee { sFirstName = "Shawn", sLastName = "Cowder", iSalary = 50000 });
            lstEmployees.Add(new clsEmployee { sFirstName = "Melissa", sLastName = "Cowder", iSalary = 75000 });
            lstEmployees.Add(new clsEmployee { sFirstName = "Mike", sLastName = "Hoskins", iSalary = 90000 });

            lstStaticEmplyees.Add(new clsEmployee { sFirstName = "Wade", sLastName = "Anderson", iSalary = 10000 });
            lstStaticEmplyees.Add(new clsEmployee { sFirstName = "John", sLastName = "Smith", iSalary = 20000 });
            lstStaticEmplyees.Add(new clsEmployee { sFirstName = "Terry", sLastName = "Smith", iSalary = 30000 });
        }

        /// <summary>
        /// Add a new employee to the list.
        /// </summary>
        /// <param name="FirstName">First name.</param>
        /// <param name="LastName">Last name.</param>
        /// <param name="Salary">Salary.</param>
        public void AddNewEmployee(string FirstName, string LastName, int Salary)
        {
            lstEmployees.Add(new clsEmployee { sFirstName = FirstName, sLastName = LastName, iSalary = Salary });
        }

        /// <summary>
        /// Add a new employee to the static list.
        /// </summary>
        /// <param name="FirstName">First name.</param>
        /// <param name="LastName">Last name.</param>
        /// <param name="Salary">Salary.</param>
        public static void AddNewStaticEmployee(string FirstName, string LastName, int Salary)
        {
            lstStaticEmplyees.Add(new clsEmployee { sFirstName = FirstName, sLastName = LastName, iSalary = Salary });
        }

        /// <summary>
        /// Create a string to report the employee data.
        /// </summary>
        /// <returns>String of employee data.</returns>
        public string CreateReportString()
        {
            string sDataToReport = "";

            foreach (clsEmployee clsMyEmployee in lstEmployees)
            {
                sDataToReport += "\n" + clsMyEmployee.sFirstName + " " + clsMyEmployee.sLastName + " " + clsMyEmployee.iSalary.ToString();
            }

            return sDataToReport;
        }

        /// <summary>
        /// Create a string to report the static employee data.
        /// </summary>
        /// <returns>String of employee data.</returns>
        public static string CreateReportStringForStaticData()
        {
            string sDataToReport = "";

            foreach (clsEmployee clsMyEmployee in lstStaticEmplyees)
            {
                sDataToReport += "\n" + clsMyEmployee.sFirstName + " " + clsMyEmployee.sLastName + " " + clsMyEmployee.iSalary.ToString();
            }

            return sDataToReport;
        }
    }
}
