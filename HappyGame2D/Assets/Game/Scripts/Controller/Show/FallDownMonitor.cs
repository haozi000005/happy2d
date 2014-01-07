using UnityEngine;
using System.Collections;

public class FallDownMonitor : MonoBehaviour {
	public int scareYLine = -3;
	public int destroyYLine = -10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < scareYLine){
			ShowController controller = (ShowController)transform.parent.GetComponent<ShowController>();
			if(controller != null){
				if(AreaStatusAndShapeMG.findAreaStatus(gameObject) != AreaStatusAndShapeMG.EVIL){//不是邪恶
					controller.reloadFace("scareFace");
				}else{
					controller.reloadFace("evilScareFace");
				}
			}
		}

		if(transform.position.y < destroyYLine){
			if(transform.parent != null){
				DestroyObject(transform.parent.gameObject);
			}else{
				DestroyObject(gameObject);
			}
		}
	}
}
