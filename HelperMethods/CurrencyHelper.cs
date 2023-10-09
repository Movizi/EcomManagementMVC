using EcomManagement.Models.Enums;

namespace EcomManagement.HelperMethods
{
    public static class CurrencyHelper
    {
        public static string GetCurrencySymbol(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.GEL:
                    return "₾"; // Georgian Lari symbol
                case Currencies.USD:
                    return "$"; // US Dollar symbol
                case Currencies.EUR:
                    return "€"; // Euro symbol
                default:
                    return "";
            }
        }
    }
}
