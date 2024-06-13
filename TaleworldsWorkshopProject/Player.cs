namespace TaleworldsWorkshopProject;
public class Player
{
    private int _health;
    private int _attackPower;
    private Weapon _currentWeapon;
    private int _gold;
    private int _initialHealth;
    //Oyuncumuza Player.Instance olarak erişebiliyoruz ve sadece 1 tane oyuncumuz olabiliyor.
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Player();
            }

            return _instance;
        }
    }

    private static Player? _instance;

    // player ilk değerlerini initialize eder.
   
    private Player()
    {
        _gold = 500;
        _health = 150;
        _attackPower = 20;
        _health = _initialHealth = 100;
        _attackPower = 10;
        _currentWeapon = Weapon.Instance;
    }

    public int Health { get => _health; }
    public int Gold { get => _gold; }
    public int AttackPower { get => _attackPower + _currentWeapon.CalculateAttackPower(); }


    // Method to take damage
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0) _health = 0;
    }

    // Method to attack
    public int Attack()
    {
        if (_currentWeapon.Health <= 0)
        {
            SwitchToFist();
        }
        _currentWeapon.UseWeapon();
        return _attackPower + _currentWeapon.CalculateAttackPower();
    }
    private void SwitchToFist()
    {
        Weapon.Instance.ChangeWeapon(new WeaponProperties("Fist", 1, int.MaxValue, 0));
    }
    public void EarnGold(int amount)
    {
        _gold += amount;
        Console.WriteLine($"Player earned {amount} gold. Total gold: {_gold}");
    }
    public void BuyWeapon(WeaponProperties weaponProperties)
    {
        if (_gold >= weaponProperties.Cost)
        {
            _gold -= weaponProperties.Cost;
            Weapon.Instance.ChangeWeapon(weaponProperties); 
            Console.WriteLine($"Bought {weaponProperties.Name} for {weaponProperties.Cost} gold.");
        }
        else
        {
            Console.WriteLine("Not enough gold to buy this weapon.");
        }
    }

    public void PowerUp(double factor)
    {
        _health = (int)(_health * factor);
        _attackPower = (int)(_attackPower * factor);
        _gold = (int)(_gold * factor);
        _currentWeapon.PowerUp(factor);
        Console.WriteLine($"Player powered up! Health: {_health}, Attack Power: {_attackPower}, Gold: {_gold}");
    }

    public void HealPlayer(int amount)

    {
        if (_health + amount > _initialHealth)
        {
            _health = _initialHealth;
        } else
        {
            _health += amount;
        }
    }
}



