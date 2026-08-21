using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraPixelRect : EasyAnimation
{
    [SerializeField] Rect m_toPixelRect;
    private Camera m_camera;
    private Rect m_initialPixelRect;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialPixelRect = m_camera.pixelRect;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DOPixelRect(m_toPixelRect, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DOPixelRect(m_initialPixelRect, m_duration);
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.pixelRect = m_initialPixelRect;
                    });
        return m_tw;
    }
}
