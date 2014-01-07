using UnityEngine;
using System.Collections;

public class GlobalInit : MonoBehaviour {

	private static bool hasInited = false;
	// Use this for initialization
	void Awake () {
		if(!hasInited){
			AreaWithFaceMG.getMG().init();
			ShowChangeMG.getMG().init();
			AreaStatusAndShapeMG.getMG().init();


			hasInited = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
