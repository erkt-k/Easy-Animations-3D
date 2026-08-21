using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

public class EasyRbPath : EasyAnimation
{
    [SerializeField] List<Vector3> m_wayPoints;
    [SerializeField] PathType m_pathType = PathType.Linear;
    [SerializeField] PathMode m_pathMode = PathMode.Ignore;
    [SerializeField] int m_resolution = 5;
    [SerializeField] Color m_gizmoColor = Color.green;

    private Vector3 m_initialPos;
    private bool m_isKinematic;
    private Rigidbody m_rb;

    void Awake()
    {
        m_rb = gameObject.GetComponent<Rigidbody>();
        m_initialPos = transform.position;
        m_isKinematic = m_rb.isKinematic;
    }

    public override Tween Play()
    {
        CleanUp();

        if (!m_isKinematic) m_rb.isKinematic = true;
        m_tw = m_rb.DOPath(m_wayPoints.ToArray(), m_duration, m_pathType, m_pathMode, m_resolution, m_gizmoColor)
                .SetLoops(m_repeat ? -1 : m_loopAmount, m_loopType)
                .OnComplete(() =>
                {
                    m_tw = null;
                    
                    int lastIndex = m_wayPoints.Count -1;
                    Vector3 lastPos = m_wayPoints[lastIndex];
                    // reverse the path, take out the lastPos and add the initialPos
                    // We have to exchange the initialPos and lastPos because if the user
                    // set their waypoints for the bezier curve, it should stay as a multiple of 3
                    m_wayPoints.RemoveAt(lastIndex);
                    m_wayPoints.Reverse();
                    m_wayPoints.Append(m_initialPos); // make sure initial pos is in the way

                    if (m_doesReturnHome) m_rb.DOPath(m_wayPoints.ToArray(),
                                                    m_duration, m_pathType, m_pathMode, m_resolution, m_gizmoColor)
                                                    .OnComplete(() =>
                                                    {
                                                        m_rb.isKinematic = m_isKinematic; // If I'm returning home through the path, I need to keep rb kinematic till I get back.
                                                    });
                    else m_rb.isKinematic = m_isKinematic;

                    // fix the path ny reversing again, take out the initialPos and add lastPos
                    m_wayPoints.RemoveAt(lastIndex); // remove the added initial pos
                    m_wayPoints.Reverse();
                    m_wayPoints.Append(lastPos);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) transform.localPosition = m_initialPos;
                });
        return m_tw;
    }
}
