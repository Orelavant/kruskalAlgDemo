﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnionFind : MonoBehaviour {

    // Reference to all nodes
    private List<Set> forest;

    // Constructor
    public UnionFind() {
        forest = null;
    }

    // Creates a new set and adds it to forest
    public void createSet() {
        Set newSet = new Set();
        forest.Add(newSet);
    }

    // Finds the parent set which contains set
    public Set findSet(Set set) {
        while (set.getParent() != set) { 
            findSet(set.getParent()); 
        }
        return set;   
    }

    // Combines the two sets if they belong to different sets
    public void union(Set set1, Set set2) {
        Set set1Root = findSet(set1);
        Set set2Root = findSet(set2);

        // If the parents are not the same, compare ranks and set the lower ranked parent to the higher ranked.
        if (set1Root != set2Root) {
            if (set1Root.getRank() >= set2Root.getRank()) {
                set2Root.setParent(set1Root);
                set1Root.addRank(1);
                // HERE, SET THE LINE ACTIVES BETWEEN SET1 AND SET2
            } else {
                set1Root.setParent(set2Root);
                set2Root.addRank(1);
                // HERE, SET THE LINE ACTIVES BETWEEN SET1 AND SET2
            }
        }
    }
}