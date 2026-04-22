using JetBrains.Annotations;
using UnityEngine;


public class EnemyScr : MonoBehaviour
{
    private float hyp;
    private float xchange;
    private float ychange;
    private int shield = 12;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hyp = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2));
        ychange = 5f * (transform.position.y / hyp);
        xchange = 5f * (transform.position.x / hyp);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x - xchange * Time.deltaTime;
        position.y = position.y - ychange * Time.deltaTime;
        transform.position = position;
        if (shield > 0)
        shield--;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (shield < 1)
        {
            if (other.CompareTag("kct"))// Check if the object has the "Player" tag
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("CenterX"))
            {
                SpawnScript.deathcounter++;
                Destroy(gameObject);
            }
            if (other.CompareTag("Mine"))
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("Heal"))
            {
                SpawnScript.doHeal(transform.position);
                Destroy(gameObject);
            }
            if (other.CompareTag("EB"))
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("Mitosis"))
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("Boomerang"))
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("PBug"))
            {
                Destroy(gameObject);
            }
        }
    }
}
