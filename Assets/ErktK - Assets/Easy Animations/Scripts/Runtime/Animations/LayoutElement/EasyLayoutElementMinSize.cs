using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.Android.Gradle.Manifest;

[AddComponentMenu(""), RequireComponent(typeof(LayoutElement))]
public class EasyLayoutElementMinSize : EasyAnimation
{
    [SerializeField] Vector2 m_toMinSize = Vector2.one;

    private Vector2 m_initialSize;
    private LayoutElement m_layoutElement;

    void Awake()
    {
        // TODO: Try out if it is width/height OR height/width
        m_layoutElement = gameObject.GetComponent<LayoutElement>();
        m_initialSize = new Vector2(m_layoutElement.minWidth, m_layoutElement.minHeight);
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_layoutElement.DOMinSize(m_toMinSize, m_duration, m_snapping)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) m_layoutElement.DOMinSize(m_initialSize, m_duration, m_snapping);
                            });
        return m_tw;
    }
}
