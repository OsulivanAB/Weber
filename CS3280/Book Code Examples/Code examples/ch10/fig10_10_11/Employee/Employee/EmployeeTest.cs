// Fig. 10.11: EmployeeTest.cs
// Static member demonstration.
using System;

public class EmployeeTest
{
   public static void Main( string[] args )
   {
      // show that Count is 0 before creating Employees
      Console.WriteLine( "Employees before instantiation: {0}",
         Employee.Count );

      // create two Employees; Count should become 2
      Employee e1 = new Employee( "Susan", "Baker" );
      Employee e2 = new Employee( "Bob", "Blue" );

      // show that Count is 2 after creating two Employees
      Console.WriteLine( "\nEmployees after instantiation: {0}",
         Employee.Count );

      // get names of Employees
      Console.WriteLine( "\nEmployee 1: {0} {1}\nEmployee 2: {2} {3}\n",
         e1.FirstName, e1.LastName,
         e2.FirstName, e2.LastName );

      // in this example, there is only one reference to each Employee,
      // so the following statements cause the CLR to mark each 
      // Employee object as being eligible for garbage collection      
      e1 = null; // good practice: mark object e1 no longer needed     
      e2 = null; // good practice: mark object e2 no longer needed     
   } // end Main
} // end class EmployeeTest


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
 *************************************************************************/
