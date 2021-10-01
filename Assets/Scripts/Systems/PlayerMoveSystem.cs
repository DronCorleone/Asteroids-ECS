using UnityEngine;
using Leopotam.Ecs;


public class PlayerMoveSystem : IEcsRunSystem
{
    private EcsFilter<Player, PlayerInputData, GameField> _filter;
    private EcsFilter<RuntimeData> _filterData;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var player = ref _filter.Get1(i);
            ref var input = ref _filter.Get2(i);
            ref var field = ref _filter.Get3(i);

            player.Transform.Translate(Vector3.up * input.MoveInput * player.Speed * Time.deltaTime);
            player.Transform.Rotate(player.Transform.forward, input.RotateInput * player.RotationSpeed * Time.deltaTime * -1.0f);

            foreach (var j in _filterData)
            {
                ref var data = ref _filterData.Get1(i);

                data.PlayerSpeed = input.MoveInput * player.Speed;
            }

            if (player.Transform.position.x > field.MaxX)
            {
                player.Transform.position = new Vector3(field.MinX, player.Transform.position.y, player.Transform.position.z);
            }
            if (player.Transform.position.x < field.MinX)
            {
                player.Transform.position = new Vector3(field.MaxX, player.Transform.position.y, player.Transform.position.z);
            }
            if (player.Transform.position.y > field.MaxY)
            {
                player.Transform.position = new Vector3(player.Transform.position.x, field.MinY, player.Transform.position.z);
            }
            if (player.Transform.position.y < field.MinY)
            {
                player.Transform.position = new Vector3(player.Transform.position.x, field.MaxY, player.Transform.position.z);
            }
        }
    }
}