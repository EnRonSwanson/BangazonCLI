using System;

// By Mitchell
// To get and set currently active customer for use in methods for menu actions.

namespace BangazonCLI
{
    public class ActiveCustomer
    {
      private int? _activeCustomerId { get; set; }

      public void setActiveCustomerId(int customerId)
      {
          _activeCustomerId = customerId;
      }

      public int? getActiveCustomerId()
      {
          return _activeCustomerId;
      }

    }
}