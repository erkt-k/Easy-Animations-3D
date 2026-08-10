using DG.Tweening;
using UnityEngine;

[AddComponentMenu("")]
public class EasyMove : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("Does the animation m_repeat?")]
    [SerializeField] bool m_repeat = true;
    [Tooltip("The position to move to. Has priority over transform")]
    [SerializeField] Vector3 m_toPosition = Vector3.zero;

    [Tooltip("The transform to move to. The vector has priority over this value")]
    [SerializeField] Transform m_toTransform;

    [Tooltip("Duration of the movement.")]
    [Min(0.001f)]
    [SerializeField] float m_duration = 0.5f;

    [Tooltip("Duration of wait before playing the animation again.")]
    [Min(0)]
    [SerializeField] float m_interval = 0f;

    [Tooltip("True: the movement will smoothly snap to integer values.")]
    [SerializeField] bool m_snapping = false;

    [Tooltip("True: Returns to initial position.")]
    [SerializeField] bool m_doesReturnHome = false;
    private Tween m_tw;
    public Tween Tw {
        get
        {
            if (m_tw == null) m_tw = Play().Pause();
            return m_tw;
        }
    }

    public float Interval
    {
        get => m_interval;
        set => m_interval = Mathf.Max(0, value);
    }

    public Tween Play()
    {
        return null;
    }



    public void AppendTo(Sequence seq, Transform target)
    {
        Tw.SetTarget(target);
        seq.Append(Tw);
    }
}
