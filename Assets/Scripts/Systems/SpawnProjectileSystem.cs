using UnityEngine;
using Leopotam.Ecs;


public class SpawnProjectileSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private EcsFilter<PlayerInputData, Player> _filter;
    private Configuration _config;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var input = ref _filter.Get1(i);
            ref var player = ref _filter.Get2(i);

            if (input.BulletInput == true)
            {
                EcsEntity bulletEntity = _world.NewEntity();

                ref var bullet = ref bulletEntity.Get<Bullet>();

                GameObject bulletGO = Object.Instantiate(_config.BulletPrefab, player.BulletSpawnPoint.position, player.BulletSpawnPoint.rotation);

                bullet.Transform = bulletGO.transform;
                bullet.Speed = _config.BulletSpeed;
                bullet.Direction = bulletGO.transform.up;

                bulletGO.GetComponent<BulletView>().Entity = bulletEntity;
            }

            if (input.LaserInput == true)
            {
                EcsEntity laserEntity = _world.NewEntity();

                ref var laser = ref laserEntity.Get<LaserProjectile>();

                GameObject laserGO = Object.Instantiate(_config.LaserPrefab, player.BulletSpawnPoint.position, player.BulletSpawnPoint.rotation);

                laser.Transform = laserGO.transform;
                laser.Lifetime = _config.LaserLifetime;

                laserGO.GetComponent<LaserView>().Entity = laserEntity;
            }
        }
    }
}