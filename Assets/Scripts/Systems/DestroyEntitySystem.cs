using UnityEngine;
using Leopotam.Ecs;

public class DestroyEntitySystem : IEcsRunSystem
{
    private Configuration _config;
    private EcsFilter<DestroyWithGO> _filter;
    private EcsFilter<RuntimeData> _filterData;

    public void Run()
    {
        foreach (var i in _filter)
        {
            if (_filter.GetEntity(i).Has<Hit>())
            {
                ref var destoryComponent = ref _filter.Get1(i);
                
                EnemyType enemyType = destoryComponent.GameObject.GetComponent<EnemyView>().Type;
                int score = 0;
                
                switch (enemyType)
                {
                    case EnemyType.BigAsteroid:
                        score = _config.ScoreForBigAsteroid;
                        break;
                    case EnemyType.SmallAsteroid:
                        score = _config.ScoreForSmallAsteroid;
                        break;
                    case EnemyType.UFO:
                        score = _config.ScoreForUFO;
                        break;
                    default:
                        break;
                }

                foreach (var j in _filterData)
                {
                    ref var data = ref _filterData.Get1(i);
                    data.Score += score;
                }
            }

            Object.Destroy(_filter.Get1(i).GameObject);
            _filter.GetEntity(i).Destroy();
        }
    }
}