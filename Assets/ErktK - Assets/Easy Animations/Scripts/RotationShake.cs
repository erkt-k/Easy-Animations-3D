using UnityEngine;
using DG.Tweening;
using System;
using System.Collections;

public class ShakeAnimation : MonoBehaviour
{
    [Header("Animation Properties")]
    [SerializeField] bool repeat = true;
    [Tooltip("How long the animation is")]
    [SerializeField] float m_duration = 0.8f;
    [Tooltip("The strength of animation in each axis. (Set 0 if you want the axis to stay still.)")]
    [SerializeField] Vector3 m_strength = new Vector3(0f, 0.2f, 0f);
    [Tooltip("How much will the shake vibrate")]
    [SerializeField] int m_vibrato = 10;
    [Tooltip("The randomness of the shake. (0-180 -> 0 chooses only one direction)")]
    [SerializeField] float m_randomness = 90f;
    [Tooltip("If TRUE, the animation will fadeout in the duration of the animation.")]
    [SerializeField] bool m_fadeOut = true;
    [Tooltip("Full (fully random) or Harmonic (more balanced and visually more pleasant).")]
    [SerializeField] ShakeRandomnessMode m_shakeRndMode = ShakeRandomnessMode.Harmonic;
    void Start()
    {
        StartCoroutine(AnimSequence());
    }

    void RotateAnim()
    {
        transform.DOShakeRotation(
            duration: m_duration,
            strength: m_strength,
            vibrato: m_vibrato,
            randomness: m_randomness,
            fadeOut: m_fadeOut,
            randomnessMode: m_shakeRndMode
        );
    }


    IEnumerator AnimSequence()
    {
        do
        {
            RotateAnim();
            yield return new WaitForSeconds(m_duration + 0.3f);
        } while(repeat);
    }
}
