using UnityEngine;
using DG.Tweening;

public abstract class EasyAnimation : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("Does the animation m_repeat?")]
    [SerializeField] protected bool m_repeat = true;
    
    [Tooltip("Does the animation play on awaking?")]
    [SerializeField] protected bool m_playOnAwake = true;

    [Tooltip("Duration of the movement.")]
    [Min(0.001f)]
    [SerializeField] protected float m_duration = 0.5f;

    [Tooltip("Duration of wait before playing the animation again.")]
    [Min(0)]
    protected float m_interval = 0f;

    public float Interval
    {
        get => m_interval;
        set {
            m_interval = Mathf.Max(0, value);
            m_tw.Kill(true);
            Play();
        }
    }

    [Tooltip("True: the movement will smoothly snap to integer values.")]
    [SerializeField] protected bool m_snapping = false;

    [Tooltip("True: Returns to initial position.")]
    [SerializeField] protected bool m_doesReturnHome = false;

    [Tooltip("Animation's extra loop amounts.")]
    [Min(0)]
    [SerializeField] protected int m_loopAmount;
    [SerializeField] protected LoopType m_loopType = LoopType.Restart;
    protected Tween m_tw;
    public Tween Tw {
        get
        {
            return m_tw;
        }
    }

    /// <summary>
    /// Plays the tweener. If tweener doesn't exist, creates the tweener first.
    /// </summary>
    /// <returns>
    /// The tweener or Null if there is a problem with the MoveOption choice.
    /// </returns>
    public abstract Tween Play();

    public virtual void UpdateAnimation()
    {
        CleanUp();

        m_tw = Play();
    }

    public virtual void OnValidate()
    {
        if (!Application.isPlaying) return;
        Debug.Log("This played");
        UpdateAnimation();
    }

    /// <summary>
    /// If m_tw is <b> NOT null</b>, pauses it.
    /// If it is, calls <b>Play()</b> and then pauses it. 
    /// </summary>
    public virtual void Pause()
    {
        if (m_tw != null) m_tw.Pause();
        else Play()?.Pause();
    }

    public virtual void CleanUp()
    {
        if (m_tw != null)
        {
            m_tw.Kill();
            m_tw = null;
        }
    }
}
