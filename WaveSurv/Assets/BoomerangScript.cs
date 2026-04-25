using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    private float r = 0.0f;
    private float h;
    private float v;
    private float speed1 = 40;
    private float speed2 = 0;
    private Transform targetTransform;
    private Vector3 tpose;
    private Vector3 position;
    private float v2 = 0.0f;
    private float h2 = 0.0f;
    private float d = 0.0f;
    private bool hasleft = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = Movement.myr * Mathf.Deg2Rad;
        GameObject targetObj = GameObject.FindWithTag("PBug"); // Or Find("ObjectName")
        if (targetObj != null)
        {
            targetTransform = targetObj.transform;
        }
        SpawnScript.retrieval = false;
    }

    // Update is called once per frame
    void Update()
    {
        tpose = targetTransform.position;
        position = transform.position;
        v2 = tpose.y - position.y;
        h2 = tpose.x - position.x;
        d = Mathf.Sqrt(Mathf.Pow(h2, 2) + Mathf.Pow(v2, 2));
        if (d == 0.0f)
        {
            d = 0.00001f;
        }
        v2 /= d;
        h2 /= d;
        position.x += Time.deltaTime * h2 * speed2 * 30;
        position.y += Time.deltaTime * v2 * speed2 * 30;
        transform.position = position;
        Vector3 ne = transform.position;
        h = Mathf.Cos(r + Mathf.PI / 2f);
        v = Mathf.Sin(r + Mathf.PI / 2f);
        ne.x += Time.deltaTime * h * speed1;
        ne.y += Time.deltaTime * v * speed1;
        speed1 -= Time.deltaTime;
        speed2 += Time.deltaTime;
        transform.position = ne;
        if (Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.y * transform.position.y)) > 67)
        {
            SpawnScript.retrieval = true;
            Destroy(gameObject);
        }
        transform.Rotate(Vector3.forward * Time.deltaTime * 720);
    }
    private void OnTriggerExit2D(Collider2D cotlision)
    {
        if (cotlision.CompareTag("PBug"))
        {
            hasleft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PBug") && hasleft)
        {
            SpawnScript.retrieval = true;
            Destroy(gameObject);
        }
        if (other.CompareTag("CenterX"))
        {
            SpawnScript.retrieval = true;
            Destroy(gameObject);
        }
    }
}
