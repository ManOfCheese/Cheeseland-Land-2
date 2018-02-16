using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour {

    public Color enemyColor = new Color();
    public Renderer enemyRenderer;

	// Use this for initialization
	void Start () {
        enemyRenderer.material.color = enemyColor;
	}
	
	// Update is called once per frame
	void Update () {

    }
}
