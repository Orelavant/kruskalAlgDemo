using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class UnionFind : object {

    // Reference to all nodes
    private List<Set> forest;

    // Constructor
    public UnionFind() {
        forest = new List<Set>();
    }

    public List<Set> getForest() {
        return forest;
    }

    // Creates a new set and adds it to forest
    public void addSet(Set newSet) {
        forest.Add(newSet);
    }

    // Finds the parent set which contains set
    public Set getRoot(Set set) {
        while (set.getParent() != set) { 
            getRoot(set.getParent()); 
        }
        return set;   
    }

    // Combines the two sets if they belong to different sets
    public bool union(Set set1, Set set2) {
        Set set1Root = getRoot(set1);
        Set set2Root = getRoot(set2);

        // If they belong to different sets...
        if (set1Root != set2Root) {
            // If the parents are not the same, compare ranks and set the lower ranked parent to the higher ranked.
            if (set1Root.getRank() >= set2Root.getRank()) {
                set2Root.setParent(set1Root);
                set1Root.addRank(1);
                return true;
            } else {
                set1Root.setParent(set2Root);
                set2Root.addRank(1);
                return true;
            }
        }
        return false;
    }

    // Note: O(n log n) implementation. Optimize.
    // Could do this by potentially removing sets which are now children. But that might take longer?
    public bool isSpanning() {
        // Find a root
        Set currRoot = getRoot(forest[0]);

        // Check if every set belongs to that root.
        foreach (Set set in forest) {
            Set newRoot = getRoot(set);
            if (newRoot != currRoot) {
                return false;
            }
        }

        return true;
    }

    public string forestToString() {
        StringBuilder sb = new StringBuilder();

        // Will not do the last element.
        for (int i = 0; i <= forest.Count-2; i++) {
            sb.Append(forest[i].getLocation() + ", ");
        }
        sb.Append(forest[forest.Count-1].getLocation());

        return sb.ToString();
    }
}
