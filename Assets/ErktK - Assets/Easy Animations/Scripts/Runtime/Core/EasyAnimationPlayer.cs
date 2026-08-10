using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


[AddComponentMenu("EasyAnimation")]
public class EasyAnimationPlayer : MonoBehaviour
{
    [SerializeField] LoopType _loopType = LoopType.Restart;
    [SerializeField] int _loopAmount = 0;

    // s
    [HideInInspector] List<Tween> _animationSteps;
    [HideInInspector] public string m_ComponentToAdd = "EasyMove";
    [SerializeField] bool _playOnAwake = true;
    float _interval = 0f;
    float Interval
    {
        get => _interval;
        set
        {
            _interval = Mathf.Max(0, value);
        }
    }
    
    private Sequence seq;
    public Sequence Seq { get => seq; }

    void Awake()
    {
        DOTween.Init();
        _animationSteps = new List<Tween>();
    }

    void Start()
    {
        seq = DOTween.Sequence();
        seq.SetId(this);
        foreach(Tween step in _animationSteps)
        {
            if(step.target.Equals(transform)) step.SetTarget(transform);
            seq.Append(step);
        }
        seq.SetLoops(_loopAmount, _loopType);
        seq.AppendInterval(_interval);
        if (_playOnAwake) Play();
    }

    public void Play()
    {
        if (seq.IsPlaying()) return;
        seq.Play();
    }

    void OnEnable()
    {
        Play();
    }

    void OnDestroy()
    {
        seq.Complete();
        seq.Kill();
    }
}
