// https://answers.unity.com/questions/476810/flip-a-mesh-inside-out.html
using System.Linq;
using UnityEngine;
public class ReverseNormals : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        mesh.triangles = mesh.triangles.Reverse().ToArray();
    }
}
