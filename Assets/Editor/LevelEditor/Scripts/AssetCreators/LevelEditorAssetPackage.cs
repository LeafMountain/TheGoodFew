using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenuAttribute(menuName = "Level Editor/Asset Package")]
public class LevelEditorAssetPackage : ScriptableObject {
	public string packageName;
	public GameObject[] assets;

	public Texture2D[] GetAssetPreviews(){
		Texture2D[] textures = new Texture2D[assets.Length];

        for (int i = 0; i < assets.Length; i++) {
            Texture2D preview = null;

            preview = AssetPreview.GetAssetPreview (assets[i]);
            if(preview == null){
                preview = AssetPreview.GetMiniThumbnail(assets[i]);
            }

            textures[i] = preview;
        }

		return textures;
	}
}
