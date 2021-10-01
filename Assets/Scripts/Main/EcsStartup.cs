using Leopotam.Ecs;
using UnityEngine;


public class EcsStartup : MonoBehaviour
{
    [SerializeField] private Configuration _config;
    [SerializeField] private SceneData _sceneData;

    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        // void can be switched to IEnumerator for support coroutines.

        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
        _systems
            // register your systems here
            .Add(new RuntimeDataInitSystem())
            .Add(new PlayerInitSystem())
            .Add(new UIInitSystem())

            .Add(new PlayerInputSystem())
            .Add(new PlayerMoveSystem())
            .Add(new ProjectileSpawnSystem())
            .Add(new BulletMoveSystem())
            .Add(new LaserMagazineInitSystem())
            .Add(new LaserMagazineSystem())
            .Add(new LaserLifeTimeSystem())
            .Add(new EnemySpawnSystem())
            .Add(new AsteroidMoveSystem())
            .Add(new AsteroidBreakSystem())
            .Add(new UFOMoveSystem())
            .Add(new UIControlSystem())

            .Add(new DestroyEntitySystem())

            // register one-frame components (order is important), for example:
            // .OneFrame<TestComponent1> ()
            // .OneFrame<TestComponent2> ()

            // inject service instances here (order doesn't important)
            .Inject(_config)
            .Inject(_sceneData)

            .Init();
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
            _world.Destroy();
            _world = null;
        }
    }
}