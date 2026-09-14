namespace MotherboardModule.Domain.Primitives.Identifiers;

public readonly record struct MotherboardProfileId(Guid Value)
{
    public static MotherboardProfileId New() => new(Guid.NewGuid());

    public static MotherboardProfileId FromGuid(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty.", nameof(value));

        return new(value);
    }

    public static MotherboardProfileId FromString(string value)
    {
        if (!Guid.TryParse(value, out var guidValue))
            throw new ArgumentException("Value is not a valid GUID.", nameof(value));
        return FromGuid(guidValue);
    }

    public override string ToString() => Value.ToString();
}
