using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    PlayerMovement player;
    public AudioSource vocalFry;
    Vector3 lastPos;
    private void Awake() {
        vocalFry=GetComponent<AudioSource>();
        player=GetComponent<PlayerMovement>();
    }
    private void Start() {
        vocalFry.Play();
    }
    void FixedUpdate()
    {  
        //float difference= player.gameObject.transform.position.y-lastPos.y;

       // var localVel= transform.InverseTransformDirection(player.rb.velocity);
        //Debug.Log(localVel);
        vocalFry.pitch +=player.smoothvelocity.y/50;
        //switch(player.rb.velocity.y)
        //{
        //    case >0:
        //        vocalFry.pitch +=player.rb.velocity.y;
        //        break;
        //    case <0:
        //        vocalFry.pitch -=0.01f;
        //        break;
        //}
        //lastPos=player.gameObject.transform.position;
    }
}
