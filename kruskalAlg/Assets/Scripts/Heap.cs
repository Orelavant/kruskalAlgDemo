using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Heap implemented using an array (arrayHeap) and as a minHeap.
public class Heap : MonoBehaviour {

    // Array of data.
    private List<Edge> data;

    // Constructor. Creates new array.
    public Heap() {
        data = new List<Edge>();
    }

    // Insert element into heap while mantaining minHeap structure.
    public void insert(Edge newEdge) {
        // Add to the end of heap.
        data.Add(newEdge);

        // Setting initial index of new edgeWeight and its parent.
        int newIndex = data.Count - 1;
        int pIndex = parent(newIndex);

        // Bubble up new edgeWeight.
        bubbleUp(newIndex, pIndex);
    }

    private void bubbleUp(int newIndex, int pIndex) {
        // While child is < parent, swap. Then reset indices for potential future swaps.
        while (!(data[newIndex].greaterThan(data[pIndex]))) {
            swap(parent(newIndex), newIndex);
            newIndex = pIndex;
            pIndex = parent(newIndex);
        }
    }

    // Swaps parent with child
    private void swap(int pIndex, int cIndex) {
        Edge temp = data[pIndex];
        data[pIndex] = data[cIndex];
        data[cIndex] = temp;
    }

    // Accesses parent based on arrayHeap implementation.
    private int parent(int index) {
        return (int) Mathf.Ceil((index - 1) / 2);
    }

    // Accesses leftChild based on arrayHeap implementation.
    private int leftChild(int index) {
        return 2 * index + 1;
    }

    // Accesses rightChild based on arrayHeap implementation.
    private int rightChild(int index) {
        return 2 * index + 2;
    }
}
