using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AreaStatusAndShapeMG : MonoBehaviour {


	XmlDocument xml = new XmlDocument();
	
	private static Dictionary<string, int> AreastatusRes = new Dictionary<string, int>();
	private static Dictionary<string, int> AreaShapeRes = new Dictionary<string, int>();

	public static int HAPPY = 1;
	public static int SAD = 2;
	public static int EVIL = 3;

	public static int ROUND = 1;
	public static int SQUARE = 2;
	
	private AreaStatusAndShapeMG (){}
	private static AreaStatusAndShapeMG instance = new AreaStatusAndShapeMG();
	public static AreaStatusAndShapeMG getMG() {
		return instance;
	}

	// Use this for initialization
	public void init () {
		LoadXML.loadXmlResource("ResourceAreaStatusAndShape", xml);
		foreach(XmlElement element in xml.DocumentElement.ChildNodes){
			string areaName = element.GetAttribute("areaName");
			int status = int.Parse(element.GetAttribute("status"));
			int shape = int.Parse(element.GetAttribute("shape"));

			AreastatusRes.Add(areaName, status);
			AreaShapeRes.Add(areaName, shape);
		}
	}


	//-1表示参数错误，-2表示没有找到指定形状，1高兴，2悲伤，3邪恶
	public static int findAreaStatus(GameObject area) {
		if(area == null) return -1;
		string areaName = area.name;
		if(AreastatusRes.ContainsKey(areaName)){
			return AreastatusRes[areaName];
		}
		return -2;
	}


	//-1表示参数错误，-2表示没有找到指定形状，1圆形，2方形
	public static int findAreaShape(GameObject area) {
		if(area == null) return -1;
		string areaName = area.name;
		if(AreaShapeRes.ContainsKey(areaName)){
			return AreaShapeRes[areaName];
		}
		return -2;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
