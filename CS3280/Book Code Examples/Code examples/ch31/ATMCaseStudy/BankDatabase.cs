// BankDatabase.cs
// Represents the bank account information database
public class BankDatabase
{
   private Account[] accounts; // array of the bank's Accounts

   // parameterless constructor initializes accounts
   public BankDatabase()
   {
      // create two Account objects for testing and 
      // place them in the accounts array
      accounts = new Account[ 2 ]; // create accounts array 
      accounts[ 0 ] = new Account( 12345, 54321, 1000.00M, 1200.00M );
      accounts[ 1 ] = new Account( 98765, 56789, 200.00M, 200.00M );
   } // end constructor

   // retrieve Account object containing specified account number
   private Account GetAccount( int accountNumber )
   {
      // loop through accounts searching for matching account number
      foreach ( Account currentAccount in accounts )
      {
         if ( currentAccount.AccountNumber == accountNumber )
            return currentAccount;
      } // end foreach  
      
      // account not found
      return null;
   } // end method GetAccount

   // determine whether user-specified account number and PIN match 
   // those of an account in the database
   public bool AuthenticateUser( int userAccountNumber, int userPIN)
   {
      // attempt to retrieve the account with the account number
      Account userAccount = GetAccount( userAccountNumber );

      // if account exists, return result of Account function ValidatePIN
      if ( userAccount != null )
         return userAccount.ValidatePIN( userPIN ); // true if match
      else
         return false; // account number not found, so return false
   } // end method AuthenticateUser

   // return available balance of Account with specified account number
   public decimal GetAvailableBalance( int userAccountNumber )
   {
      Account userAccount = GetAccount( userAccountNumber );
      return userAccount.AvailableBalance;
   } // end method GetAvailableBalance

   // return total balance of Account with specified account number
   public decimal GetTotalBalance( int userAccountNumber )
   {
      Account userAccount = GetAccount(userAccountNumber);
      return userAccount.TotalBalance;
   } // end method GetTotalBalance

   // credit the Account with specified account number
   public void Credit( int userAccountNumber, decimal amount )
   {
      Account userAccount = GetAccount( userAccountNumber );
      userAccount.Credit( amount );
   } // end method Credit

   // debit the Account with specified account number
   public void Debit( int userAccountNumber, decimal amount )
   {
      Account userAccount = GetAccount( userAccountNumber );
      userAccount.Debit( amount );
   } // end method Debit
} // end class BankDatabase


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
