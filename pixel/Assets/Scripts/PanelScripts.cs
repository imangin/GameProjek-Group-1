using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelScripts : MonoBehaviour
{
    public GameObject Panel;
    public void hide()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Panel.gameObject.SetActive(false);
        }    
    }
}
