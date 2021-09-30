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
        ref var gameField = ref playerEntity.Get<GameField>();

        GameObject playerGO = Object.Instantiate(_config.PlayerPrefab, _sceneData.PlayerSpawnPoint.position, Quaternion.identity);

        player.Transform = playerGO.transform;
        player.Speed = _config.PlayerSpeed;
        player.RotationSpeed = _config.PlayerRotationSpeed;
        player.BulletSpawnPoint = playerGO.GetComponent<PlayerView>().BulletSpawnPoint;

        gameField.MinX = _config.MinX;
        gameField.MaxX = _config.MaxX;
        gameField.MinY = _config.MinY;
        gameField.MaxY = _config.MaxY;

        playerGO.GetComponent<PlayerView>().Entity = playerEntity;
    }
}