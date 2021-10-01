using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIController : MonoBehaviour
{
    private List<BaseMenuView> _menues = new List<BaseMenuView>();
    private InGameUIView _inGameUI;
    private EndGameMenuView _endGameMenu;


    private void Start()
    {
        UIEvents.Current.OnButtonStartGame += StartGame;
        UIEvents.Current.OnButtonPauseGame += PauseGame;
        UIEvents.Current.OnButtonResumeGame += StartGame;
        UIEvents.Current.OnButtonRestartGame += RestartGame;

        Time.timeScale = 0.0f;
        SwitchUI(UIState.MainMenu);
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PauseGame()
    {
        SwitchUI(UIState.Pause);
        Time.timeScale = 0.0f;
    }

    private void StartGame()
    {
        SwitchUI(UIState.InGame);
        Time.timeScale = 1.0f;
    }

    public void UpdateUIText(string score, string gps, string angle, string speed, string laserMagazine, string laserTimer)
    {
        _inGameUI.UpdateText(score, gps, angle, speed, laserMagazine, laserTimer);
    }

    public void AddView(BaseMenuView view)
    {
        _menues.Add(view);

        if (view.GetType() == typeof(InGameUIView))
        {
            _inGameUI = view as InGameUIView;
        }
        else if (view.GetType() == typeof(EndGameMenuView))
        {
            _endGameMenu = view as EndGameMenuView;
        }
    }

    private void SwitchUI(UIState state)
    {
        if (_menues.Count == 0)
        {
            Debug.LogWarning("There is no menues to switch.");
        }
        switch (state)
        {
            case UIState.MainMenu:
                SwitchMenu(typeof(MainMenuView));
                break;
            case UIState.InGame:
                SwitchMenu(typeof(InGameUIView));
                break;
            case UIState.Pause:
                SwitchMenu(typeof(PauseMenuView));
                break;
            case UIState.EndGame:
                SwitchMenu(typeof(EndGameMenuView));
                break;
        }
    }
    private void SwitchMenu(System.Type type)
    {
        bool isFound = false;

        for (int i = 0; i < _menues.Count; i++)
        {
            if (_menues[i].GetType() == type)
            {
                _menues[i].Show();
                isFound = true;
            }
            else
            {
                _menues[i].Hide();
            }

            if (i == _menues.Count - 1f && !isFound)
            {
                Debug.LogWarning($"Oops! Menu {type} not found");
            }
        }
    }
}