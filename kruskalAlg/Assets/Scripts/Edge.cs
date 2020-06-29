using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour {

    private float edgeWeight;
    private GameObject line;
    private List<Set> vertices = new List<Set>();

    // Constructor
    public Edge(float newEdgeWeight, GameObject newLine) {
        edgeWeight = newEdgeWeight;
        line = newLine;
        //vertices.Add(node1);
        //vertices.Add(node2);
    }

    private float getEdgeWeight() {
        return edgeWeight;
    }

    private Set getVertex(int index) {
        return vertices[index];
    }

    public bool greaterThan(Edge compEdge) {
        if (edgeWeight > compEdge.edgeWeight) {
            return true;
        }
        return false;
    }
}
