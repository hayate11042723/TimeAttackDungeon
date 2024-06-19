using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;
    public float Player_Speed;
    public float Rotation_Speed;

    Vector3 speed = Vector3.zero;
    Vector3 rot = Vector3.zero;

    public Animator PlayerAnimator;
    bool isRun;

    public Collider WeaponCollider;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotation();
        Attack();
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

        if (Input.GetKey(KeyCode.W))
        {
            rot.y = 0;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.S))
        {
            rot.y = 180;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.A))
        {
            rot.y = -90;
            MoveSet();
        }
        if (Input.GetKey(KeyCode.D))
        {
            rot.y = 90;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAnimator.SetBool("attack2", true);
            }
            else
            {
                return;
            }
            canMove = false;
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
}
