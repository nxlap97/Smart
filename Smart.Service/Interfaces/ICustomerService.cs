using Smart.Core.Domain;
using Smart.Domain.Model;
using Smart.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Service.Interfaces
{
    public interface ICustomerService
    {
        #region MyRegion

        #endregion
        ResultStatus<Customer> CheckSignIn(string userName, string password);
        List<CustomerModel> GetCustomers();
    }
}
