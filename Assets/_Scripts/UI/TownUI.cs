using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TownUI : MonoBehaviour
{
    [SerializeField] private Button _goHuntingButton;
    [SerializeField] private TextMeshProUGUI _playerNameText, _playerLevelText;

    private void Awake()
    {
        _goHuntingButton.onClick.AddListener(OnGoHuntingClick);
    }

    private void OnEnable()
    {
        EventManager.OnLoadPlayerData += OnLoadPlayerData;
    }

    private void OnDisable()
    {
        EventManager.OnLoadPlayerData -= OnLoadPlayerData;
    }

    private void OnLoadPlayerData(PlayerData playerData)
    {
        SetPlayerName(playerData.Name);
        SetPlayerLevel(playerData.Level);
    }

    private void OnGoHuntingClick()
    {
        LoadManager.Instance.ChangeScene(SceneType.Hunting);
    }

    public void SetPlayerName(string name)
    {
        _playerNameText.text = name;
    }
    public void SetPlayerLevel(int level)
    {
        _playerLevelText.text = $"Level: {level}";
    }
}
