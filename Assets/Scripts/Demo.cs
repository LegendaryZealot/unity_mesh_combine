using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour {
	void Start () { 
		MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();  
        Material[] mats = new Material[meshRenderers.Length];  
        for (int i = 0; i < meshRenderers.Length; i++) {
            mats[i] = meshRenderers[i].sharedMaterial;   
        }
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();  
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];   
        for (int i = 0; i < meshFilters.Length; i++) {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh(); 
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, false);
        transform.gameObject.SetActive(true);
        transform.GetComponent<MeshRenderer>().sharedMaterials = mats;
	}
}
