using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(LoadMap))]
public class LoadMapEditor : Editor {

	private int numLimit = 20;
	void OnEnable() {
		
	}
	
	// Update is called once per frame
	public override void OnInspectorGUI() {
		LoadMap map = target as LoadMap;


		EditorGUILayout.LabelField("Map Editor", GUILayout.ExpandWidth(true));

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.BeginVertical();
		map.prefabStart = EditorGUILayout.Vector2Field("Start Editor", map.prefabStart);
		map.prefabRotation = EditorGUILayout.Vector3Field("Rotation Editor", map.prefabRotation);
		map.prefabNum = EditorGUILayout.IntSlider("Num Editor", map.prefabNum, 0, numLimit);
		map.prefabGround = (Ground)EditorGUILayout.EnumPopup("Ground Editor", map.prefabGround);
		EditorGUILayout.EndVertical();

		if(GUILayout.Button(new GUIContent("Add Map"),  GUILayout.ExpandWidth(true), GUILayout.Height(86))) {
			if(map.maps == null || map.maps.Count == 0) {
				map.AddMap(0, map.prefabStart, map.prefabNum, map.prefabGround, map.prefabRotation);
			}else{
				map.AddMap(map.maps.Count, map.prefabStart, map.prefabNum, map.prefabGround, map.prefabRotation);
			}
			
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		if(GUILayout.Button(new GUIContent("Reload Map（运行时有效）"),  GUILayout.ExpandWidth(true), GUILayout.Height(30)) && (EditorApplication.isPlaying || EditorApplication.isPaused)) {
			map.reloadMap();
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.Space();EditorGUILayout.Space();EditorGUILayout.Space();
		
		if(map.maps != null && map.maps.Count > 0){
			for(int nNode = 0; nNode < map.maps.Count; nNode++){
				map.maps[nNode].bFold = EditorGUILayout.Foldout(map.maps[nNode].bFold, "Start " + map.maps[nNode].start);
				if(map.maps[nNode].bFold){
					EditorGUILayout.BeginHorizontal();
					EditorGUILayout.BeginVertical();
					//loop.persistenceList[nNode].isShowNow = EditorGUILayout.Toggle("Is Show At Main Scene", loop.persistenceList[nNode].isShowNow, GUILayout.ExpandWidth(true));
					map.maps[nNode].start = EditorGUILayout.Vector2Field("Start", map.maps[nNode].start);
					map.maps[nNode].rotation = EditorGUILayout.Vector3Field("Rotation", map.maps[nNode].rotation);
					map.maps[nNode].num = EditorGUILayout.IntSlider("Num", map.maps[nNode].num, 0, numLimit);
					map.maps[nNode].groundKind = (Ground)EditorGUILayout.EnumPopup("Ground", map.maps[nNode].groundKind);

					EditorGUILayout.EndVertical();
					if(GUILayout.Button(new GUIContent("Del"),  GUILayout.ExpandWidth(true), GUILayout.Height(68))) { 
						map.RemoveMap(nNode);
					}
					EditorGUILayout.EndHorizontal();
				}
			}
		}
		
	}
}
