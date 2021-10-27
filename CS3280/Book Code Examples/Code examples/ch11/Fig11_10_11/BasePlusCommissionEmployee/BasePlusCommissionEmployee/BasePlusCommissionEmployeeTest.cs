// Fig. 11.11: BasePlusCommissionEmployeeTest.cs
// Testing class BasePlusCommissionEmployee.
using System;

public class BasePlusCommissionEmployeeTest
{
   public static void Main( string[] args )
   {
      // instantiate BasePlusCommissionEmployee object
      BasePlusCommissionEmployee basePlusCommissionEmployee =
         new BasePlusCommissionEmployee( "Bob", "Lewis",
         "333-33-3333", 5000.00M, .04M, 300.00M );

      // display BasePlusCommissionEmployee's data
      Console.WriteLine(
         "Employee information obtained by properties and methods: \n" );
      Console.WriteLine( "First name is {0}",
         basePlusCommissionEmployee.FirstName );
      Console.WriteLine( "Last name is {0}", 
         basePlusCommissionEmployee.LastName );
      Console.WriteLine( "Social security number is {0}",
         basePlusCommissionEmployee.SocialSecurityNumber );
      Console.WriteLine( "Gross sales are {0:C}",
         basePlusCommissionEmployee.GrossSales );
      Console.WriteLine( "Commission rate is {0:F2}",
         basePlusCommissionEmployee.CommissionRate );
      Console.WriteLine( "Earnings are {0:C}",
         basePlusCommissionEmployee.Earnings() );
      Console.WriteLine( "Base salary is {0:C}",
         basePlusCommissionEmployee.BaseSalary );

      basePlusCommissionEmployee.BaseSalary = 1000.00M; // set base salary

      Console.WriteLine( "\n{0}:\n\n{1}",
         "Updated employee information obtained by ToString",
         basePlusCommissionEmployee );
      Console.WriteLine( "earnings: {0:C}",
         basePlusCommissionEmployee.Earnings() );
   } // end Main
} // end class BasePlusCommissionEmployeeTest

/**************************************************************************
 * (C) Copyright 1992-2011 by Deitel & Associates, Inc. and               *
 * Pearson Education, Inc. All Rights Reserved.                           *
 *                                                                        *
 * DISCLAIMER: The authors and publisher of this book have used their     *
 * best efforts in preparing the book. These efforts include the          *
 * development, research, and testing of the theories and programs        *
 * to determine their effectiveness. The authors and publisher make       *
 * no warranty of any kind, expressed or implied, with regard to these    *
 * programs or to the documentation contained in these books. The authors *
 * and publisher shall not be liable in any event for incidental or       *
 * consequential damages in connection with, or arising out of, the       *
 * furnishing, performance, or use of these programs.                     *
 **************************************************************************/