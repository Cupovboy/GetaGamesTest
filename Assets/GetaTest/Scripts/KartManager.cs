using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KartManager : MonoBehaviour
{
    public int speed;
    Rigidbody m_Rigidbody;
    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;
    public GameObject Wheel4;
    private Timer Timer;
    private GameManager GM;
    public bool powerspeed;
    private int oSpeed;
    private float timerStart;
    public Text SpeedT;
    public bool mitad;
    public Text carrera;
    public bool jumping;
    private LoadManager LM;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Timer = GameObject.FindObjectOfType<Timer>();
        GM = GameObject.FindObjectOfType<GameManager>();
        LM = GameObject.FindObjectOfType<LoadManager>();
        oSpeed = speed;
        m_Rigidbody.transform.parent = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!Timer.getEndGame())
        {
            move();
            rotate();
            if (powerspeed)
                speedRecover();
            SpeedDisplay();
            textCarrera();
        }
        else
        {
            LM.Loadlevel(2);
        }
      
    }
    /// <summary>
    /// Function in charge of the kart moverment using vertical input and movement speed ;
    /// </summary>
    private void move()
    {
        wheelRotate();
        Vector3 m_Input = new Vector3(Vector3.forward.x, 0, Vector3.forward.z);
        
        if (Input.GetAxis("Vertical") != 0)
        {
           float speedInput = 0f;
            wheelRotate();
            if (Input.GetAxis("Vertical") > 0)
            {
                speedInput = Input.GetAxis("Vertical") * speed * 10f;
            }
            else if (Input.GetAxis("Vertical") < 0)

            {
                speedInput = Input.GetAxis("Vertical") * (speed) * 10f;

            }


            if(speedInput !=0)
                m_Rigidbody.AddForce(transform.forward*speedInput);



        }
    

        
    }
    /// <summary>
    /// Function in charge of the kart rotation 
    /// </summary>
    private void rotate()
    {

        if (Input.GetAxis("Horizontal") != 0) 
            m_Rigidbody.AddTorque(Vector3.up * Input.GetAxis("Horizontal") * 1);

    }
    /// <summary>
    /// Function that animate the rotation of the wheels 
    /// </summary>

    private void wheelRotate()
    {
        Wheel1.transform.Rotate(new Vector3(10f, 0f, 0) * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        Wheel2.transform.Rotate(new Vector3(10f, 0f, 0) * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        Wheel3.transform.Rotate(new Vector3(10f, 0f, 0) * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        Wheel4.transform.Rotate(new Vector3(10f, 0f, 0) * Time.deltaTime * speed * Input.GetAxis("Vertical"));

    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Box")
        {
            Destroy(other.gameObject);
            Timer.addtime();

        }
        if (other.tag == "speed")
        {

            speed = speed * 20;
            powerspeed = true;
            
            
        }
        if (other.tag == "oil")
        {
            rotateoil();
        }
        if (other.tag == "jump")
        {
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
            m_Rigidbody.AddRelativeForce(new Vector3(0f, 80f, 0) * speed *  5);
            jumping = true;

           
        }
        if (other.tag == "m1")
        {
            mitad = !mitad;

        }
        if (other.tag == "End" && mitad)
        {
            GM.aumentarCareras();
            mitad = false;
        }
    }

    /// <summary>
    /// Function that slow down the accelaration 
    /// </summary>
    private void speedRecover()
    {
        if (speed >= oSpeed)
        {
            speed -= 1;
        }
        else
        {
            powerspeed = false;
            speed = oSpeed;
        }
    }
    /// <summary>
    /// Function that display the real speed of the kart
    /// </summary>
    private void SpeedDisplay ()
    {
        SpeedT.text = "Speed " + m_Rigidbody.velocity.magnitude.ToString(); ;

    }
    /// <summary>
    /// FUnction use it to lose control ofn the cart for a small amount of time 
    /// </summary>
    private void rotateoil()
    {
       
        m_Rigidbody.AddTorque(new Vector3(180f, 180f, 180f) );
       
    }
    private void textCarrera()
    {

       carrera.text = "Carreras:  " + GM.getCarrera() ;


    }
    private void changeConstrain()
    {

      // m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY;
    }

   


}
