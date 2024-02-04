using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public float maxSteeringAngle = 30f;
    public float motorForce = 50f;
    public float brakeForce = 0f;

    public GameObject com;
    public Rigidbody rigid;

    public Vector3 offset;
    public int jump;
    private Quaternion initialRotation;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.centerOfMass = com.transform.localPosition;
        initialRotation = rigid.transform.rotation;
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        if (Input.GetKeyDown("f"))
        {
            rigid.transform.position = rigid.transform.position + offset;
            rigid.transform.rotation = initialRotation;
            Debug.Log("space key was pressed");
        }
        if (Input.GetKeyDown("space"))
        {
            rigid.AddForce(new Vector3(0, jump, 0), ForceMode.Impulse);
        }
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);

    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * ((motorForce * 5) / 4);
        frontRightWheelCollider.motorTorque = verticalInput * ((motorForce * 5) / 4);
        rearLeftWheelCollider.motorTorque = verticalInput * ((motorForce * 5) / 4);
        rearRightWheelCollider.motorTorque = verticalInput * ((motorForce * 5) / 4);

        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;

        // if (frontLeftWheelCollider.rpm > 200)
        // {
        //     frontLeftWheelCollider.motorTorque = 0;
        // }
        // if (frontRightWheelCollider.rpm > 200)
        // {
        //     frontRightWheelCollider.motorTorque = 0;
        // }
        // if (rearLeftWheelCollider.rpm > 200)
        // {
        //     rearLeftWheelCollider.motorTorque = 0;
        // }
        // if (rearRightWheelCollider.rpm > 200)
        // {
        //     rearRightWheelCollider.motorTorque = 0;
        // }
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
    }

}