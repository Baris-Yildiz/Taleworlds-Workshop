namespace TaleworldsWorkshopProject;
using System.Text;
public class Turn
{
    private int _turnIndex;
    public IReadOnlyList<Enemy> Enemies { get => _enemies; }
    private Enemy[] _enemies = new Enemy[3];

    private Random _randomNumberGenerator = new Random();
    private List<int> pickedIndexes = new List<int>();

    // yeni bir tur oluşturur.
    public Turn(int turnIndex)
    {
        _turnIndex = turnIndex;
        for (int i = 0; i < _enemies.Length; i++)
        {
            int randomIndex = _randomNumberGenerator.Next(0, EntityFactory.EnemiesInGame.Count);
            while (pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.EnemiesInGame.Count);
            }
            pickedIndexes.Add(randomIndex);

            _enemies[i] = EntityFactory.EnemiesInGame[randomIndex];
        }

        Console.WriteLine(_turnDescription());
    }

    // turda karşılaşılan düşmanları yazdırır ve seçenekler playera gösterilir.
    private string _turnDescription()
    {
        StringBuilder prompt = new StringBuilder();
        prompt.Append("\nTurn: " + _turnIndex + " / 30\nThere are three enemies: \n");

        for (int i = 0; i < _enemies.Length; i++)
        {
            Enemy enemy = _enemies[i];
            prompt.Append(" ( " + i + " ) " + enemy.Name + " with " + enemy.AttackPower + " attack power and " + enemy.Health + " hp.\n");
        }

        prompt.Append("You can attack the enemy with index x using the Game.SelectEnemy(x) method.\n");
        prompt.Append("You can instead escape using the Game.Escape() method.\n");

        return prompt.ToString();
    }
    // Her tur başladığında oyuncu ve düşmanları güçlendiren yöntem
    public void StartTurn()
    {
        Console.WriteLine($"Turn {_turnIndex} started.");
        Player.Instance.PowerUp(1 + _turnIndex * 0.1); // Her turda oyuncuyu güçlendir
        foreach (var enemy in _enemies)
        {
            enemy.PowerUp(1 + _turnIndex * 0.1); // Her turda düşmanları güçlendir
        }
    }
    public void EndTurn()
    {
        Console.WriteLine($"Turn {_turnIndex} ended.");
    }
    public void ListEnemies()
    {
        Console.WriteLine("Enemies in this turn:");
        foreach (var enemy in _enemies)
        {
            Console.WriteLine($"{enemy.Name} - Health: {enemy.Health}, Attack Power: {enemy.AttackPower}");
        }
    }
}
