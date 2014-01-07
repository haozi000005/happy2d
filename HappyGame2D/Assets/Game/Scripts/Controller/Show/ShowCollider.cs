using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		/*if(gameObject.activeSelf == true && collision.collider != null){
			GameObject other = collision.gameObject;
			ShowCollider myConllider = gameObject.GetComponent<ShowCollider>();
			ShowCollider otherConllider = other.GetComponent<ShowCollider>();
			if(otherConllider != null && myConllider != null){
				Transform father = transform.parent;
				if(father != null){
					ShowController myController = father.GetComponent<ShowController>();
					if(myController != null){
						if(myController.getStayObjects().Contains(other)){
							return;
						}
						myController.addStayObject(other);
						ShowController controller = father.GetComponent<ShowController>();
						controller.reloadShow(gameObject, other);
					}
				}
			}
		}*/

		if(gameObject.activeSelf == true && collision.collider != null){
			GameObject other = collision.gameObject;
			ShowCollider myConllider = gameObject.GetComponent<ShowCollider>();
			ShowCollider otherConllider = other.GetComponent<ShowCollider>();
			if(otherConllider != null && myConllider != null){
				ShowController myController = gameObject.GetComponent<ShowController>();
				ShowController otherController = other.GetComponent<ShowController>();
				if(myController != null && otherController != null){
					if(myController.getStayObjects().Contains(other)){
						return;
					}
					myController.addStayObject(other);

					myController.reloadShow(myController.area, otherController.area);
				}
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		/*if(gameObject.activeSelf == true && collision.collider != null){
			GameObject other = collision.gameObject;
			ShowCollider myConllider = gameObject.GetComponent<ShowCollider>();
			ShowCollider otherConllider = other.GetComponent<ShowCollider>();
			if(otherConllider != null && myConllider != null){
				Transform father = transform.parent;
				if(father != null){
					ShowController myController = father.GetComponent<ShowController>();
					if(myController != null){
						myController.removeStayObject(other);
					}
				}
			}
		}*/
		if(gameObject.activeSelf == true && collision.collider != null){
			GameObject other = collision.gameObject;
			ShowCollider myConllider = gameObject.GetComponent<ShowCollider>();
			ShowCollider otherConllider = other.GetComponent<ShowCollider>();
			if(otherConllider != null && myConllider != null){
				ShowController myController = gameObject.GetComponent<ShowController>();
				ShowController otherController = other.GetComponent<ShowController>();
				if(myController != null && otherController != null){
					if(myController != null){
						myController.removeStayObject(other);
					}
				}
			}
		}
	}
}
