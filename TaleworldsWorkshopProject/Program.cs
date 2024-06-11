﻿

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


    public  void StartGame()
    {
        Console.WriteLine("Started new game");
        Console.WriteLine("Oyuncu OLuşturuldu");


    }

    public  void Help()
    {
        Console.WriteLine("Help page!");
        Console.WriteLine("\n===== OYUN Tanıtımı =====");
        List<string> gameRules = new List<string>
            {
                "Oyunda 3 tip düşman var." +
                "final boss hariç diğer düşmanlardan kaçma imkanı var." +
                "Tur aralarında shopdan item alabilirsiniz." +
                "10 Tip silah mevcuttur."+
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

public class Shop
{

}