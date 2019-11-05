using System.Globalization;
using System.Reflection;
using System.Resources;

namespace OnlineRetailPortal.Contracts
{
    public static class CustomErrorCodes
    {
        private const string _resxFile = "OnlineRetailPortal.Contracts.ErrorCodesMessage";
        public static string getErrorMessage(int errorCode)
        {
            ResourceManager rm = new ResourceManager(_resxFile,Assembly.GetExecutingAssembly());
            return rm.GetString(errorCode.ToString(), CultureInfo.CurrentCulture);
        }
    }
}
