using System.Collections.Generic;

namespace CodeChallenges.ATM.Library
{
    internal interface IAtmDispenser
    {
        string DispenseAmount(int amount);

        void CheckDenomicationsCount(int amount, List<Currency> currencies);

        bool IsAmountDispenasable(int amount, int leastAmount);

        List<Currency> GetCurrencyData();
    }
}