using UnityEngine;
using UnityEngine.InputSystem;

public class TestBehaviourTempScript : MonoBehaviour
{
    [SerializeField] EasyAnimationPlayer target;
    


public void OnFire(InputAction.CallbackContext context)
{
    // Only play when the button is initially pressed down
    if (context.performed) 
    {
        target.Play();
    }
}
}