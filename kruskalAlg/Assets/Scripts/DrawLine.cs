using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    // Line object references
    public GameObject linePrefab;
    public GameObject currLine;

    // Components of line
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;

    // Whether a line has begun to be drawn or not.
    private bool lineActive = false;

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            CreateLine();
        }
    }

    // Instantiates line and sets its start to the first mouse click position, and end to the second mouse click position.
    void CreateLine() {
        if (!lineActive) {
            // Instantiate line and get its components
            currLine = Instantiate(linePrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            lineRenderer = currLine.GetComponent<LineRenderer>();
            edgeCollider = currLine.GetComponent<EdgeCollider2D>();

            // Make current mouse position the starting point for the line. Set lineActive.
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lineRenderer.SetPosition(0, fingerPositions[0]);
            lineRenderer.SetPosition(1, fingerPositions[0]);
            edgeCollider.points = fingerPositions.ToArray();
            lineActive = true;
        } else {
            // Get second position for the end of the line, set lineActive to false, and clear fingerpositions.
            fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lineRenderer.SetPosition(1, fingerPositions[1]);
            edgeCollider.points = fingerPositions.ToArray();
            lineActive = false;
            fingerPositions.Clear();
        }
    }
}
