using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Image))]
public class EasyImageBlendableColor : EasyAnimation
{
    [SerializeField] Color m_toColor = Color.white;

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

        m_tw = m_image.DOBlendableColor(m_toColor, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_image.DOBlendableColor(m_initialColor, m_duration);
                    });
        return m_tw;
    }
}
