using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HuntingPanel : PanelBase
{
    [SerializeField] private Button _backToTownButton;
    [SerializeField] private TextMeshProUGUI _enemyKilledText;
    protected override void Awake()
    {
        base.Awake();
        _backToTownButton.onClick.AddListener(OnBackToTown);
    }

    private void OnEnable()
    {
        EventManager.OnEnemyDied += OnEnemyDied;
    }
    private void OnDisable()
    {
        EventManager.OnEnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied()
    {
        SetEnemyKilledText(GameManager.Instance.EnemyKilled);
    }

    private void OnBackToTown()
    {
        LoadManager.Instance.ChangeScene(SceneType.Town);
    }

    private void SetEnemyKilledText(int enemyKilledCount)
    {
        _enemyKilledText.text = $"Quái đã tiêu diệt: {enemyKilledCount}";
    }
}
