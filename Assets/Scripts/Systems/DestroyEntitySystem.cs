using UnityEngine;
using Leopotam.Ecs;

public class DestroyEntitySystem : IEcsRunSystem
{
    private EcsFilter<Destroy, Bullet> _filterBullet;
    private EcsFilter<Destroy, LaserProjectile> _filterLaser;

    public void Run()
    {
        foreach (var i in _filterBullet)
        {
            EcsEntity bulletEntity = _filterBullet.GetEntity(i);

            ref var bullet = ref _filterBullet.Get2(i);

            Object.Destroy(bullet.Transform.gameObject);

            bulletEntity.Destroy();
        }

        foreach (var i in _filterLaser)
        {
            EcsEntity laserEntity = _filterLaser.GetEntity(i);

            ref var laser = ref _filterLaser.Get2(i);

            Object.Destroy(laser.Transform.gameObject);

            laserEntity.Destroy();
        }
    }
}