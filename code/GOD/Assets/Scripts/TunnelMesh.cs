//http://wiki.unity3d.com/index.php/MeshHelper
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMesh : MonoBehaviour {

    public MeshFilter MF;

    void Start()
    {
        Mesh mesh = MF.mesh;
        MeshHelper.Subdivide(mesh, 6);   // divides a single quad into 6x6 quads
        MF.mesh = mesh;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
