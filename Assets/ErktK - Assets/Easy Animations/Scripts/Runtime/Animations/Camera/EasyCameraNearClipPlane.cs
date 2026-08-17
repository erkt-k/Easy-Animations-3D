using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraNearClipPlane : EasyAnimation
{
    [SerializeField] float m_toFloat;
    private Camera m_camera;
    private float m_initialNearClipPlane;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialNearClipPlane = m_camera.nearClipPlane;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DONearClipPlane(m_toFloat, m_duration)
                    .SetLoops(m_repeat ? -1 : 0, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DONearClipPlane(m_initialNearClipPlane, m_duration);
                    });
        return m_tw;
    }
}
