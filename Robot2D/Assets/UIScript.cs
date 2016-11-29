using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour {

    public Slider leftSlider;
    public Slider rightSlider;
    public Toggle checkBox;
    public GameObject forwardButton;
    public GameObject backButton;

    public PlayerScript player;

    public bool pressedForward;
    public bool pressedBack;


	// Use this for initialization
	void Start () {
        pressedForward = false;
        pressedBack = false;
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnClickForward((PointerEventData)data); });
        forwardButton.GetComponent<EventTrigger>().triggers.Add(entry);

        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerDown;
        entry2.callback.AddListener((data) => { OnClickBack((PointerEventData)data); });
        backButton.GetComponent<EventTrigger>().triggers.Add(entry2);

	}

    public void OnClickForward(PointerEventData data) {
        pressedForward = true;
        pressedBack = false;
        Debug.Log("forward");
    }

    public void OnClickBack(PointerEventData data) {
        pressedBack = true;
        pressedForward = false;
        Debug.Log("back");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0)) {
            pressedForward = false;
            pressedBack = false;
            Debug.Log("false");
        }

        if (pressedForward) {
            player.isConnected = checkBox.isOn;
            if (checkBox.isOn) {
                player.BothPower = (int)leftSlider.value;
            }
            else {
                player.LeftPower = (int)leftSlider.value;
                player.RightPower = (int)rightSlider.value;
            }
        }
        if (pressedBack) {
            player.isConnected = checkBox.isOn;
            if (checkBox.isOn) {
                player.BothPower = -(int)leftSlider.value;
            }
            else {
                player.LeftPower = -(int)leftSlider.value;
                player.RightPower = -(int)rightSlider.value;
            }
        }
        if (!pressedForward && !pressedBack) {
            player.LeftPower = 0;
            player.RightPower = 0;
            player.isConnected = false;
        }
      
	}
}
