using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Image))]

public class EasyImageFillAmount : EasyAnimation
{
    [SerializeField, Range(0f, 1f)] float m_toFillAmount = 0f;
    private float m_initialAmount;
    private Image m_image;

    void Awake()
    {
        m_image = gameObject.GetComponent<Image>();
        m_initialAmount = m_image.fillAmount;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_image.DOFillAmount(m_toFillAmount, m_duration)
                            .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                            .OnComplete(() =>
                            {
                                m_tw = null;

                                if(m_doesReturnHome) m_image.DOFillAmount(m_initialAmount, m_duration);
                            })
                            .OnKill(() =>
                            {
                                m_tw = null;

                                if (m_doesReturnHome) m_image.fillAmount = m_initialAmount;
                            });

        return m_tw;
    }
}
