using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class handAnimationController : MonoBehaviour
{
    public InputActionProperty pinchAnimation;
    public InputActionProperty rockAnimation;

    public Animator handAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float pinchValue = pinchAnimation.action.ReadValue<float>();
        handAnimation.SetFloat("PinchFloat", pinchValue);

        float rockValue = rockAnimation.action.ReadValue<float>();
        handAnimation.SetFloat("RockFloat", rockValue);
    }
}
