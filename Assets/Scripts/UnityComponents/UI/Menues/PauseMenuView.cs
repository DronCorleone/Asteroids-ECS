using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuView : BaseMenuView
{
    [Header("Panel")]
    [SerializeField] private GameObject _panel;

    [Header("Elements")]
    [SerializeField] private Button _buttonResume;


    private void Awake()
    {
        FindMyController();

        _buttonResume.onClick.AddListener(UIEvents.Current.ButtonResumeGame);
    }


    public override void Hide()
    {
        if (!IsShow) return;
        _panel.gameObject.SetActive(false);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow) return;
        _panel.gameObject.SetActive(true);
        IsShow = true;
    }

    public override void FindMyController()
    {
        transform.parent.GetComponent<UIController>().AddView(this);
    }

    private void OnDestroy()
    {
        _buttonResume.onClick.RemoveAllListeners();
    }
}