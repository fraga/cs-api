using System.Runtime.InteropServices;

namespace Knuth.Native
{
    internal static class NodeSettingsNative
    {
        [DllImport(Constants.KTH_C_LIBRARY)]
        public static extern CurrencyType node_settings_get_currency();
    }

}