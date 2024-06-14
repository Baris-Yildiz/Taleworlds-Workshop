using System.Text;
namespace TaleworldsWorkshopProject;
public struct WeaponProperties
{
    public string Name { get => _name; }
    private string _name;

    public int AttackPower { get => _attackPower; }
    private int _attackPower;

    public int Durability { get => _durability; }
    private int _durability;

    public int Cost { get => _cost; }
    private int _cost;

    public string Description { get => _description(); }

    public WeaponProperties(string name, int power, int durability, int cost)
    {
        _name = name;
        _attackPower = power;
        _durability = durability;
        _cost = cost;   
    }
    public void IncreaseStats(double factor)
    {
        if (!Shop.CallFromShop)
        {
            Console.WriteLine("Invalid.");
            return;
        }
        _attackPower = (int)(AttackPower * factor);
    }

    private string _description()
    {
        string description = Name + " with " + AttackPower + " attack power and " + Durability + " durability.";
        if (Cost == 0)
        {
            return description;
        }
        return description + " Costs " + Cost + " gold.\n";
    }
}
