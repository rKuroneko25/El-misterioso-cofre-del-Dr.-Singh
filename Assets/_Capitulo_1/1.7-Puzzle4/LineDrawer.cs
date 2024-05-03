using UnityEditor;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public Material lineMaterial;
    private Vector3? prevPoint = null;

    void OnDrawGizmos()
    {
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!prevPoint.HasValue)
                {
                    prevPoint = hit.point;
                }
                else
                {
                    DrawLine(prevPoint.Value, hit.point, lineMaterial);
                    prevPoint = hit.point;
                }
            }
        }
    }

    void DrawLine(Vector3 start, Vector3 end, Material material)
    {
        if (material == null)
        {
            Debug.LogError("Material for line drawing is not assigned.");
            return;
        }

        if (!Camera.current)
            return;

        GL.PushMatrix();
        material.SetPass(0);
        GL.LoadPixelMatrix();
        GL.Begin(GL.LINES);
        GL.Color(material.color);
        GL.Vertex(Camera.current.WorldToScreenPoint(start));
        GL.Vertex(Camera.current.WorldToScreenPoint(end));
        GL.End();
        GL.PopMatrix();
    }
}