
public class Player
{
    private int _health;
    private int _attackPower;
    private Inventory _inventory;

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

    private static Player _instance;

    private Player() { }
}
