using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimations : MonoBehaviour
{
    [Header("Assign Animator")]
    public Animator animatorOverride;   // Inspector slot

    private Animator anim;
    private const float blendSpeed = 5f; // higher = faster blend

    private float[] targetWeights = new float[6]; // 0 unused, layers 1–5
    private float playTimer = 0f;
    private int activeLayer = -1;

    private void Awake()
    {
        // Use assigned animator if provided
        if (animatorOverride != null)
        {
            anim = animatorOverride;
        }
        else
        {
            // Try to find an Animator on this GameObject
            anim = GetComponent<Animator>();

            if (anim == null)
            {
                Debug.LogError($"No Animator found on {gameObject.name}.");
            }
        }
    }

    private void Update()
    {
        if (anim == null) return;

        // Smooth blending for layers 1–4 (will need updating if more animations are added)
        for (int i = 1; i <= 4; i++)
        {
            float current = anim.GetLayerWeight(i);
            float target = targetWeights[i];
            float newWeight = Mathf.MoveTowards(current, target, Time.deltaTime * blendSpeed);
            anim.SetLayerWeight(i, newWeight);
        }

        // Handle animation timing
        if (activeLayer != -1)
        {
            playTimer -= Time.deltaTime;

            if (playTimer <= 0f)
            {
                // Blend out the active animation
                targetWeights[activeLayer] = 0f;
                activeLayer = -1;
            }
        }
    }

    // This function is called in other scripts
    /* Current setup
        Index 0. Idle
        Index 1. SittingTalking
        Index 2. SittingDisbelief
        Index 3. SittingLaugh
        Index 4. SittingVictory

     So calling NPCAnimations.PlayAnimation(1); You are fading in SittingTalking.
    */
    public void PlayAnimation(int layerIndex)
    {
        if (anim == null) return;

        // Blend out any currently active animation
        if (activeLayer != -1)
            targetWeights[activeLayer] = 0f;

        activeLayer = layerIndex;

        // Blend in the new animation
        for (int i = 1; i <= 4; i++)
            targetWeights[i] = (i == layerIndex) ? 1f : 0f;

        // Get the animation clip for this layer
        AnimationClip clip = anim.runtimeAnimatorController.animationClips[layerIndex - 1];

        // Always play once
        clip.wrapMode = WrapMode.Once;

        // Set timer to clip length
        playTimer = clip.length;
    }
}
