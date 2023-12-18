using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform Camera;
    public float PlayerSpeed;
    public float RotationSpeed;

    Vector3 speed = Vector3.zero;
    Vector3 rot = Vector3.zero;

    public Animator PlayerAnimator;
    bool isRun;

    public Collider WeaponCollider;
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
        Camera.transform.position = transform.position;

    }

    void Move()
    {
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
        speed.z = PlayerSpeed;
        transform.eulerAngles = Camera.transform.eulerAngles + rot;
        isRun = true;

    }

    void Rotation()
    {
        var speed = Vector3.zero;
        if (Input.GetKey(KeyCode.Q))
        {
            speed.y = -RotationSpeed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            speed.y = RotationSpeed;
        }

        Camera.transform.eulerAngles += speed;
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAnimator.SetBool("attack", true);
        }
    }

    void WeaponOn()
    {
        WeaponCollider.enabled = true;

    }

    void WeaponOff()
    {
        WeaponCollider.enabled = false;
        PlayerAnimator.SetBool("attack", false);

    }
}
