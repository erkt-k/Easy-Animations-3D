using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraFarClipPlane : EasyAnimation
{
    [SerializeField] float m_toFloat;
    private Camera m_camera;
    private float m_initialFarClipPlane;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialFarClipPlane = m_camera.farClipPlane;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DOFarClipPlane(m_toFloat, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DOFarClipPlane(m_initialFarClipPlane, m_duration);
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.farClipPlane = m_initialFarClipPlane;
                    });
        return m_tw;
    }
}
