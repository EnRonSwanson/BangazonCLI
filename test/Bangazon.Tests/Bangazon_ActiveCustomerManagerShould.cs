using System;
using Xunit;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using BangazonCLI;

// Author: Mitchell
// Tests get and set methods in Active Customer Manager

namespace BangazonCLI.Tests
{
    public class ActiveCustomerShould
    {
        //Create a new instance of ActiveCustomer
        private readonly ActiveCustomer _active;
        private readonly string _activeModelId;   // string on purpose
        public ActiveCustomerShould()
        {
          _activeModelId= "1";
          ActiveCustomer _active = new ActiveCustomer();
        }

        // [Fact]
        // public void setAndgetActiveCustomerId()
        // {
        //   _active.setActiveCustomerId(_activeModelId);
        //   int activeTestId = _active.getActiveCustomerId();
        //   Assert.True(activeTestId != 0);
        // }

    }
}