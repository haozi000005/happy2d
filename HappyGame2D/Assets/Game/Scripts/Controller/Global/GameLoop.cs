using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameLoop : MonoBehaviour {
	
	//private static string mainSceneName = "main scene";
	
	public List<PersistenceEntry> persistenceList;
	
	public void AddEntry(int node) {
		if(persistenceList == null) persistenceList = new List<PersistenceEntry>();
		persistenceList.Insert(node, new PersistenceEntry());
	}
	
	public void RemoveEntry(int node) {
		if(persistenceList == null) return;
		persistenceList.RemoveAt(node);
	}
	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
		if(persistenceList != null){
			for(int i = 0; i < persistenceList.Count; i ++){
				PersistenceEntry persistenceEntry = persistenceList[i];
				DontDestroyOnLoad(persistenceEntry.entry);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(persistenceList != null){
			for(int i = 0; i < persistenceList.Count; i ++){
				PersistenceEntry persistenceEntry = persistenceList[i];
				if(persistenceEntry != null){
					//if(mainSceneName.Equals(Application.loadedLevelName) && !persistenceEntry.isShowNow){
					string names = persistenceEntry.notShowSceneNames;
					if(names != null && names.IndexOf(Application.loadedLevelName) != -1){
						//persistenceEntry.entry.renderer.enabled = false;
						persistenceEntry.entry.SetActive(false);
					}else{
						//persistenceEntry.entry.renderer.enabled = true;
						persistenceEntry.entry.SetActive(true);
					}
				}
			}
		}
	}
	
	[System.Serializable]
	public class PersistenceEntry{
		//public bool isShowNow;
		public string notShowSceneNames;
		public GameObject entry;
	}
}
