// Exercise 7.6: Sphere.cs
// Calculate the volume of a sphere.
using System;

public class Sphere
{
   // obtain radius from user and display volume of sphere
   public static void Main( string[] args )
   {
      Console.Write( "Enter radius of sphere: " );
      double radius = Convert.ToDouble( Console.ReadLine() );

      Console.WriteLine( "Volume is {0:F3}", SphereVolume( radius ) );
   } // end Main

   // calculate and return sphere volume
   public static double SphereVolume( double radius )
   {
      double volume = ( 4.0 / 3.0 ) * Math.PI * Math.Pow( radius, 3 );
      return volume;
   } // end method SphereVolume
} // end class Sphere

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
