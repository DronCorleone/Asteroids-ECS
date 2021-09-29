using UnityEngine;
using Leopotam.Ecs;


public class LaserLifeTimeSystem : IEcsRunSystem
{
    private EcsFilter<LaserProjectile> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var laser = ref _filter.Get1(i);

            laser.Lifetime -= Time.deltaTime;

            if (laser.Lifetime <= 0)
            {
                _filter.GetEntity(i).Get<Destroy>();
            }
        }
    }
}