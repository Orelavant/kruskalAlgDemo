using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

    // Line object references.
    public GameObject linePrefab;
    private GameObject currLine;

    // Components of line.
    private LineRenderer lineRenderer;
    private List<GameObject> nodeArr = new List<GameObject>();
    private List<Vector2> fingerPositions = new List<Vector2>();

    // Whether a line has begun to be drawn or not.
    private bool lineActive = false;

    // Node references.
    public bool onNode = false;
    public Vector2 nodePos;

    // Reference to main
    Main main = new Main(); 

    // Update is called once per frame.
    void Update() {
        // On left click, line create function.
        if (Input.GetMouseButtonDown(0)) {
            CreateLine();
        }

        // On delete key down, delete function.
        if (Input.GetKeyDown("delete")) {
            // Identify all lines and then delete each one.
            GameObject[] lineClones = GameObject.FindGameObjectsWithTag("line");
            foreach (GameObject line in lineClones) {
                Destroy(line);
            }
        }

        // On enter key down, run Kruskal's algorithm.
        if (Input.GetKeyDown("space")) {
            // Populate forest and minHeap.
            main.collection();

            // Find minimum spanning tree.
            //main.kruskalAlg();
        }
    }

    // Instantiates line and sets its start to the first mouse click position, and end to the second mouse click position.
    void CreateLine() {
        if (!lineActive) {
            // Instantiate line and get its components.
            currLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            lineRenderer = currLine.GetComponent<LineRenderer>();
            nodeArr.Add(currLine.transform.Find("node1").gameObject);
            nodeArr.Add(currLine.transform.Find("node2").gameObject);

            // Create and set start point for new line.
            CreatePoint();
            lineRenderer.SetPosition(0, fingerPositions[0]);
            lineRenderer.SetPosition(1, fingerPositions[0]);
            nodeArr[0].transform.position = fingerPositions[0];

            // Set node and lineActive to true.
            nodeArr[0].SetActive(true);
            lineActive = true;
        } else {
            // Create and set end point for current line.
            CreatePoint();
            lineRenderer.SetPosition(1, fingerPositions[1]);
            nodeArr[1].transform.position = fingerPositions[1];

            // Set node to true and lineActive to false.
            nodeArr[1].SetActive(true);
            lineActive = false;

            // Clear node positions and fingerpositions.
            nodeArr.Clear();
            fingerPositions.Clear();
        }
    }

    // Sets point of line based on mouse position
    private void CreatePoint() {
        // Make current mouse position the starting point for the line.
        // If a node is nearby, snap to it.
        if (onNode) {
            fingerPositions.Add(nodePos);
        } else {
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
