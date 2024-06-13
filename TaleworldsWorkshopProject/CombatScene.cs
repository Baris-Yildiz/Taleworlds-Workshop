namespace TaleworldsWorkshopProject;
public class CombatScene
{
    Enemy enemy;
    public static bool CallFromCombatScene { get => _callFromCombatScene; }
    private static bool _callFromCombatScene;

    public CombatScene(Enemy enemy)
    {
        if (!Game.CallFromGame)
        {
            return;
        }
        this.enemy = enemy;
    }

    public void StartCombat()
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        _callFromCombatScene = true;
        Console.WriteLine("-----------------------COMBAT-----------------------");
        Console.WriteLine($"Player vs {enemy.Name}! Let the fight begin!\n");
        Player player = Player.Instance;

        while (player.Health > 0 && enemy.Health > 0)
        {
            //enemy attacks player
            Console.WriteLine($"{enemy.Name} attacks Player");
            int enemyAttackPower = enemy.Attack();
            player.TakeDamage(enemyAttackPower);
            Console.WriteLine($"Player takes {enemyAttackPower} damage. Player health: {player.Health}");
            if (player.Health <= 0)
            {
                Console.WriteLine("Player is dead. Game Over.");
                Game.Instance.ExitGame();
                return;
            }
            //player attacks enemy 
            Console.WriteLine($"Player attacks {enemy.Name}");
            int playerAttackPower=player.Attack();
            enemy.TakeDamage(playerAttackPower);
            Console.WriteLine($"Enemy takes {playerAttackPower} damage. {enemy.Name} health: {enemy.Health}");
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} is dead.");
                player.EarnGold(10);
            }
        }

        if (player.Health > 0)
        {
            Console.WriteLine("Enemy defeated! Proceeding to the next turn.");
        }
        Console.WriteLine("--------------------END OF COMBAT--------------------");
        _callFromCombatScene = false;
    }
}


