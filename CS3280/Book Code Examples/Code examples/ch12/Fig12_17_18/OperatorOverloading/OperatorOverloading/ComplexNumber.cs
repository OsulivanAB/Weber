// Fig. 12.17: ComplexNumber.cs
// Class that overloads operators for adding, subtracting
// and multiplying complex numbers.
using System;

public class ComplexNumber
{
   // read-only property that gets the real component
   public double Real { get; private set; }

   // read-only property that gets the imaginary component
   public double Imaginary { get; private set; }

   // constructor
   public ComplexNumber( double a, double b )
   {
      Real = a;
      Imaginary = b;
   } // end constructor

   // return string representation of ComplexNumber
   public override string ToString()
   {
      return string.Format( "({0} {1} {2}i)",
         Real, ( Imaginary < 0 ? "-" : "+" ), Math.Abs( Imaginary ) );
   } // end method ToString

   // overload the addition operator
   public static ComplexNumber operator+ (
      ComplexNumber x, ComplexNumber y )
   {
      return new ComplexNumber( x.Real + y.Real,
         x.Imaginary + y.Imaginary );
   } // end operator +                          

   // overload the subtraction operator         
   public static ComplexNumber operator- (
      ComplexNumber x, ComplexNumber y )
   {
      return new ComplexNumber( x.Real - y.Real,
         x.Imaginary - y.Imaginary );
   } // end operator -                          

   // overload the multiplication operator
   public static ComplexNumber operator* (
      ComplexNumber x, ComplexNumber y )
   {
      return new ComplexNumber(
         x.Real * y.Real - x.Imaginary * y.Imaginary,
         x.Real * y.Imaginary + y.Real * x.Imaginary );
   } // end operator *                                 
} // end class ComplexNumber

/**************************************************************************
 * (C) Copyright 1992-2009 by Deitel & Associates, Inc. and               *
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