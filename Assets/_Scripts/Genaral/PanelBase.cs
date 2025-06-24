using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour
{
    protected float _hidePos = 0;
    protected float _showPos = 0;
    [SerializeField] protected Button _bgButton;
    [SerializeField] protected RectTransform _menu;

    protected virtual void Awake()
    {
        _bgButton.gameObject.SetActive(false);
        _menu.gameObject.SetActive(false);

        _bgButton.onClick.AddListener((() => PanelState(false)));
    }

    protected virtual void ShowPanel()
    {
        _menu.gameObject.SetActive(true);
    }

    protected virtual void HidePanel()
    {
        _bgButton.gameObject.SetActive(false);
    }

    public virtual void PanelState(bool state)
    {
        if (state) ShowPanel();
        else HidePanel();
    }
}
