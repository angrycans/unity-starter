using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTextureHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		TextureHelper textureHelper=new TextureHelper();
		textureHelper.CreateTextureInEditor(new Color(),"Assets/Textures/test.png");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
