using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;
    public float Player_Speed;
    public float Rotation_Speed;

    public float JumpPower;
    private Rigidbody rb;
    private bool isJumping = false;
    bool isJump = false;

    Vector3 speed = Vector3.zero;
    Vector3 rot = Vector3.zero;

    public Animator PlayerAnimator;
    bool isRun;

    public Collider WeaponCollider;
    bool canMove = true;

    public AudioSource audioSource;
    public AudioClip AttackSE;

    public string TagName;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        Attack();
        Jump();
        Camera.transform.position=transform.position;
    }

    void Move()
    {
        if (canMove == false)
        {
            return;
        }

        speed = Vector3.zero;
        rot = Vector3.zero;
        isRun = false;
        WeaponCollider.enabled = false;


        if (Input.GetKey(KeyCode.W))
        {
            rot.y = -90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rot.y = 90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.A))
        {
            rot.y = -180;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rot.y = 0;
            MoveSet();
        }

        transform.Translate(speed);
        PlayerAnimator.SetBool("run", isRun);
    }

    void MoveSet()
    {
        speed.z = Player_Speed;
        transform.eulerAngles = Camera.transform.eulerAngles + rot;
        isRun = true;
    }

    void Rotation()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed.y = -Rotation_Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            speed.y = Rotation_Speed;
        } 

        Camera.transform.eulerAngles += speed;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetBool("attack", true);
            canMove = false;
            audioSource.PlayOneShot(AttackSE);
        }
    }

    void WeaponON()
    {
        WeaponCollider.enabled = true;
    }

    void WeaponOFF()
    {
        WeaponCollider.enabled = false;
        PlayerAnimator.SetBool("attack", false);
    }

    void CanMove()
    {
        canMove = true;
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            rb.velocity = Vector3.up * JumpPower;

            isJumping = true;
            PlayerAnimator.SetBool("jump", true);
            isJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(TagName))
        {
            isJumping = false;
            isJump = false;
        }
    }
}
