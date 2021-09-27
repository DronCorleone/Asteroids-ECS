using UnityEngine;


[CreateAssetMenu]
public class Configuration : ScriptableObject
{
    [Header("Player")]
    public GameObject PlayerPrefab;
    public float PlayerSpeed;

    [Header("Game field")]
    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
}