using UnityEngine;
using Leopotam.Ecs;

public class DestroyEntitySystem : IEcsRunSystem
{
    private EcsFilter<DestroyWithGO> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            Object.Destroy(_filter.Get1(i).GameObject);
            _filter.GetEntity(i).Destroy();
        }
    }
}