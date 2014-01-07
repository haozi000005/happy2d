using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;

public class LoadXML : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private static string baseDir = "Xmls/";

	public static void loadXmlResource(string file, XmlDocument xml) {
		TextAsset rscAsset = Resources.Load(baseDir + file, typeof(TextAsset)) as TextAsset;
		if (rscAsset != null) {
			xml.Load(new MemoryStream(rscAsset.bytes));
			Debug.Log ("load " + file + " succ!");
			return;
		}
		Debug.LogError ("load " + file + " file!");
		Application.Quit();
	}
}
