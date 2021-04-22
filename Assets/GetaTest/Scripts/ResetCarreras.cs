using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCarreras : MonoBehaviour
{
    private GameManager GM;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        changeCarreras();
    }
    void changeCarreras()
    {
        GM.carrera = 0;
    }
}
