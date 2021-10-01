using Leopotam.Ecs;
using UnityEngine;

public class UIControlSystem : IEcsRunSystem
{
    private EcsFilter<UIComponent> _filterUI;
    private EcsFilter<RuntimeData> _filterData;

    private UIController _uiController;
    private string _score;
    private string _gps;
    private string _angle;
    private string _speed;
    private string _laserMagazine;
    private string _laserTimer;

    public void Run()
    {
        foreach (var i in _filterUI)
        {
            ref var uiComponent = ref _filterUI.Get1(i);

            _uiController = uiComponent.UIGO.GetComponent<UIController>();

            foreach (var j in _filterData)
            {
                ref var data = ref _filterData.Get1(i);

                _score = $"SCORE:{data.Score}";
                _gps = $"X:{Mathf.Round(data.PlayerTransform.position.x)} Y:{Mathf.Round(data.PlayerTransform.position.y)}";
                _angle = $"ANGLE:{Mathf.Round(data.PlayerTransform.rotation.eulerAngles.z)}";
                _speed = $"SPEED:{Mathf.Round(data.PlayerSpeed)}";
                _laserMagazine = $"LASERS:{data.CurrentLasers}";
                _laserTimer = $"{Mathf.Round(data.LaserTimer)}";
            }

            _uiController.UpdateUIText(_score, _gps, _angle, _speed, _laserMagazine, _laserTimer);
        }
    }
}