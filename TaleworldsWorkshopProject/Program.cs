namespace TaleworldsWorkshopProject;
public class Game
{
    private Game() { }
    
    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }
    }
            
    private static Game? _instance;

    private int _currentTurnIndex = 1;
    private Turn _currentTurn;

    private Shop _currentShop;

    public bool InBossTurn { get => _inBossTurn;}
    private bool _inBossTurn = false;

    private BossTurn _currentBossTurn;
    private int _currentBossTurnIndex = 1;

    public bool GameStarted { get => _gameStarted; }
    private bool _gameStarted = false;

    public bool InTurn { get => _inTurn; }
    private bool _inTurn = false;

    public bool InShop { get => _inShop; }
    private bool _inShop = false;

    private bool _escaped = false;
    int escapeAmount = 0;

    public static bool CallFromGame { get => _callFromGame; }
    private static bool _callFromGame = false;

    public void StartGame()
    {
        if (_gameStarted) {
            Console.WriteLine("The game has already started!");
            return;
        }
        
        _gameStarted = true;
        Console.WriteLine("\nStarted a new game! Advancing to the first turn.\n");

        _callFromGame = true;
        _callFromGame = false;
        _inTurn = true;
    }

    public void Help()
    {
        if (_gameStarted)
        {
            Console.WriteLine("The help menu cannot be accessed while the game is running!");
            return;
        }
        ShowGameRules();
        Console.WriteLine("Good luck!");
    }
    private void ShowGameRules()
    {
        Console.WriteLine("\n----------------------GAME RULES----------------------");
        List<string> gameRules = new List<string>
            {
                "The game consists of 30 turns.",
                "Every third turn, there is a shop where you can buy weapons and potions with gold.",
                "Every tenth turn, there is a mini-boss and at the end, you fight the final boss.",
                "Every other turn, you pick from three random enemies to fight with. The enemies get increasingly more difficult. You can also choose to escape.",
                "If you escape, you will not get a buff at the start of the next turn. Enemies always get a buff at the start of a turn.",
                "Weapons have durabilities and they can break down in the middle of a combat. If your weapon breaks down, you use your fists. You can change weapons by buying a new one from the shop."
            };

        gameRules.ForEach(rule => Console.WriteLine(rule));
        Console.WriteLine("-------------------END OF GAME RULES-------------------\n");
    }

    public void ExitGame()
    {
        if (!_gameStarted)
        {
            Console.WriteLine("No game to exit from.");
            return;
        }

        Console.WriteLine("Exited game");
        _instance = null;
        _gameStarted=false;
    }

    // bir sonraki tura geçer.
    public void Advance()
    {
        if (!_gameStarted)
        {
            Console.WriteLine("The game hasn't started yet!");
            return;
        }

        if (_inShop)
        {
            _escaped = true;
        }

        if (!_escaped)
        {
            Console.WriteLine("You need to pick an enemy to fight or escape.");
            return;
        }

        _inShop = false;
        _inTurn = false;
        _inBossTurn = false;

        if (_currentTurnIndex % 3 == 0)
        {
           
            _inShop = true;
            _callFromGame = true;
            _currentShop = new Shop(_currentTurnIndex);
            _callFromGame = false;

        } else if (_currentTurnIndex % 10 == 0)
        {
            _inBossTurn = true;
            _callFromGame = true;
            _currentBossTurn = new BossTurn(_currentBossTurnIndex++);
            _callFromGame = false;

        } else
        {
            _inTurn = true;
            _callFromGame = true;
            _currentTurn = new Turn(_currentTurnIndex);
            _callFromGame = false;
        }

        _currentTurnIndex++;
        _escaped = false;
    }

    public void Escape()
    {
        if (!_gameStarted)
        {
            Console.WriteLine("The game hasn't started yet!");
            return;
        }

        if (escapeAmount > 2)
        {
            Console.WriteLine("You've escaped enough.");
            return;
        }

        if (_inBossTurn)
        {
            Console.WriteLine("You cannot escape from the boss.");
            return;
        }

        if (_inTurn)
        {
            escapeAmount++;
            Console.WriteLine($"One escape used. Remaining escapes: {3 - escapeAmount}");
             
            _escaped = true;
            Advance();
        } else
        {
            Console.WriteLine("You cannot escape from here.");
        }
    }

    public void SelectEnemy(int index)
    {
        if (!_gameStarted)
        {
            Console.WriteLine("The game hasn't started yet!");
            return;
        }

        if (!_inTurn)
        {
            Console.WriteLine("No enemy to select from.");
            return;
        }

        if (index > 2)
        {
            Console.WriteLine("Select either 0,1 or 2 as index");
            return;
        }
        _callFromGame = true;
        Enemy enemy = _currentTurn.Enemies[index]; 

        CombatScene combatScene = new CombatScene(new Enemy(enemy.Name, enemy.Health, enemy.AttackPower));

        
        combatScene.StartCombat();
        _callFromGame = false;

        _escaped = true;
        Advance();
    }

    public void BuyWeapon(int index)
    {
        if (!_inShop)
        {
            Console.WriteLine("Invalid command.");
            return;
        }

        if (index > 2)
        {
            Console.WriteLine("Select either 0,1 or 2 as index");
            return;
        }

        WeaponProperties weaponProperties = _currentShop.WeaponProperties[index];
        _callFromGame = true;
        Player.Instance.BuyWeapon(weaponProperties);
        _callFromGame = false;
    }

    public void FightBoss()
    {
        if (!_inBossTurn)
        {
            Console.WriteLine("Invalid command.");
            return;
        }

        Enemy boss = _currentBossTurn.Boss;
        CombatScene combatScene = new CombatScene(new Enemy(boss.Name, boss.Health, boss.AttackPower));

        _callFromGame = true;
        combatScene.StartCombat();
        _callFromGame = false;

        if (_gameStarted)
        {
            _escaped = true;
            Advance();
        }
        
    }

    public void BuyHealthPotion()
    {
        if (!_inShop)
        {
            Console.WriteLine("No health potion here.");
            return;
        }

        Potion healthPotion = _currentShop.HealthPotion;
        Player player = Player.Instance;

        if (healthPotion.Cost > Player.Instance.Gold)
        {
            Console.WriteLine($"You don't have enough gold to buy that. Current Gold: {Player.Instance.Gold}");
            return;
        }

        _callFromGame = true;
        Player.Instance.HealPlayer(healthPotion);
        _callFromGame = false;

        Console.WriteLine($"Healed player for {healthPotion.EffectRatio}.\nRemaining Gold: {Player.Instance.Gold} Current Health: {Player.Instance.Health}");
    }

    public void BuyAttackPotion()
    {
        if (!_inShop)
        {
            Console.WriteLine("No attack potion here.");
            return;
        }

        Potion attackPotion = _currentShop.AttackPotion;
        
        if (attackPotion.Cost > Player.Instance.Gold)
        {
            Console.WriteLine($"You don't have enough gold to buy that. Current Gold: {Player.Instance.Gold}");
            return;
        }

        _callFromGame = true;
        Player.Instance.BuffWeapon(attackPotion);
        _callFromGame = false;
        Console.WriteLine($"Buffed weapon for {attackPotion.EffectRatio}.\nRemaining Gold: {Player.Instance.Gold} Current Attack Power: {Weapon.Instance.AttackPower}");
    }

    public static void Main(string[] args)
    {
        Game game = Game.Instance;
        game.StartGame();
        // Display the number of command line arguments.
    }
}