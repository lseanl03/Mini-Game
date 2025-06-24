using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour
{
    private GameObject menu;

    protected virtual void Awake()
    {
        if (!menu)
        {
            menu = transform.GetChild(0).gameObject;
            menu.SetActive(false);
        }
    }

    public virtual void ShowPanel()
    {
        menu.SetActive(true);
    }
    public virtual void HidePanel()
    {
        menu.SetActive(false);
    }

    public virtual void PanelState(bool state)
    {
        if (state) ShowPanel();
        else HidePanel();
    }
}
