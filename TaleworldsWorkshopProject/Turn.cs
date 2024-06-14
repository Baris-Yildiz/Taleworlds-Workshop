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
    private List<int> _pickedIndexes = new List<int>();

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
            while (_pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.EnemiesInGame.Count);
            }
            _pickedIndexes.Add(randomIndex);

            Enemy enemy = EntityFactory.EnemiesInGame[randomIndex];
            _enemies[i] = new Enemy(enemy.Name, enemy.Health, enemy.AttackPower);
        }

        _startTurn();
        _listEnemies();
        Console.WriteLine("You can fight one of these enemies using Game.Instance.SelectEnemy(x), x being 0, 1 or 2.");
        Console.WriteLine("You can also choose to escape using Game.Instance.Escape().");
    }

    // Her tur başladığında oyuncu ve düşmanları güçlendiren yöntem
    private void _startTurn()
    {
        Console.WriteLine($"Turn {_turnIndex} / 15 started.");
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

    private void _listEnemies()
    {
        Console.WriteLine("Enemies in this turn:");
        int index = 0;
        foreach (var enemy in _enemies)
        {
            Console.WriteLine($"({index++}) {enemy.Name} - Health: {enemy.Health}, Attack Power: {enemy.AttackPower}");
        }
    }
   
}
