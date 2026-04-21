using System;
using UnityEngine;

public class HealMove : MonoBehaviour
{
    public float r;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = Movement.myr * Mathf.Deg2Rad;
    }
    private float v = 0.0f;
    private float h = 0.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 ne = transform.position;
        h = Mathf.Cos(r + Mathf.PI/2f);
        v = Mathf.Sin(r + Mathf.PI/2f);
        ne.x += Time.deltaTime * h * 25;
        ne.y += Time.deltaTime * v * 25;
        transform.position = ne;
        if (Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.y * transform.position.y)) > 67)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("E1"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("E2"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Sent"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("CenterX"))
        {
            Destroy(gameObject);
        }
    }
}
