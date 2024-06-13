using System.Collections;
using System.Text;
namespace TaleworldsWorkshopProject;
public class Shop
{
    public IReadOnlyList<WeaponProperties> WeaponProperties { get => _weaponProperties; }
    private WeaponProperties[] _weaponProperties;

    Random _randomNumberGenerator = new Random();
    List<int> pickedIndexes = new List<int>();

    public Potion HealthPotion { get => healthPotion; }
    private Potion healthPotion;

    public Potion AttackPotion { get => attackPotion; }
    private Potion attackPotion;

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
            while (pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.WeaponsInGame.Count);
            }
            pickedIndexes.Add(randomIndex);

            WeaponProperties weaponProperties = EntityFactory.WeaponsInGame[randomIndex];
            _weaponProperties[i] = new WeaponProperties(weaponProperties.Name, weaponProperties.AttackPower, weaponProperties.Durability, weaponProperties.Cost);
        }

        IncreaseWeaponStats(1 + _turnIndex * 0.1);
        healthPotion = new Potion(Potion.Type.Health, _randomNumberGenerator.Next(50, 70));
        attackPotion = new Potion(Potion.Type.Attack, _randomNumberGenerator.Next(50, 70));

        Console.WriteLine(_shopDescription());
        _turnIndex = turnIndex;
    }
    public void IncreaseWeaponStats(double factor)
    {
        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            _weaponProperties[i] = _weaponProperties[i].IncreaseStats(factor);
        }
    }

    // shoptaki itemleri konsola yazdırır.
    private string _shopDescription()
    {
        StringBuilder prompt = new StringBuilder();

        prompt.AppendLine("Player encounters a shop! There are 3 items inside waiting to be wielded by a master.");
        prompt.AppendLine("------------------------SHOP------------------------");
        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            WeaponProperties weapon = _weaponProperties[i];
            prompt.Append($"({i}) {weapon.Description}");
        }

        prompt.AppendLine("You can buy one of these weapons and equip it using the Game.Instance.BuyWeapon() method.");
        prompt.AppendLine($"You can buy a Health Potion for {healthPotion.Cost} gold using the Game.Instance.BuyHealthPotion() method.");
        prompt.AppendLine($"You can buy an Attack Potion for {attackPotion.Cost} gold using the Game.Instance.BuyAttackPotion() method.");

        prompt.AppendLine($"Exit the shop and Advance to the next turn using Game.Instance.Advance().");
        prompt.AppendLine("---------------------END OF SHOP---------------------");

        return prompt.ToString();

    }
    

}