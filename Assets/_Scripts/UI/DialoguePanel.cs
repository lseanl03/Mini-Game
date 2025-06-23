using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePanel : PanelBase
{
    private void OnEnable()
    {
        EventManager.OnNPCCollisionEnter += ShowPanel;
        EventManager.OnNPCCollisionExit += HidePanel;
    }
    private void OnDisable()
    {
        EventManager.OnNPCCollisionEnter -= ShowPanel;
        EventManager.OnNPCCollisionExit -= HidePanel;
    }
}
