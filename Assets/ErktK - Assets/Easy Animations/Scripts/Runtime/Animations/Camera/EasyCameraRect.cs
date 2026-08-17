using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraRect : EasyAnimation
{
    [SerializeField] Rect m_toRect;
    private Camera m_camera;
    private Rect m_initialRect;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialRect = m_camera.rect;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DORect(m_toRect, m_duration)
                    .SetLoops(m_repeat ? -1 : 0, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DORect(m_initialRect, m_duration);
                    });
        return m_tw;
    }
}
