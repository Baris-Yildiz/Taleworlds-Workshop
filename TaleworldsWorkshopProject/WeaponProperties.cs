public struct WeaponProperties
{
    public string Name { get => _name; }
    private string _name;

    public int AttackPower { get => _attackPower; }
    private int _attackPower;

    public int Durability { get => _durability; }
    private int _durability;

    public WeaponProperties(string name, int power, int durability)
    {
        _name = name;
        _attackPower = power;
        _durability = durability;
    }
}
