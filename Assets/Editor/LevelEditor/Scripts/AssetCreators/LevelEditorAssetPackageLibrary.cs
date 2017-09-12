using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(menuName = "Level Editor/Asset Package Library")]

public class LevelEditorAssetPackageLibrary : ScriptableObject {
	public LevelEditorAssetPackage[] packages;
}
