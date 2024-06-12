using System;
using System.Xml.Linq;
namespace TaleworldsWorkshopProject;
public class Weapon
{
    private string _name;
    private int _health;
    private int _attackPower;
    private int _maxHealth;
    private Inventory _inventory = null;
    private Random _random;
    private Player _player;
    private bool _isFist;
    private int _cost;




    public int Cost { get => _cost; }
    public string Name { get => _name; }

    //Oyuncumuza Player.Instance olarak erişebiliyoruz ve sadece 1 tane oyuncumuz olabiliyor.
    public static Weapon Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Weapon();
            }

            return _instance;
        }
    }
    private static Weapon? _instance;

    private Weapon()
    {
        _maxHealth = 100; // Initial maximum health of the weapon
        _health = _maxHealth; // Set current health to maximum health
        _attackPower = 50; // Initial base attack power of the weapon
        _random = new Random(); // Initialize the random number generator
        _isFist = false;
    }

    // Method to use the weapon

    public Weapon(string name, int attackPower, int maxHealth, int cost, bool isFist = false)
    {
        _name = name;
        _attackPower = attackPower;
        _maxHealth = maxHealth;
        _health = maxHealth;
        _cost = cost;
        _random = new Random();
        _isFist = isFist;
    }

    public int Health { get => _health; }
    public int AttackPower { get => _attackPower; }

    public void UseWeapon()
    {
        if (_isFist)
        {
            Console.WriteLine("Using Fist. Attack power is fixed.");
            return;
        }
        if (_health > 0)
        {
            int healthReduction = _random.Next(1, 30); // Random health reduction between 5 and 15
            _health -= healthReduction;
            if (_health < 0) _health = 0; // Ensure health doesn't go below 0

            int attackReduction = _random.Next(1,5 ); // Random attack power reduction between 1 and 5
            int currentAttackPower = CalculateAttackPower() - attackReduction;
            if (currentAttackPower < 0) currentAttackPower = 0; // Ensure attack power doesn't go below 0

            Console.WriteLine($"Weapon used. Current health: {_health}, Current attack power: {currentAttackPower}");

            if (_health <= 0)
            {
                BreakWeapon();
            }
        }
        else
        {
            Console.WriteLine("Weapon is broken and cannot be used.");
        }
    }

    // Method to calculate the current attack power based on the weapon's health
    public int CalculateAttackPower()
    {
        return _isFist ? _attackPower : (int)((double)_health / _maxHealth * _attackPower);
    }

    // Method to handle weapon breaking
    private void BreakWeapon()
    {
        Console.WriteLine("Weapon has broken!");
        // Logic to remove the weapon from inventory or disable it
        _health = 0;
    }
}




