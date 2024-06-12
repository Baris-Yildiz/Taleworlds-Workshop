﻿namespace TaleworldsWorkshopProject;
public class EntityFactory
{
    public static IReadOnlyList<Enemy> EnemiesInGame => _enemiesInGame;
    private static Enemy[] _enemiesInGame = 
    {
        new Enemy("Goblin", 50, 4),
        new Enemy("Dwarf", 20, 10),
        new Enemy("Spider", 70, 2),
        new Enemy("Elemental", 100, 10),
        new Enemy("Assasin", 10, 30),
        new Enemy("Zombie", 110, 8)
    };

    public static IReadOnlyList<WeaponProperties> WeaponsInGame => _weaponsInGame;
    private static WeaponProperties[] _weaponsInGame =
    {
        new WeaponProperties("Rusty Sword", 100, 10, 50),
        new WeaponProperties("Silver Sword", 150, 20, 70),
        new WeaponProperties("Legendary Sword", 1000, 50, 2000),
        new WeaponProperties("Mace", 200, 50, 500),
        new WeaponProperties("Katana", 2000, 20, 900),
        new WeaponProperties("Nunchaku", 300, 30, 250)
    };

    public static IReadOnlyList<Enemy> BossesInGame => _bossesInGame;
    private static Enemy[] _bossesInGame =
    {
        new Enemy("Boss1", 500, 100),
        new Enemy("Boss2", 1500, 300),
        new Enemy("Final Boss", 5000, 600)
    };



}
