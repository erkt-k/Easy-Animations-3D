using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(ScrollRect))]
public class EasyScrollRectNormalizedPos : EasyAnimation
{
    [SerializeField] Vector2 m_toPos = Vector2.zero;

    Vector2 m_initialPos;
    ScrollRect m_scrollRect;

    void Awake()
    {
        m_scrollRect = GetComponent<ScrollRect>();
        m_initialPos = m_scrollRect.normalizedPosition;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_scrollRect.DONormalizedPos(m_toPos, m_duration, m_snapping)
                        .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                        .OnComplete(() =>
                        {
                            m_tw = null;

                            if(m_doesReturnHome) m_scrollRect.DONormalizedPos(m_initialPos, m_duration, m_snapping);
                        })
                        .OnKill(() =>
                        {
                            m_tw = null;

                            if (m_doesReturnHome) m_scrollRect.normalizedPosition = m_initialPos;
                        });

        return m_tw;
    }
}
