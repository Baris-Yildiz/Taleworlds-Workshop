namespace TaleworldsWorkshopProject;
public class EntityFactory
{
    public static IReadOnlyList<Enemy> EnemiesInGame => _enemiesInGame;
    private static Enemy[] _enemiesInGame = 
    {
        new Enemy("Goblin", 60, 10),
        new Enemy("Dwarf", 80, 15),
        new Enemy("Spider", 70, 12),
        new Enemy("Elemental", 100, 20),

        new Enemy("Assasin", 50, 25),
        new Enemy("Zombie", 120, 18),
        new Enemy("Dark Elf", 80, 12),
        new Enemy("Vampire", 120, 18),
        new Enemy("Werewolf", 150, 20),
        new Enemy("Lich", 180, 22)
    };

    public static IReadOnlyList<WeaponProperties> WeaponsInGame => _weaponsInGame;
    private static WeaponProperties[] _weaponsInGame =
    {
        new WeaponProperties("Rusty Sword", 50, 100, 30),
        new WeaponProperties("Silver Sword", 70, 150, 50),
        new WeaponProperties("Legendary Sword", 100, 250, 100),
        new WeaponProperties("Mace", 80, 120, 40),
        new WeaponProperties("Katana", 140, 100, 80),
        new WeaponProperties("Nunchaku", 60, 300, 20),
        new WeaponProperties("Flaming Sword", 35, 250, 180),
        new WeaponProperties("Ice Dagger", 25, 150, 120),
        new WeaponProperties("Thunder Axe", 45, 300, 220)
    };

    public static IReadOnlyList<Enemy> BossesInGame => _bossesInGame;
    private static Enemy[] _bossesInGame =
    {

         
        new Enemy("Fire Lord", 350, 25),
        new Enemy("Ice Queen", 1000, 60),
        new Enemy("Thunder King", 5000, 90)

    };

}
