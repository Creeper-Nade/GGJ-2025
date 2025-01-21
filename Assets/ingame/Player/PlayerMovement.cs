using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Player_input player_input;
    [SerializeField] Rigidbody2D rb;
    private InputAction ascend;
    public float speed;


    [SerializeField] Vector2 moveDir=Vector2.zero;
        private Vector2 smoothmove;
    private Vector2 smoothvelocity;
    private void OnEnable() {
        ascend=player_input.Player.ascend;
        ascend.Enable();
    }
    private void OnDisable() {
        ascend.Disable();
    }
    // Update is called once per frame
    private void Awake() {
        player_input=new Player_input();
        rb=this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveDir=ascend.ReadValue<Vector2>(); 
    }
    private void FixedUpdate() {
        //if(moveDir.y>0 && speed<Max_speed)
        //speed+=acceleration;
        //else if (speed>5)
        //speed-=acceleration;
        smoothmove=Vector2.SmoothDamp(smoothmove,moveDir,ref smoothvelocity,0.1f);
        rb.velocity=new Vector2(0,smoothmove.y*speed);

    }
}
