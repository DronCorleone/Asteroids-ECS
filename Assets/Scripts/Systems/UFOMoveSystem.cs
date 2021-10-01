using Leopotam.Ecs;
using UnityEngine;

public class UFOMoveSystem : IEcsRunSystem
{
    private EcsFilter<RuntimeData> _filterData;
    private EcsFilter<UFO>.Exclude<DestroyWithGO> _filter;

    private Transform _playerTransform;

    public void Run()
    {
        foreach (var i in _filterData)
        {
            ref var data = ref _filterData.Get1(i);
            _playerTransform = data.PlayerTransform;
        }

        foreach (var i in _filter)
        {
            ref var ufo = ref _filter.Get1(i);
            Vector3 direction = (_playerTransform.position - ufo.Transform.position).normalized;
            ufo.Transform.Translate(direction * ufo.Speed * Time.deltaTime);
        }
    }
}