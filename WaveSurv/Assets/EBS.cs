using UnityEngine;

public class EBS : MonoBehaviour
{
    private float r = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 rot = transform.rotation.eulerAngles;
        rot.z += 90;
        transform.rotation = Quaternion.Euler(rot.x,rot.y, rot.z);
        r = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.y * transform.position.y)) > 67)
        {
            Destroy(gameObject);
        }
        Vector3 ne = transform.position;
        float h = Mathf.Cos(r + Mathf.PI);
        float v = Mathf.Sin(r + Mathf.PI);
        ne.x += Time.deltaTime * h * 25;
        ne.y += Time.deltaTime * v * 25;
        transform.position = ne;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CenterX"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("E1"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Sent"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("PBug"))
        {
            Destroy(gameObject);
        }
    }
}
