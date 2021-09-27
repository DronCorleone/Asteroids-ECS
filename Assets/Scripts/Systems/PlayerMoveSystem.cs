using UnityEngine;
using Leopotam.Ecs;


public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData, GameField> _filter;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var player = ref _filter.Get1(i);
            ref var input = ref _filter.Get2(i);
            ref var field = ref _filter.Get3(i);

            player.PlayerTransform.Translate(Vector3.up * input.MoveInput * player.PlayerSpeed * Time.deltaTime);
            player.PlayerTransform.Rotate(player.PlayerTransform.forward, input.RotateInput * player.PlayerSpeed * Time.deltaTime * -10.0f);

            if (player.PlayerTransform.position.x > field.MaxX)
            {
                player.PlayerTransform.position = new Vector3(field.MinX, player.PlayerTransform.position.y, player.PlayerTransform.position.z);
            }
            if (player.PlayerTransform.position.x < field.MinX)
            {
                player.PlayerTransform.position = new Vector3(field.MaxX, player.PlayerTransform.position.y, player.PlayerTransform.position.z);
            }
            if (player.PlayerTransform.position.y > field.MaxY)
            {
                player.PlayerTransform.position = new Vector3(player.PlayerTransform.position.x, field.MinY, player.PlayerTransform.position.z);
            }
            if (player.PlayerTransform.position.y < field.MinY)
            {
                player.PlayerTransform.position = new Vector3(player.PlayerTransform.position.x, field.MaxY, player.PlayerTransform.position.z);
            }
        }
    }
}