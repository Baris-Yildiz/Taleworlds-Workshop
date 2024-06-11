
public class Player
{
    private int _health;
    private int _attackPower;
    private Inventory _inventory = null;
    private Weapon _currentWeapon = null;

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
    private Player() {
        _health = 100;
        _attackPower = 10;
    }

    private void _destroyPlayer()
    {
        _instance = null;
    }
}
