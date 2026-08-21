using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(RectTransform))]
public class EasyRectTransformAnchorPos3D : EasyAnimation
{
    [SerializeField] Vector3 m_toAnchorPos = Vector3.zero;
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

        m_tw = m_rectTransform.DOAnchorPos3D(m_toAnchorPos, m_duration, m_snapping)
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

        return m_tw;
    }
}
