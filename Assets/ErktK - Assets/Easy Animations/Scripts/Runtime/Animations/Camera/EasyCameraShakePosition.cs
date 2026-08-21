using UnityEngine;
using DG.Tweening;
using EasyAnimationsEnums;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraShakePosition : EasyAnimation
{
    [SerializeField] MoveOption m_strengthOption = MoveOption.V3;

    [Tooltip("Allows you to choose the strength for each axis.")]
    [SerializeField] Vector3 m_strength = Vector3.zero;
    [SerializeField] float m_strengthUniform = 0f;

    [SerializeField] int m_vibrato = 1;

    [Range(0f, 180f)]
    [SerializeField] float m_randomness = 1f;
    [SerializeField] bool m_fadeOut = true;
    [SerializeField] ShakeRandomnessMode m_shakeRndMode = ShakeRandomnessMode.Harmonic;
    private Camera m_camera;
    private Vector3 m_initialPos;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialPos = transform.position;
    }

    public override Tween Play()
    {
        CleanUp();

        switch(m_strengthOption)
        {
            case MoveOption.V3:
                m_tw = m_camera.DOShakePosition(m_duration, m_strength, m_vibrato, m_randomness, m_fadeOut, m_shakeRndMode)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) transform.DOMove(m_initialPos, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) transform.position = m_initialPos;
                            });
                break;
            case MoveOption.Uniform:
                m_tw = m_camera.DOShakePosition(m_duration, m_strengthUniform, m_vibrato, m_randomness, m_fadeOut, m_shakeRndMode)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) transform.DOMove(m_initialPos, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) transform.position = m_initialPos;
                            });
                break;
            default:
                m_tw = null;
                break;
        }

        return m_tw;
    }
}
