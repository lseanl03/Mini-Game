using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownUI : MonoBehaviour
{
    [SerializeField] private Button _goHuntingButton;

    private void Awake()
    {
        _goHuntingButton.onClick.AddListener(OnGoHuntingClick);
    }

    private void OnGoHuntingClick()
    {
        LoadManager.Instance.ChangeScene(SceneType.Hunting);
    }
}
