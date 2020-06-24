using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    // Line object references
    public GameObject linePrefab;
    private GameObject currLine;

    // Components of line
    private LineRenderer lineRenderer;
    private List<GameObject> nodeArr = new List<GameObject>();
    private List<Vector2> fingerPositions = new List<Vector2>();

    // Whether a line has begun to be drawn or not
    private bool lineActive = false;

    // currNode references
    public bool onNode = false;
    public Vector2 nodePos;

    // Update is called once per frame
    void Update() {
        // On left click, line create function
        if (Input.GetMouseButtonDown(0)) {
            CreateLine();
        }

        // On delete key down, delete function
        if (Input.GetKeyDown("delete")) {
            // Identify all lines and then delete each one.
            GameObject[] lineClones = GameObject.FindGameObjectsWithTag("line");
            foreach (GameObject line in lineClones) {
                Destroy(line);
            }
        }
    }

    // Instantiates line and sets its start to the first mouse click position, and end to the second mouse click position.
    void CreateLine() {
        if (!lineActive) {
            // Instantiate line and get its components
            currLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
            lineRenderer = currLine.GetComponent<LineRenderer>();
            nodeArr.Add(currLine.transform.Find("node1").gameObject);
            nodeArr.Add(currLine.transform.Find("node2").gameObject);

            // Make current mouse position the starting point for the line
            // If a node is nearby, snap to it
            if (onNode) {
                fingerPositions.Add(nodePos);
            } else {
                fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            // Set start of line and node.
            lineRenderer.SetPosition(0, fingerPositions[0]);
            lineRenderer.SetPosition(1, fingerPositions[0]);
            nodeArr[0].transform.position = fingerPositions[0];

            // Set node and lineActive to true.
            nodeArr[0].SetActive(true);
            lineActive = true;
        } else {
            // Get second position for the end of the line
            // If a node is nearby, snap to it
            if (onNode) {
                fingerPositions.Add(nodePos);
            } else {
                fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            lineRenderer.SetPosition(1, fingerPositions[1]);

            // Position/activate node
            nodeArr[1].transform.position = fingerPositions[1];
            nodeArr[1].SetActive(true);

            // Set lineActive to false, and clear node positions and fingerpositions
            lineActive = false;
            nodeArr.Clear();
            fingerPositions.Clear();
        }
    }
}
