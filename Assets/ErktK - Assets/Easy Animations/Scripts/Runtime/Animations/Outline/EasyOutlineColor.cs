using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

[AddComponentMenu(""), RequireComponent(typeof(Outline))]
public class EasyOutlineColor : EasyAnimation
{
    [SerializeField] Color m_toColor = Color.white;
    private Color m_initialColor;
    private Outline m_outline;

    void Awake()
    {
        m_outline = gameObject.GetComponent<Outline>();
        m_initialColor = m_outline.effectColor;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_outline.DOColor(m_toColor, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if(m_doesReturnHome) m_outline.DOColor(m_initialColor, m_duration);
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;

                        if(m_doesReturnHome) m_outline.effectColor = m_initialColor;
                    });
        return m_tw;
    }
}
