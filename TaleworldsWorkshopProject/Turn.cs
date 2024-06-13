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
}
