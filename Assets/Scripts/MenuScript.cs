using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class MenuScript : MonoBehaviour
{
    private float menuAlpha = 0.7f;

    public Canvas menuUI;
    public Slider slider;
    public Image menuBackground;
    public TextMeshProUGUI percentageLabel;
    public AudioSource[] audioSources;
    private bool isMenuPressedDown = false;
    private bool isMuted = false;

    // Update is called once per frame
    void Update()
    {
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), InputHelpers.Button.MenuButton, out bool isPressed);
        if (isPressed)
        {
            if (!isMenuPressedDown)
            {
                menuUI.enabled = !menuUI.enabled;
            }
            isMenuPressedDown = true;
        }
        else
        {
            isMenuPressedDown = false;
        }
    }

    void Start()
    {
        // Ensure we have audio sources from the same object if none were explicitly assigned.
        if (audioSources == null || audioSources.Length == 0)
        {
            audioSources = GetComponents<AudioSource>();
        }

        // Add listener for slider value changes
        slider.onValueChanged.AddListener(UpdatePercentageLabel);

        // Set initial value
        UpdatePercentageLabel(slider.value);
    }

    void UpdatePercentageLabel(float value)
    {
        // Convert slider value (0-1) to percentage (0-100)
        int percentage = (int)(value * 100f);
        percentageLabel.text = percentage + "%";

        // Set audio source volumes only if not muted
        if (!isMuted && audioSources != null)
        {
            foreach (var source in audioSources)
            {
                if (source != null)
                {
                    source.volume = value;
                }
            }
        }
    }

    void OnDestroy()
    {
        // Clean up listener to prevent memory leaks
        slider.onValueChanged.RemoveListener(UpdatePercentageLabel);
    }

    public void TransparentBackground_OnValueChanged(bool isOn)
    {
        menuAlpha = isOn ? 0.7f : 1.0f;

        menuBackground.color = new Color(menuBackground.color.r, menuBackground.color.g, menuBackground.color.b, menuAlpha);
    }

    public void Mute_OnValueChanged(bool isOn)
    {
        if (isOn)
        {
            isMuted = true;
            SetAudioSourcesVolume(0f);
            slider.interactable = false;
        }
        else
        {
            isMuted = false;
            SetAudioSourcesVolume(slider.value);
            slider.interactable = true;
        }
    }

    private void SetAudioSourcesVolume(float volume)
    {
        if (audioSources == null)
        {
            return;
        }

        foreach (var source in audioSources)
        {
            if (source != null)
            {
                source.volume = volume;
            }
        }
    }
}
