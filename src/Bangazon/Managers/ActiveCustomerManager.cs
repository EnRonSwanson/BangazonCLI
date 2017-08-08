using System;

// By Mitchell
// To get and set currently active customer for use in methods for menu actions.

namespace BangazonCLI
{
    public class ActiveCustomer
    {
      private string _activeCustomerId { get; set; }

      public void setActiveCustomerId(string customerId)
      {
          _activeCustomerId = customerId;
      }

      public string getActiveCustomerId()
      {
          return _activeCustomerId;
      }

    }
}