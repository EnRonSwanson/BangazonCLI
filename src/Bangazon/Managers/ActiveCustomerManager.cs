using System;

// By Mitchell
// To get and set currently active customer for use in methods for menu actions.

namespace BangazonCLI
{
    public class ActiveCustomer
    {
      public static int activeCustomerId { get; set; }

      public void setActiveCustomerId(int customerId)
      {
          activeCustomerId = customerId;
      }

    }
}