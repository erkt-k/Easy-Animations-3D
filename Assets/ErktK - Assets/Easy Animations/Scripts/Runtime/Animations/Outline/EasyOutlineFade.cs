using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Outline))]
public class EasyOutlineFade : EasyAnimation
{
    [SerializeField] float m_toAlpha = 0f;
    private float m_initialAlpha;
    private Outline m_outline;

    void Awake()
    {
        m_outline = gameObject.GetComponent<Outline>();
        m_initialAlpha = m_outline.effectColor.a;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_outline.DOFade(m_toAlpha, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if(m_doesReturnHome) m_outline.DOFade(m_initialAlpha, m_duration);
                    });
        return m_tw;
    }
}
