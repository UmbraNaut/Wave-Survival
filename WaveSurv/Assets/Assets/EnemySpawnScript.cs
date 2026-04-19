using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject E1;
    public GameObject E2;
    public GameObject Sent;
    private float timercount = 0;
    private float goal = 1000;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timercount++;
        timercount += Time.deltaTime;
        if (timercount >= goal)
        {
            timercount = 0;
            if (Random.Range(0, 3) == 0)
                SpawnEnemy1(E1);
            else if (Random.Range(0, 2) == 0)
                SpawnEnemy1(E2);
            else
                SpawnEnemy1(Sent);
        }
    }
    public float ransom;
    public float ranyon;
    void SpawnEnemy1(GameObject thing)
    {
        int ran1 = Random.Range(0, 2);
        int ran2 = Random.Range(0, 2);
        if (ran1 == 0)
        {
            ransom = Random.Range(-70f, 70f);
            ranyon = Mathf.Sqrt(4900 - (Mathf.Pow(ransom, 2)));
            if (ran2 == 0)
            {
                ranyon = -ranyon;
            }
        }
        else
        {
            ranyon = Random.Range(-70f, 70f);
            ransom = Mathf.Sqrt(4900 - (Mathf.Pow(ranyon, 2)));
            if (ran2 == 0)
            {
                ransom = -ransom;
            }
        }
        Vector3 pos = new Vector3(ransom, ranyon, 0);
        Instantiate(thing, pos, Quaternion.Euler(0f, 0f, 0f));
    }
}
