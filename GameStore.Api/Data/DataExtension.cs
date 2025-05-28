
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

public static class DataExtension
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}


// Automatically applies any pending EF Core migrations at runtime.
// Useful in development or local environments to avoid manual `dotnet ef database update`.
// Not recommended for production, where migrations should be applied manually.