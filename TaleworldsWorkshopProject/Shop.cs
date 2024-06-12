using System.Collections;
using System.Text;
namespace TaleworldsWorkshopProject;
public class Shop
{
    public IReadOnlyList<WeaponProperties> WeaponProperties { get => _weaponProperties; }
    private WeaponProperties[] _weaponProperties;

    Random _randomNumberGenerator = new Random();
    List<int> pickedIndexes = new List<int>();

    // shop constructorı içinde random 3 weapon belirlenir ve sunulur.
    public Shop()
    {
        _weaponProperties = new WeaponProperties[3];

        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            int randomIndex = _randomNumberGenerator.Next(0, EntityFactory.WeaponsInGame.Count);
            while (pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.WeaponsInGame.Count);
            }
            pickedIndexes.Add(randomIndex);
            _weaponProperties[i] = EntityFactory.WeaponsInGame[randomIndex];
        }

        Console.WriteLine(_shopDescription());
    }

    // shoptaki itemleri konsola yazdırır.
    private string _shopDescription()
    {
        StringBuilder prompt = new StringBuilder(); 

        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            WeaponProperties weapon = _weaponProperties[i];
            prompt.Append("( " + i + " ) " + weapon.Description);
        }

        return prompt.ToString();
    }

    //shoptan item almak için
    public void BuyItem(int index)
    {

    }
}