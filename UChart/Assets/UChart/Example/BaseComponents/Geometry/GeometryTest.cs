using UnityEngine;

namespace UChart.Test
{
    public class GeometryTest : MonoBehaviour
    {
        private void OnGUI()
        {
            if( GUILayout.Button("Generate CONE"))
            {
                var meshFilter = this.GetComponent<MeshFilter>();
                var meshRenderer = this.GetComponent<MeshRenderer>();

                Mesh mesh = new Mesh();
                mesh.name = "CONE";

                ConeGeometry cone = new ConeGeometry();
                cone.bottom = new Vector3(0,0,0);
                cone.height = 1.5f;
                cone.radius = 1.2f;
                cone.smoothness = 3;
                cone.FillGeometry();
                
                ConeGeometry cone2 = new ConeGeometry();
                cone2.bottom = new Vector3(5,0,0);
                cone2.height = 10f;
                cone2.radius = 3f;
                cone2.smoothness = 3;
                cone2.FillGeometry();
                cone.geometryBuffer.CombineGeometry(cone2.geometryBuffer);

                CubeGeometry cube = new CubeGeometry();
                cube.FillGeometry();                
                cone.geometryBuffer.CombineGeometry(cube.geometryBuffer);
                
                cone.geometryBuffer.FillMesh(mesh,MeshTopology.Triangles);

                meshFilter.mesh = mesh;
                meshRenderer.material = new Material(Shader.Find("Standard"));
            }

            if( GUILayout.Button("Generate Rounded Cylinder"))
            {
                var meshFilter = this.GetComponent<MeshFilter>();
                var meshRenderer = this.GetComponent<MeshRenderer>();

                Mesh mesh = new Mesh();
                mesh.name = "Rounded Cylinder";

                RoundedCylinderGeometry rCylinder = this.GetComponent<RoundedCylinder>().roundedCylinder;
                rCylinder.FillGeometry();
                rCylinder.geometryBuffer.FillMesh(mesh,MeshTopology.Triangles);

                mesh.RecalculateNormals();
                mesh.RecalculateTangents();
                meshFilter.mesh = mesh;
                meshRenderer.material = new Material(Shader.Find("Standard"));
            }

            if( GUILayout.Button("Generate Cylinder"))
            {
                var meshFilter = this.GetComponent<MeshFilter>();
                var meshRenderer = this.GetComponent<MeshRenderer>();

                Mesh mesh = new Mesh();
                mesh.name = "Cylinder";

                CylinderGeometry cylinder = this.GetComponent<Cylinder>().cylinder;
                cylinder.FillGeometry();
                cylinder.geometryBuffer.FillMesh(mesh,MeshTopology.Triangles);

                mesh.RecalculateNormals();
                mesh.RecalculateTangents();
                meshFilter.mesh = mesh;
                meshRenderer.material = new Material(Shader.Find("Standard"));
            }
        }
    }
}