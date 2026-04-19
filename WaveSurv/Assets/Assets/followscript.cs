using UnityEngine;

public class followscript : MonoBehaviour
{
    public GameObject leader;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos = leader.transform.position;
        transform.position = pos;
    }
}
