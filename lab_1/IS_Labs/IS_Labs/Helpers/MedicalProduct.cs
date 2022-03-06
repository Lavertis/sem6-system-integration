namespace IS_Labs.Helpers;

public class MedicalProduct
{
    public string ProductName { get; set; } = string.Empty;
    public string CommonName { get; set; } = string.Empty;
    public string Form { get; set; } = string.Empty;
    public int ActiveSubstancesCount { get; set; }

    protected bool Equals(MedicalProduct other)
    {
        return ProductName == other.ProductName && CommonName == other.CommonName && Form == other.Form &&
               ActiveSubstancesCount == other.ActiveSubstancesCount;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((MedicalProduct) obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductName, CommonName, Form, ActiveSubstancesCount);
    }

    public static bool operator ==(MedicalProduct? left, MedicalProduct? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(MedicalProduct? left, MedicalProduct? right)
    {
        return !Equals(left, right);
    }

    public override string ToString()
    {
        return "MedicalProduct[" +
               $"ProductName: {ProductName}, " +
               $"CommonName: {CommonName}, " +
               $"Form: {Form}, " +
               $"ActiveSubstancesCount: {ActiveSubstancesCount}" +
               "]";
    }
}