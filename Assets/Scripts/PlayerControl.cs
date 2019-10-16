using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Public Variables
    public float speed;
    public GameObject laser;
    public Transform laserSpawn;
    public float fireRate = 0.5f;
    public Vector2 bottomLeftBoundary;
    public Vector2 topRightBoundary;

    //Private Variables
    private Rigidbody2D rBody;
    private float counter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if (Input.GetButton("Fire1") && counter > fireRate)
        {
            //Instantiate the laser
            Instantiate(laser, laserSpawn.position, laser.transform.rotation);
            counter = 0.0f;
        }
    }

    // Update is called once per frame
    // FixedUpdate is used when modifying physics values
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        //Debug.Log("Horizontal: " + horiz + "Vertical: " + vert);

        rBody.velocity = new Vector2(horiz * speed, vert * speed);

        //Restrict player from leaving play area
        rBody.position = new Vector2(
            Mathf.Clamp(rBody.position.x, bottomLeftBoundary.x, topRightBoundary.x),
            Mathf.Clamp(rBody.position.y, bottomLeftBoundary.y, topRightBoundary.y));
    }
}
