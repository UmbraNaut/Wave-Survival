using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SpriteRenderer sprender;
    public Sprite[] sprArray;
    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
    }
    public float counter = 0;
    public static float myr = 0.0f;
    public static float myf;
    public static float myv;
    public static float trackf;
    public static float trackv;
    public static float cont2 = 0;
    public static int con1 = 0;
    // Update is called once per frame
    void Update()
    {
        myf = 0.0f;
        myv = 0.0f;
        if (Keyboard.current.aKey.isPressed)
        {
            myf = -1.0f;
            myr = 90.0f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            myf = 1.0f;
            myr = 270.0f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            myv = -1.0f;
            myr = 180.0f;
        }
        if (Keyboard.current.wKey.isPressed)
        {
            myv = 1.0f;
            myr = 0.0f;
        }
        if (myv == 1.0f && myf == 1.0f)
        {
            myr = 315;
            myv /= Mathf.Sqrt(2);
            myf /= Mathf.Sqrt(2);
            con1 = 1;
            cont2 = 20;
        }
        if (myv == -1.0f && myf == 1.0f)
        {
            myr = 225;
            myv /= Mathf.Sqrt(2);
            myf /= Mathf.Sqrt(2);
            con1 = 2;
            cont2 = 20;
        }
        if (myv == -1.0f && myf == -1.0f)
        {
            myr = 135;
            myv /= Mathf.Sqrt(2);
            myf /= Mathf.Sqrt(2);
            con1 = 3;
            cont2 = 20;
        }
        if (myv == 1.0f && myf == -1.0f)
        {
            myr = 45;
            myv /= Mathf.Sqrt(2);
            myf /= Mathf.Sqrt(2);
            con1 = 4;
            cont2 = 20;
        }
        Animation();
        if (myf != 0.0f || myv != 0.0f)
        {
            trackf = myf;
            trackv = myv;
        }
        if (myf == 0.0f && myv == 0.0f)
        {
            if (cont2 > 1)
            {
                switch (con1)
                {
                    case 1:
                        myr = 315;
                        trackf = 1 / Mathf.Sqrt(2);
                        trackv = 1 / Mathf.Sqrt(2);
                        break;
                    case 2:
                        myr = 225;
                        trackf = 1 / Mathf.Sqrt(2);
                        trackv = -1 / Mathf.Sqrt(2);
                        break;
                    case 3:
                        myr = 135;
                        trackf = -1 / Mathf.Sqrt(2);
                        trackv = -1 / Mathf.Sqrt(2);
                        break;
                    case 4:
                        myr = 45;
                        trackf = -1 / Mathf.Sqrt(2);
                        trackv = 1 / Mathf.Sqrt(2);
                        break;
                }
            }
        }
        if (cont2 > 0)
        {
            cont2 -= Time.deltaTime*60;
        }
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)) >= 64.6)
        {
            float thex = transform.position.x;
            float they = transform.position.y;
            float thehyp = Mathf.Sqrt((thex * thex) + (they * they));
            myf = -(transform.position.x / thehyp);
            myv = -(transform.position.y / thehyp);
        }
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2)) <= 6)
        {
            float thex = transform.position.x;
            float they = transform.position.y;
            float thehyp = Mathf.Sqrt((thex * thex) + (they * they));
            myf = (transform.position.x / thehyp);
            myv = (transform.position.y / thehyp);
        }
        Vector2 position = transform.position;
        position.x = position.x + Time.deltaTime * (myf) * 15f;
        position.y = position.y + Time.deltaTime * (myv) * 15f;
        transform.rotation = Quaternion.Euler(0f, 0f, myr);
        transform.position = position;
    }
    void Animation()
    {
        if (myv != 0.0f || myf != 0.0f)
        {
            counter += Time.deltaTime * 150;
            if (counter / 120 > 1)
            {
                sprender.sprite = sprArray[0];
                counter = 0;
            }
            else if (counter / 90 > 1)
                sprender.sprite = sprArray[1];
            else if (counter / 60 > 1)
                sprender.sprite = sprArray[2];
            else if (counter / 30 > 1)
                sprender.sprite = sprArray[1];
        }
        else
        {
            counter = 0;
            sprender.sprite = sprArray[0];
        }
    }
}

