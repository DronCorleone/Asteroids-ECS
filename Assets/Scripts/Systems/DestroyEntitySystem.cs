using UnityEngine;
using Leopotam.Ecs;

public class DestroyEntitySystem : IEcsRunSystem
{
    private EcsFilter<Destroy, Bullet> _filterBullet;

    public void Run()
    {
        foreach (var i in _filterBullet)
        {
            EcsEntity bulletEntity = _filterBullet.GetEntity(i);

            ref var bullet = ref _filterBullet.Get2(i);

            Object.Destroy(bullet.Transform.gameObject);

            bulletEntity.Destroy();
        }
    }
}