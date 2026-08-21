using UnityEngine;
using DG.Tweening;

[AddComponentMenu(""), RequireComponent(typeof(Camera))]
public class EasyCameraFieldOfView : EasyAnimation
{
    [SerializeField] float m_toFloat;
    private Camera m_camera;
    private float m_initialFieldOfView;

    void Awake()
    {
        m_camera = gameObject.GetComponent<Camera>();
        m_initialFieldOfView = m_camera.fieldOfView;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = m_camera.DOFieldOfView(m_toFloat, m_duration)
                    .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                    .OnComplete(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.DOFieldOfView(m_initialFieldOfView, m_duration);
                    })
                    .OnKill(() =>
                    {
                        m_tw = null;

                        if (m_doesReturnHome) m_camera.fieldOfView = m_initialFieldOfView;
                    });
        return m_tw;
    }
}
