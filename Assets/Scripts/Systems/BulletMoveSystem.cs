using UnityEngine;
using Leopotam.Ecs;

public class BulletMoveSystem : IEcsRunSystem
{
    private EcsFilter<Bullet> _filter;
    private Configuration _config;

    public void Run()
    {
        foreach (var i in _filter)
        {
            EcsEntity bulletEntity = _filter.GetEntity(i);

            ref var bullet = ref _filter.Get1(i);

            bullet.Transform.Translate(Vector3.up * bullet.Speed * Time.deltaTime);

            if (bullet.Transform.position.x > _config.MaxX ||
                bullet.Transform.position.x < _config.MinX ||
                bullet.Transform.position.y > _config.MaxY ||
                bullet.Transform.position.y < _config.MinY)
            {
                bulletEntity.Get<Destroy>();
            }
        }
    }
}