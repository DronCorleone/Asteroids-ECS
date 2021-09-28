using UnityEngine;


[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    [Header("Player")]
    public GameObject PlayerPrefab;
    public float PlayerSpeed;

    [Header("Weapon")]
    public GameObject BulletPrefab;
    public GameObject LaserPrefab;
    public int LaserMagazine;
    public float LaserCooldown;

    [Header("Game field")]
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

    [Header("Input config")]
    public KeyCode BulletFire;
    public KeyCode LaserFire;
}