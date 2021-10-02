using Leopotam.Ecs;

public class GameControllerSystem : IEcsRunSystem
{
    private EcsFilter<Player> _filterPlayer;
    private EcsFilter<UIComponent> _filterUI;
    private EcsFilter<RuntimeData> _filterData;
    private PlayerView _playerView;


    public void Run()
    {
        foreach (var i in _filterPlayer)
        {
            ref var player = ref _filterPlayer.Get1(i);

            if (player.Transform.gameObject.GetComponent<PlayerView>().IsDead == true)
            {
                foreach (var j in _filterData)
                {
                    ref var data = ref _filterData.Get1(i);

                    foreach (var k in _filterUI)
                    {
                        ref var ui = ref _filterUI.Get1(i);

                        ui.UIGO.GetComponent<UIController>().GameOver(data.Score);
                    }
                }
            }
        }
    }
}