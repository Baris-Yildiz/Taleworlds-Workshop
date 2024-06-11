using System.Text;
public class Turn
{
    private int _turnIndex;
    private Enemy[] _enemies = new Enemy[3];
    public static int maxTurns = 20;

    // yeni bir tur oluşturur.
    public Turn(int turnIndex)
    {
        _turnIndex = turnIndex;
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i] = new Enemy("test");
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
            prompt.Append(" ( " + i + " ) " + enemy.Name + " with " + enemy.AttackPower + " attack power.\n");
        }

        prompt.Append("You can attack the enemy with index x using the attack(x) method.\n");
        prompt.Append("You can instead escape using the escape() method.\n");

        Console.WriteLine(prompt.ToString());   
    }

}
