
public class Player
{
    private int _health;
    private int _attackPower;
    private Inventory _inventory = null;
    private Weapon _currentWeapon;

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
        _health = 100;
        _attackPower = 10;
        _currentWeapon = Weapon.Instance;
    }

    public int Health { get => _health; }
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
        _currentWeapon.UseWeapon();
        return _attackPower + _currentWeapon.CalculateAttackPower();
    }

    private void _destroyPlayer()
    {
        _instance = null;
    }
}



