using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    CharacterController Controller;

    float Horizontal;
    float Vertical;
    public float playerSpeed = 10;

    // Smooth turning variable.
    float turnSmoothVelocity;
    float TurnSmooth = 0.1f;


    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(Horizontal, 0, Vertical);
        Controller.Move(move * Time.deltaTime * playerSpeed);
        Vector3 direction = new Vector3(Horizontal, 0 ,Vertical);
        

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            // Smooth turning
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

    }
}
