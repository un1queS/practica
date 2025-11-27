using System.Runtime.Versioning;
using System.Windows.Forms;
using RentalSystemV1.Data;
using RentalSystemV1.Models;
using RentalSystemV1.Services;
using RentalSystemV1.UI;

[SupportedOSPlatform("windows")]
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var dataDirectory = Path.Combine(AppContext.BaseDirectory, "data");
        var dbPath = Path.Combine(dataDirectory, "rentals_v1.db");

        var repository = new SqliteRentalRepository(dbPath);
        repository.EnsureDatabase();

        var rentalService = new RentalService(repository);
        var authService = new AuthService(repository);

        using var loginForm = new LoginForm(authService);
        if (loginForm.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        Application.Run(new MainForm(rentalService, loginForm.SelectedRole));
    }
}

