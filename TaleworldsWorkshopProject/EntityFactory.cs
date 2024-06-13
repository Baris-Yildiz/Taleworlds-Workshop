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
        new Enemy("Zombie", 120, 18)
    };

    public static IReadOnlyList<WeaponProperties> WeaponsInGame => _weaponsInGame;
    private static WeaponProperties[] _weaponsInGame =
    {
        new WeaponProperties("Rusty Sword", 50, 20, 30),
        new WeaponProperties("Silver Sword", 70, 40, 50),
        new WeaponProperties("Legendary Sword", 100, 50, 100),
        new WeaponProperties("Mace", 60, 35, 30),
        new WeaponProperties("Katana", 85, 45, 60),
        new WeaponProperties("Nunchaku", 40, 25, 20)
    };

    public static IReadOnlyList<Enemy> BossesInGame => _bossesInGame;
    private static Enemy[] _bossesInGame =
    {
        new Enemy("Boss1", 400, 30),
        new Enemy("Boss2", 750, 50),
        new Enemy("Final Boss", 1000, 60)
    };

}
