using UnityEngine;
using UnityEngine.UIElements;

public class SentScr : MonoBehaviour
{
    private Transform targetTransform;
    private Vector3 tpose;
    private Vector3 position;
    private float r;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject targetObj = GameObject.FindWithTag("PBug"); // Or Find("ObjectName")
        if (targetObj != null)
        {
            targetTransform = targetObj.transform;
        }
    }
    private float v = 0.0f;
    private float h = 0.0f;
    private float d = 0.0f;

    // Update is called once per frame
    void Update()
    {
        tpose = targetTransform.position;
        position = transform.position;
        v = tpose.y - position.y;
        h = tpose.x - position.x;
        d = Mathf.Sqrt(Mathf.Pow(h, 2) + Mathf.Pow(v, 2));
        v /= d;
        h /= d;
        turn();
        position.x += Time.deltaTime * h * 8;
        position.y += Time.deltaTime * v * 8;
        transform.position = position;
        transform.rotation = Quaternion.Euler(0, 0, r);
    }
    void turn()
    {
        float ych = tpose.y - position.y;
        float xch = tpose.x - position.x;
        float hyp = Mathf.Sqrt(Mathf.Pow(xch, 2) + Mathf.Pow(ych, 2));
        r = Mathf.Rad2Deg * Mathf.Asin(ych / hyp);
        if (xch >= 0 && ych >= 0)
            r = -(90 - r);
        if (xch < 0 && ych >= 0)
            r = 90 - r;
        if (xch < 0 && ych < 0)
            r += 90;
        if (xch >= 0 && ych < 0)
            r = (90 - r) + 180;
        if (ych < 0)
            r = -r;
        if (ych >= 0)
            r += 180;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heal"))
        {
            SpawnScript.doHeal(transform.position);
        }
        if (other.CompareTag("CenterX"))
        {
            SpawnScript.deathcounter++;
            Destroy(gameObject);
        }
        if (other.CompareTag("PBug"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("EB"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("kct") || other.CompareTag("Heal") || other.CompareTag("Mine") || other.CompareTag("Mitosis"))
        {
            Destroy(gameObject);
        }
    }
}
