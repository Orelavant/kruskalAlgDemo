using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : object {

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

    public float getEdgeWeight() {
        return edgeWeight;
    }

    public Set getVertex(int index) {
        return vertices[index];
    }

    public GameObject getLine() {
        return line;
    }

    public bool greaterThan(Edge compEdge) {
        if (edgeWeight > compEdge.edgeWeight) {
            return true;
        }
        return false;
    }

    public void setActive() {
        Material lineMaterial = line.GetComponent<Renderer>().material;
        lineMaterial = line.GetComponent<LineRenderer>().materials[1];
    }
}
