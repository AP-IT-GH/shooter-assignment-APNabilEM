using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float X_SPEED = 30f;
    public float X_POS_MIN = -25f;
    public float X_POS_MAX = 25f;
    public float Y_POS_MIN = -15f;
    public float Y_POS_MAX = 15f;
    bool isControllable = true;
    public GameObject explosionFX;
    public GameObject laser;
    public Quaternion originalRotationValue;
    public float rotationResetSpeed = 5f;
    public float transformRotationSpeed = 360f;
    
    void Start()
    {
        originalRotationValue = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        //Smooth Barrelroll reset (maar werkt niet v_v)
        /*
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        if (transform.rotation.y != 0 || transform.rotation.x != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, eulerRotation.z);
        }
        */
        
        if (isControllable)
            Movement();

        if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            isControllable = false;
            FindObjectOfType<GameUI>().Winner();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isControllable = false;
        FindObjectOfType<GameUI>().GameOver();
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void Movement()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");
        float xOffset = horizontal * Time.deltaTime * X_SPEED;
        float yOffset = vertical * Time.deltaTime * X_SPEED;
        float xNewPos = xOffset + transform.localPosition.x;
        float yNewPos = yOffset + transform.localPosition.y;
        transform.localPosition = new Vector3(Mathf.Clamp(xNewPos, X_POS_MIN, X_POS_MAX), Mathf.Clamp(yNewPos, Y_POS_MIN, Y_POS_MAX), transform.localPosition.z);

        LaserShooting();
        BarrelRoll();
    }

    private void BarrelRoll()
    {
        var barrelRollKeyLeft = Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.X);
        var barrelRollKeyRight = Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.C);

        if (barrelRollKeyLeft)
        {
            transform.Rotate(new Vector3(0, 0, transformRotationSpeed) * Time.deltaTime);
        }
        else if (barrelRollKeyRight)
        {
            transform.Rotate(new Vector3(0, 0, -transformRotationSpeed) * Time.deltaTime);
        }
        else
        {
            //reset Z Rotation Axis Smooth Barrelroll reset (maar werkt niet v_v)
            //transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.deltaTime * rotationResetSpeed);
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void LaserShooting()
    {
        var shootKey = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse2);

        if (shootKey)
            laser.SetActive(true);
        else
            laser.SetActive(false);
    }
}
