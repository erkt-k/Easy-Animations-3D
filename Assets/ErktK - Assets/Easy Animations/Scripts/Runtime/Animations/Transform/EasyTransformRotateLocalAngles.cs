using System.Collections;
using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
public class EasyTransformRotateLocalAngles : EasyAnimation
{
    [Tooltip("The angle to rotate to. It uses Euler Angles not Quaternion angles.")]
    [SerializeField] Vector3 m_toAngle = Vector3.zero;
    [SerializeField] RotateMode m_rotateMode = RotateMode.Fast;

    private Vector3 m_originalRot;

    void Awake()
    {
        m_originalRot = transform.localEulerAngles;
    }

    public override Tween Play()
    {
        CleanUp();

        m_tw = transform.DOLocalRotate(m_toAngle, m_duration, m_rotateMode)
                        .SetLoops(m_repeat ? -1 : m_loopAmount)
                        .OnComplete(() =>
                        {
                            m_tw = null;
                            if (m_doesReturnHome)
                            {
                                transform.DOLocalRotate(m_originalRot, m_duration, m_rotateMode);
                            }
                        });

        return m_tw;
    }
}
