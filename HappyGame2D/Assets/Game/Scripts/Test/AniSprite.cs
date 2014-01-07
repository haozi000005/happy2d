using UnityEngine;
using System.Collections;

public class AniSprite : MonoBehaviour {

	public bool Awaked = false;
	public float timeLength = 0;
	public int columnSize;
	public int rowSize;
	public int colFrameStart;
	public int rowFrameStart;
	public int totalFrames;
	public int framePerSecond;
	public int totalTimes = 1;

	private float myTime = 0.0f;
	private float myTimeLength = 0.0f;

	private bool isPlay = true;
	private Vector2 size;
	private Vector2 offset;
	private int u;

	void Awake() {
		renderer.enabled = false;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Awaked){
			renderer.enabled = true;
			Awaked = doAniSprite(columnSize, rowSize, colFrameStart, rowFrameStart, totalFrames, framePerSecond, totalTimes, true);
		}

		myTimeLength += Time.deltaTime;
		if(timeLength != 0 && myTimeLength > timeLength){
			Destroy(gameObject);
		}
	}

	bool doAniSprite(int columnSize, int rowSize, int colFrameStart, int rowFrameStart, int totalFrames, int framePerSecond, int totalTimes, bool moveDirection) {
		myTime += Time.deltaTime;
		if(totalTimes != 0 && myTime > (totalTimes * (totalFrames * (1.0 / framePerSecond)))){
			isPlay = false;
			myTime = 0;
			renderer.enabled = false;
			return isPlay;
		}
		int index = (int)(myTime * (Mathf.Max(1, framePerSecond)));
		index = index % totalFrames;

		int v = index / columnSize;
		if(moveDirection){
			size = new Vector2(1.0f / columnSize, 1.0f / rowSize);
			u = index % columnSize;
		}else{
			size = new Vector2(-1.0f / columnSize, 1.0f / rowSize);
			u = -index % columnSize;
		}

		offset = new Vector2((u + colFrameStart) * size.x, (1.0f - size.y) - (v + rowFrameStart) * size.y);
		renderer.material.mainTextureOffset = offset;
		renderer.material.mainTextureScale = size;
		return true;
	}


	public void doAniSprite(int times) {
		if(times > 0){
			Awaked = true;
			totalTimes = times;
		}
	}
}
