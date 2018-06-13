//*******************************************************************************************************
//* Deals with level resourcces.																		*
//*																										*
//*******************************************************************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;

namespace JSONFactory{
	class JSONAssembly {

		private static Dictionary<string, string> _resourceList = new Dictionary<string, string>{
			{"Event1", "/Resources/Dialogues/Event1.json"},
			{"Event2", "/Resources/Dialogues/Event2.json"},
			{"Event3", "/Resources/Dialogues/Event3.json"}

		};

		public static DiaNarrativeEvent RunJSONFactoryForScene(string sceneName) {
			string resourcePath = PathForScene (sceneName);

			if (IsValidJSON (resourcePath) == true) {
				string jsonString = File.ReadAllText (Application.dataPath + resourcePath);
				DiaNarrativeEvent narrativeEvent = JsonMapper.ToObject<DiaNarrativeEvent>(jsonString);

				return narrativeEvent;
			} else {
				throw new Exception ("Resource path not valid");
			}
		}

		private static string PathForScene(string sceneName){
			string resourcePathResult;

			if (_resourceList.TryGetValue (sceneName, out resourcePathResult)) {
				return _resourceList [sceneName];
			} else {
				throw new Exception ("Scene number does not exist.");
			}
		}

		private static bool IsValidJSON(string path){
			return (Path.GetExtension(path) == ".json") ? true : false;
		}
	}
}