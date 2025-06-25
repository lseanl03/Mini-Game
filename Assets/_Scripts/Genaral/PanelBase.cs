using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour
{
    protected float _hidePos = 0;
    protected float _showPos = 0;
    protected CanvasGroup _canvasGroup;
    [SerializeField] protected RectTransform _menu;
    protected UIManager _uiManager => UIManager.Instance;

    protected virtual void Awake()
    {
        _menu.gameObject.SetActive(false);
        _canvasGroup = _menu.GetComponent<CanvasGroup>();
    }
    protected virtual void OnEnable() { }
    protected virtual void OnDisable()
    {
        _menu.DOKill();
    }

    protected virtual void ShowPanel()
    {
        _menu.gameObject.SetActive(true);
    }

    protected virtual void HidePanel()
    {
        _menu.gameObject.SetActive(false);
    }

    protected virtual void OnCloseClick()
    {
        HidePanel();
    }

    public virtual void PanelState(bool state)
    {
        if (state) ShowPanel();
        else HidePanel();
    }
}
