using UnityEngine;
using System.Collections;

public class Rope : MonoBehaviour {

	public GameObject start;
	public GameObject end;
	private Click click;

	public float length;
	// Use this for initialization
	void Start () {
		click = (Click)start.GetComponent<Click>();
		if(click != null) {
			click.setRopeStart(true);
		}
		float detX = end.transform.position.x - start.transform.position.x;
		float detY = end.transform.position.y - start.transform.position.y;
		float angle = Mathf.Atan2(detY, detX);
		if(length != 0)
			transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);
		else
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * Mathf.Sqrt(detX * detX + detY * detY), transform.localScale.z);
		transform.localEulerAngles = new Vector3(0, 0, (angle / Mathf.PI) * 180 + 90);
		transform.position = start.transform.position;
		gameObject.renderer.sortingOrder -= 1;

		GameObject empty = (GameObject)Instantiate(Resources.Load("Prefabs/Other/empty"), new Vector3(0, 0, 0), Quaternion.identity);
		empty.transform.parent = start.transform;
		empty.GetComponent<HingeJoint2D>().connectedAnchor = new Vector3(start.transform.position.x, start.transform.position.y, start.transform.position.z);
		Rigidbody2D emptyRigidbody = empty.GetComponent<Rigidbody2D>();
		emptyRigidbody.mass = 2f;

		if(end.GetComponent<AreaInit>() != null){
			end = end.transform.parent.gameObject;
		}
		HingeJoint2D endJoint = end.AddComponent<HingeJoint2D>();
		/*if(endJoint == null) {
			endJoint = end.AddComponent<HingeJoint2D>();
		}*/
		endJoint.connectedBody = empty.GetComponent<Rigidbody2D>();
		endJoint.connectedAnchor = new Vector3(detX, detY, end.transform.position.z - start.transform.position.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(length != 0)
			transform.localScale = new Vector3(transform.localScale.x, length, transform.localScale.z);

		float detX = end.transform.position.x - start.transform.position.x;
		float detY = end.transform.position.y - start.transform.position.y;
		float angle = Mathf.Atan2(detY, detX);
		transform.localEulerAngles = new Vector3(0, 0, (angle / Mathf.PI) * 180 + 90);

		if(click != null && click.getDestroyNow()) {
			destroyStartAndRope();
		}
	}


	public void destroyStartAndRope() {
		click.doDestroy();
		DestroyObject(gameObject);
	}
}
