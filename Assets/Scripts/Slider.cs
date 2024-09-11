using System.Collections;
using UnityEngine;

public class Slider : MonoBehaviour
{
    private SliderJoint2D SliderJoint;
    private JointMotor2D motorSlider;

    private float timeToChange = 2;
    
    void Start()
    {
        SliderJoint = GetComponent<SliderJoint2D>();
        motorSlider = SliderJoint.motor;
    }

    void Update()
    {
        if (SliderJoint.limitState == JointLimitState2D.UpperLimit || SliderJoint.limitState == JointLimitState2D.LowerLimit)
        {
            motorSlider.motorSpeed = 0;
            Invoke("ChangeDirection", timeToChange);
        }
    }

    private void ChangeDirection(int motorDirection)
    {
        motorSlider.motorSpeed *= -1;
        SliderJoint.motor = motorSlider;
        timeToChange = Random.Range(2, 5);
    }
}
