using System.Reflection;
using GetTheRide.DataAccess.EnumHelpers.Exceptions;
using GetTheRide.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GetTheRide.DataAccess.EnumHelpers;

public static class EnumInitializer
{
    public static ModelBuilder CreateTablesForAllEnums(this ModelBuilder modelBuilder, Assembly assembly)
    {
        var types = assembly.GetTypes()
            .Where(t => t.GetCustomAttributes(typeof(EnumDescriberAttribute), false).Length > 0)
            .Select(t => new
            {
                t.GetCustomAttribute<EnumDescriberAttribute>()!.EnumType,
                EnumTypeInfo = t
            });

        foreach (var type in types)
        {
            var constructor = type.EnumTypeInfo.GetConstructor(new[] { type.EnumType })
                ?? throw new ConstructorNotFoundException(new string(
                    $"In the describer type {type.EnumTypeInfo.Name} not exists constructor with the single parameter " +
                    $"of type {type.EnumType.Name}, which describes enum type."));

            var enumValues = Enum.GetValues(type.EnumType);

            for (int i = 0; i < enumValues.Length; i++)
            {
                if(((int)enumValues.GetValue(i)!) != i + 1)
                    throw new IncorrectEnumSetupException(
                        "Enum values must start at 1 and increase with each successive member by 1.");
            }

            foreach (var enumValue in enumValues)
            {
                modelBuilder.Entity(type.EnumTypeInfo).HasData(constructor.Invoke(new[] { enumValue }));
            }
        }

        return modelBuilder;
    }

    public static ModelBuilder CreateTableForEnum<TEnum>(this ModelBuilder modelBuilder) where TEnum : struct, Enum
    {
        Type enumType = typeof(TEnum);
        Type enumTypeInfo = null!;

        try
        {
            enumTypeInfo = typeof(TEnum).Assembly.GetTypes()
                .Single(t => t.GetCustomAttributes(typeof(EnumDescriberAttribute), false)
                    .Any(a => ((EnumDescriberAttribute)a)!.EnumType == enumType));
        }
        catch (Exception e)
        {
            throw new AttributeNotFoundException($"In the assembly with {enumType.Name} not found class describer " +
                                                 $"with {nameof(EnumDescriberAttribute)}.", e);
        }


        var constructor = enumTypeInfo.GetConstructor(new[] { typeof(TEnum) })
                          ?? throw new ConstructorNotFoundException(new string(
                              $"In the describer type {enumTypeInfo.Name} not exists constructor with the single parameter " +
                              $"of type {enumType.Name}, which describes enum type."));

        var enumValues = Enum.GetValues(enumType);

        for (int i = 0; i < enumValues.Length; i++)
        {
            if (((int)enumValues.GetValue(i)!) != i + 1)
                throw new IncorrectEnumSetupException(
                    "Enum values must start at 1 and increase with each successive member by 1.");
        }

        foreach (var enumValue in enumValues)
        {
            modelBuilder.Entity(enumTypeInfo).HasData(constructor.Invoke(new[] { enumValue }));
        }

        return modelBuilder;
    }
}
