namespace TaleworldsWorkshopProject;
public class Enemy
{
    public string Name { get => _name; }
    private string _name;

    public int Health { get => _health; }
    private int _health;

    public int AttackPower { get => _attackPower; }
    private int _attackPower;

    private Random _random = new Random();
    
    public Enemy(string name, int health = 80, int attackPower = 15)
    {
        _name = name;
        _health = health;
        _attackPower = attackPower;
    }

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

    public int Attack()
    {
        if (!CombatScene.CallFromCombatScene)
        {
            Console.WriteLine("Invalid.");
            return -1;
        }

        return _random.Next((int)(_attackPower * 0.9), (int)(_attackPower *1.1));
    }
    public void PowerUp(double factor)
    {
        if (!Turn.CallFromTurn)
        {
            Console.WriteLine("Invalid.");
            return;
        }
        _health = (int)(_health * factor);
        _attackPower = (int)(_attackPower * factor);
    }
}
