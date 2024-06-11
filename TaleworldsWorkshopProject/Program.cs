
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


    public void StartGame()
    {
        Console.WriteLine("Started new game");
        Advance();
    }

    public  void Help()
    {
        Console.WriteLine("Help page!");
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
        Console.WriteLine("Exited game");
        _instance = null;
        
    }

    // bir sonraki tura geçer.
    public void Advance()
    {

        if (_currentTurnIndex % 3 == 0)
        {
            _currentShop = new Shop();
        } else
        {
            _currentTurn = new Turn(_currentTurnIndex);
        }

        _currentTurnIndex++;
        
    }

    public void Escape()
    {
        Advance();
    }

    public void SelectEnemy(int index)
    {
        CombatScene combatScene = new CombatScene(_currentTurn.Enemies[index]);
        combatScene.StartCombat();
    }

   public static void Main(string[] args)
    {
        Game game = Game.Instance;
        game.StartGame();
        // Display the number of command line arguments.
    }
}