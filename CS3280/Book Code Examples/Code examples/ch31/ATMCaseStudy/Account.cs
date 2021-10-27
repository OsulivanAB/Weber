// Account.cs
// Class Account represents a bank account.
public class Account
{
   private int accountNumber; // account number
   private int pin; // PIN for authentication
   private decimal availableBalance; // available withdrawal amount
   private decimal totalBalance; // funds available + pending deposit

   // four-parameter constructor initializes attributes
   public Account( int theAccountNumber, int thePIN, 
      decimal theAvailableBalance, decimal theTotalBalance )
   {
      accountNumber = theAccountNumber;
      pin = thePIN;
      availableBalance = theAvailableBalance;
      totalBalance = theTotalBalance;
   } // end constructor

   // read-only property that gets the account number
   public int AccountNumber
   {
      get
      {
         return accountNumber;
      } // end get
   } // end property AccountNumber

   // read-only property that gets the available balance
   public decimal AvailableBalance
   {
      get
      {
         return availableBalance;
      } // end get
   } // end property AvailableBalance

   // read-only property that gets the total balance
   public decimal TotalBalance
   {
      get
      {
         return totalBalance;
      } // end get
   } // end property TotalBalance

   // determines whether a user-specified PIN matches PIN in Account
   public bool ValidatePIN( int userPIN )
   {
      return ( userPIN == pin );
   } // end method ValidatePIN

   // credits the account (funds have not yet cleared)
   public void Credit( decimal amount )
   {
      totalBalance += amount; // add to total balance
   } // end method Credit

   // debits the account
   public void Debit( decimal amount )
   {
      availableBalance -= amount; // subtract from available balance
      totalBalance -= amount; // subtract from total balance
   } // end method Debit
} // end class Account


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
 *************************************************************************/
