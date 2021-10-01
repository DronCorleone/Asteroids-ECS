using UnityEngine;


[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    [Header("Player")]
    public GameObject PlayerPrefab;
    public float PlayerSpeed;
    public float PlayerRotationSpeed;

    [Header("Game")]
    public int ScoreForBigAsteroid;
    public int ScoreForSmallAsteroid;
    public int ScoreForUFO;

    [Header("Weapon")]
    public GameObject BulletPrefab;
    public GameObject LaserPrefab;
    public int LaserMagazine;
    public float LaserCooldown;
    public float LaserLifetime;
    public float BulletSpeed;

    [Header("Enemies")]
    public GameObject[] BigAsteroidPrefabs;
    public GameObject[] SmallAsteroidPrefabs;
    public GameObject UFOPrefab;
    public float BigAsteroidSpeed;
    public float SmallAsteroidSpeed;
    public float AsteroidRotationSpeedMin;
    public float AsteroidRotationSpeedMax;
    public float UFOSpeed;
    public float AsteroidSpawnTimer;
    public float UFOSpawnTimer;

    [Header("Game field")]
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

    [Header("Input config")]
    public KeyCode BulletFire;
    public KeyCode LaserFire;

    [Header("Enemy moving bounds")]
    public float EnemyMinX;
    public float EnemyMaxX;
    public float EnemyMinY;
    public float EnemyMaxY;
}