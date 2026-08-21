using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;

[AddComponentMenu(""), RequireComponent(typeof(Rigidbody2D))]
public class EasyRb2DPath : EasyAnimation
{
    [SerializeField] List<Vector2> m_wayPoints;
    [SerializeField] PathType m_pathType = PathType.Linear;
    [SerializeField] PathMode m_pathMode = PathMode.Ignore;
    [SerializeField] int m_resolution = 5;
    [SerializeField] Color m_gizmoColor = Color.green;

    private Vector2 m_initialPos;
    private RigidbodyType2D m_rbBodyType;
    private Rigidbody2D m_rb;

    void Awake()
    {
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_initialPos = transform.position;
        m_rbBodyType = m_rb.bodyType;
    }

    public override Tween Play()
    {
        CleanUp();

        if (m_rbBodyType != RigidbodyType2D.Kinematic) m_rb.bodyType = RigidbodyType2D.Kinematic;

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
                                                        m_rb.bodyType = m_rbBodyType; // If I'm returning home through the path, I need to keep rb kinematic till I get back.
                                                    });
                    else m_rb.bodyType = m_rbBodyType;

                    // fix the path ny reversing again, take out the initialPos and add lastPos
                    m_wayPoints.RemoveAt(lastIndex); // remove the added initial pos
                    m_wayPoints.Reverse();
                    m_wayPoints.Append(lastPos);
                })
                .OnKill(() =>
                {
                    m_tw = null;

                    if (m_doesReturnHome) m_rb.position = m_initialPos;
                });
        return m_tw;
    }
}
