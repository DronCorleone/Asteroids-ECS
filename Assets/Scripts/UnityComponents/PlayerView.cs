using UnityEngine;
using Leopotam.Ecs;


public class PlayerView : MonoBehaviour
{
    private bool _isDead = false;

    public EcsEntity Entity;
    public Transform BulletSpawnPoint;

    public bool IsDead => _isDead;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyView enemy))
        {
            _isDead = true;
        }
    }
}