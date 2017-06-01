using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTextureHelper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ATextureHelper textureHelper=new ATextureHelper();
		textureHelper.CreateTextureInEditor(new Color(),"Assets/Textures/test.png");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
