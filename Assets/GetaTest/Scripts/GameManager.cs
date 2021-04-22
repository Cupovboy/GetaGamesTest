using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int carrera = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

     public void aumentarCareras()
    {
        carrera += 1;
    }
    public int getCarrera()
    {
        return carrera;
    }
}