namespace TaleworldsWorkshopProject;


public class Enemy
{
    private string _name;
    private int _health;
    private int _attackPower;

    private Random _random = new Random();

    public string Name { get => _name; }
    public int Health { get => _health; }
    public int AttackPower { get => _attackPower; }

    public Enemy(string name, int health = 80, int attackPower = 15)
    {
        _name = name;
        _health = health;
        _attackPower = attackPower;
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0) _health = 0;
    }

    // Method to attack
    public int Attack()
    {
        return _random.Next((int)(_attackPower * 0.9), (int)(_attackPower *1.1));
    }
    public void PowerUp(double factor)
    {
        _health = (int)(_health * factor);
        _attackPower = (int)(_attackPower * factor);
        Console.WriteLine($"Enemy powered up! Health: {_health}, Attack Power: {_attackPower}");
    }
}
