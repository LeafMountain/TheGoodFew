using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetupLevel {

    public bool CheckIfSetup () {
        string[] requiredItems = { "Units", "PlayerUnits", "EnemyUnits", "Ground", "Props", "BattleManager", "GlobalStateMachine" };
        
        for (int i = 0; i < requiredItems.Length; i++) {
            if (!GameObject.Find (requiredItems[i])) {
                return false;
            }
        }
        return true;
    }

    public void SetupHierarchy () {
        GameObject units = SetupNewGameObject ("Units");
        SetupNewGameObject ("PlayerUnits", units.transform);
        SetupNewGameObject ("EnemyUnits", units.transform);

        GameObject environment = SetupNewGameObject ("Environment");
        SetupNewGameObject ("Ground", environment.transform);
        SetupNewGameObject ("Props", environment.transform);

        SetupCamera ();
        InstantiatePrefab ("GameSystems/BattleManager");
        InstantiatePrefab ("GameSystems/GlobalStateMachine");
    }

    private GameObject SetupNewGameObject (string goName, Transform parent = null) {
        GameObject existingGO = GameObject.Find (goName);
        if (!existingGO) {
            GameObject go = new GameObject (goName);

            if (parent) {
                go.transform.SetParent (parent);
            }

            return go;
        }

        return existingGO;
    }
    private void SetupCamera () {
        GameObject camera = GameObject.Find ("Main Camera");
        if (camera) {
            GameObject.DestroyImmediate (camera);
        }

        InstantiatePrefab ("GameSystems/CameraAnchor");
    }

    private GameObject InstantiatePrefab (string prefabPath) {
        Object prefab = Resources.Load ("LevelEditor/" + prefabPath);
        if (!GameObject.Find ((prefab as GameObject).name)) {
            GameObject prefabGO = PrefabUtility.InstantiatePrefab (prefab) as GameObject;
            return prefabGO;
        }

        return null;
    }
}