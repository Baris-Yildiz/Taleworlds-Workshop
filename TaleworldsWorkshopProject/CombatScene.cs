namespace TaleworldsWorkshopProject;
public class CombatScene
{
    public static bool CallFromCombatScene { get => _callFromCombatScene; }
    private static bool _callFromCombatScene;

    Enemy _enemy;
    Random _random = new Random();

    public CombatScene(Enemy enemy)
    {
        if (!Game.CallFromGame)
        {
            return;
        }
        _enemy = enemy;
    }

    public void StartCombat()
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }

        _callFromCombatScene = true;
        Console.WriteLine("-----------------------COMBAT-----------------------\n");
        Console.WriteLine($"Player vs {_enemy.Name}! Let the fight begin!\n");
        Player player = Player.Instance;

        while (player.Health > 0 && _enemy.Health > 0)
        {
            //enemy attacks player
            Console.WriteLine($"{_enemy.Name} attacks Player");
            int enemyAttackPower = _enemy.Attack();
            player.TakeDamage(enemyAttackPower);
            Console.WriteLine($"Player takes {enemyAttackPower} damage. Player health: {player.Health}\n");
            if (player.Health <= 0)
            {
                Console.WriteLine("Player is dead. Game Over.");
                Game.Instance.ExitGame();
                return;
            }
            //player attacks enemy 
            Console.WriteLine($"Player attacks {_enemy.Name}");
            int playerAttackPower=player.Attack();
            _enemy.TakeDamage(playerAttackPower);
            Console.WriteLine($"Enemy takes {playerAttackPower} damage. {_enemy.Name} health: {_enemy.Health}\n");
            if (_enemy.Health <= 0)
            {
                Console.WriteLine($"{_enemy.Name} is dead.");
                int goldAmount = _random.Next(50, 100);
                foreach (Enemy e in EntityFactory.BossesInGame)
                {
                    if (e.Name.Equals(_enemy.Name))
                    {
                        goldAmount = _random.Next(300, 400);
                        break;
                    }
                }
                player.EarnGold(goldAmount);
            }
        }

        if (player.Health > 0)
        {
            Console.WriteLine("Enemy defeated! Proceeding to the next turn.");
        }
        Console.WriteLine("\n--------------------END OF COMBAT--------------------");
        _callFromCombatScene = false;
    }
}


