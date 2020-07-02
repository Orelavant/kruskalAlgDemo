using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Heap implemented using an array (arrayHeap) and as a minHeap.
public class Heap : object {

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

    // Remove top element and mantain minHeap structure.
    public Edge removeMin() {
        // Saving min for later
        Edge minEdge = min();

        // If last element, remove and return it. Preventing overindex.
        if (size() == 1) {
            remove(size() - 1);
            return minEdge;
        }

        // Saving last for later.
        Edge last = data[size() - 1];

        // Replacing min with the last element in the heap and removing the last element.
        data[0] = last;
        remove(size() - 1);

        // If there is only top and left, pass right as left to avoid overindexing.
        if (size() == 2) {
            bubbleDown(0, left(0), left(0));
        } else if (size() == 1) {
            return minEdge;
        } else {
            // Bubble down to mantain heap structure.
            bubbleDown(0, left(0), right(0));
        }

        return minEdge;
    }

    private void bubbleUp(int newIndex, int pIndex) {
        // While child is < parent, swap. 
        // Then reset indices for potential future swaps.
        while (!(data[newIndex].greaterThan(data[pIndex])) && newIndex != pIndex) {
            swap(parent(newIndex), newIndex);
            newIndex = pIndex;
            pIndex = parent(newIndex);
        }
    }

    private void bubbleDown(int newIndex, int lIndex, int rIndex) {
        // While parent > either child, swap with the smallest child.
        while (data[newIndex].greaterThan(data[lIndex]) ||
            data[newIndex].greaterThan(data[lIndex])) {
            // Go right if right is smaller. Check for over indexing.
            // TODO: You might have same issue here as bubbleUp where lIndex & rIndex equal each other.
            if (data[lIndex].greaterThan(data[rIndex])) {
                swap(newIndex, rIndex);
                newIndex = rIndex;
                lIndex = left(newIndex);
                rIndex = right(newIndex);
                if (rIndex >= size()) {
                    break;
                }
                // Go left if left is smaller.
            } else if (!(data[lIndex].greaterThan(data[rIndex]))) {
                swap(newIndex, lIndex);
                newIndex = lIndex;
                lIndex = left(newIndex);
                rIndex = right(newIndex);
                if (rIndex >= size()) {
                    break;
                }
            }
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

    // Accesses left child based on arrayHeap implementation.
    private int left(int index) {
        return 2 * index + 1;
    }

    // Accesses right based on arrayHeap implementation.
    private int right(int index) {
        return 2 * index + 2;
    }

    private Edge min() {
        if (isEmpty()) {
            return null;
        }
        return data[0];
    }

    public bool isEmpty() {
        if (size() == 0) {
            return true;
        }
        return false;
    }

    private int size() {
        return data.Count;
    }

    private Edge remove(int index) {
        Edge temp = data[index];
        data.Remove(data[index]);
        return temp;
    }

    public string heapToString() {
        StringBuilder sb = new StringBuilder();

        // Will not do the last element.
        for (int i = 0; i <= data.Count - 2; i++) {
            sb.Append(data[i].getEdgeWeight() + ", ");
        }
        sb.Append(data[data.Count - 1].getEdgeWeight());

        return sb.ToString();
    }
}
