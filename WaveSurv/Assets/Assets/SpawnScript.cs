using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class SpawnScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject mine;
    public GameObject heal;
    public GameObject mitos;
    public GameObject boomer;
    [SerializeField] private GameObject healpref;
    public static GameObject healer;
    public Transform shotpoint;
    private float coneter = 0;
    public static int deathcounter = 0;
    public static int healcount = 0;
    private int type = 4;
    private float goal = 400;
    public static Transform shotPoint2;
    public static Transform targetTransform;
    private GameObject targetObject;
    public static bool retrieval = false;
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
        else if (type == 3)
            goal = 800;
        else if (type == 4)
        {
            retrieval = true;
            goal = Mathf.Infinity;
        }
        healer = healpref;
        try
        {
            // Ensure the tag exists and is assigned in the Tag Manager
            targetObject = GameObject.FindWithTag("PBug");

            if (targetObject != null)
            {
                targetTransform = targetObject.transform;
            }
            else
            {
            }
        }
        catch (UnityException e)
        {
        }
    }


        // Update is called once per frame
        void Update()
    {
        if (Keyboard.current.spaceKey.isPressed && (coneter > goal || retrieval))
        {
            GetFunction();
            coneter = 0;
        }
        coneter++;
        coneter += Time.deltaTime;
        targetTransform = targetObject.transform;
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
        else if (type == 3)
        {
            Instantiate(mitos, shotpoint.position, shotpoint.rotation);
        }
        else if (type == 4)
        {
            Instantiate(boomer, shotpoint.position, shotpoint.rotation);
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
