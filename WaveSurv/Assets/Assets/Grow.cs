using UnityEngine;

public class Grow : MonoBehaviour
{
    public Vector3 scale;
    private int dc;
    private float gox;
    private float goy;
    private float rate = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scale = transform.localScale;
        if (dc != SpawnScript.deathcounter)
        {
            gox = scale.x + 0.5f;
            goy = scale.y + 0.5f;
            dc = SpawnScript.deathcounter;
        }
        if (scale.x < gox)
        {
            scale.x += rate * Time.deltaTime;
            scale.y += rate * Time.deltaTime;
        }
        transform.localScale = scale;
    }
}
