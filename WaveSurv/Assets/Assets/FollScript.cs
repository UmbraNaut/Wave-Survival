using UnityEngine;

public class FollScript : MonoBehaviour
{
    public GameObject leader;
    float x;
    float y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = leader.transform.position.x;
        y = leader.transform.position.y;
        transform.position = new Vector3(x, y, -7);
    }
}
