﻿namespace TaleworldsWorkshopProject;
public class Weapon
{
    private string _name;
    private int _health;
    private int _attackPower;
    private int _maxHealth;
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

    public int Health { get => _health; }
    public int AttackPower { get => _attackPower; }

    public void UseWeapon()
    {
        if (!Player.CallFromPlayer)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        if (_isFist)
        {
            Console.WriteLine("Using Fist. Attack power is fixed.");
            return;
        }
        if (_health > 0)
        {
            int healthReduction = _random.Next(1, 20); // Random health reduction between 5 and 15
            _health -= healthReduction;
            if (_health < 0) _health = 0; // Ensure health doesn't go below 0

            int attackReduction = _random.Next(1,5 ); // Random attack power reduction between 1 and 5
            int currentAttackPower = CalculateAttackPower() - attackReduction;
            if (currentAttackPower < 0) currentAttackPower = 0; // Ensure attack power doesn't go below 0

            Console.WriteLine($"Weapon used. Current weapon health: {_health}, Current weapon attack power: {currentAttackPower}");

            if (_health == 0)
            {
                _breakWeapon();
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
    private void _breakWeapon()
    {
        Console.WriteLine("Weapon has been broken!");
        _isFist = true;
        // Logic to remove the weapon from inventory or disable it
        _health = 0;
    }

    public void ChangeWeapon(WeaponProperties weaponProperties)
    {
        if (!Player.CallFromPlayer)
        {
            Console.WriteLine("Invalid.");
            return;
        }
        _health = _maxHealth = weaponProperties.Durability;
        _attackPower = weaponProperties.AttackPower;
        _isFist = false;
    }

    public void PowerUp(double factor)
    {
        if (!Player.CallFromPlayer)
        {
            Console.WriteLine("Invalid.");
            return;
        }
        _attackPower = (int)(_attackPower * factor);
        Console.WriteLine($"Weapon powered up! Attack Power: {_attackPower}");
    }

    public void BuffWeapon(int amount)
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }
        _attackPower += amount;
    }

    public void ResetWeapon()
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        _instance = null;
    }

}




