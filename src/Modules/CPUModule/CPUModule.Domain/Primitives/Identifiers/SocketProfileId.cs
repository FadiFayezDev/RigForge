namespace CPUModule.Domain.Primitives.Identifiers;

public readonly record struct SocketProfileId(Guid Value)
{
    public static SocketProfileId New() => new(Guid.NewGuid());

    public static SocketProfileId FromGuid(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("Value cannot be empty.", nameof(value));

        return new(value);
    }

    public static SocketProfileId FromString(string value)
    {
        if (!Guid.TryParse(value, out var guidValue))
            throw new ArgumentException("Value is not a valid GUID.", nameof(value));
        return FromGuid(guidValue);
    }

    public override string ToString() => Value.ToString();
}
