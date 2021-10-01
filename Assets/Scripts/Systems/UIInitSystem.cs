using Leopotam.Ecs;
using UnityEngine;

public class UIInitSystem : IEcsInitSystem
{
    private EcsWorld _world = null;
    private Configuration _config;


    public void Init()
    {
        EcsEntity uiEntity = _world.NewEntity();

        GameObject uiGO = Object.Instantiate(_config.UIPrefab, Vector3.zero, Quaternion.identity);

        ref var ui = ref uiEntity.Get<UIComponent>();
        ui.UIGO = uiGO;
    }
}