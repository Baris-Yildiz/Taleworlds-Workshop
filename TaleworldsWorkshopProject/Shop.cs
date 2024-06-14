using System.Collections;
using System.Numerics;
using System.Text;
namespace TaleworldsWorkshopProject;
public class Shop
{
    public IReadOnlyList<WeaponProperties> WeaponProperties { get => _weaponProperties; }
    private WeaponProperties[] _weaponProperties;

    Random _randomNumberGenerator = new Random();
    List<int> _pickedIndexes = new List<int>();

    public static bool CallFromShop { get => _callFromShop; }
    private static bool _callFromShop = false;

    public Potion HealthPotion { get => _healthPotion; }
    private Potion _healthPotion;

    public Potion AttackPotion { get => _attackPotion; }
    private Potion _attackPotion;

    private int _turnIndex;

    // shop constructorı içinde random 3 weapon belirlenir ve sunulur.
    public Shop(int turnIndex)
    {
        if (!Game.CallFromGame)
        {
            Console.WriteLine("Invalid.");
            return;
        }
        _turnIndex = turnIndex;
        _weaponProperties = new WeaponProperties[3];

        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            int randomIndex = _randomNumberGenerator.Next(0, EntityFactory.WeaponsInGame.Count);
            while (_pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.WeaponsInGame.Count);
            }
            _pickedIndexes.Add(randomIndex);

            WeaponProperties weaponProperties = EntityFactory.WeaponsInGame[randomIndex];
            _weaponProperties[i] = new WeaponProperties(weaponProperties.Name, weaponProperties.AttackPower, weaponProperties.Durability, weaponProperties.Cost);
            _callFromShop = true;
            _weaponProperties[i].IncreaseStats(1 + _turnIndex * 0.1);
            _callFromShop = false;
        }


        _healthPotion = new Potion(Potion.Type.Health, _randomNumberGenerator.Next(50, 70));
        _attackPotion = new Potion(Potion.Type.Attack, _randomNumberGenerator.Next(50, 70));

        Console.WriteLine(_shopDescription());
        _turnIndex = turnIndex;
    }

    // shoptaki itemleri konsola yazdırır.
    private string _shopDescription()
    {
        StringBuilder prompt = new StringBuilder();
        prompt.Append($"Turn {_turnIndex} / 15 started.");
        prompt.AppendLine("\nPlayer encounters a shop! There are 3 items inside waiting to be wielded by a master.");
        prompt.AppendLine("------------------------SHOP------------------------");
        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            WeaponProperties weapon = _weaponProperties[i];
            prompt.Append($"({i}) {weapon.Description}");
        }

        prompt.AppendLine("\nYou can buy one of these weapons and equip it using the Game.Instance.BuyWeapon() method.");
        prompt.AppendLine($"\nYou can buy a Health Potion for {_healthPotion.Cost} gold using the Game.Instance.BuyHealthPotion() method.");
        prompt.AppendLine($"\nYou can buy an Attack Potion for {_attackPotion.Cost} gold using the Game.Instance.BuyAttackPotion() method.");

        prompt.AppendLine($"Exit the shop and advance to the next turn using Game.Instance.Advance().");
        prompt.AppendLine("---------------------END OF SHOP---------------------");

        return prompt.ToString();

    }
    

}