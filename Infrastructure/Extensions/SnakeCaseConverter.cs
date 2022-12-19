using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class SnakeCaseConverter
{
    public static void ToSnakeCase(this ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName().ToSnakeCase());

            foreach (var property in entity.GetProperties())
                property.SetColumnName(property.Name.ToSnakeCase());

            foreach (var key in entity.GetKeys())
                key.SetName(key.GetName().ToSnakeCase());

            foreach (var key in entity.GetForeignKeys())
                key.SetConstraintName(key.GetConstraintName().ToSnakeCase());

            foreach (var index in entity.GetIndexes())
                index.SetDatabaseName(index.GetDatabaseName().ToSnakeCase());
        }
    }

    private static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var noLeadingUnderscore = Regex.Replace(input, @"^_", "");
        return Regex.Replace(noLeadingUnderscore, @"(?:(?<l>[a-z0-9])(?<r>[A-Z])|(?<l>[A-Z])(?<r>[A-Z][a-z0-9]))", "${l}_${r}").ToLower();
    }
}