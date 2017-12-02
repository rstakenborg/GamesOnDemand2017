//http://wiki.unity3d.com/index.php/MeshHelper
//https://forum.unity.com/threads/perlin-noise-on-mesh-vertices.242200/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelMesh : MonoBehaviour {

    private MeshFilter MF;
    private Vector3[] vertPositions;
    private int scaleX = 2;
    private int scaleY = 2;
    private int invertscaleX = -2;
    private int invertscaleY = -2;
    void Start()
    {
        MF = GetComponent<MeshFilter>();
        Mesh mesh = MF.mesh;
        MeshHelper.Subdivide(mesh, 6);   // divides a single quad into 6x6 quads
        MF.mesh = mesh;
        vertPositions = mesh.vertices;

        mesh.vertices = AddNoise(vertPositions);
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }

    Vector3[] AddNoise(Vector3[] vertices) {
        // .. todo:: add noise only to the farthest ring?
        for (var i = 0; i < vertices.Length; i++)
        {
            vertices[i].x = vertPositions[i].x + (Mathf.PerlinNoise(Time.deltaTime + (vertPositions[i].x * scaleX), Time.deltaTime + (vertPositions[i].y * scaleY))) - (Mathf.PerlinNoise(Time.deltaTime + (vertPositions[i].x * invertscaleX), Time.deltaTime + (vertPositions[i].y * invertscaleY)));
        }
        return vertices;
    }
    // Update is called once per frame
    void Update () {
        Mesh mesh = MF.mesh;
        mesh.vertices = AddNoise(mesh.vertices);
    }
}
