using UnityEngine;
using DG.Tweening;

public interface IEasyAnimation
{
    // TODO: Update to be more in line with the new EasyAnimation class and add doc comments
    public Tween Play();
    public float Interval {get; set;}
    public Tween Tw {get;}
}
