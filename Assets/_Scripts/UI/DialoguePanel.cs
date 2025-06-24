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
        _agreeButton.onClick.AddListener(OnAgreeButtonClicked);
        _rejectButton.onClick.AddListener(OnRejectButtonClicked);

        base.Awake();
    }
    private void OnEnable()
    {
        EventManager.OnNPCCollisionEnter += OnNPCCollisionEnter;
        EventManager.OnNPCCollisionExit += HidePanel;
    }
    private void OnDisable()
    {
        EventManager.OnNPCCollisionEnter -= OnNPCCollisionEnter;
        EventManager.OnNPCCollisionExit -= HidePanel;
    }
    private void OnAgreeButtonClicked()
    {
        HidePanel();
        UIManager.Instance.ShopPanel.PanelState(true);
    }
    private void OnRejectButtonClicked()
    {
        HidePanel();
    }
    private void OnNPCCollisionEnter()
    {
        ShowPanel();

        var dialogData = GameManager.Instance.dialogueData.GetRandomDialogue();
        SetContentText(dialogData.description);
    }
    protected override void ShowPanel()
    {
        base.ShowPanel();
        _menu.DOAnchorPosY(_showPos, 0.2f).SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _bgButton.gameObject.SetActive(true);
            });
    }
    protected override void HidePanel()
    {
        base.HidePanel();
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
