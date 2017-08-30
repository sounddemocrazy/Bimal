using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BraintreeASPExample.Models
{
    public class CustomerModel
    {

        public string Company { get; set; }
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string FirstName { get; set; }
        public string Id { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public string Website { get; set; }

        public string CreditCardNumber { get; set; }

        public string cvv { get; set; }

        public string ExpireDate { get; set; }



    }
}