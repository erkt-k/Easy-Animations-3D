using DG.Tweening;
using UnityEngine;


[AddComponentMenu("EasyAnimation")]
public class EasyAnimationPlayer : MonoBehaviour
{
    /* 
        TODO: I can add a property to flag if the user wants to run onvalidate in EasyAnimation or not here.
        EasyAnimation would have a parameter? that tracks the EasyAnimationPlayer component that added them and pulls the bool to check if they want to play with OnValidate or not.
    */
    
    void Awake()
    {
        DOTween.Init(recycleAllByDefault: false);
    }

    /// <summary>
    /// Gets every <b> Easy Animation </b> component the gameObject has and plays them.
    /// </summary>
    public void Play()
    {
        EasyAnimation[] animations = transform.GetComponents<EasyAnimation>();

        foreach (EasyAnimation anim in animations)
        {
            anim.Play();
        }
    }
}
