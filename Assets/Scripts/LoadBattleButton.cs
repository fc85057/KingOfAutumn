using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadBattleButton : MonoBehaviour
{

    public static event Action<string> OnButtonClicked;

    [SerializeField]
    private Image padlock;
    [SerializeField]
    private string battle;
    [SerializeField]
    bool unlocked;

    public void Unlock()
    {
        unlocked = true;
        padlock.enabled = false;
    }

    public void OnClick()
    {
        if (unlocked)
        {
            OnButtonClicked(battle);
        }
    }


}
