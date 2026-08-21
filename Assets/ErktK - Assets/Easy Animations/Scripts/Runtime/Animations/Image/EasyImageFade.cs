using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Image))]

public class EasyImageFade : EasyAnimation
{
    [SerializeField] float m_toAlpha = 0f;
    private Color m_initialColor;
    private Image m_image;

    void Awake()
    {
        m_image = gameObject.GetComponent<Image>();
        m_initialColor = m_image.color;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_image.DOFade(m_toAlpha, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_image.DOFade(m_initialColor.a, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) m_image.color = m_initialColor;
                            });

        return m_tw;
    }
}
