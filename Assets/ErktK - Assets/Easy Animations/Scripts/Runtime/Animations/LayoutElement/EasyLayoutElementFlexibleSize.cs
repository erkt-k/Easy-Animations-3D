using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(LayoutElement))]
public class EasyLayoutElementFlexibleSize : EasyAnimation
{
    [SerializeField] Vector2 m_toFlexibleSize = Vector2.one;

    private Vector2 m_initialSize;
    private LayoutElement m_layoutElement;

    void Awake()
    {
        // TODO: Try out if it is width/height OR height/width
        m_layoutElement = gameObject.GetComponent<LayoutElement>();
        m_initialSize = new Vector2(m_layoutElement.flexibleWidth, m_layoutElement.flexibleHeight);
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_layoutElement.DOFlexibleSize(m_toFlexibleSize, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) m_layoutElement.DOFlexibleSize(m_initialSize, m_duration, m_snapping);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome)
                                {
                                    m_layoutElement.flexibleWidth = m_initialSize[0];
                                    m_layoutElement.flexibleHeight = m_initialSize[1];
                                }
                            });
        return m_tw;
    }
}
