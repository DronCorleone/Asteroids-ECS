using Leopotam.Ecs;
using UnityEngine;

public class AsteroidBreakSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private Configuration _config;

    private EcsFilter<AsteroidBig, Broken> _filter;


    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var asteroid = ref _filter.Get1(i);

            for (int x = 0; x < Random.Range(1, 3); x++)
            {
                EcsEntity asteroidSmallEntity = _world.NewEntity();

                ref var asteroidSmall = ref asteroidSmallEntity.Get<AsteroidSmall>();

                GameObject asteroidGO = Object.Instantiate(_config.SmallAsteroidPrefabs[Random.Range(0, _config.SmallAsteroidPrefabs.Length - 1)],
                                                            asteroid.Transform.position, asteroid.Transform.rotation);

                asteroidGO.GetComponent<EnemyView>().Entity = asteroidSmallEntity;

                asteroidSmall.Speed = _config.SmallAsteroidSpeed;
                asteroidSmall.Transform = asteroidGO.transform;
                asteroidSmall.Direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized;
            }

            ref var destroy = ref _filter.GetEntity(i).Get<DestroyWithGO>();
            destroy.GameObject = asteroid.Transform.gameObject;
        }
    }
}