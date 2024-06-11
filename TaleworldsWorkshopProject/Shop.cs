using System.Text;

public class Shop
{
    WeaponProperties[] _weaponProperties;
    Random _randomNumberGenerator = new Random();

    // shop constructorı içinde random 3 weapon belirlenir ve sunulur.
    public Shop()
    {
        _weaponProperties = new WeaponProperties[3];

        for (int i = 0; i < _weaponProperties.Length; i++)
        {
            _weaponProperties[i] = new WeaponProperties("test " + i, _randomNumberGenerator.Next(10,100), _randomNumberGenerator.Next(1,10), _randomNumberGenerator.Next(50, 500));
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
            prompt.Append(weapon.description());
        }

        Console.WriteLine(prompt.ToString());
    }

    //shoptan item almak için
    public void BuyItem(int index)
    {

    }
}