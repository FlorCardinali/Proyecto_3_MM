using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class ForzarNavmesh : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return null; // esperar 1 frame

        var surface = GetComponent<NavMeshSurface>();
        surface.RemoveData();
        surface.BuildNavMesh();

        yield return null;

        var tri = NavMesh.CalculateTriangulation();
        Debug.Log("VERTICES NAVMESH = " + tri.vertices.Length);

        foreach (var agent in FindObjectsByType<NavMeshAgent>(FindObjectsInactive.Include))
        {
            agent.enabled = true;
            Debug.Log("Agent activado: " + agent.name + " | isOnNavMesh = " + agent.isOnNavMesh);
        }
    }
}