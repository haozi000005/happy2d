using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadMap : MonoBehaviour {
	public Vector2 prefabStart;
	public int prefabNum;
	public Ground prefabGround;
	public Vector3 prefabRotation;

	private static string PREFABBRICKDIR = "Prefabs/Ground";
	public List<GroundMap> maps;
	public void AddMap(int node, Vector2 start, int num, Ground groundKind, Vector3 rotation) {
		if(maps == null) maps = new List<GroundMap>();
		GroundMap map = new GroundMap();
		map.start = start;
		map.num = num;
		map.groundKind = groundKind;
		map.rotation = rotation;
		maps.Insert(node, map);
	}
	
	public void RemoveMap(int node) {
		if(maps == null) return;
		maps.RemoveAt(node);
	}

	// Use this for initialization
	void Start () {
		if(maps != null) {
			initMap();
		}
	}

	private void initMap() {
		foreach (GroundMap map in maps)  {
			Vector3 startV = new Vector3(map.start.x, map.start.y, 0);
			int num = map.num;
			Object prefab = findResource(map.groundKind);
			for(int i = 0; i < num; i ++){
				GameObject brick = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
				
				if(brick.collider2D != null && brick.collider2D as BoxCollider2D != null)
					brick.transform.position = new Vector3(startV.x + i * (brick.collider2D as BoxCollider2D).size.x, startV.y, startV.z);
				else
					brick.transform.position = new Vector3(startV.x + i, startV.y, startV.z);
				brick.transform.localEulerAngles = map.rotation;
				brick.transform.parent = gameObject.transform;
			}
		}
	}

	public void reloadMap() {
		if(maps != null) {
			foreach(Transform child in transform){
				child.gameObject.SetActive(false);
				DestroyObject(child.gameObject);
			}

			initMap();
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	Object findResource(Ground groundKind) {
		string name = PREFABBRICKDIR;
		if(groundKind == Ground.brick) {
			name += "/brick";
		}else if(groundKind == Ground.brickWithWood) {
			name += "/brickWithWood";
		}else if(groundKind == Ground.halfBrickWithWood){
			name += "/halfBrickWithWood";
		}else if(groundKind == Ground.towHalfBrickWithWood){
			name += "/2halfBrickWithWood";
		}


		return Resources.Load(name);
	}

	[System.Serializable]
	public class GroundMap{
		public Vector2 start;
		public int num;
		public Ground groundKind;
		public Vector3 rotation;
		public bool bFold;
	}
}


