﻿using System.Text;
namespace TaleworldsWorkshopProject;
// silah özellikleri belirten bir class. Shoplar ve düşmanlar bunu düşürür, alınırsa envantere eklenir ve kullanılırsa Weapon özelliklerine kopyalanır
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
    //düşmandan düşerse cost = 0.
    public WeaponProperties(string name, int power, int durability, int cost)
    {
        _name = name;
        _attackPower = power;
        _durability = durability;
        _cost = cost;   
    }
    public WeaponProperties IncreaseStats(double factor)
    {
        int newAttackPower = (int)(AttackPower * factor);
        int newDurability = (int)(Durability * factor);
        int newCost = (int)(Cost * factor);

        return new WeaponProperties(Name, newAttackPower, newDurability, newCost);
    }
    // weapon açıklaması. düşmandan düştüyse cost = 0 old. için açıklama değişir.
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
