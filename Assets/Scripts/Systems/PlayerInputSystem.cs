using UnityEngine;
using Leopotam.Ecs;


public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData> _filter;
    private Configuration _config;

    private string _hor = "Horizontal";
    private string _vert = "Vertical";

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var input = ref _filter.Get1(i);

            if (Input.GetAxis(_vert) > 0)
            {
                input.MoveInput = Input.GetAxis(_vert);
            }
            else
            {
                input.MoveInput = 0.0f;
            }

            input.RotateInput = Input.GetAxis(_hor);

            input.BulletInput = Input.GetKeyDown(_config.BulletFire);
            input.LaserInput = Input.GetKeyDown(_config.LaserFire);
        }
    }
}