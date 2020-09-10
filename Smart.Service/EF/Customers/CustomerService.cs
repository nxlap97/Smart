using Smart.Core.Domain;
using Smart.Core.Domain.Enums;
using Smart.Data.Infrastructor;
using Smart.Service.Interfaces;
using Smart.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Service.EF
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer, string> _customerService;
        public CustomerService(IRepository<Customer, string> customerService)
        {
            _customerService = customerService;
        }
        public ResultStatus<Customer> CheckSignIn(string userName, string password)
        {
            
            var customer = _customerService.FindAll(x => x.UserName == userName.Trim()).FirstOrDefault();
            var result = new ResultStatus<Customer>() { Status = true, Message = "Đăng nhập thành công", Object = customer };

            if (customer == null)
                return new ResultStatus<Customer>() { Status = false, Message = "Tài khoản không tồn tại trong hệ thống" };

            if (customer.Password != password)
                return new ResultStatus<Customer>() { Status = false, Message = "Mật khẩu không đúng vui lòng kiểm tra lại" };

            switch (customer.Status)
            {
                case CustomerStatus.Register:
                    return new ResultStatus<Customer>() { Status = false, Message = "Tài khoản chưa kích hoạt vui lòng liên hệ với admin để được kích hoạt tài khoản" };
                case CustomerStatus.Blocked:
                    return new ResultStatus<Customer>() { Status = false, Message = "Tài khoản này đã bị khóa." };
                case CustomerStatus.Remove:
                    return new ResultStatus<Customer>() { Status = false, Message = "Tài khoản này đã bị xóa khỏi hệ thống." };
            }
            
            return result;
        }
    }
}
