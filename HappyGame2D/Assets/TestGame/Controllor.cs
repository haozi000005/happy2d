using UnityEngine;
using System.Collections;

public class Controllor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		if(GUI.Button(new Rect(10,10,100,50), "测试")){
			AniSprite aniSprite = gameObject.GetComponent<AniSprite>();
			aniSprite.doAniSprite(1);
		}
	}
}
