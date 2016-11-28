using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public const int maxSpeed = 10;
    public GameObject leftWheel;
    public GameObject rightWheel;
    [Range(-100, 100)]
    public int LeftPower;
    [Range(-100, 100)]
    public int RightPower;

    private Rigidbody2D leftWheelRigidBody;
    private Rigidbody2D rightWheelRigidBody;
    private Rigidbody2D thisRigidBody;

    // Use this for initialization
    void Start() {
        leftWheelRigidBody = leftWheel.GetComponent<Rigidbody2D>();
        rightWheelRigidBody = rightWheel.GetComponent<Rigidbody2D>();
        thisRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        leftWheelRigidBody.velocity = leftWheel.transform.up * maxSpeed * LeftPower / 100;
        rightWheelRigidBody.velocity = rightWheel.transform.up * maxSpeed * RightPower / 100;
    }
}