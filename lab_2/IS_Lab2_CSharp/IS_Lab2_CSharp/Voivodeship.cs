namespace IS_Lab2_Extra;

public class Voivodeship
{
    public string Name { get; set; }
    public int GW { get; set; }
    public int GMW { get; set; }
    public int MNP { get; set; }
    public int dzielnica { get; set; }
    public int W { get; set; }
    public int GM { get; set; }
    public int P { get; set; }

    public Voivodeship(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        var str = $"Voivodeship[name: {Name}, GW: {GW}, GWM: {GMW}, MNP: {MNP}, " +
                  $"dzielnica: {dzielnica}, W: {W}, GM: {GM}, P: {P}]";
        return str;
    }
}