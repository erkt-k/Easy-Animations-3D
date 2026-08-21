using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformSizeDelta: EasyAnimation
{
    [SerializeField] Vector2 m_toSizeDelta = Vector2.zero;
    private Vector2 m_initialSizeDelta;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialSizeDelta = m_rectTransform.sizeDelta;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_rectTransform.DOSizeDelta(m_toSizeDelta, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOSizeDelta(m_initialSizeDelta, m_duration, m_snapping);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.sizeDelta = m_initialSizeDelta;
                            });

        return m_tw;
    }
}
