using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class ShowChangeMG : MonoBehaviour {
	XmlDocument xml = new XmlDocument();

	private static Dictionary<string, List<Dictionary<string, string>>> changeRes = new Dictionary<string, List<Dictionary<string, string>>>();

	private ShowChangeMG (){}
	private static ShowChangeMG instance = new ShowChangeMG();
	public static ShowChangeMG getMG() {
		return instance;
	}

	// Use this for initialization
	public void init () {
		LoadXML.loadXmlResource("ResourceShowChange", xml);
		foreach(XmlElement element in xml.DocumentElement.ChildNodes){
			string srcName = element.GetAttribute("srcName");
			string dstName = element.GetAttribute("dstName");
			string srcToName = element.GetAttribute("srcToName");
			Dictionary<string, string> entry = new Dictionary<string, string>();
			entry.Add(dstName, srcToName);

			List<Dictionary<string, string>> srcNameList;
			if(!changeRes.ContainsKey(srcName)){
				srcNameList = new List<Dictionary<string, string>>();
				srcNameList.Insert(0, entry);
			}else{
				srcNameList = changeRes[srcName];
				srcNameList.Insert(srcNameList.Count, entry);
				changeRes.Remove(srcName);
			}
			changeRes.Add(srcName, srcNameList);
		}
	}

	public static string findToAreaName(GameObject src, GameObject dst) {
		if(changeRes.ContainsKey(src.name)){
			List<Dictionary<string, string>> srcNameList = changeRes[src.name];
			foreach(Dictionary<string, string> entry in srcNameList){
				if(entry.ContainsKey(dst.name)){
					return entry[dst.name];
				}
			}
		}
		return null;
	}
}
