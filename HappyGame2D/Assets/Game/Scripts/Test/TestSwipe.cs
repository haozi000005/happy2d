using UnityEngine;
using System.Collections;

public class TestSwipe : MonoBehaviour {
	public GameObject groupObj;
	float touchDeltaPositionX;
	float touchDeltaPositionY;
	float maxX = 0f;
	float maxY = 0f;
	float targetX = 0f;
	float targetY = 0f;
	float newPositionX;
	float newPositionY;
	float xVelocity = 0f;
	float yVelocity = 0f;
	float smoothTime = 0.3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			print ("hello");
		}
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			touchDeltaPositionX = Input.GetTouch(0).deltaPosition.x;
			touchDeltaPositionY = Input.GetTouch(0).deltaPosition.y;
			maxX = Mathf.Max(maxX, Mathf.Abs(touchDeltaPositionX));
			maxY = Mathf.Max(maxY, Mathf.Abs(touchDeltaPositionY));
			if(touchDeltaPositionX < 0){
				maxX = -maxX;
			}
			if(touchDeltaPositionY < 0){
				maxY = -maxY;
			}
			groupObj.transform.Translate(maxX * Time.deltaTime * 10, maxY * Time.deltaTime * 10, 0);
		}else{
			if(groupObj.transform.position.y >= -170 && groupObj.transform.position.y <= 670f && groupObj.transform.position.x >= -680 && groupObj.transform.position.x <= 500){
				if(!Mathf.Approximately(maxX, 0f) || !Mathf.Approximately(maxY, 0f)){
					maxX = Mathf.MoveTowards(maxX, 0f, 0.6f);
					maxY = Mathf.MoveTowards(maxY, 0f, 0.6f);
				}
				groupObj.transform.Translate(maxX * Time.deltaTime * 10, maxY * Time.deltaTime * 10, 0);
			}else{
				maxY=0;
				maxX=0;
				targetX=groupObj.transform.position.x;
				targetY=groupObj.transform.position.y;
				if(groupObj.transform.position.x > 500)
					targetX = 500;
				if(groupObj.transform.position.x < -680)
					targetX = -680;						
				if(groupObj.transform.position.y > 670)
					targetY = 670;
				if(groupObj.transform.position.y < -170)
					targetY = -170;	
				newPositionX = Mathf.SmoothDamp(groupObj.transform.position.x, targetX, ref xVelocity, smoothTime);
				newPositionY = Mathf.SmoothDamp(groupObj.transform.position.y, targetY, ref yVelocity, smoothTime);
				groupObj.transform.position = new Vector3(newPositionX,newPositionY,groupObj.transform.position.z);
			}
		}
	}
}
