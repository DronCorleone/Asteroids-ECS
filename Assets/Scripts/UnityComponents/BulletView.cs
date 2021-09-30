using UnityEngine;
using Leopotam.Ecs;


public class BulletView : MonoBehaviour
{
    public EcsEntity Entity;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyView enemy))
        {
            if (enemy.Type == EnemyType.BigAsteroid)
            {
                ref var breaking = ref enemy.Entity.Get<Broken>();
            }
            else
            {
                ref var destroy = ref enemy.Entity.Get<DestroyWithGO>();

                destroy.GameObject = enemy.gameObject;
            }

        }

        ref var selfDestoy = ref Entity.Get<DestroyWithGO>();
        selfDestoy.GameObject = this.gameObject;
    }
}