using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class PanelScript : MonoBehaviour
{
    private float menuAlpha = 0.5f;

    public Image menuBackground;

    private void Start()
    {
        menuBackground = GetComponent<Image>();
        menuBackground.color = new Color(menuBackground.color.r, menuBackground.color.g, menuBackground.color.b, menuAlpha);
    }
    public void TransparentBackground_OnValueChanged(bool isOn)
    {
       
        menuAlpha = isOn ? 0.5f : 1.0f;
        Debug.Log(gameObject +" is " +isOn +", alpha is " + menuAlpha);

        menuBackground.color = new Color(menuBackground.color.r, menuBackground.color.g, menuBackground.color.b, menuAlpha);
    }
}
