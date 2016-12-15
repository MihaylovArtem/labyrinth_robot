using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour {

    public Toggle checkBox;
    public PlayerScript player;

	public Slider leftSlider;
	public Slider rightSlider;
	public Slider bothSlider;

    public GameObject forwardBothButton;
	public GameObject forwardLeftButton;
	public GameObject forwardRightButton;

    public GameObject backBothButton;
	public GameObject backLeftButton;
	public GameObject backRightButton;


	private bool pressedForwardBoth = false;
	private bool pressedForwardLeft = false;
	private bool pressedForwardRight = false;

    private bool pressedBackBoth = false;
	private bool pressedBackLeft = false;
	private bool pressedBackRight = false;


	// Use this for initialization
	void Start () {
        var entryBothF = new EventTrigger.Entry();
        entryBothF.eventID = EventTriggerType.PointerDown;
        entryBothF.callback.AddListener((data) => { OnClickForwardBoth((PointerEventData)data); });
        forwardBothButton.GetComponent<EventTrigger>().triggers.Add(entryBothF);

		var entryLeftF = new EventTrigger.Entry ();
		entryLeftF.eventID = EventTriggerType.PointerDown;
		entryLeftF.callback.AddListener ((data) => { OnClickForwardLeft ((PointerEventData)data); });
		forwardLeftButton.GetComponent<EventTrigger> ().triggers.Add (entryLeftF);

		var entryRightF = new EventTrigger.Entry ();
		entryRightF.eventID = EventTriggerType.PointerDown;
		entryRightF.callback.AddListener ((data) => { OnClickForwardRight ((PointerEventData)data); });
		forwardRightButton.GetComponent<EventTrigger> ().triggers.Add (entryRightF);

        var entryBothB = new EventTrigger.Entry();
        entryBothB.eventID = EventTriggerType.PointerDown;
        entryBothB.callback.AddListener((data) => { OnClickBackBoth((PointerEventData)data); });
        backBothButton.GetComponent<EventTrigger>().triggers.Add(entryBothB);

		var entryLeftB = new EventTrigger.Entry ();
		entryLeftB.eventID = EventTriggerType.PointerDown;
		entryLeftB.callback.AddListener ((data) => { OnClickBackLeft ((PointerEventData)data); });
		backLeftButton.GetComponent<EventTrigger> ().triggers.Add (entryLeftB);

		var entryRightB = new EventTrigger.Entry ();
		entryRightB.eventID = EventTriggerType.PointerDown;
		entryRightB.callback.AddListener ((data) => { OnClickBackRight ((PointerEventData)data); });
		backRightButton.GetComponent<EventTrigger> ().triggers.Add (entryRightB);

	}

    public void OnClickForwardBoth(PointerEventData data) {
        pressedForwardBoth = true;
    }

	public void OnClickForwardLeft (PointerEventData data) {
		pressedForwardLeft = true;
	}

	public void OnClickForwardRight (PointerEventData data) {
		pressedForwardRight = true;
	}

    public void OnClickBackBoth(PointerEventData data) {
        pressedBackBoth = true;
    }

	public void OnClickBackLeft (PointerEventData data) {
		pressedBackLeft = true;
	}

	public void OnClickBackRight (PointerEventData data) {
		pressedBackRight = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		ConfigureUI ();

        if (Input.GetMouseButtonUp(0)) {
			pressedForwardBoth = false;
			pressedForwardLeft = false;
			pressedForwardRight = false;
			pressedBackBoth = false;
			pressedBackLeft = false;
			pressedBackRight = false;
        }

        if (pressedForwardBoth) {
            player.isConnected = checkBox.isOn;
            player.BothPower = (int)bothSlider.value;
        } else
		if (pressedForwardLeft) {
			player.isConnected = checkBox.isOn;
            player.LeftPower = (int)leftSlider.value;
        } else 
		if (pressedForwardRight) {
			player.isConnected = checkBox.isOn;
			player.RightPower = (int)rightSlider.value;
		} else 
        if (pressedBackBoth) {
            player.isConnected = checkBox.isOn;
            player.BothPower = -(int)bothSlider.value;
        } else
		if (pressedBackLeft) {
			player.isConnected = checkBox.isOn;
            player.LeftPower = -(int)leftSlider.value;
        } else 
		if (pressedBackRight) {
			player.isConnected = checkBox.isOn;
			player.RightPower = -(int)rightSlider.value;
		} else {
			player.LeftPower = 0;
			player.RightPower = 0;
			player.BothPower = 0;
		}
      
	}

	void ConfigureUI() {
		if (!checkBox.isOn) {
			bothSlider.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			leftSlider.gameObject.transform.localScale = new Vector3 (1, 1, 1);
			rightSlider.gameObject.transform.localScale = new Vector3 (1, 1, 1);

			backBothButton.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			backLeftButton.gameObject.transform.localScale = new Vector3 (1, 1, 1);
			backRightButton.gameObject.transform.localScale = new Vector3 (1, 1, 1);

			forwardBothButton.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			forwardLeftButton.gameObject.transform.localScale = new Vector3 (1, 1, 1);
			forwardRightButton.gameObject.transform.localScale = new Vector3 (1, 1, 1);
		} else {
			bothSlider.gameObject.transform.localScale = new Vector3 (1, 1, 1);
			leftSlider.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			rightSlider.gameObject.transform.localScale = new Vector3 (0, 0, 0);

			backBothButton.gameObject.transform.localScale = new Vector3 (1, 1, 1);
			backLeftButton.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			backRightButton.gameObject.transform.localScale = new Vector3 (0, 0, 0);

			forwardBothButton.gameObject.transform.localScale = new Vector3 (1, 1, 1);
			forwardLeftButton.gameObject.transform.localScale = new Vector3 (0, 0, 0);
			forwardRightButton.gameObject.transform.localScale = new Vector3 (0, 0, 0);
		}
	}
}
