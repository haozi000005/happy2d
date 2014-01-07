using UnityEngine;
using System.Collections;

public class AreaInit : MonoBehaviour {
	
	private GameObject father;
	public void setFather(GameObject father) {
		this.father = father;
	}

	public GameObject getFather() {
		return father;
	}

	private ShowController controller;
	private GameObject faceInstace;
	private string faceDir = "Prefabs/Faces/";
	// Use this for initialization
	void Start () {
		bool isReload = true;

		Collider2D collider = transform.GetComponent<Collider2D>();
		collider.enabled = false;
		if(father == null){
			isReload = false;
			father = new GameObject();
			father.name = gameObject.name + "Show";
			father.transform.parent = transform.parent;
			father.transform.position = transform.position;
			father.AddComponent<ShowCollider>();


			Rigidbody2D fatherRigidbody = father.AddComponent<Rigidbody2D>();
			fatherRigidbody.angularDrag = 0f;
			//fatherRigidbody.drag = 0.1f;

			fatherRigidbody.mass *= 3f;
			if(AreaStatusAndShapeMG.findAreaStatus(gameObject) == 3){
				fatherRigidbody.mass *= 2f;
			}

			Collider2D fatherCollider;
			if(collider.GetType() == typeof(BoxCollider2D)){
				fatherRigidbody.mass *= 2f;
				fatherCollider = father.AddComponent<BoxCollider2D>();
				((BoxCollider2D)fatherCollider).size = new Vector2(((BoxCollider2D)collider).size.x * transform.localScale.x, ((BoxCollider2D)collider).size.y * transform.localScale.y);
				((BoxCollider2D)fatherCollider).center = ((BoxCollider2D)collider).center;

			}else if(collider.GetType() == typeof(CircleCollider2D)){
				fatherCollider = father.AddComponent<CircleCollider2D>();

				((CircleCollider2D)fatherCollider).radius = ((CircleCollider2D)collider).radius * transform.localScale.x;
				((CircleCollider2D)fatherCollider).center = ((CircleCollider2D)collider).center;
			}else if(collider.GetType() == typeof(EdgeCollider2D)){
				fatherCollider = father.AddComponent<EdgeCollider2D>();
			}else if(collider.GetType() == typeof(PolygonCollider2D)){
				fatherCollider = father.AddComponent<PolygonCollider2D>();
			}

		}

		Destroy(collider);

		transform.parent = father.transform;
		gameObject.AddComponent<FallDownMonitor>();

		loadFace(gameObject, null);

		if(!isReload){
			controller = father.AddComponent<ShowController>();
		}else{
			controller = father.GetComponent<ShowController>();
		}
		controller.area = gameObject;
		controller.face = faceInstace;
	}

	//默认faceName可以填null
	public GameObject loadFace(GameObject area, string faceName) {
		AreaWithFaceMG.AreaWithFace areaWithFace = AreaWithFaceMG.findAreaFace(area, faceName);
		GameObject toFace = (GameObject)Resources.Load(faceDir + areaWithFace.faceName);
		
		faceInstace = (GameObject)Instantiate(toFace, transform.position, Quaternion.identity);
		faceInstace.name = toFace.name;
		faceInstace.transform.parent = father.transform;
		faceInstace.transform.localScale = new Vector3(areaWithFace.faceScaleX, areaWithFace.faceScaleY, 1f);
		faceInstace.renderer.sortingOrder = gameObject.renderer.sortingOrder + 1;

		return faceInstace;
	}
}
