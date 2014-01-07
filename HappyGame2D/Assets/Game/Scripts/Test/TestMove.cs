using UnityEngine;
using System.Collections;
public enum Dir:int{Left = 0,Stop,Right}
public class TestMove : MonoBehaviour {
	// 挂一个用来显示图片的plane对象
	public GameObject plane;
	// 每0.5秒换一张图片
	public float duration = 0.5f; 
	// 挂30张图片
	public Texture2D[] texAll; 
	// 当前的手势
	Dir _touchDir;   

	float curTime = 0;
	int index = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android){//平台为IOS或者android时
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){//输入触点大于0且移动时
				if(Input.GetTouch(0).deltaPosition.x < 0 - Mathf.Epsilon)_touchDir = Dir.Left;else _touchDir = Dir.Right;
			}
			// 当输入的触点数量大于0，且手指不动时
			if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary){
				_touchDir = Dir.Stop;
			}
		}
		
		// 根据手势顺序或逆序换图
		if(_touchDir != Dir.Stop){
			if(_touchDir == Dir.Left){
				curTime += Time.deltaTime;
				if(curTime > duration){
					curTime = 0;
					index = index == 0 ? texAll.Length - 1 : index ;
					plane.renderer.material.mainTexture = texAll[index--];
				}
			}else{
				curTime += Time.deltaTime;
				if(curTime > duration){
					curTime = 0;
					index = index == texAll.Length - 1 ? 0 : index ;
					plane.renderer.material.mainTexture = texAll[index++];
				}
			}
		}
	}
}
