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

    // Use this for initialization
    void Start() {
        leftWheelRigidBody = leftWheel.GetComponent<Rigidbody2D>();
        rightWheelRigidBody = rightWheel.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate ()
	{
		updateVelocityWithConnected (isConnected);
		leftWheelRigidBody.velocity = leftWheelSpeed*leftWheel.transform.up;
		rightWheelRigidBody.velocity = rightWheelSpeed*leftWheel.transform.up;
		Camera.main.transform.position = new Vector3 (gameObject.transform.position.x,
													  gameObject.transform.position.y,
													  -20);
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