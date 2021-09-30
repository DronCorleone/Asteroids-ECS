using UnityEngine;
using Leopotam.Ecs;


public class EnemySpawnSystem : IEcsRunSystem
{
    private EcsWorld _world = null;
    private SceneData _sceneData;
    private Configuration _config;

    private float _asteroidTimeSpawn;
    private float _ufoTimeSpawn;


    public void Run()
    {
        _asteroidTimeSpawn += Time.deltaTime;
        _ufoTimeSpawn += Time.deltaTime;

        if (_asteroidTimeSpawn >= _config.AsteroidSpawnTimer)
        {
            SpawnAsteroid();
            _asteroidTimeSpawn = 0.0f;
        }

        if (_ufoTimeSpawn >= _config.UFOSpawnTimer)
        {
            SpawnUFO();
            _ufoTimeSpawn = 0.0f;
        }
    }


    private void SpawnAsteroid()
    {
        EcsEntity bigAsteroid = _world.NewEntity();

        ref var bigAsteroidComponent = ref bigAsteroid.Get<AsteroidBig>();

        GameObject prefab = _config.BigAsteroidPrefabs[Random.Range(0, _config.BigAsteroidPrefabs.Length - 1)];
        Transform spawnPoint = _sceneData.EnemySpawnPoints[Random.Range(0, _sceneData.EnemySpawnPoints.Length - 1)];
        GameObject asteroidGO = Object.Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        asteroidGO.GetComponent<EnemyView>().Entity = bigAsteroid;

        bigAsteroidComponent.Transform = asteroidGO.transform;
        bigAsteroidComponent.Direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f).normalized;
        bigAsteroidComponent.Speed = _config.BigAsteroidSpeed;
        bigAsteroidComponent.RotationSpeed = Random.Range(_config.AsteroidRotationSpeedMin, _config.AsteroidRotationSpeedMax);
    }

    private void SpawnUFO()
    {
        //TODO
    }
}