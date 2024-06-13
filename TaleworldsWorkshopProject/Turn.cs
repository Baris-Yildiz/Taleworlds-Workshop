namespace TaleworldsWorkshopProject;
using System.Text;
public class Turn
{
    

    public static bool CallFromTurn { get => _callFromTurn; }
    private static bool _callFromTurn;

    private int _turnIndex;
    public IReadOnlyList<Enemy> Enemies { get => _enemies; }
    private Enemy[] _enemies = new Enemy[3];

    private Random _randomNumberGenerator = new Random();
    private List<int> pickedIndexes = new List<int>();

    // yeni bir tur oluşturur.
    public Turn(int turnIndex)
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }
       
        _turnIndex = turnIndex;
        for (int i = 0; i < _enemies.Length; i++)
        {
            int randomIndex = _randomNumberGenerator.Next(0, EntityFactory.EnemiesInGame.Count);
            while (pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.EnemiesInGame.Count);
            }
            pickedIndexes.Add(randomIndex);

            Enemy enemy = EntityFactory.EnemiesInGame[randomIndex];
            _enemies[i] = new Enemy(enemy.Name, enemy.Health, enemy.AttackPower);
        }

        StartTurn();
        ListEnemies();
    }

    // Her tur başladığında oyuncu ve düşmanları güçlendiren yöntem
    private void StartTurn()
    {
        Console.WriteLine($"Turn {_turnIndex} / 30 started.");
        if (_turnIndex > 1 ) {
            _callFromTurn = true;
            Player.Instance.PowerUp(1 + _turnIndex * 0.1); // Her turda oyuncuyu güçlendir

            foreach (var enemy in _enemies)
            {
                enemy.PowerUp(1 + _turnIndex * 0.1); // Her turda düşmanları güçlendir
            }

            _callFromTurn = false;
        }
    }

    private void ListEnemies()
    {
        Console.WriteLine("Enemies in this turn:");
        int index = 0;
        foreach (var enemy in _enemies)
        {
            Console.WriteLine($"({index++}) {enemy.Name} - Health: {enemy.Health}, Attack Power: {enemy.AttackPower}");
        }
    }
   
}
