using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;
	public bool isLaunched = false;
	// Use this for initialization
	void Start () {
		ball = GetComponent <Ball>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DragStart(){
		if(!isLaunched) {
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}
	public void DragEnd(){
		if(!isLaunched) {
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragTime = endTime - startTime;
			Vector3 distance = dragEnd - dragStart;

			float launchSpeedX = distance.x / dragTime;
			float launchSpeedZ = distance.y / dragTime;

			ball.LaunchBall (new Vector3 (launchSpeedX, 0f, launchSpeedZ));
			isLaunched = true;
		}
	}public void MoveBallRight(){
		if(!isLaunched){
			if(transform.position.x + 5f <= 50f)transform.position += Vector3.right * 5f; 
		}

	}
	public void MoveBallLeft(){
		if(!isLaunched){
			if(transform.position.x + 5f >= -40f)transform.position += Vector3.left * 5f; 
		}

	}

}
