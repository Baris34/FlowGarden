using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
private Vector2 startTouchPosition, endTouchPosition;
    private Vector2 dragDirection;
    public float maxForce = 20f;
    public float minSwipeDistance = 50f;
    private Rigidbody2D rb;
    private bool isDragging = false;
    private bool hasMoved = false; 
    public LineRenderer lineRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && isDragging)
        {
            UpdateIndicator();
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endTouchPosition = Input.mousePosition;
            LaunchCube();
            isDragging = false;
            lineRenderer.enabled = false;
        }

    }

    void OnMouseDown()
    {
        if (!hasMoved) 
        {
            startTouchPosition = Input.mousePosition;
            isDragging = true;
            lineRenderer.enabled = true;
            UpdateIndicator();
        }
    }

    void LaunchCube()
    {
        if (hasMoved) return; 

        Vector2 swipeDirection = endTouchPosition - startTouchPosition;
        float swipeDistance = swipeDirection.magnitude;

        if (swipeDistance > minSwipeDistance)
        {
            dragDirection = swipeDirection.normalized;

            float forceMagnitude = Mathf.Min(swipeDistance / Screen.width * maxForce, maxForce);
            rb.AddForce(-dragDirection * forceMagnitude, ForceMode2D.Impulse);
            hasMoved = true;
        }
    }

    void UpdateIndicator()
    {
        Vector2 currentPosition = Input.mousePosition;
        
        Vector3 worldStartPoint = Camera.main.ScreenToWorldPoint(new Vector3(startTouchPosition.x, startTouchPosition.y, -Camera.main.transform.position.z));
        Vector3 worldCurrentPoint = Camera.main.ScreenToWorldPoint(new Vector3(currentPosition.x, currentPosition.y, -Camera.main.transform.position.z));
        
        Vector3 direction = worldCurrentPoint - worldStartPoint;
        
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position+new Vector3(-direction.y,direction.x,direction.z));
    }
}
