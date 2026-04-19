using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class SpawnScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject mine;
    public GameObject heal;
    [SerializeField] private GameObject healpref;
    public static GameObject healer;
    public Transform shotpoint;
    private float coneter = 0;
    public static int deathcounter = 0;
    public static int healcount = 0;
    private int type = 2;
    private int goal = 400;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void Start()
    {
        Vector3 p2 = new Vector3(0, 0, 0);
        if (type == 1)
            goal = 600;
        else if (type == 2)
            goal = 200;
        healer = healpref;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && coneter > goal)
        {
            GetFunction();
            coneter = 0;
        }
        coneter++;
        coneter += Time.deltaTime;
    }
    void GetFunction()
    {
        if (type == 0)
        {
            Instantiate(bullet, shotpoint.position, shotpoint.rotation);
        }
        else if (type == 1)
        {
            Instantiate(mine, shotpoint.position, Quaternion.Euler(0, 0, 0));
        }
        else if (type == 2)
        {
            Instantiate(heal, shotpoint.position, shotpoint.rotation);
        }
    }
    public static void doHeal(Vector3 enem)
    {
        healcount++;
        if (healcount == 4)
        {
            healcount = 0;
            Instantiate(healer, enem, Quaternion.Euler(0, 0, 0));
        }
    }

}
