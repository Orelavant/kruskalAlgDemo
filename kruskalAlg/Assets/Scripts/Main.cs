using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : object {

    public UnionFind unionFind = new UnionFind();
    public Heap minHeap = new Heap();

    public void collection() {
        // Array of existing lines and current node location collection.
        GameObject[] lineClones = GameObject.FindGameObjectsWithTag("line");
        List<Set> currNodes = new List<Set>();

        // Populate forest and minHeap.
        foreach (GameObject line in lineClones) {
            //Create Edge.
            Edge currEdge = new Edge(line);

            // Get positions of the two nodes of line.
            Vector2 node1Pos = line.transform.Find("node1").gameObject.transform.position;
            Vector2 node2Pos = line.transform.Find("node2").gameObject.transform.position;
            Vector2[] nodesPos = { node1Pos, node2Pos };

            // Set Edge weight
            float edgeWeight = Vector2.Distance(node1Pos, node2Pos);
            currEdge.setEdgeWeight(edgeWeight);

            // Create a new set with nodesPos. Use for forest and the edge vertices.
            for (int i = 0; i <= nodesPos.Length-1; i++) {
                // Create a new set
                Set currSet = new Set(nodesPos[i]);

                // If not in currNodes, add to union, currEdge, and to currNodePos.
                if (!(currNodes.Contains(currSet))) {
                    unionFind.addSet(currSet);
                    currEdge.setVertex(i, currSet);
                    currNodes.Add(currSet);
                } else {
                // If in currNodes, just add it to currEdge.
                    Set addSet = currNodes.Find(Set => Set.getLocation() == currSet.getLocation());
                    currEdge.setVertex(i, addSet);
                }
            }

            // Insert into minHeap.
            minHeap.insert(currEdge);
        }
    }

    public void kruskalAlg() {
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
