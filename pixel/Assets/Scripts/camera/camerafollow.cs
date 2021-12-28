using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
	private Transform Player;
    private float minX = 0, maxX = 0;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        if (Player != null)
        {
            Vector3 vitri = transform.position;
            vitri.x = Player.position.x;
            if (vitri.x < minX) vitri.x = 0;
            if (vitri.x < maxX) vitri.x = maxX;
            transform.position = vitri;
        }
    }
}
