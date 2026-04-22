using UnityEngine;
using UnityEngine.InputSystem.Android;

public class MitosiScript : MonoBehaviour
{
    private float r = 0.0f;
    private float h;
    private float v;
    private float coutner = 0.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 thispos = transform.position;
        Vector3 rotate;
        Vector3 pbpos = SpawnScript.targetTransform.position;
        float pseudodist = Mathf.Abs(thispos.x - pbpos.x) + Mathf.Abs(thispos.y - pbpos.y);
        if (pseudodist > 3)
        {
            transform.Rotate(Vector3.back, 15);
            rotate = transform.rotation.eulerAngles;
        }
        else
        {
            rotate.z = Movement.myr;
        }
            r = (rotate.z * Mathf.Deg2Rad);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ne = transform.position;
        h = Mathf.Cos(r + Mathf.PI / 2f);
        v = Mathf.Sin(r + Mathf.PI / 2f);
        ne.x += Time.deltaTime * h * 25;
        ne.y += Time.deltaTime * v * 25;
        transform.position = ne;
        if (Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.y * transform.position.y)) > 67)
        {
            Destroy(gameObject);
        }
        coutner += Time.deltaTime * 50;
        if (coutner >= 50)
        {
            Instantiate(gameObject, transform.position, transform.rotation);
            transform.Rotate(Vector3.forward, 15);
            r += Mathf.PI / 12;
            coutner = 0;
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
