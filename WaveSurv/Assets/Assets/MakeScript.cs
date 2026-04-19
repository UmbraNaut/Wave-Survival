using UnityEngine;

public class MakeScript : MonoBehaviour
{
    float on;
    float ox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        on = Movement.trackv;
        ox = Movement.trackf;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y += Time.deltaTime * on * 25;
        pos.x += Time.deltaTime * ox * 25;
        transform.position = pos;
        if (Mathf.Sqrt((transform.position.x * transform.position.x) + (transform.position.y * transform.position.y)) > 67)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("E1"))// Check if the object has the "Player" tag
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("CenterX"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Sent"))
        {
            Destroy(gameObject);
        }
    }
}