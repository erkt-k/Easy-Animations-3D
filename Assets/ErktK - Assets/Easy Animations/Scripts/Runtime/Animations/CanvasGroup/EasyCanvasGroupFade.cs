using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(CanvasGroup))]
public class EasyCanvasGroupFade : EasyAnimation
{
    [SerializeField] float m_toAlpha = 0f;
    private float m_initialAlpha;
    private CanvasGroup m_canvasGroup;

    void Awake()
    {
        m_canvasGroup = gameObject.GetComponent<CanvasGroup>();
        m_initialAlpha = m_canvasGroup.alpha;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_canvasGroup.DOFade(m_toAlpha, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_canvasGroup.DOFade(m_initialAlpha, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) m_canvasGroup.alpha = m_initialAlpha;
                            });;

        return m_tw;
    }
}
