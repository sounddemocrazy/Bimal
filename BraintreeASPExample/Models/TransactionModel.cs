using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BraintreeASPExample.Models
{
    public class TransactionModel
    {


        public long offerId { get; set; }

        public List<OrderItem> OrderItemList { get; set; }

        public decimal Freight { get; set; }

        public string UserId { get; set; }

        public string CreditCardId { get; set; }

        public string TransactionCode { get; set; }

        public string TransactionId { get; set; }
        public decimal Amount { get; set; } //Price
        public AddressRequest BillingAddress { get; set; }
        public string BillingAddressId { get; set; }
        public string Channel { get; set; }
        public TransactionCreditCardRequest CreditCard { get; set; }
        public CustomerRequest Customer { get; set; }
        public string CustomerId { get; set; }
        public Dictionary<string, string> CustomFields { get; set; }
        public DescriptorRequest Descriptor { get; set; }
        public string DeviceData { get; set; }
        public string DeviceSessionId { get; set; }
        public string FraudMerchantId { get; set; }
        public IndustryRequest Industry { get; set; }
        public string MerchantAccountId { get; set; }
        public TransactionOptionsRequest Options { get; set; }
        public string OrderId { get; set; }
        public string PaymentMethodNonce { get; set; }
        public string PaymentMethodToken { get; set; }
        public TransactionPayPalRequest PayPalAccount { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public bool? Recurring { get; set; }
        public RiskDataRequest RiskData { get; set; }
        public decimal? ServiceFeeAmount { get; set; }
        public string SharedBillingAddressId { get; set; }
        public string SharedCustomerId { get; set; }
        public string SharedPaymentMethodToken { get; set; }
        public string SharedShippingAddressId { get; set; }
        public AddressRequest ShippingAddress { get; set; }
        public string ShippingAddressId { get; set; }
        public decimal? TaxAmount { get; set; }
        public bool? TaxExempt { get; set; }
        public TransactionThreeDSecurePassThruRequest ThreeDSecurePassThru { get; set; }
        public string ThreeDSecureToken { get; set; }
        public string TransactionSource { get; set; }
        public TransactionType Type { get; set; }
        public string VenmoSdkPaymentMethodCode { get; set; }

    }

    public class OrderItem
    {
        private int? _OfferAttributeMapID;
        public int? OfferAttributeMapID
        {
            get
            {
                return _OfferAttributeMapID;
            }

            set
            {
                _OfferAttributeMapID = value;
            }
        }
        private decimal _Quantity;
        public decimal Quantity
        {
            get
            {
                return _Quantity;
            }

            set
            {
                _Quantity = value;
            }
        }
    }
}