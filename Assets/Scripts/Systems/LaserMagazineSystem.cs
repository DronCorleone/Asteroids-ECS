using Leopotam.Ecs;
using UnityEngine;

public class LaserMagazineSystem : IEcsRunSystem
{
    private EcsFilter<LaserMagazine> _filter;
    private EcsFilter<RuntimeData> _filterData;
    private Configuration _config;
    private float _timer;


    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var laserMagazine = ref _filter.Get1(i);

            if (laserMagazine.Capacity == _config.LaserMagazine)
            {
                _timer = 0.0f;
            }
            else
            {
                _timer += Time.deltaTime;

                if (_timer >= _config.LaserCooldown)
                {
                    _timer = 0.0f;
                    laserMagazine.Capacity++;
                }
            }

            foreach (var j in _filterData)
            {
                ref var data = ref _filterData.Get1(i);

                data.CurrentLasers = laserMagazine.Capacity;
                
                if (_timer == 0.0f)
                {
                    data.LaserTimer = 0.0f;
                }
                else
                {
                    data.LaserTimer = _config.LaserCooldown - _timer;
                }
            }
        }
    }
}