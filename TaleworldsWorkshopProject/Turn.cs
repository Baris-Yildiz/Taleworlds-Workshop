namespace TaleworldsWorkshopProject;
using System.Text;
public class Turn
{
    private int _turnIndex;
    public Enemy[] Enemies { get => _enemies; }
    private Enemy[] _enemies = new Enemy[3];

    public static int maxTurns = 20;

    private Random _randomNumberGenerator = new Random();
    List<int> pickedIndexes = new List<int>();

    // yeni bir tur oluşturur.
    public Turn(int turnIndex)
    {
        _turnIndex = turnIndex;
        for (int i = 0; i < _enemies.Length; i++)
        {
            int randomIndex = _randomNumberGenerator.Next(0, EntityFactory.enemiesInGame.Length);
            while (pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.enemiesInGame.Length);
            }
            pickedIndexes.Add(randomIndex);

            _enemies[i] = EntityFactory.enemiesInGame[randomIndex];
        }

        WriteTurn();
    }

    // turda karşılaşılan düşmanları yazdırır ve seçenekler playera gösterilir.
    public void WriteTurn()
    {
        StringBuilder prompt = new StringBuilder();  
        prompt.Append("Turn: " + _turnIndex + " / " + maxTurns + " \nThere are three enemies: \n");

        for (int i = 0; i < _enemies.Length; i++)
        {
            Enemy enemy = _enemies[i];
            prompt.Append(" ( " + i + " ) " + enemy.Name + " with " + enemy.AttackPower + " attack power and " + enemy.Health + " hp.\n");
        }

        prompt.Append("You can attack the enemy with index x using the Game.SelectEnemy(x) method.\n");
        prompt.Append("You can instead escape using the Game.Escape() method.\n");

        Console.WriteLine(prompt.ToString());   
    }

}
