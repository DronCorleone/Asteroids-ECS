using UnityEngine;
using Leopotam.Ecs;


public class AsteroidMoveSystem : IEcsRunSystem
{
    private EcsFilter<AsteroidBig>.Exclude<DestroyWithGO> _filterBig;
    private EcsFilter<AsteroidSmall>.Exclude<DestroyWithGO> _filterSmall;

    private Configuration _config;

    
    public void Run()
    {
        foreach (var i in _filterBig)
        {
            ref var bigAsteroid = ref _filterBig.Get1(i);

            Move(bigAsteroid.Transform, bigAsteroid.Direction, bigAsteroid.Speed, bigAsteroid.RotationSpeed);

            if (bigAsteroid.Transform.position.x > _config.EnemyMaxX ||
                bigAsteroid.Transform.position.x < _config.EnemyMinX ||
                bigAsteroid.Transform.position.y > _config.EnemyMaxY ||
                bigAsteroid.Transform.position.y < _config.EnemyMinY)
            {
                ref var destroy = ref _filterBig.GetEntity(i).Get<DestroyWithGO>();

                destroy.GameObject = bigAsteroid.Transform.gameObject;
            }
        }

        foreach (var i in _filterSmall)
        {
            ref var smallAsteroid = ref _filterSmall.Get1(i);

            Move(smallAsteroid.Transform, smallAsteroid.Direction, smallAsteroid.Speed, smallAsteroid.RotationSpeed);

            if (smallAsteroid.Transform.position.x > _config.EnemyMaxX ||
                smallAsteroid.Transform.position.x < _config.EnemyMinX ||
                smallAsteroid.Transform.position.y > _config.EnemyMaxY ||
                smallAsteroid.Transform.position.y < _config.EnemyMinY)
            {
                ref var destroy = ref _filterSmall.GetEntity(i).Get<DestroyWithGO>();

                destroy.GameObject = smallAsteroid.Transform.gameObject;
            }
        }
    }

    private void Move(Transform transform, Vector3 direction, float movingSpeed, float rotationSpeed)
    {
        transform.Translate(direction * movingSpeed * Time.deltaTime);
    }
}