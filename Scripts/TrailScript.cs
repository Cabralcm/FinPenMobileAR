using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using UnityEngine.UI;
#if UNITY_EDITOR
    // Set up touch input propagation while using Instant Preview in the editor.    
    using Input = GoogleARCore.InstantPreviewInput;
#endif


public class TrailScript : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject camera;
    private int buttonState;
    public GameObject info;
    public Button infoButton;

    public List<GameObject> Points = new List<GameObject>();
    public Color[] ColorBank;
    // public Color32[] priColorBank = {new Color32(255,0,0,255), new Color32(0,0,255,255), new Color32 (0,255,0,255), new Color32(255,255,255,255), new Color32 (0,0,0,255)};
    private Color[] priColorBank = {new Color(1, 1, 1, 1), new Color(1, 0, 1, 1), new Color(1, 1, 0, 1), new Color(0, 1, 0, 1), new Color(1, 1, 1, 1), new Color(0, 0, 0, 1)};

    private int color_flag;
    private int clear_flag;
    private Material m_Material;
    private int count;

    // Use this for initialization
    void Start()
    {
        info.SetActive(false);
        buttonState = 0;
        count = 0;
        //infoButton.on
        //int num = Random.Range(0, ColorBank.Length);

    }

    // Update is called once per frame
    void Update()
    {
        if(count > 0 && count < 20)
        {
            count++;
        }
        else
        {
            count = 0;
        }
        if (Input.touchCount == 0)
        {
            color_flag = 0; //reset colour option selection

            if(clear_flag == 1)
            {
                for (int i = Points.Count - 1; i >= 0; i--)
                {
                    Destroy(Points[i]);
                }
                clear_flag = 2;

                //Debug.Log("Touched");
                Vector3 camPos = camera.transform.position;
                Vector3 camDirection = camera.transform.forward;
                Quaternion camRotation = camera.transform.rotation;
                float spawnDistance = 2;
                //Debug.Log("Touched" + camPos.x + " " + camPos.y + " " + camPos.z);
                Vector3 spawnPos = camPos + (camDirection * spawnDistance);
                GameObject cur = Instantiate(gameObject, spawnPos, camRotation);
                cur.transform.SetParent(this.transform);
                Points.Add(cur);
              
            }
        }
        if (Input.GetMouseButton(0) || Input.touchCount == 1){

            //if (Input.GetTouch.transform
            Debug.Log(Input.GetTouch(0).position);

            Vector2 current_position = Input.GetTouch(0).position;
            if(count == 0 && current_position.x > 65 && current_position.x < 125 && current_position.y > 525 && current_position.y < 575)
            {
                TaskOnClick();
                count = 1;
            }

            if (clear_flag == 2)
            {
                for (int i = Points.Count - 1; i >= 0; i--)
                {
                    Destroy(Points[i]);
                }
            }
            //Debug.Log("Touched");

            //Vector3 camPos = camera.transform.position;
            //ector2 tapPoint = current_position;
            //Debug.Log(tapPoint.x);
            //Debug.Log(tapPoint.y);

            //apPoint.x = (-tapPoint.x / (float)(Screen.width)) + (0.5f);
            //tapPoint.y = (tapPoint.y / (float)(Screen.height)) - (0.5f);
            //Vector3 track = new Vector3(tapPoint.y, tapPoint.x, camPos.z);
            //Vector3 fingerPos = Camera.main.ScreenToViewportPoint(track); //Input.GetTouch(0).position ,camPos.z);
            //Vector3 camDirection = camera.transform.forward;
            //Quaternion camRotation = camera.transform.rotation;
            //Debug.Log("X Pos: " + current_position.x + " Y Pos: " + current_position.y);
            //float spawnDistance = 2;
            //Vector3 spawnPos = track + (camDirection * spawnDistance);
            //GameObject cur = Instantiate(gameObject, spawnPos, camRotation);
            //cur.transform.SetParent(this.transform);
            //Points.Add(cur);

            //// Previous way of drawing
            Debug.Log("Touched");
            Vector3 camPos = camera.transform.position;
            Vector3 camDirection = camera.transform.forward;
            Quaternion camRotation = camera.transform.rotation;
            Debug.Log("Touched" + camPos.x + " " + camPos.y + " " + camPos.z);
            float spawnDistance = 2;
            Vector3 spawnPos = camPos + (camDirection * spawnDistance);
            GameObject cur = Instantiate(gameObject, spawnPos, camRotation);
            cur.transform.SetParent(this.transform);
            Points.Add(cur);


            clear_flag = 0;

        }
        if (Input.touchCount == 2)
        {
            if (color_flag == 0)
            {
                int num = Random.Range(0, priColorBank.Length);

                Renderer rend = GetComponent<Renderer>();
                m_Material = rend.material;
                m_Material.color = priColorBank[num];

                //rend.material.shader = Shader.Find("_Color");
                //rend.material.SetColor("_Color", ColorBank[num]);

                //rend.material.shader = Shader.Find("Specular");
                //rend.material.SetColor("_SpecColor", ColorBank[num]);
                color_flag = 1;
            }

        }
        if (Input.touchCount >= 3)
        {
            clear_flag = 1;
           
        }
    }


    public void TaskOnClick()
    {

        if (buttonState == 0)
        {
            info.SetActive(true);
            buttonState = 1;
        }
        else if (buttonState == 1)
        {
            info.SetActive(false);
            buttonState = 0;
        }
    }
}