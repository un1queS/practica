using System.Runtime.Versioning;
using System.Windows.Forms;

namespace RentalSystemV1;

[SupportedOSPlatform("windows")]
internal static class ApplicationConfiguration
{
    public static void Initialize()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
    }
}

