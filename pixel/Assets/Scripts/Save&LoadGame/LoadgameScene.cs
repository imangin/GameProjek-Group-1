using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadgameScene : MonoBehaviour
{
    private GameObject finish;
    // Start is called before the first frame update
    void Start()
    {
        finish = GameObject.Find("TX Struct Gate T2 B");
        finish.GetComponent<Finish>().Loadgame();
    }

   
    
}
