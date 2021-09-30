using UnityEngine;
using Leopotam.Ecs;


public class EnemyView : MonoBehaviour
{
    [SerializeField] private EnemyType _type;

    public EcsEntity Entity;

    public EnemyType Type => _type;
}