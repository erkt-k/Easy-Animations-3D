using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformAnchorMin : EasyAnimation
{
    [SerializeField] Vector2 m_toAnchorMin = Vector2.zero;
    private Vector2 m_initialAnchorMin;
    private RectTransform m_rectTransform;

    void Awake()
    {
        m_rectTransform = gameObject.GetComponent<RectTransform>();
        m_initialAnchorMin = m_rectTransform.anchorMin;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_rectTransform.DOAnchorMin(m_toAnchorMin, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_rectTransform.DOAnchorMin(m_initialAnchorMin, m_duration, m_snapping);
                            });

        return m_tw;
    }
}
