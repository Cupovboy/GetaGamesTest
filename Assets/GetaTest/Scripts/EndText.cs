using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndText : MonoBehaviour
{
    private GameManager GM;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GM.getCarrera() > 0)
            text.text = "You won   " + GM.getCarrera().ToString() + "  laps ";
        else
            text.text = "You lose  " + GM.getCarrera().ToString() + " laps ";
        
    }

  
}
