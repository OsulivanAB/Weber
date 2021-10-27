// Fig. 10.10: Employee.cs
// Static variable used to maintain a count of the number of 
// Employee objects that have been created.
using System;

public class Employee
{
   public static int Count { get; private set; } // objects in memory

   // read-only auto-implemented property FirstName
   public string FirstName { get; private set; }

   // read-only auto-implemented property LastName
   public string LastName { get; private set; }

   // initialize employee, add 1 to static Count and 
   // output string indicating that constructor was called
   public Employee( string first, string last )
   {
      FirstName = first;
      LastName = last;
      ++Count; // increment static count of employees
      Console.WriteLine( "Employee constructor: {0} {1}; Count = {2}",
         FirstName, LastName, Count );
   } // end Employee constructor
} // end class Employee

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
