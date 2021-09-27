using UnityEngine;
using Leopotam.Ecs;


public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld _world = null;
    private Configuration _config;
    private SceneData _sceneData;

    public void Init()
    {
        EcsEntity playerEntity = _world.NewEntity();

        ref var player = ref playerEntity.Get<Player>();
        ref var inputData = ref playerEntity.Get<PlayerInputData>();

        GameObject playerGO = Object.Instantiate(_config.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);

        player.PlayerTransform = playerGO.transform;
        player.PlayerSpeed = _config.PlayerSpeed;
    }
}