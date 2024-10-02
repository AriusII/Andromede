using System.Reflection;
using DbUp;

namespace Andromede.Libs.Framework.Scripts;

public readonly struct DatabaseMigrator
{
    public static void Migrate(string connectionString)
    {
        var database =
            DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

        var databaseMigrationResult = database.PerformUpgrade();

        Console.WriteLine("Database migration successful");
    }
}