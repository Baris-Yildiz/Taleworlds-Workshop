namespace TaleworldsWorkshopProject;
public class Player
{
    private int _health;
    private int _attackPower;
    private Weapon _currentWeapon;
    private int _gold;
    private int _initialHealth;

    public static bool CallFromPlayer { get => _callFromPlayer; }
    private static bool _callFromPlayer;

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
        if (!CombatScene.CallFromCombatScene)
        {
            Console.WriteLine("Invalid.");
            return;
        }
        _health -= damage;
        if (_health < 0) _health = 0;
    }

    // Method to attack
    public int Attack()
    {
        if (!CombatScene.CallFromCombatScene)
        {
            Console.WriteLine("Invalid.");
            return -1;
        }

        if (_currentWeapon.Health <= 0)
        {
            SwitchToFist();
        }

        _callFromPlayer = true;
        _currentWeapon.UseWeapon();
        _callFromPlayer = false;

        return _attackPower + _currentWeapon.CalculateAttackPower();
    }

    private void SwitchToFist()
    {
        _callFromPlayer = true;
        Weapon.Instance.ChangeWeapon(new WeaponProperties("Fist", 1, int.MaxValue, 0));
        _callFromPlayer = false;
    }

    public void EarnGold(int amount)
    {
        if (!CombatScene.CallFromCombatScene)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        _gold += amount;
        Console.WriteLine($"Player earned {amount} gold. Total gold: {_gold}");
    }
    public void BuyWeapon(WeaponProperties weaponProperties)
    {
        if(!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        if (_gold >= weaponProperties.Cost)
        {
            _gold -= weaponProperties.Cost;

            _callFromPlayer = true;
            Weapon.Instance.ChangeWeapon(weaponProperties); 
            _callFromPlayer = false;

            Console.WriteLine($"Bought {weaponProperties.Name} for {weaponProperties.Cost} gold.");
        }
        else
        {
            Console.WriteLine("Not enough gold to buy this weapon.");
        }
    }

    public void PowerUp(double factor)
    {
        if (!Turn.CallFromTurn)
        {
            Console.WriteLine("Invalid");
            return;
        }
        _health = (int)(_health * factor);
        _attackPower = (int)(_attackPower * factor);
        

        _callFromPlayer = true;
        _currentWeapon.PowerUp(factor);
        _callFromPlayer = false;

        Console.WriteLine($"Player powered up! Health: {_health}, Attack Power: {_attackPower}");
    }

    public void HealPlayer(Potion potion)
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        int amount = potion.EffectRatio;
        _gold -= potion.Cost;

        if (_health + amount > _initialHealth)
        {
            _health = _initialHealth;
        } else
        {
            _health += amount;
        }
        
    }

    public void BuffWeapon(Potion potion)
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        _gold -= potion.Cost;
        _attackPower += potion.EffectRatio;
        Weapon.Instance.BuffWeapon(potion.EffectRatio);
    }

    public void ResetPlayer()
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        _instance = null;
    }

    public void ShowStats()
    {
        Console.WriteLine($"Health: {_health}, Attack Power: {_attackPower}, Gold: {_gold}.\n Weapon Attack Power: {Weapon.Instance.AttackPower}, Durability: {Weapon.Instance.Health}");
    }
}



