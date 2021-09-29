using Leopotam.Ecs;


public class LaserMagazineInitSystem : IEcsInitSystem
{
    readonly EcsWorld _world = null;
    private Configuration _config;

    public void Init()
    {
        EcsEntity laserMagazineEntity = _world.NewEntity();

        ref var laserMagazine = ref laserMagazineEntity.Get<LaserMagazine>();

        laserMagazine.Capacity = _config.LaserMagazine;
        laserMagazine.Cooldown = _config.LaserCooldown;
    }
}