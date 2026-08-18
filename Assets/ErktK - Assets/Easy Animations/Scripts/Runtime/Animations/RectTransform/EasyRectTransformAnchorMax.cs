using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformAnchorMax : EasyAnimation
{
    [SerializeField] Vector2 m_toAnchorMax = Vector2.zero;
    private Vector2 m_initialAnchorMax;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialAnchorMax = m_rectTransform.anchorMax;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_rectTransform.DOAnchorMax(m_toAnchorMax, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorMax(m_initialAnchorMax, m_duration, m_snapping);
                            });

        return m_tw;
    }
}
