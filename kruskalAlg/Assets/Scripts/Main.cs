using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    UnionFind unionFind;
    Heap minHeap;

    private void Start() {

        // Create UnionFind and minHeap.
        unionFind = new UnionFind();
        minHeap = new Heap();
    }

    private void Update() {
        // On enter key down, run Kruskal's algorithm.
        if (Input.GetKeyDown("space")) {
            // Populate forest and minHeap.
            collection();

            // Find minimum spanning tree.
            kruskalAlg();
        }
    }

    private void collection() {
        // Array of existing lines and current node and node location collection.
        GameObject[] lineClones = GameObject.FindGameObjectsWithTag("line");
        List<Vector2> currNodes = new List<Vector2>();

        // Populate forest and minHeap.
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

    private void kruskalAlg() {
        // While minHeap is not empty and unionFind is not spanning...
        while (!(minHeap.isEmpty()) && !(unionFind.isSpanning())) {
            // Get the smallest edge and remove it.
            Edge minEdge = minHeap.removeMin();

            // Run union.
            Set node1 = minEdge.getVertex(0);
            Set node2 = minEdge.getVertex(1);
            bool isUnion = unionFind.union(node1, node2);

            // Change line color according to results of union.
            if (isUnion) {
                minEdge.setActive();
            }
        }
    }
}
