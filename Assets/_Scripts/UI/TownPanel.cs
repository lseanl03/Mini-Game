using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownPanel : PanelBase
{
    [SerializeField] private Button _goHuntingButton;
    protected override void Awake()
    {
        base.Awake();
        _goHuntingButton.onClick.AddListener(OnGoHuntingClick);
    }

    private void OnGoHuntingClick()
    {
        LoadManager.Instance.ChangeScene(SceneType.Hunting);
    }
}
