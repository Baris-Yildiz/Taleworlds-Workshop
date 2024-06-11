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
            enemy.TakeDamage(player.Attack());
            Console.WriteLine($"Enemy takes {playerAttackPower} damage. {enemy.Name} Enemy  health: {enemy.Health}");
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


