using Braintree;
using BraintreeASPExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BraintreeASPExample.Controllers
{
    public class CheckoutsController : Controller
    {
        public IBraintreeConfiguration config = new BraintreeConfiguration();

        public static readonly TransactionStatus[] transactionSuccessStatuses = {
                                                                                    TransactionStatus.AUTHORIZED,
                                                                                    TransactionStatus.AUTHORIZING,
                                                                                    TransactionStatus.SETTLED,
                                                                                    TransactionStatus.SETTLING,
                                                                                    TransactionStatus.SETTLEMENT_CONFIRMED,
                                                                                    TransactionStatus.SETTLEMENT_PENDING,
                                                                                    TransactionStatus.SUBMITTED_FOR_SETTLEMENT
                                                                                };

        //public ActionResult New()
        //{
        //    var gateway = config.GetGateway();
        //    var clientToken = gateway.ClientToken.generate();
        //    ViewBag.ClientToken = clientToken;


        //    //var nonce = "145c499d-24fa-0e5f-7ec8-17e6ed45b5db";
        //    var request1 = new TransactionRequest
        //    {
        //        Amount = 10.00M,
        //        PaymentMethodNonce = "fake-valid-nonce",
        //        Options = new TransactionOptionsRequest
        //        {
        //            SubmitForSettlement = true
        //        }
        //    };
        //    Result<Transaction> result1 = gateway.Transaction.Sale(request1);
        //    bool success = result1.IsSuccess();
        //    Transaction transaction = result1.Target;
        //    return View();
        //}

        //public ActionResult Create()
        //{
        //    var gateway = config.GetGateway();
        //    Decimal amount;

        //    try
        //    {
        //        amount = Convert.ToDecimal(Request["amount"]);
        //    }
        //    catch (FormatException e)
        //    {
        //        TempData["Flash"] = "Error: 81503: Amount is an invalid format.";
        //        return RedirectToAction("New");
        //    }

        //    var nonce = Request["payment_method_nonce"];



        //    //  var nonce = Request["payment_method_nonce"];
        //    var request = new TransactionRequest
        //    {
        //        Amount = amount,
        //        PaymentMethodNonce = nonce,
        //        Options = new TransactionOptionsRequest
        //        {
        //            SubmitForSettlement = true
        //        }
        //    };

        //    Result<Transaction> result = gateway.Transaction.Sale(request);
        //    if (result.IsSuccess())
        //    {
        //        Transaction transaction = result.Target;
        //        return RedirectToAction("Show", new { id = transaction.Id });
        //    }
        //    else if (result.Transaction != null)
        //    {
        //        return RedirectToAction("Show", new { id = result.Transaction.Id });
        //    }
        //    else
        //    {
        //        string errorMessages = "";
        //        foreach (ValidationError error in result.Errors.DeepAll())
        //        {
        //            errorMessages += "Error: " + (int)error.Code + " - " + error.Message + "\n";
        //        }
        //        TempData["Flash"] = errorMessages;
        //        return RedirectToAction("New");
        //    }

        //}

        //public ActionResult Show(String id)
        //{
        //    var gateway = config.GetGateway();
        //    Transaction transaction = gateway.Transaction.Find(id);

        //    if (transactionSuccessStatuses.Contains(transaction.Status))
        //    {
        //        TempData["header"] = "Sweet Success!";
        //        TempData["icon"] = "success";
        //        TempData["message"] = "Your test transaction has been successfully processed. See the Braintree API response and try again.";
        //    }
        //    else
        //    {
        //        TempData["header"] = "Transaction Failed";
        //        TempData["icon"] = "fail";
        //        TempData["message"] = "Your test transaction has a status of " + transaction.Status + ". See the Braintree API response and try again.";
        //    };

        //    ViewBag.Transaction = transaction;
        //    return View();
        //}


        public ActionResult Index(string id)
        {
            string cardNumber = "5555551212121212121212121212121212121256565456454544444";
            string Bin = cardNumber.Substring(0, 6);
            string lastFour = cardNumber.Substring(cardNumber.Length - 4, 4);
            if (id == "" || id == null)
            {
                id = "Index_controller";
            }
            ViewBag.Message = id;
            return View();
        }
        public ActionResult CreateCustomer()
        {
            var model = new CustomerModel
            {
                FirstName = "First",
                LastName = "Last",
                Company = "Jones Co.",
                Email = "first.last@example.com",
                Fax = "419-555-1234",
                Phone = "614-555-1234",
                Website = "http://example.com",
                CreditCardNumber = "4000111111111115",
                cvv = "123",
                ExpireDate = "08/22",


            };

            return View(model);
        }
        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            var gateway = config.GetGateway();
            var clientToken = gateway.ClientToken.generate();

            var result = gateway.Customer.Find("190564803");
            var address = gateway.Address.Find(result.Id, result.Addresses[0].Id);
            string cardType = result.CreditCards[0].CardType.ToString();
            if (result != null)
            {

                var creditCard = new CustomerRequest
                {
                    //  CustomerId = result.Id,
                    CreditCard = new CreditCardRequest
                    {
                        BillingAddress = new CreditCardAddressRequest
                        {

                            CountryName = "US",

                        },
                        CVV = "123",
                        CardholderName = result.FirstName + " " + result.LastName,
                        Number = "2223000048400011",
                        ExpirationDate = "08/20",


                    },



                };
                var response = gateway.Customer.Update(result.Id, creditCard);
            }


            return RedirectToAction("Index", new { id = "POST _ CreateCustomer_ Success" });

        }

        //var creditCard = new CustomerRequest
        //{
        //    FirstName = "RAM",
        //    LastName = "Bhai",
        //    Email = "learning.ananta@gmail.com",
        //    Phone = "1234567",
        //    Website = "www.braindigit.com",
        //    //  CustomerId = result.Id,
        //    CreditCard = new CreditCardRequest
        //    {
        //        CVV = "123",
        //        CardholderName = "RAM Bhai",
        //        Number = "2223000048400011",
        //        ExpirationDate = "08/20",
        //        Options = new CreditCardOptionsRequest
        //        {

        //            MakeDefault=true,
        //            VerifyCard = true
        //        }
        //    }

        //};
        //var response = gateway.Customer.Create(creditCard);
        //   return RedirectToAction("Index", new { id = "POST _ CreateCustomer_ Success" });
        //else
        //{
        //    return RedirectToAction("Index", new { id = "POST _ CreateCustomer_ Fail" });

        //}



        public ActionResult CreateTransaction(string customerId)
        {
            customerId = "835883953";
            var transaction = new TransactionModel();
            transaction.CustomerId = customerId;
            return View(transaction);
        }
        [HttpPost]
        public ActionResult CreateTransaction(TransactionModel model)
        {
            var result = CreateTransaction1(" 835883953", "5zsp7y", "123", 10, null, 20, 10, 0.12M, "835883953");
            if (result.IsSuccess())
            {
                return RedirectToAction("Index", new { id = "POST _ CreateTransaction _ Success" });
            }
            else
            {
                return RedirectToAction("Index", new { id = "POST _ CreateTransaction _ Fail" });

            }

        }


        public Result<Transaction> CreateTransaction1(string customerToken, string paymentMethodToken, string key, long offerID, List<OrderItem> orderItemList, decimal price, decimal freight, decimal tax, string userid)
        {
            var model = new TransactionModel();
            model.CustomerId = customerToken;
            model.PaymentMethodToken = paymentMethodToken;
            // model.CreditCard.CVV = key;
            model.offerId = offerID;
            model.OrderItemList = orderItemList;
            model.Amount = price;
            model.Freight = freight;
            model.TaxAmount = tax;
            model.UserId = userid;
            //model.Options.AddBillingAddressToPaymentMethod = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var gateway = config.GetGateway();

            var clientToken = gateway.ClientToken.generate();

            decimal totalPrice = 120;

            //foreach (var item in model.OrderItemList)
            //{
            //    totalPrice = totalPrice + ((item.Quantity) * model.Amount + model.Freight);
            //}
            var creditCard = gateway.CreditCard.Find(paymentMethodToken);
            if (creditCard.IsExpired == true && creditCard.Token != paymentMethodToken)
            {
                return null;
            }
            else
            {
                var transactionRequest = new TransactionRequest
                {
                    Amount = Convert.ToDecimal(totalPrice + totalPrice * model.TaxAmount),
                    CustomerId = model.CustomerId,
                    PaymentMethodToken = model.PaymentMethodToken,
                    CreditCard = new TransactionCreditCardRequest
                    {

                        CVV = key
                    },
                    Options = new TransactionOptionsRequest
                    {
                        SubmitForSettlement = true,
                        SkipCvv = false,
                        SkipAvs = false,
                        AddBillingAddressToPaymentMethod = true
                    }
                };
                var result = gateway.Transaction.Sale(transactionRequest);
                return result;
            }
        }

    }
}
