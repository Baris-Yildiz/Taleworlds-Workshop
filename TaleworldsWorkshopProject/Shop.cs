using System.Collections;
using System.Text;
namespace TaleworldsWorkshopProject;
public class Shop
{
    WeaponProperties[] _weaponProperties;
    Random _randomNumberGenerator = new Random();
    List<int> pickedIndexes = new List<int>();

    // shop constructorı içinde random 3 weapon belirlenir ve sunulur.
    public Shop()
    {
        _weaponProperties = new WeaponProperties[3];

        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            int randomIndex = _randomNumberGenerator.Next(0, EntityFactory.weaponsInGame.Length);
            while (pickedIndexes.Contains(randomIndex))
            {
                randomIndex = _randomNumberGenerator.Next(0, EntityFactory.weaponsInGame.Length);
            }
            pickedIndexes.Add(randomIndex);
            _weaponProperties[i] = EntityFactory.weaponsInGame[randomIndex];
        }

        _showItems();
    }

    // shoptaki itemleri konsola yazdırır.
    private void _showItems()
    {
        StringBuilder prompt = new StringBuilder(); 

        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            WeaponProperties weapon = _weaponProperties[i];
            prompt.Append("( " + i + " ) " + weapon.description());
        }

        Console.WriteLine(prompt.ToString());
    }

    //shoptan item almak için
    public void BuyItem(int index)
    {

    }
}