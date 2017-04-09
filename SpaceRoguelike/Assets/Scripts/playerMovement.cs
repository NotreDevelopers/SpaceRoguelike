using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public float maxSpeed = 5f; //Max spped the player can move


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);       // Get the position of the mouse to adjust rotation

        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg + 90;   // Calculate the angle to turn the player
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        GetComponent<Rigidbody2D>().velocity = targetVelocity * maxSpeed;

    }
}
