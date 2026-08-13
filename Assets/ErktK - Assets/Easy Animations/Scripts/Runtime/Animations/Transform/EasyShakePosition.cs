using UnityEngine;
using DG.Tweening;

[AddComponentMenu("")]
public class EasyShakePosition : EasyAnimation
{
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
    private Vector3 m_initialPos;

    void Awake()
    {
        m_initialPos = transform.position;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = transform.DOShakePosition(m_duration, m_strength, m_vibrato, m_randomness, m_snapping, m_fadeOut, m_shakeRndMode)
                        .SetLoops(m_repeat ? -1 : 0, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;
                            if (m_doesReturnHome) transform.DOMove(m_initialPos, m_duration, m_snapping);
                        });
        return m_tw;
    }
}