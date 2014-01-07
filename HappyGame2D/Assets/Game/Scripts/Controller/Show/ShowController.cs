using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShowController : MonoBehaviour {

	public GameObject area;
	public GameObject face;

	private List<GameObject> stayObjects = new List<GameObject>();
	public List<GameObject> getStayObjects() {
		return stayObjects;
	}


	public void addStayObject(GameObject other) {
		if(stayObjects.Contains(other)){
			return;
		}
		stayObjects.Add(other);
	}

	public void removeStayObject(GameObject other) {
		if(stayObjects.Contains(other)){
			stayObjects.Remove(other);
		}
	}

	private string areaDir = "Prefabs/Areas/";
	//private string faceDir = "Prefabs/Faces/";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//face.transform.position = area.transform.position;
		area.transform.LookAt(transform);
		face.transform.LookAt(transform.position);
		face.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -transform.localEulerAngles.z);
	}

	private void reloadPriShow(GameObject newArea) {
		face.SetActive(false);
		DestroyObject(face);

		area.SetActive(false);
		DestroyObject(area);

		GameObject tmpArea = (GameObject)Instantiate(newArea, area.transform.position, Quaternion.identity);
		AreaInit init = tmpArea.GetComponent<AreaInit>();
		AreaInit oldInit = area.GetComponent<AreaInit>();
		init.setFather(oldInit.getFather());
		tmpArea.name = newArea.name;
	}

	public void reloadFace(string newFaceName) {
		face.SetActive(false);
		DestroyObject(face);

		AreaInit init = area.GetComponent<AreaInit>();
		GameObject newFace = init.loadFace(area, newFaceName);
		face = newFace;
	}

	public void reloadShow(GameObject nowArea, GameObject nowOtherArea) {
		if(nowArea.name.Equals(nowOtherArea.name)){
			return;
		}
		string toAreaName = ShowChangeMG.findToAreaName(nowArea, nowOtherArea);
		if(toAreaName == null) return;
		GameObject toArea = (GameObject)Resources.Load(areaDir + toAreaName);
		reloadPriShow(toArea);
	}
}
