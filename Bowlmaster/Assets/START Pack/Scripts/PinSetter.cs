using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PinSetter : MonoBehaviour {

	public Text PinNumberText;
	private Pin[] pin;
	private bool isBallEntered = false;
	private int lastStandingCount = -1;
	private float lastChanceTime;
	private Ball ball;
	// Use this for initialization
	void Start () {
		pin = GameObject.FindObjectsOfType <Pin> ();
		ball = GameObject.FindObjectOfType <Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isBallEntered) {
			PinNumberText.text = CheckPinNumber ().ToString ();
			CheckStanding ();
		}
	}
	void CheckStanding(){
		int CurrentStanding = CheckPinNumber ();
		if(CurrentStanding != lastStandingCount){
			lastChanceTime = Time.time;
			lastStandingCount = CurrentStanding;
			return;
		}
		float settleTime = 3f;
		if ((Time.time - lastChanceTime) > settleTime) {
			PinsHaveSettled ();
		}

	}
	void PinsHaveSettled(){
		ball.Reset ();
		lastStandingCount = -1;
		PinNumberText.color = Color.green;
		isBallEntered = false;
	}

	int CheckPinNumber(){
		int Number = 0;
		foreach(Pin script in pin){
			if(script) {
				if (script.isStanding ())
					Number++;
			}
		}
		return Number;	
	}


	void OnTriggerEnter(Collider col){
		if (col.tag == "Ball") {
			isBallEntered = true;
			PinNumberText.color = Color.red;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.tag == "Pin") {
			Destroy (col.gameObject.transform.parent.gameObject);
			pin = GameObject.FindObjectsOfType <Pin> ();
		}
	}
}
