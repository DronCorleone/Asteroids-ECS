using UnityEngine;
using Leopotam.Ecs;


public class LaserView : MonoBehaviour
{
    public EcsEntity Entity;

    [SerializeField] private float _distance = 50.0f;


    private void Awake()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, _distance);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.TryGetComponent(out EnemyView enemy))
            {
                if (enemy.Type == EnemyType.BigAsteroid)
                {
                    ref var breaking = ref enemy.Entity.Get<Broken>();
                    ref var hit = ref enemy.Entity.Get<Hit>();
                }
                else
                {
                    ref var destroy = ref enemy.Entity.Get<DestroyWithGO>();
                    ref var hit = ref enemy.Entity.Get<Hit>();

                    destroy.GameObject = enemy.gameObject;
                }
            }
        }
    }
}