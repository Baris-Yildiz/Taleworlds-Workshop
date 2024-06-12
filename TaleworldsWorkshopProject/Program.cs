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

    public static bool GameStarted { get => _gameStarted; }
    private static bool _gameStarted = false;

    public static bool InTurn { get => _inTurn; }
    private static bool _inTurn = false;

    public static bool InShop { get => _inShop; }
    private static bool _inShop = false;

    private static bool _escaped = false;
    int escapeAmount = 0;

    private static bool _inBossTurn = false;


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
        if (_gameStarted)
        {
            Console.WriteLine("The help menu cannot be accessed while the game is running!");
            return; 
        }

        Console.WriteLine("\n===== OYUN Tanıtımı =====");
        List<string> gameRules = new List<string>
            {
                "Oyunda 3 tip düşman var." ,
                "final boss hariç diğer düşmanlardan kaçma imkanı var." ,
                "Tur aralarında shopdan item alabilirsiniz." ,
                "10 Tip silah mevcuttur.",
                "Silahlar zamanla kırılabilir."
              
                
            };

        gameRules.ForEach(rule => Console.WriteLine(rule));

        Console.WriteLine("\nİyi oyunlar!");
    }

    public  void ExitGame()
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

        if (!_escaped)
        {
            Console.WriteLine("You need to pick an enemy to fight or escape.");
            return;
        }

        _inShop = false;
        _inTurn = false;

        if (_currentTurnIndex % 3 == 0)
        {
            _inShop = true;
            _currentShop = new Shop();
        }
        else
        {
            _inTurn = true;
            _currentTurn = new Turn(_currentTurnIndex);
        }

        _currentTurnIndex++;
    }

    public void Escape()
    {
        if (!_gameStarted)
        {
            Console.WriteLine("The game hasn't started yet!");
            return;
        }

        if (escapeAmount > 3)
        {
            Console.WriteLine("You cannot escape any more times.");
            return;
        }

        if (_inBossTurn)
        {
            Console.WriteLine("You cannot escape from the boss.");
            return;
        }

        if (_inTurn)
        {
            _escaped = true;
            Advance();
            _escaped = false;
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

        CombatScene combatScene = new CombatScene(_currentTurn.Enemies[index]);
        combatScene.StartCombat();
        _escaped = true;
        Advance();
        _escaped = false;
    }

    public static void Main(string[] args)
    {
        Game game = Game.Instance;
        game.StartGame();
        // Display the number of command line arguments.
    }
}