using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

using AmpFC.Battle;

public class PlayerMovement : MonoBehaviour
{
    public Player_input player_input;
    public Rigidbody2D rb;
    private InputAction ascend;
    public float speed;

    public Vector2 moveDir = Vector2.zero;
    public Vector2 smoothmove;
    public Vector2 smoothvelocity;

    private void OnEnable()
    {
        ascend = player_input.Player.ascend;
        ascend.Enable();
        Projectile.onPlayerHit += Knockback;
    }

    private void OnDisable()
    {
        ascend.Disable();
        Projectile.onPlayerHit -= Knockback;
    }

    // Update is called once per frame
    private void Awake()
    {
        player_input = new Player_input();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDir = ascend.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        smoothmove = Vector2.SmoothDamp(smoothmove, moveDir, ref smoothvelocity, 0.1f);

        rb.AddForce(new Vector2(0, smoothmove.y * speed) - rb.velocity, ForceMode2D.Impulse);

        //rb.velocity = new Vector2(0, smoothmove.y * speed);
    }

    private void Knockback(float damage, float knockback, Vector2 direction)
    {
        var force = direction.normalized * knockback;
        var constrainedForce = new Vector2(0, force.y);
        rb.AddForce(constrainedForce, ForceMode2D.Impulse);
    }
}
