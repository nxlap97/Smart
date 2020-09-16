using Smart.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Domain.Model
{
    public class CustomerModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? TExpired { get; set; }
        public string IPAddress { get; set; }
        public CustomerType Type { get; set; }
        public CustomerStatus Status { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Published { get; set; }
    }
}
