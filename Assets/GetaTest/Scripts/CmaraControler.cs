    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CmaraControler : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation,10);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y,0)) ;
    }
}
