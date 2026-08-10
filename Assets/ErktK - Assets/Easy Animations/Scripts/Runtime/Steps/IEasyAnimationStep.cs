using UnityEngine;
using DG.Tweening;

public interface IEasyAnimationStep
{
    public Tween Play();
    public void AppendTo(Sequence seq, Transform target);
    public float Interval {get; set;}
    public Tween Tw {get;}
}
