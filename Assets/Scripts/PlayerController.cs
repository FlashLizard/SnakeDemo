using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private PlayerState playerState;
    [SerializeField]
    public float velocity;
    public float dashVelocity;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerState = GetComponent<PlayerState>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float v = Input.GetButton("Dash") ? dashVelocity : velocity;
        Vector2 vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (vector.magnitude < 0.1) vector = Vector2.zero;
        else
        {
            vector = vector.normalized;
            //transform.rotation = Quaternion.LookRotation(Vector3.forward,vector);
            transform.up = vector;
        }
        rigidbody.velocity = vector * v;
        playerState.AdjectBody(transform.position);
    }
}
