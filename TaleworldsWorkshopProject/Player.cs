namespace TaleworldsWorkshopProject;
public class Player
{
private int _health;
    private int _attackPower;
    private List<Weapon> _inventory;
    private Weapon _currentWeapon;
    private int _gold;
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
        _gold = 0;
        _inventory = new List<Weapon>();
        _health = 100;
        _attackPower = 10;
        _currentWeapon = new Weapon("Fist", 1, int.MaxValue, 0, true);
        _inventory.Add(_currentWeapon);// Add Fist as default weapon
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
        _currentWeapon = new Weapon("Fist", 1, int.MaxValue, 0, true);
    }
    public void EarnGold(int amount)
    {
        _gold += amount;
        Console.WriteLine($"Player earned {amount} gold. Total gold: {_gold}");
    }
    public void BuyWeapon(Weapon weapon)
    {
        if (_gold >= weapon.Cost)
        {
            _gold -= weapon.Cost;
            _inventory.Add(weapon);
            Console.WriteLine($"Bought {weapon.Name} for {weapon.Cost} gold.");
        }
        else
        {
            Console.WriteLine("Not enough gold to buy this weapon.");
        }
}

    private static void _destroyPlayer()
    {
        _instance = null;
    }

}



