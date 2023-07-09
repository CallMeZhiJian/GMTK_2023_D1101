using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power;
    public Rigidbody2D playerRb;
    public Transform playerTrans;

    public Vector2 minPower;
    public Vector2 maxPower;

    private TrajectoryLine tl;
    private TimeManager timeManager;
    
    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    private Vector3 screenPos;

    void Awake()
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

            screenPos = cam.WorldToScreenPoint(transform.position);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPoint, currentPoint);

            Vector3 vec3 = Input.mousePosition - screenPos;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle);
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
            timeManager.DoSlowMo();
            Destroy(collision.gameObject);
            ScoreSystem.score += 10;
        }
    }
}
