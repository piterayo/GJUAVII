using UnityEngine;
using System.Collections;

public class Control_Movimiento : MonoBehaviour
{

    public float maxSpeed = 10f;
    public float AlturaSalto = 10f;
    public int powerUp = 0; // 0 NO HAY - 1 ROCA - ETC
    bool powerUpActivo = false;
    bool facingRight = true;

    bool pushing=false;

    private float flyingTime;
    private float landingTimer;

    Animator anim;

    bool grounded = false;

    Rigidbody2D rigidBody;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("VSpeed", rigidBody.velocity.y);

        if (!powerUpActivo)
        {
            float move = Input.GetAxis("MovimientoHorizontal" + transform.name);
            anim.SetFloat("Speed", Mathf.Abs(move));

            if (grounded && Input.GetButtonDown("Salto" + transform.name))
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, AlturaSalto);

            rigidBody.velocity = new Vector2(move * maxSpeed, rigidBody.velocity.y);

            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();
        }

        if (!grounded)
        {
            flyingTime += Time.deltaTime;
            anim.SetFloat("AirTime", flyingTime);

        }
        //if (GetComponentInChildren<colisionSuelo> ().isGrounded ()) {
        //    grounded = true;

        //} else {
        //    grounded = false;
        //}
        //anim.SetBool ("Ground", grounded);

    }

    void FixedUpdate()
    {

        //float move = Input.GetAxis ("Horizontal");

    }

    public void setOnGround(bool g)
    {
        grounded = g;
        anim.SetBool("Ground", grounded);
        if (!grounded) flyingTime = 0.0f;
    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        Control_Altar altar = other.GetComponent<Control_Altar>();

        if (altar != null)
        {
            transform.GetComponent<PlayerState>().CurrentPower = altar.PowerUP;
            transform.GetComponent<PlayerState>().Transformation = altar.PowerUpTransformation;
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Pushable")
        {
            if (facingRight && (other.transform.position.x > transform.position.x) && rigidBody.velocity.x != 0)
            {
                pushing = true;
            }
            else if (!facingRight && (other.transform.position.x < transform.position.x) && rigidBody.velocity.x != 0)
            {
                pushing = true;
            }
            else
            {
                pushing = false;
            }
            anim.SetBool("Pushing", pushing);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Pushable")
        {
            pushing = false;
        }
        anim.SetBool("Pushing", pushing);
    }

}
