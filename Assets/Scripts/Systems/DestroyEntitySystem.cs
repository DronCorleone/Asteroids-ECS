using UnityEngine;
using Leopotam.Ecs;

public class DestroyEntitySystem : IEcsRunSystem
{
    private EcsFilter<DestroyWithGO>.Exclude<BigAsteroid> _filter;
    private EcsFilter<DestroyWithGO, BigAsteroid> _filterBigAsteroid;

    public void Run()
    {
        foreach (var i in _filter)
        {
            Object.Destroy(_filter.Get1(i).GameObject);
            _filter.GetEntity(i).Destroy();
        }

        foreach (var i in _filterBigAsteroid)
        {
            Object.Destroy(_filter.Get1(i).GameObject);
            _filter.GetEntity(i).Destroy();

            //TODO spawn little asteroids
        }
    }
}