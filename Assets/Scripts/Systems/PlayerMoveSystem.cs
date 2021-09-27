using UnityEngine;
using Leopotam.Ecs;


public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var player = ref _filter.Get1(i);
            ref var input = ref _filter.Get2(i);

            player.PlayerTransform.Translate(Vector3.up * input.MoveInput * player.PlayerSpeed * Time.deltaTime);
            player.PlayerTransform.Rotate(player.PlayerTransform.forward, input.RotateInput * player.PlayerSpeed * Time.deltaTime * -10.0f);
        }
    }
}