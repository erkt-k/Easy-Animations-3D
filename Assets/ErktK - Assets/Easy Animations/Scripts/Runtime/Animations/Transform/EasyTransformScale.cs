using UnityEngine;
using DG.Tweening;
using UnityEditor.EditorTools;
using UnityEngine.UIElements;
using UnityEngine.Lumin;

[AddComponentMenu("")]
public class EasyTransformScale : EasyAnimation
{
    enum ScaleOption {V3, Uniform}

    [Tooltip("Which way to scale?")]
    [SerializeField] ScaleOption scaleOption = ScaleOption.Uniform;

    [Tooltip("The scale to change to.")]
    [SerializeField] Vector3 m_toScale = Vector3.one;

    [Tooltip("Scales uniformly.s")]
    [SerializeField] float m_toScaleUniformly = 1f;

    private Vector3 m_initialScale;

    void Awake()
    {
        m_initialScale = transform.localScale;
    }

    public override Tween Play()
    {
        CleanUp();

        switch(scaleOption)
        {
            case ScaleOption.Uniform:
                m_tw = transform.DOScale(m_toScaleUniformly, m_duration)
                                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                                .OnComplete(() =>
                                {
                                    m_tw = null;
                                    if (m_doesReturnHome) transform.DOScale(m_initialScale, m_duration);
                                });
                return m_tw;
            case ScaleOption.V3:
                m_tw = transform.DOScale(m_toScale, m_duration)
                                .SetLoops(m_repeat ? -1 : 0, m_loopType)
                                .OnComplete(() =>
                                {
                                    m_tw = null;
                                    if (m_doesReturnHome) transform.DOScale(m_initialScale, m_duration);
                                });
                return m_tw;
            default:
                return null;
        }
    }
}
