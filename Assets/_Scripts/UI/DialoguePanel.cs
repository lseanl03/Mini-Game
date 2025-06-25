using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePanel : PanelBase
{
    [SerializeField] private Button _agreeButton;
    [SerializeField] private Button _rejectButton;
    [SerializeField] private TextMeshProUGUI _contentText;

    protected override void Awake()
    {
        _hidePos = -220;
        _showPos = 175;
        _agreeButton.onClick.AddListener(OnAgreeClick);
        _rejectButton.onClick.AddListener(OnRejectClick);

        base.Awake();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        EventManager.OnNPCCollisionEnter += OnNPCCollisionEnter;
        EventManager.OnNPCCollisionExit += HidePanel;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        EventManager.OnNPCCollisionEnter -= OnNPCCollisionEnter;
        EventManager.OnNPCCollisionExit -= HidePanel;
    }
    private void OnAgreeClick()
    {
        HidePanel();
        UIManager.Instance.ShopPanel.PanelState(true);
        UIManager.Instance.InventoryPanel.PanelState(true);
    }
    private void OnRejectClick()
    {
        HidePanel();
    }
    private void OnNPCCollisionEnter()
    {
        ShowPanel();

        var dialogData = GameManager.Instance.DialogueData.GetRandomDialogue();
        SetContentText(dialogData.description);
    }
    protected override void ShowPanel()
    {
        _menu.gameObject.SetActive(true);
        _menu.anchoredPosition = new Vector2(0, _hidePos);
        _menu.DOAnchorPosY(_showPos, 0.2f).SetEase(Ease.Linear);
    }
    protected override void HidePanel()
    {
        _menu.anchoredPosition = new Vector2(0, _showPos);
        _menu.DOAnchorPosY(_hidePos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _menu.gameObject.SetActive(false);
            });
    }
    private void SetContentText(string text)
    {
        _contentText.text = text;
    }
}
