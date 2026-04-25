using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class E2Scr : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float hyp1;
    private float xchange;
    private float ychange;
    private Vector3 tpose;
    private Vector3 position;
    private float r;
    private float counter = 0;
    public GameObject E1;
    public GameObject EBullet;
    private Transform targetTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()   
    {
        GameObject targetObj = GameObject.FindWithTag("PBug"); // Or Find("ObjectName")
        if (targetObj != null)
        {
            targetTransform = targetObj.transform;
        }
        hyp1 = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2));
        ychange = 5f * (transform.position.y / hyp1);
        xchange = 5f * (transform.position.x / hyp1);

    }
    // Update is called once per frame
    void Update()
    {
        tpose = targetTransform.position;
        position = transform.position;
        turn();
        position.x = position.x - xchange * Time.deltaTime;
        position.y = position.y - ychange * Time.deltaTime;
        transform.position = position;
        transform.rotation = Quaternion.Euler(0, 0, r);
        counter += Time.deltaTime;
        if (counter > 3)
        {
            Instantiate(EBullet, transform.position, transform.rotation);
            counter = 0;
        }
    }
    void turn()
    {
        float ych = tpose.y - position.y;
        float xch = tpose.x - position.x;
        float hyp = Mathf.Sqrt(Mathf.Pow(xch, 2) + Mathf.Pow(ych, 2));
        r = Mathf.Rad2Deg * Mathf.Asin(ych/hyp);
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
        if(other.CompareTag("Heal"))
        {
            Instantiate(E1, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
        if (other.CompareTag("CenterX"))
        {
            SpawnScript.deathcounter++;
            Destroy(gameObject);
        }
        if (other.CompareTag("kct") || other.CompareTag("Heal") || other.CompareTag("Mine") || other.CompareTag("Mitosis") || other.CompareTag("Boomerang") || other.CompareTag("Burst"))
        {
            Instantiate(E1, transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }
        if (other.CompareTag("PBug"))
        {
            Destroy(gameObject);
        }
    }
}
