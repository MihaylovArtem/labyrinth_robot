using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public const int maxSpeed = 10;
    public GameObject leftWheel;
    public GameObject rightWheel;
	public FloorScript floorScript;
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
	void FixedUpdate () {
		updateVelocityWithConnected (isConnected);
		leftWheelRigidBody.velocity = leftWheelSpeed * leftWheel.transform.up;
		rightWheelRigidBody.velocity = rightWheelSpeed * rightWheel.transform.up;
		Camera.main.transform.position = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, -20);
		
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

	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Finish") {
			Debug.Log ("FINISH!!!");
			floorScript.leftSpeed = 0;
			floorScript.rightSpeed = 0;
		} else {
			Debug.Log (floorScript);
			StartCoroutine (turnLeft ());
		}
	}


	public IEnumerator turnLeft() {
		floorScript.leftSpeed = -100;
		floorScript.rightSpeed = 0;
		yield return new WaitForSeconds (0.1f);
		floorScript.moveForward ();
	}
}