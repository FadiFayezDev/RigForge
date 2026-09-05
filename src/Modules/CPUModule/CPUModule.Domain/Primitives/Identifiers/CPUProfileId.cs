namespace CPUModule.Domain.Primitives.Identifiers;

public readonly record struct CPUProfileId(Guid Value)
{
    public static CPUProfileId New() => new(Guid.NewGuid());

    public static CPUProfileId FromGuid(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty.", nameof(value));
        return new CPUProfileId(value);
    }

    public static CPUProfileId FromString(string value)
    {
        if (!Guid.TryParse(value, out var guidValue))
            throw new ArgumentException("Value is not a valid GUID.", nameof(value));
        return FromGuid(guidValue);
    }

    public override string ToString() => Value.ToString();
}
