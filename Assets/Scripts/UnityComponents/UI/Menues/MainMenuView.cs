using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : BaseMenuView
{
    [Header("Panel")]
    [SerializeField] private GameObject _panel;

    [Header("Elements")]
    [SerializeField] private Button _buttonStart;


    private void Awake()
    {
        FindMyController();

        _buttonStart.onClick.AddListener(UIEvents.Current.ButtonStartGame);
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
        _buttonStart.onClick.RemoveAllListeners();
    }
}