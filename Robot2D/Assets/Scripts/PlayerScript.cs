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
    [Range(-100, 100)]
    public int BothPower;

	public float leftWheelSpeed;
	public float rightWheelSpeed;

    public bool isConnected;

	private Rigidbody2D leftWheelRigidBody;
    private Rigidbody2D rightWheelRigidBody;

	//private Vector3 beforeRotation = new Vector3 (0, 0, 0);
	public Vector3 afterRotation = new Vector3 (0, 0, 0);
	public bool isTurning;

    // Use this for initialization
    void Start() {
		//isTurning = true;
		afterRotation = new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 90);
	    leftWheelRigidBody = leftWheel.GetComponent<Rigidbody2D>();
        rightWheelRigidBody = rightWheel.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate () {
		//updateVelocityWithConnected (isConnected);
		leftWheelRigidBody.velocity = leftWheelSpeed * leftWheel.transform.up;
		rightWheelRigidBody.velocity = rightWheelSpeed * rightWheel.transform.up;

		//if (isTurning) {
		//	rotateLeft ();
		//}

	}

	public void rotateLeft() {
		if (transform.rotation.eulerAngles.z < afterRotation.z) {
			LeftPower = -50;
			RightPower = 50;
		} else {
			LeftPower = 0;
			RightPower = 0;
			isTurning = false;
			Quaternion rot = transform.rotation;
			rot.eulerAngles = new Vector3 (afterRotation.x, afterRotation.y, afterRotation.z);
			transform.rotation = rot;
		}
	}

	public void rotateRight ()
	{
		if (transform.rotation.eulerAngles.z > afterRotation.z) {
			LeftPower = 50;
			RightPower = -50;
		} else {
			LeftPower = 0;
			RightPower = 0;
			isTurning = false;
			Quaternion rot = transform.rotation;
			rot.eulerAngles = new Vector3 (afterRotation.x, afterRotation.y, afterRotation.z);
			transform.rotation = rot;
		}
	}

	public void rotateAround ()
	{
		if (transform.rotation.eulerAngles.z > afterRotation.z) {
			LeftPower = 50;
			RightPower = -50;
		} else {
			LeftPower = 0;
			RightPower = 0;
			isTurning = false;
			Quaternion rot = transform.rotation;
			rot.eulerAngles = new Vector3 (afterRotation.x, afterRotation.y, afterRotation.z);
			transform.rotation = rot;
		}
	}

	public void moveForward () {
		LeftPower = 100;
		RightPower = 100;
	}

	public void updateVelocityWithConnected (bool connected) {
		if (connected) {
			leftWheelSpeed = maxSpeed * BothPower / 100;
			rightWheelSpeed = maxSpeed * BothPower / 100;
		} else {
			leftWheelSpeed = maxSpeed * LeftPower / 100;
			rightWheelSpeed = maxSpeed * RightPower / 100;
		}
	}
}