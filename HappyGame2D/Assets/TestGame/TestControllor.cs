using UnityEngine;
using System.Collections;

public class TestControllor : MonoBehaviour {

	public GameObject skill;
	private Animator anim;
	private bool state;
	public string name;
	public Rect rect;
	public string clickName;
	// Use this for initialization
	void Start () {
		anim = skill.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//anim.SetFloat("play", state);
		if(state){
			anim.SetBool(name, state);
			state = !state;
		}else{
			anim.SetBool(name, state);
		}
	}

	void OnGUI() {
		if(GUI.Button(rect, clickName)){
			state = !state;
		}
	}
}
