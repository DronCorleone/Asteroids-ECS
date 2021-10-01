using Leopotam.Ecs;


public class RuntimeDataInitSystem : IEcsInitSystem
{
    readonly EcsWorld _world = null;

    public void Init()
    {
        EcsEntity runtimeDataEntity = _world.NewEntity();
        ref var runtimeDataComponent = ref runtimeDataEntity.Get<RuntimeData>();
    }
}