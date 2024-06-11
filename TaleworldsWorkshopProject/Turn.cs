using System.Text;
using System.Xml.Linq;

public class Turn
{
    private int _turnIndex;
    private Enemy[] _enemies = new Enemy[3];
    public static int maxTurns = 20;

    public Turn()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i] = new Enemy("test");
        }
    }

    public override string ToString()
    {
        StringBuilder prompt = new StringBuilder();  
        prompt.Append("Turn: " + _turnIndex + " / " + maxTurns + " \nThere are three enemies: ");

        for (int i = 0; i < _enemies.Length; i++)
        {
            Enemy enemy = _enemies[i];
            prompt.Append(" ( " + i + " ) " + enemy.Name + " with " + enemy.AttackPower + " attack power.\n");
        }

        prompt.Append("You can instead escape using the escape() method.\n");

        return prompt.ToString();
    }

}
