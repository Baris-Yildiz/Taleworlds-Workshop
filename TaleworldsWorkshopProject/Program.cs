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

    public void StartGame()
    {
        if (_gameStarted) {
            Console.WriteLine("The game has already started!");
            return;
        }

        
        _gameStarted = true;
        Console.WriteLine("Started new game! Advancing to the first turn.");


        _currentTurn = new Turn(_currentTurnIndex++);
        _inTurn = true;
    }

    public  void Help()
    {
        Console.WriteLine("\n===== HELP MENU =====");
        ShowGameRules();

        if (_gameStarted)
        {
            Console.WriteLine("The help menu cannot be accessed while the game is running!");
            return; 
        }

        Console.WriteLine("\nİyi oyunlar!");
    }
    private void ShowGameRules()
    {
        Console.WriteLine("\n===== OYUN TANITIMI =====");
        List<string> gameRules = new List<string>
            {
                "Oyunda 3 tip düşman var.",
                "Her tur istediğin düşmanı seçebilirsin",
                "Bosslar hariç diğer düşmanlardan kaçma imkanı var.",
                "Tur aralarında shopdan item alabilirsiniz.",
                "6 Tip silah mevcuttur.",
                "Silahlar zamanla kırılabilir.",
                "Enemy ile Fight sırasında sadece bir silah kullanabilirsin;eğer bu kullandığın silah kırılırsa default olarak yumruk kullanırsın (yumruk kırılamaz ve hep aynı hasarı vurur)",
            };

        gameRules.ForEach(rule => Console.WriteLine(rule));
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
        _instance = Game.Instance;
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
            _currentShop = new Shop();
        } else if (_currentTurnIndex % 10 == 0)
        {
            _inBossTurn = true;
            _currentBossTurn = new BossTurn(_currentBossTurnIndex++);

        } else
        {
            _inTurn = true;
            _currentTurn = new Turn(_currentTurnIndex);
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

        Enemy enemy = _currentTurn.Enemies[index]; 
        CombatScene combatScene = new CombatScene(new Enemy(enemy.Name, enemy.Health, enemy.AttackPower));
        combatScene.StartCombat();

        _escaped = true;
        Advance();
    }

    public void BuyWeapon(int index)
    {
        if (!_inShop || !_gameStarted)
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
        Player.Instance.BuyWeapon(weaponProperties);
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
        combatScene.StartCombat();

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

        Player.Instance.HealPlayer((int)(healthPotion.EffectRatio * player.Health * 0.01f));
        Console.WriteLine($"Healed player for %{(int)healthPotion.EffectRatio}.");
    }

    public void BuffWeapon()
    {
        if (!_inShop)
        {
            Console.WriteLine("No attack potion here.");
            return;
        }

        Potion attackPotion = _currentShop.AttackPotion;
        Weapon.Instance.BuffWeapon((int)(attackPotion.EffectRatio * Weapon.Instance.AttackPower * 0.01f));
        Console.WriteLine($"Buffed weapon for %{(int)attackPotion.EffectRatio}.");
    }

    public static void Main(string[] args)
    {
        Game game = Game.Instance;
        game.StartGame();
        // Display the number of command line arguments.
    }
}