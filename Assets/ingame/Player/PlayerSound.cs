using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    PlayerMovement player;
    public AudioSource vocalFry;
    Vector3 lastPos;
    private void Awake()
    {
        vocalFry = GetComponent<AudioSource>();
        player = GetComponent<PlayerMovement>();
    }
    private void Start()
    {
        vocalFry.Play();
    }
    void FixedUpdate()
    {
        float difference = transform.position.y - lastPos.y;
        //Debug.Log(difference);
        //var localVel= transform.InverseTransformDirection(player.rb.velocity);
        //Debug.Log(localVel);
        vocalFry.pitch += difference / 10;
        //switch (difference)
        //{
        //    case > 0:
        //        vocalFry.pitch += player.smoothmove.y / 200;
        //        break;
        //    case < 0:
        //        vocalFry.pitch -= player.smoothmove.y / 200;
        //        break;
        //}
        lastPos = transform.position;
    }
}
