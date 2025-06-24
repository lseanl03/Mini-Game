using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour
{
    protected float _hidePos = 0;
    protected float _showPos = 0;
    protected CanvasGroup _canvasGroup;
    [SerializeField] protected Button _bg;
    [SerializeField] protected RectTransform _menu;

    protected virtual void Awake()
    {
        _bg.gameObject.SetActive(false);
        _menu.gameObject.SetActive(false);
        _canvasGroup = _menu.GetComponent<CanvasGroup>();

        _bg.onClick.AddListener((() => PanelState(false)));
    }

    protected virtual void ShowPanel() { }

    protected virtual void HidePanel() { }

    public virtual void PanelState(bool state)
    {
        if (state) ShowPanel();
        else HidePanel();
    }
}
