using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour {

    private int edgeWeight;
    private List<Set> vertices = new List<Set>();

    // Constructor
    public Edge(int newEdgeWeight, Set node1, Set node2) {
        edgeWeight = newEdgeWeight;
        vertices.Add(node1);
        vertices.Add(node2);
    }

    private int getEdgeWeight() {
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
