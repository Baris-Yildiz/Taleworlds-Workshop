using TaleworldsWorkshopProject;

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


    public void StartGame()
    {
        Console.WriteLine("Started new game");
    }

    public void Help()
    {
        Console.WriteLine("Help page!");
    }

    public void ExitGame()
    {
        Console.WriteLine("Exited game");
        _instance = null;
        
    }

    static void Main(string[] args)
    {
        // Display the number of command line arguments.
    }
}


public class Enemy
{

}


public class Boss
{

}


public class Inventory
{

}


public class Items
{

}

public class Weapon : Item
{

}

public class Shop
{

}