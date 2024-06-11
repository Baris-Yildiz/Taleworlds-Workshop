public class CombatScene
{

    public void StartCombat()
    {
        Player player = Player.Instance;
        int round = 1;

        Enemy enemy = new Enemy($"Enemy{round}");

        Console.WriteLine($"\nRound {round}");
        while (player.Health > 0 && enemy.Health > 0)
        {
            Console.WriteLine($"{enemy.Name} attacks Player");
            player.TakeDamage(enemy.Attack());
            Console.WriteLine($"Player health: {player.Health}");
            if (player.Health <= 0)
            {
                Console.WriteLine("Player is dead. Game Over.");
                Game.Instance.ExitGame();
                return;
            }

            Console.WriteLine($"Player attacks {enemy.Name}");
            enemy.TakeDamage(player.Attack());
            Console.WriteLine($"{enemy.Name} health: {enemy.Health}");
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"{enemy.Name} is dead.");
            }
        }

        if (player.Health > 0)
        {
            Console.WriteLine("Enemy defeated! Proceeding to the next round.");
            
        }

    
    }
}


