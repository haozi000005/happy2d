using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class AreaWithFaceMG : MonoBehaviour {
	XmlDocument xml = new XmlDocument();

	private static Dictionary<string, List<AreaWithFace>> areaWithFaceRes = new Dictionary<string, List<AreaWithFace>>();

	private AreaWithFaceMG (){}
	private static AreaWithFaceMG instance = new AreaWithFaceMG();
	public static AreaWithFaceMG getMG() {
		return instance;
	}

	// Use this for initialization
	public void init () {
		LoadXML.loadXmlResource("ResourceAreaWithFace", xml);
		foreach(XmlElement element in xml.DocumentElement.ChildNodes){
			string areaName = element.GetAttribute("areaName");
			string faceName = element.GetAttribute("faceName");
			float faceScaleX = float.Parse(element.GetAttribute("faceScaleX"));
			float faceScaleY = float.Parse(element.GetAttribute("faceScaleY"));
			AreaWithFace entry = new AreaWithFace(areaName, faceName, faceScaleX, faceScaleY);

			List<AreaWithFace> areaNameList;
			if(!areaWithFaceRes.ContainsKey(areaName)){
				areaNameList = new List<AreaWithFace>();
				areaNameList.Insert(0, entry);
			}else{
				areaNameList = areaWithFaceRes[areaName];
				areaNameList.Insert(areaNameList.Count, entry);
				areaWithFaceRes.Remove(areaName);
			}
			areaWithFaceRes.Add(areaName, areaNameList);
		}
	}

	public static AreaWithFace findAreaFace(GameObject area, string faceName) {
		List<AreaWithFace> areaNameList = areaWithFaceRes[area.name];
		AreaWithFace areaWithFace = null;
		if(null == faceName){
			//areaWithFace = areaNameList[0];
			foreach(AreaWithFace entry in areaNameList){
				areaWithFace = entry;
				break;
			}
		}else{
			foreach(AreaWithFace entry in areaNameList){
				if(faceName.Equals(entry.faceName)){
					areaWithFace = entry;
					break;
				}
			}
		}
		return areaWithFace;
	}

	public class AreaWithFace {
		public string areaName;
		public string faceName;
		public float faceScaleX;
		public float faceScaleY;
		public AreaWithFace(string areaName, string faceName, float faceScaleX, float faceScaleY){
			this.areaName = areaName;
			this.faceName = faceName;
			this.faceScaleX = faceScaleX;
			this.faceScaleY = faceScaleY;
		}
	}
}
