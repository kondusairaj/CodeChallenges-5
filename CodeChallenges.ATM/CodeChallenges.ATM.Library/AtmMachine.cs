using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CodeChallenges.ATM.Library
{
    public class AtmMachine : IAtmDispenser
    {
        public string DispenseAmount(int amount)
        {
            List<Currency> currencies = GetCurrencyData();

            StringBuilder output = new StringBuilder();

            var isDespensable = IsAmountDispenasable(amount, currencies[currencies.Count - 1].Denomination);

            if (isDespensable)
            {
                CheckDenomicationsCount(amount, currencies);
                foreach (var currency in currencies)
                {
                    if (currency.Count != 0)
                    {
                        output.AppendLine(currency.Denomination.ToString() + " * " + currency.Count);
                    }
                }
            }
            else
            {
                output.Append("Amount cannot be dispensed");
            }

            return output.ToString();
        }

        public void CheckDenomicationsCount(int amount, List<Currency> currencies)
        {
            foreach (var currency in currencies)
            {
                currency.Count = amount / currency.Denomination;
                amount = amount % currency.Denomination;
            }
        }

        public bool IsAmountDispenasable(int amount, int leastAmount)
        {
            if (amount % leastAmount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Currency> GetCurrencyData()
        {
            List<Currency> currencies = new List<Currency>();

            XmlDocument currenciesXml = new XmlDocument();
            currenciesXml.Load(@"Currencies.xml");

            if (currenciesXml.DocumentElement != null)
            {
                XmlNodeList xmlNodeList = currenciesXml.DocumentElement.SelectNodes("Denomination");
                if (xmlNodeList != null)
                    foreach (XmlElement denomination in xmlNodeList)
                    {
                        var currency = new Currency
                        {
                            Denomination = Convert.ToInt16(denomination.InnerText),
                            Order = Convert.ToInt16(denomination.Attributes[0].InnerText)
                        };
                        currencies.Add(currency);
                    }
            }

            return currencies.OrderBy(c => c.Order).ToList();
        }
    }
}