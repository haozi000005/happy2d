using UnityEngine;
using System.Collections;

public class AndroidMonitor : MonoBehaviour {

	public string exitSceneName = "main scene, init scene";
	public string mainSceneName = "main scene";
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android &&(Input.GetKeyDown(KeyCode.Escape))) {
			if(exitSceneName != null){
				if(exitSceneName.IndexOf(Application.loadedLevelName) == -1){
					Application.LoadLevel(mainSceneName);
				}else{
					Application.Quit();
				}
			}
		}
	}
}
