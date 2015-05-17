using UnityEngine;
using System.Collections;

public class RenderParticle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingLayerName = "background";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
