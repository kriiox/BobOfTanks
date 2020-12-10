using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float speedRotation = 3f;

    private Vector3 velocity;
    private Vector3 _RotationX;
    private Vector3 _turretRotationY;

    public Transform turret;
    public Rigidbody rb;
    public GameController gameController;
    public SFXPlaying sfxPlaying;

    // Permet de gerer le déplacement du joueur.

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameController.isStart == false && GameController.instance.gameEnded == false)
        {

            // Calcule de la velocité du mouvement en un vecteur 3D
            float _movementX = Input.GetAxisRaw("Horizontal");
            float _movementZ = Input.GetAxisRaw("Vertical");
            Vector3 _moveHorizontal = transform.right * _movementX;
            Vector3 _moveVertical = transform.forward * _movementZ;
            velocity = (_moveHorizontal + _moveVertical).normalized * speed;

            // Calcule de la rotation du joueur en un vecteur 3D
            float _rotationX = Input.GetAxisRaw("Mouse X");
            _RotationX = new Vector3(0, _rotationX, 0) * speedRotation;

            // Calcule de la rotation du turret en un vecteur 3D
            float _rotationY = Input.GetAxisRaw("Mouse Y");
            _turretRotationY = new Vector3(_rotationY, 0, 0) * speedRotation;
        }


        // Gestion du curseur de la souris.
        if (GameController.instance.gameEnded == false)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        } else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void FixedUpdate()
    {
        Movement();
        Rotate();
    }

    private void Rotate()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(_RotationX));
        turret.transform.Rotate(-_turretRotationY);
        
    }

    private void Movement()
    {
        if(velocity != Vector3.zero)
        {            
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
}