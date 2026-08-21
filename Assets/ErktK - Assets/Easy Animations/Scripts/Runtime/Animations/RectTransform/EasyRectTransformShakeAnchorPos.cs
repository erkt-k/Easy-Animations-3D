using UnityEngine;
using DG.Tweening;
using EasyAnimationsEnums;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformShakeAnchorPos : EasyAnimation
{
    [SerializeField] MoveOption m_shakeOption = MoveOption.V3;
    [SerializeField] Vector3 m_shakeStrength = Vector3.one;
    [SerializeField] float m_shakeStrengthUniform = 1f;
    [SerializeField] int m_vibrato = 10;
    [SerializeField, Range(0f, 180f)] float m_randomnes = 50f;
    [SerializeField] bool m_fadeOut = true;
    [SerializeField] ShakeRandomnessMode m_shakeRndMode = ShakeRandomnessMode.Harmonic;
    private Vector3 m_initialAnchorPos;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialAnchorPos = m_rectTransform.anchoredPosition3D;
    }

    public override Tween Play()
    {
        CleanUp();

        switch (m_shakeOption)
        {
            case MoveOption.V3:
                m_tw = m_rectTransform.DOShakeAnchorPos(m_duration, m_shakeStrength, m_vibrato, 
                                            m_randomnes, m_snapping, m_fadeOut, m_shakeRndMode)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPos3D(m_initialAnchorPos, m_duration, m_snapping);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.anchoredPosition3D = m_initialAnchorPos;
                            });
                break;
            case MoveOption.Uniform:
                m_tw = m_rectTransform.DOShakeAnchorPos(m_duration, m_shakeStrengthUniform, m_vibrato, 
                                            m_randomnes, m_snapping, m_fadeOut, m_shakeRndMode)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorPos3D(m_initialAnchorPos, m_duration, m_snapping);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.anchoredPosition3D = m_initialAnchorPos;
                            });
                break;
            default:
                m_tw = null;
                break;
        }

        return m_tw;
    }
}
