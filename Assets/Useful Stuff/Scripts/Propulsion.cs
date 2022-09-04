using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Propulsion : MonoBehaviour
{
    public Joystick joystick;
    public GameObject wingL, wingR;
    public float c = 1;
    public Camera engineView;
    public Camera mainView;
    public GameObject landingPad;
    public GameObject winPanel;
    public GameObject Star1; public GameObject Star2; public GameObject Star3;
    public GameObject rocketPos;
    public ParticleSystem explosionParticle;
    public GameObject gamePanel;
    public GameObject endPanel;
    public GameObject menuPanel;
    public static bool isPlaying = false;
    //public GameObject pianeta;
    public Slider thrustSlider;
    public Slider propSlider;
    //public ParticleSystem explosion;
    public TextMeshProUGUI heightText;
    public TextMeshProUGUI velocityText;
    public TextMeshProUGUI propPerc;
    public ParticleSystem sbuffoneDestro;
    public ParticleSystem sbuffoneSinistro;
    private Rigidbody rocket;
    public float forceMultiplier = 1;
    float NThrustperEngine = 2200000, NThrustMax;
    public float numOfEngine = 6;
    float rocketMass = 120000, propMassI;
    public float propMass = 1000000;
    float exhaustMassperSecond, t; 
    Vector3 NThrust, gravityEarth;
    public static bool endCarb;
    void Start()
    {
        endCarb = false;
        rocket = GetComponent<Rigidbody>();

        NThrustMax = numOfEngine * NThrustperEngine * forceMultiplier;
        rocket.mass = rocketMass + propMass;
        propMassI = propMass;

        rocket.velocity = new Vector3(0, Random.Range(-50, -80), Random.Range(10, -10));
        transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-50, 50), transform.position.z + Random.Range(-70, 70));
        exhaustMassperSecond = RewardedAdsButton.rewardedProp < 10 ? 20000 - (RewardedAdsButton.rewardedProp * 1000) : 5000; // kg/s
    }
    void FixedUpdate()
    {
        if (thrustBTPressed && rocket.position.y < 10000 && propMass > 0)
        {
            propMass = propMass <= 0 ? 0 : propMassI - (exhaustMassperSecond * t);
            rocket.mass = propMass + rocketMass;
            
            rocket.AddRelativeForce(Vector3.up * NThrustMax * thrustSlider.value);
            SoundManagerScript.playEngineSound(thrustSlider.value);
            t += 0.02f;
        }
        if (propMass <= 0)
        {
            endCarb = true;
        }
        if(rocket.position.y > 10000)
        {
            heightText.text = "MAXIMUM HEIGHT REACH";
        }
        else
        {
            heightText.text = "HEIGHT: " + (int)rocket.position.y + " m";
        }
        float th = 100000000 + (thrustSlider.value * (thrustBTPressed ? 50000000 : 0));
        /*
        if (leftBTPressed)
        {
            rocket.AddRelativeTorque(Vector3.left * th * c);
            sbuffoneSinistro.gameObject.SetActive(true);
        }
        if (rightBTPressed)
        {
            rocket.AddRelativeTorque(Vector3.right * th * c);
            sbuffoneDestro.gameObject.SetActive(true);
        }
        if (!leftBTPressed)
        {
            sbuffoneSinistro.gameObject.SetActive(false);
        }
        if (!rightBTPressed)
        {
            sbuffoneDestro.gameObject.SetActive(false);
        }
        */
        rocket.AddRelativeTorque(Vector3.right * joystick.Horizontal * th * c);
        rocket.AddRelativeTorque(Vector3.forward * joystick.Vertical * th * c);
        if (!thrustBTPressed)
        {
            SoundManagerScript.stopplaySound();
        }
        if (menuPanel.activeSelf)
        {
            GeneralScript.PauseStaticGame();
            gamePanel.SetActive(false);
        }
        velocityText.text = "VELOCITY: " + (int)(rocket.velocity.magnitude * 3.6f * rocket.velocity.normalized.y) + "km/h";
        propPerc.text = (int)(propMass / propMassI * 100) + "%";
        propSlider.value = propMass / propMassI;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 10)
        {
            if (engineView.isActiveAndEnabled)
            {
                mainView.enabled = true;
                mainView.GetComponent<AudioListener>().enabled = true;
            }
            endPanel.SetActive(true);
            Instantiate(explosionParticle, rocketPos.transform.position, new Quaternion(0, 0, 0, 0));
            Destroy(gamePanel);
            Destroy(gameObject);
        }
        if(collision.gameObject == landingPad && collision.relativeVelocity.magnitude <= 10)
        {
            int star = (int)Mathf.Abs((collision.relativeVelocity.magnitude / 10 * 3) - 3) + 1;
            winPanel.SetActive(true);
            Destroy(gamePanel);
            Star1.SetActive(star >= 1 ? true : false);
            Star2.SetActive(star >= 2 ? true : false);
            Star3.SetActive(star >= 3 ? true : false);
        }
    }
    public void isPlayingFunc()
    {
        isPlaying = true;
    }

    #region stuffForButton
    bool thrustBTPressed = false;
    bool leftBTPressed = false;
    bool rightBTPressed = false;
    public void thrustButtonClick()
    {
        thrustBTPressed = true;
    }
    public void thrustButtonNotClick()
    {
        thrustBTPressed = false;
    }
    public void leftButtonClick()
    {
        leftBTPressed = true;
    }
    public void leftButtonNotClick()
    {
        leftBTPressed = false;
    }
    public void rightButtonClick()
    {
        rightBTPressed = true;
    }
    public void rightButtonNotClick()
    {
        rightBTPressed = false;
    }
    #endregion
    /*double rQuadro, gCost, gForce, earthMass, alpha, gAccel;
    gCost = 6.67 * Math.Pow(10, -11);
    earthMass = (float)(5.972 * Math.Pow(10, 24));
    rQuadro = Math.Pow((pianeta.transform.position.x - rocket.position.x), 2) + Math.Pow((pianeta.transform.position.y - rocket.position.y + 6380000), 2);
    gForce = gCost * earthMass * rocket.mass / rQuadro;
    alpha = Math.Atan2(pianeta.transform.position.y - rocket.position.y, pianeta.transform.position.x - rocket.position.x);
    gAccel = gForce / rocket.mass;
    gravityEarth = new Vector2((float)(Math.Cos(alpha) * gForce), (float)(Math.Sin(alpha) * gForce));
    rocket.AddForce(gravityEarth);*/
}