
public class Enemy
{
    public string Name { get => _name; }
    private string _name;

    public int AttackPower { get => _attackPower; }
    private int _attackPower;

    public Enemy(string name)
    {
        _name = name;
    }
}



