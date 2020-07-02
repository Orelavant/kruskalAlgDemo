using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : object {

    private float edgeWeight;
    private GameObject line;
    private Set[] vertices = new Set[2];

    // Constructor
    public Edge(GameObject newLine) {
        line = newLine;
    }

    public float getEdgeWeight() {
        return edgeWeight;
    }

    public Set getVertex(int index) {
        return vertices[index];
    }

    public GameObject getLine() {
        return line;
    }

    public void setEdgeWeight(float newEdgeWeight) {
        edgeWeight = newEdgeWeight;
    }

    public void setVertex(int index, Set newVertex) {
        vertices[index] = newVertex;
    }

    public bool greaterThan(Edge compEdge) {
        if (edgeWeight > compEdge.edgeWeight) {
            return true;
        }
        return false;
    }

    public void setActive() {
        Color lineMaterialColor = line.GetComponent<Renderer>().material.color;
        lineMaterialColor = Color.red;
    }
}
