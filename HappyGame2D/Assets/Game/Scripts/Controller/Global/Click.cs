using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

	public string sceneName;
	public TOUCH_EVENT touchEvent;
	public Animator breakAnimator;
	public string animatorControName;
	private bool isRopeStart = false;
	public bool getIsRopeStart() {
		return isRopeStart;
	}
	public void setRopeStart(bool isRopeStart) {
		this.isRopeStart = isRopeStart;
	}
	
	private bool destroyNow = false;
	public bool getDestroyNow() {
		return destroyNow;
	}



	public enum TOUCH_EVENT{
		DESTROY,
		JUMP,
		QUIT,
		RESTART,
		BREAK
	}

	// Use this for initialization
	void Start () {
		if(transform.rigidbody2D){
			breakAnimator.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		if(touchEvent == TOUCH_EVENT.DESTROY){
			if(!isRopeStart){
				DestroyObject(gameObject);
			}else{
				destroyNow = true;
			}
		}else if(touchEvent == TOUCH_EVENT.JUMP){
			if(gameObject.renderer != null && gameObject.renderer.enabled == true)
				Application.LoadLevel(sceneName);
		}else if(touchEvent == TOUCH_EVENT.QUIT){
			Application.Quit();
		}else if(touchEvent == TOUCH_EVENT.RESTART){
			if(gameObject.renderer != null && gameObject.renderer.enabled == true)
				Application.LoadLevel(Application.loadedLevelName);
		}else if(touchEvent == TOUCH_EVENT.BREAK){
			if(breakAnimator){
				breakAnimator.enabled = true;
				breakAnimator.SetBool(animatorControName, true);
			}else{
				if(!isRopeStart){
					DestroyObject(gameObject);
				}else{
					destroyNow = true;
				}
			}
		}
	}

	void OnClick() {
		if(touchEvent == TOUCH_EVENT.DESTROY){
			if(!isRopeStart){
				DestroyObject(gameObject);
			}else{
				destroyNow = true;
			}
		}else if(touchEvent == TOUCH_EVENT.JUMP){
			//if(gameObject.renderer != null && gameObject.renderer.enabled == true)
			Application.LoadLevel(sceneName);
		}else if(touchEvent == TOUCH_EVENT.QUIT){
			Application.Quit();
		}
	}

	public void doDestroy() {
		DestroyObject(gameObject);
	}

	public void animationDestroy() {
		if(!isRopeStart){
			doDestroy();
		}else{
			destroyNow = true;
		}
	}
}
