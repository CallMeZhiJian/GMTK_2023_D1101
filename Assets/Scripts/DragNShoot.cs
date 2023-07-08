using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power;
    public Rigidbody2D playerRb;

    public Vector2 minPower;
    public Vector2 maxPower;

    private TrajectoryLine tl;
    private TimeManager timeManager;
    
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TrajectoryLine>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerRb.velocity = new Vector2(0f, 0f);
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            timeManager.DoSlowMo();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            playerRb.AddForce(force * power, ForceMode2D.Impulse);

            tl.EndLine();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("SlowDown");
            timeManager.DoSlowMo();
        }
    }
}
