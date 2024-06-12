using System;
namespace TaleworldsWorkshopProject;
public class Weapon
{
    private int _health;
    private int _attackPower;
    private int _maxHealth;
    private Inventory _inventory = null;
    private Random _random;
    private Player _player;


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
    }

    // Method to use the weapon
    public void UseWeapon()
    {
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
        return (int)((double)_health / _maxHealth * _attackPower);
    }

    // Method to handle weapon breaking
    private void BreakWeapon()
    {
        Console.WriteLine("Weapon has broken!");
        // Logic to remove the weapon from inventory or disable it
        _health = 0;
    }

    public void ChangeWeapon(WeaponProperties weaponProperties)
    {
        _health = _maxHealth = weaponProperties.Durability;
        _attackPower = weaponProperties.AttackPower;
    }
}




