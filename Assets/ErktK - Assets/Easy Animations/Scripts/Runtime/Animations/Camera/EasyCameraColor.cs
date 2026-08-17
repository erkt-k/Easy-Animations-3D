using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraColor : EasyAnimation
{
    [SerializeField] Color m_toColor;
    private Camera m_camera;
    private Color m_initialColor;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialColor = m_camera.backgroundColor;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DOColor(m_toColor, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DOColor(m_initialColor, m_duration);
                    });
        return m_tw;
    }
}
