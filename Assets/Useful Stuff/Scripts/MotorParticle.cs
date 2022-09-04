using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotorParticle : MonoBehaviour
{
    public ParticleSystem seaMotor1;
    public ParticleSystem seaMotor2;
    public ParticleSystem seaMotor3;
    public ParticleSystem vacMotor1;
    public ParticleSystem vacMotor2;
    public ParticleSystem vacMotor3;
    public Slider thrustSlider;

    [System.Obsolete]
    public void thrustParticle(bool state)
    {
        if (state && Propulsion.endCarb == false)
        { 
            //seaMotor1.startLifetime = thrustSlider.value * 2;
            //seaMotor2.startLifetime = thrustSlider.value * 2;
            //seaMotor3.startLifetime = thrustSlider.value * 2;
            vacMotor1.startLifetime = thrustSlider.value * 2;
            vacMotor2.startLifetime = thrustSlider.value * 2;
            vacMotor3.startLifetime = thrustSlider.value * 2;
        }
        else
        {
            seaMotor1.startLifetime = 0;
            seaMotor2.startLifetime = 0;
            seaMotor3.startLifetime = 0;
            vacMotor1.startLifetime = 0;
            vacMotor2.startLifetime = 0;
            vacMotor3.startLifetime = 0;
        }
    }
}
