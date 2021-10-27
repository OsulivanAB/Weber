// Fig. 12.12: Invoice.cs
// Invoice class implements IPayable.
using System;

public class Invoice : IPayable
{
   private int quantity;
   private decimal pricePerItem;

   // property that gets and sets the part number on the invoice
   public string PartNumber { get; set; }

   // property that gets and sets the part description on the invoice
   public string PartDescription { get; set; }

   // four-parameter constructor
   public Invoice( string part, string description, int count,
      decimal price )
   {
      PartNumber = part;
      PartDescription = description;
      Quantity = count; // validate quantity via property
      PricePerItem = price; // validate price per item via property
   } // end four-parameter Invoice constructor

   // property that gets and sets the quantity on the invoice
   public int Quantity
   {
      get
      {
         return quantity;
      } // end get
      set
      {
         if ( value >= 0 ) // validate quantity
            quantity = value;
         else
            throw new ArgumentOutOfRangeException( "Quantity",
               value, "Quantity must be >= 0" );
      } // end set
   } // end property Quantity

   // property that gets and sets the price per item
   public decimal PricePerItem
   {
      get
      {
         return pricePerItem;
      } // end get
      set
      {
         if ( value >= 0 ) // validate price
            pricePerItem = value; 
         else
            throw new ArgumentOutOfRangeException( "PricePerItem",
               value, "PricePerItem must be >= 0" );
      } // end set
   } // end property PricePerItem

   // return string representation of Invoice object
   public override string ToString()
   {
      return string.Format(
         "{0}: \n{1}: {2} ({3}) \n{4}: {5} \n{6}: {7:C}",
         "invoice", "part number", PartNumber, PartDescription,
         "quantity", Quantity, "price per item", PricePerItem );
   } // end method ToString

   // method required to carry out contract with interface IPayable
   public decimal GetPaymentAmount()
   {
      return Quantity * PricePerItem; // calculate total cost
   } // end method GetPaymentAmount                          
} // end class Invoice

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