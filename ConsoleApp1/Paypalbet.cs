using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Paypalbet
    {
        public void makePayment(string emailaddress,int amount)
        {
            string _MerchantEmail = emailaddress;
            string _ReturnURL = "https://www.yourwebsite.com/paymentsuccess";
            string _CancelURL = "https://www.yourwebsite.com/paymentfailed";
            string _CurrencyCode = "EUR";
            int _Amount = amount;
            string _ItemName = "item1"; //We are using this field to pass the order number
            int _Discount = 0;
            double _Tax = 0;
            string _PayPalURL = $"https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business={_MerchantEmail}&return={_ReturnURL}&cancel_return={_CancelURL}&currency_code={_CurrencyCode}&amount={_Amount}&item_name={_ItemName}&discount_amount={_Discount}&tax={_Tax}";

            System.Diagnostics.Process.Start(_PayPalURL);
        }
    }
}
