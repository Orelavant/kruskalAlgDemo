using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    
    private void Update() {
        // On enter key down, run Kruskal's algorithm.
        if (Input.GetKeyDown("space")) {
            // Find all nodes and put them into forest.
            collection();
            // Put each edge into a min heap based on edge weight.
        }
    }

    private void collection() {
        // Create UnionFind and Heap
        UnionFind unionFind = new UnionFind();
        Heap minHeap = new Heap();

        // Array of existing lines and current node and node location collection.
        GameObject[] lineClones = GameObject.FindGameObjectsWithTag("line");
        List<Vector2> currNodes = new List<Vector2>();

        foreach (GameObject line in lineClones) {
            // Get positions of the two nodes of line.
            Vector2 node1Pos = line.transform.Find("node1").gameObject.transform.position;
            Vector2 node2Pos = line.transform.Find("node2").gameObject.transform.position;
            Vector2[] nodesPos = { node1Pos, node2Pos };
            
            // If not in currNodes, createSet() for each line point and add to currNodes.
            foreach (Vector2 nodePos in nodesPos) {
                if (!(currNodes.Contains(nodePos))) {
                    unionFind.createSet(nodePos);
                    currNodes.Add(nodePos);
                }
            }

            // Then create an edge for each line with Edge().
            float edgeWeight = Vector2.Distance(node1Pos, node2Pos);
            Edge newEdge = new Edge(edgeWeight, line);
            minHeap.insert(newEdge);
        }

    }
}
