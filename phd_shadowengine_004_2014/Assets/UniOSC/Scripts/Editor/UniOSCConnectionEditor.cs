/*
* UniOSC
* Copyright © 2014 Stefan Schlupek
* All rights reserved
* info@monoflow.org
*/
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Net;
using System;

namespace UniOSC{

	[CustomEditor (typeof(UniOSCConnection))]
	[CanEditMultipleObjects]
	public class UniOSCConnectionEditor :  Editor {

		private UniOSCConnection _target;
		private Texture2D tex_logo;
		//private SerializedObject obj;

		SerializedProperty AutoConnectOSCInProp ;
		SerializedProperty OSCPortProp ;
		SerializedProperty OSCMappingFileObjListProp ;
		SerializedProperty OSCSessionFileObjListProp ;
		SerializedProperty AutoConnectOSCOutProp ;
		SerializedProperty OSCOutPortProp;
		SerializedProperty OSCOutIPAddressProp; 
		SerializedProperty FoldoutOSCOutProp; 
		SerializedProperty FoldoutOSCInProp; 


		public static Texture2D texTestMessage;
		public static Texture2D texON;
		public static Texture2D texOFF;

		void OnEnable () {

			if(target  !=_target) _target = target as UniOSCConnection;

			serializedObject.Update();
			tex_logo = Resources.Load(UniOSCUtils.LOGO16_NAME,typeof(Texture2D)) as Texture2D;
			LoadTextures();
		
			AutoConnectOSCInProp = serializedObject.FindProperty ("autoConnectOSCIn");
			AutoConnectOSCOutProp = serializedObject.FindProperty ("autoConnectOSCOut");
			OSCPortProp = serializedObject.FindProperty ("oscPort");
			OSCMappingFileObjListProp = serializedObject.FindProperty("oscMappingFileObjList");
			OSCSessionFileObjListProp = serializedObject.FindProperty("oscSessionFileObjList");
			OSCOutPortProp = serializedObject.FindProperty("oscOutPort");
			OSCOutIPAddressProp = serializedObject.FindProperty("oscOutIPAddress");
			FoldoutOSCOutProp = serializedObject.FindProperty("foldoutOSCOut");
			FoldoutOSCInProp = serializedObject.FindProperty("foldoutOSCIn");

			serializedObject.ApplyModifiedProperties();
		}
		public static void LoadTextures(){
			if(texTestMessage == null) texTestMessage = Resources.Load(UniOSCUtils.OSCOUTTEST_NAME,typeof(Texture2D)) as Texture2D;
			if(texON == null) texON = Resources.Load(UniOSCUtils.OSCCONNECTION_ON_NAME,typeof(Texture2D)) as Texture2D;
			if(texOFF == null) texOFF = Resources.Load(UniOSCUtils.OSCCONNECTION_OFF_NAME,typeof(Texture2D)) as Texture2D;
		}
	
		public static void Show (string label,SerializedProperty list) {

			if(String.IsNullOrEmpty(label)){
				EditorGUILayout.PropertyField(list);
			}else{
				list.isExpanded = EditorGUILayout.Foldout(list.isExpanded,label);
			}

			EditorGUI.indentLevel += 1;
			if (list.isExpanded) {
				EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
				for (int i = 0; i < list.arraySize; i++) {
					EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
				}
			}
			EditorGUI.indentLevel -= 1;
		}


		override public void OnInspectorGUI(){
			GUILayout.Space(5);
			if(tex_logo != null){
				UniOSCUtils.DrawClickableTextureHorizontal(tex_logo,()=>{EditorApplication.ExecuteMenuItem(UniOSCUtils.MENUITEM_EDITOR);});
			}

			serializedObject.Update();

			EditorGUI.BeginChangeCheck();

			FoldoutOSCInProp.boolValue = EditorGUILayout.Foldout(FoldoutOSCInProp.boolValue,"OSC IN");
			if(FoldoutOSCInProp.boolValue){
				GUILayout.BeginVertical("box");
				EditorGUILayout.PropertyField(AutoConnectOSCInProp,new GUIContent("Auto connect on start","") );
				EditorGUILayout.PropertyField(OSCPortProp,new GUIContent("Port:"));
				OSCPortProp.intValue = Mathf.Min(UniOSCUtils.MAXPORT,OSCPortProp.intValue);
				GUILayout.EndVertical();
			}


			FoldoutOSCOutProp.boolValue = EditorGUILayout.Foldout(FoldoutOSCOutProp.boolValue,"OSC OUT");
			if(FoldoutOSCOutProp.boolValue){
				GUILayout.BeginVertical("box");
				EditorGUILayout.PropertyField(AutoConnectOSCOutProp,new GUIContent("Auto connect on start","") );
				EditorGUILayout.PropertyField(OSCOutPortProp,new GUIContent("Port","") );
				OSCOutPortProp.intValue = Mathf.Min(UniOSCUtils.MAXPORT,OSCOutPortProp.intValue);
				EditorGUILayout.PropertyField(OSCOutIPAddressProp,new GUIContent("Target IPAddress","") );
				GUILayout.EndVertical();
			}

			GUILayout.Space(10);

			if(EditorGUI.EndChangeCheck()) {
				serializedObject.ApplyModifiedProperties();
				UniOSCConnection.Update_AvailablePorts();
			}
			ShowOSCReciverStatus(_target);
			Show("Mapping Files",OSCMappingFileObjListProp);
			Show("Session Files",OSCSessionFileObjListProp);

			if(_target.hasOSCSessionFileAttached){
				//EditorGUILayout.PropertyField(AutoConnectOSCInProp,new GUIContent("Auto connect on start","") );
				if(GUILayout.Button(new GUIContent("Send Session Data","Send the last OSC data that are recorded with your session files."),GUILayout.Width(150f)) ){
					_target.SendSessionData();
				}
				if(!_target.isConnectedOut){
					EditorGUILayout.HelpBox("To send the session data you have to turn on OSC OUT!",MessageType.Warning);
					//EditorGUI.HelpBox(area,"OSC IN: "+UniOSCConnection.localIPAddress+"\nPort: "+oscConnection.oscPort+"\nListening", MessageType.Info);
				}
			}

			serializedObject.ApplyModifiedProperties();

			if (GUI.changed) {
				EditorUtility.SetDirty (_target);
			}

		}

		protected void ForceUpdate(){

		}

		private static void _DropArea (Event evt, Rect area,UniOSCConnection oscConnection)
			{
				switch (evt.type) {

				case EventType.MouseDown :
					if (area.Contains(evt.mousePosition)) {
						EditorGUIUtility.PingObject(oscConnection);
						Selection.activeObject = oscConnection;
					}
					break;

				case EventType.DragUpdated:
				case EventType.DragPerform:
					if (!area.Contains (evt.mousePosition))return;
					
					DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
					
					if (evt.type == EventType.DragPerform) {
						DragAndDrop.AcceptDrag ();
						foreach (UnityEngine.Object dragged_object in DragAndDrop.objectReferences) {
							
							if(dragged_object.GetType() == typeof(UniOSCMappingFileObj) ){

								if(!oscConnection.oscMappingFileObjList.Contains((UniOSCMappingFileObj)dragged_object) ){
									oscConnection.oscMappingFileObjList.Add((UniOSCMappingFileObj)dragged_object);
								}
							}

							if(dragged_object.GetType() == typeof(UniOSCSessionFileObj) ){
								
								if(!oscConnection.oscSessionFileObjList.Contains((UniOSCSessionFileObj)dragged_object) ){
									oscConnection.oscSessionFileObjList.Add((UniOSCSessionFileObj)dragged_object);
								}
							}


						}//foreach
					}//DragPerform
					break;
				}//switch
			}


		public static void ShowOSCReciverStatus(UniOSCConnection oscConnection){

			EditorGUI.BeginChangeCheck();

			EditorGUILayout.BeginHorizontal();
			
			Event evt = Event.current;

			GUIStyle style = new GUIStyle(GUI.skin.button);
			style.padding = new RectOffset(0,0,0,0);
			style.border = new RectOffset(0,0,0,0);

			#region IN

			EditorGUILayout.BeginVertical(GUILayout.MaxWidth(200));

			Rect area = GUILayoutUtility.GetRect (195.0f, 40.0f);
			area.width*=1f;
			Rect r1 = GUILayoutUtility.GetRect (195.0f, 20.0f);
			r1.width*=1f;


			int btnsize1 = 20;
			Rect r1b = new Rect(area);
			r1b.x+= r1b.width-(btnsize1*1);
			r1b.y+= r1b.height-btnsize1;
			r1b.width = btnsize1*1;
			r1b.height= btnsize1;


			if(oscConnection.isConnected){
				GUI.contentColor = Color.white;
				//GUI.backgroundColor =  UniOSCUtils.CONNECTION_BG;
				//GUI.Box(area,"");//to dimm the background
				GUI.backgroundColor = oscConnection.dispatchOSC ? UniOSCUtils.CONNECTION_ON_COLOR : UniOSCUtils.CONNECTION_PAUSE_COLOR;
				EditorGUI.HelpBox(area,"OSC IN: "+UniOSCConnection.localIPAddress+"\nPort: "+oscConnection.oscPort+"\nListening", MessageType.Info);
				if (GUI.Button (r1,"Disconnect")){oscConnection.DisconnectOSC();}

				GUI.backgroundColor = Color.white;
				GUI.contentColor = Color.white;
				//if (GUI.Button (r1b,new GUIContent(tex2,""),style ) ){oscConnection.SendTestMessage();}
				Texture2D currTex = oscConnection.dispatchOSC ?  texON : texOFF ;
				oscConnection.dispatchOSC = GUI.Toggle(r1b,oscConnection.dispatchOSC,new GUIContent(currTex,"Turn the OSC dispatching into Unity on/off"),style );

			}else{
				GUI.contentColor = Color.white;
				GUI.backgroundColor = UniOSCUtils.CONNECTION_BG;
				//GUI.Box(area,"");//GUI.skin.box
				GUI.backgroundColor = UniOSCUtils.CONNECTION_OFF_COLOR;
				EditorGUI.HelpBox(area,"OSC IN: "+UniOSCConnection.localIPAddress+"\nPort: "+oscConnection.oscPort+"\nNot listening", MessageType.Warning);
				if (GUI.Button (r1,"Connect")){oscConnection.ConnectOSC();}
			}

			_DropArea(evt, area, oscConnection);

			EditorGUILayout.EndVertical();

			#endregion IN




			if(oscConnection.oscOut){

			GUILayout.Space(5f);
			//GUILayout.FlexibleSpace();

			//OUT-------------------------

			EditorGUILayout.BeginVertical(GUILayout.MaxWidth(200f));

			Rect area_out = GUILayoutUtility.GetRect (100.0f, 40.0f);//, GUILayout.ExpandWidth (true)
			area_out.width*=1f;//0.95f;

			Rect r2 = GUILayoutUtility.GetRect (100.0f, 20.0f);
			r2.width*=1f;//0.95f;
				int btnsize = 20;
				Rect r2b = new Rect(area_out);
				r2b.x+= r2b.width-(btnsize*1);
				r2b.y+= r2b.height-btnsize;
				r2b.width = btnsize*1;
				r2b.height= btnsize;


			if(oscConnection.isConnectedOut){
				GUI.contentColor = Color.white;
				GUI.backgroundColor = oscConnection.dispatchOSCOut ? UniOSCUtils.CONNECTION_ON_COLOR : UniOSCUtils.CONNECTION_PAUSE_COLOR;
				EditorGUI.HelpBox(area_out,"OSC OUT: "+oscConnection.oscOutIPAddress+"\nPort: "+oscConnection.oscOutPort+"\nIs sending",MessageType.Info);//oscConnection.name+
			
				if (GUI.Button (r2,"Disconnect")){oscConnection.DisconnectOSCOut();}

					GUI.backgroundColor = Color.white;
					GUI.contentColor = Color.white;

					//if ( GUI.Button (r2b,new GUIContent(texTestMessage,""),style ) ){oscConnection.SendTestMessage();}

					Texture2D currTex = oscConnection.dispatchOSCOut ?  texON : texOFF ;
					oscConnection.dispatchOSCOut = GUI.Toggle(r2b,oscConnection.dispatchOSCOut,new GUIContent(currTex,"Turn the OSC sending from Unity on/off without start/stop the network resources"),style );


				}else{
					GUI.backgroundColor = Color.red;
					GUI.contentColor = Color.white;
					EditorGUI.HelpBox(area_out,"OSC OUT: "+oscConnection.oscOutIPAddress+"\nPort: "+oscConnection.oscOutPort+"\nNot sending",MessageType.Warning);//oscConnection.name+
				
					if (GUI.Button (r2,"Connect")){
						IPAddress addr ;
						if(UniOSCUtils.ValidateIPAddress(oscConnection.oscOutIPAddress,out addr)){
							oscConnection.ConnectOSCOut();
						}else{
							 EditorUtility.DisplayDialog("Invalid IP Address", "The IPAddress you have choosen is not valid! Please use a different.", "OK");

						}
						//oscConnection.ConnectOSCOut();
				}
			}
				
			_DropArea(evt,area_out,oscConnection);
			
			EditorGUILayout.EndVertical();
			//OUT--------------------------------


			}//if(oscConnection.OSCOut){

			GUI.backgroundColor = Color.white;
			GUI.contentColor = Color.white;


		
			EditorGUILayout.EndHorizontal();

			if(EditorGUI.EndChangeCheck()){
				EditorUtility.SetDirty(oscConnection);
			}
		}


	}
}