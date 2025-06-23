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
        base.Awake();
        _agreeButton.onClick.AddListener(OnAgreeButtonClicked);
        _rejectButton.onClick.AddListener(OnRejectButtonClicked);
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
    private void SetContentText(string text)
    {
        _contentText.text = text;
    }
}
