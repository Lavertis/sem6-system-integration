namespace IS_Labs.Helpers;

public class MedicalProduct
{
    public string? CommonName { get; set; } = string.Empty;
    public string? Form { get; set; } = string.Empty;
    public int? ActiveSubstancesCount { get; set; }
    public string? EntityResponsible { get; set; } = string.Empty;

    public override string ToString()
    {
        return "MedicalProduct[" +
               $"CommonName: {CommonName}, " +
               $"Form: {Form}, " +
               $"ActiveSubstancesCount: {ActiveSubstancesCount}" +
               $"EntityResponsible: {EntityResponsible}" +
               "]";
    }
}