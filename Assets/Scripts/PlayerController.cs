using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerController : MonoBehaviour {

    public Animator eyeAnimator;
    public string amulet;
    List<string> keys = new List<string>(); //suas chaves
    public float grabDistance = 2.5f;

    static List<string> KEYS = new List<string>();
    static List<string> DOORS = new List<string>();
    static List<string> AMULETS = new List<string>();
    static List<Texture> TEXTURES = new List<Texture>();


    // Use this for initialization
    void Start () {
		//Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
        
        amulet = null;

        KEYS.Add("K1");
        KEYS.Add("K2");
        KEYS.Add("K3");
        KEYS.Add("K4");
        KEYS.Add("K5");
        KEYS.Add("K6");
        KEYS.Add("K7");
        KEYS.Add("K8");

        DOORS.Add("D1");
        DOORS.Add("D2");
        DOORS.Add("D3");
        DOORS.Add("D4");
        DOORS.Add("D5");
        DOORS.Add("D6");
        DOORS.Add("D7");
        DOORS.Add("D8");

        AMULETS.Add("A1");
        AMULETS.Add("A2");
        AMULETS.Add("A3");
        AMULETS.Add("A4");
        AMULETS.Add("A5");
        AMULETS.Add("A6");
        AMULETS.Add("A7");
        AMULETS.Add("A8");

        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
        TEXTURES.Add((Texture)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Textures/KnobTexture.png", typeof(Texture)));
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, grabDistance))
            {
                print("Hit something at distance " + hit.distance + ". " + hit.collider.gameObject.tag);

                print(hit.collider.gameObject.tag);

                if (AMULETS.Contains(hit.collider.gameObject.tag))
                {
                    if (amulet != null)
                    {
                        print("nao null");
                        string aux = amulet;
                        amulet = hit.collider.gameObject.tag;
                        hit.collider.gameObject.tag = aux;
                        hit.transform.gameObject.GetComponent<Renderer>().material.mainTexture = TEXTURES[Convert.ToInt32(aux.Remove(0, 1))];
                    }
                    else
                    {
                        print("null");
                        amulet = hit.collider.gameObject.tag;
                        Destroy(hit.collider.gameObject);
                    }
                }
                else if (KEYS.Contains(hit.collider.gameObject.tag)) // pegou a chave e colocou no inventário
                {
                    keys.Add(hit.collider.gameObject.tag);
                    Destroy(hit.collider.gameObject);

                }
                else if (DOORS.Contains(hit.collider.gameObject.tag)) // tenta usar a chave na porta
                {
                    if (keys.Contains("K" + hit.collider.gameObject.tag.Remove(0, 1))) //verifica se tem a chave certa
                    {
                        hit.collider.gameObject.SendMessageUpwards("Open");
                        keys.Remove("K" + hit.collider.gameObject.tag.Remove(0, 1)); //remove chave do inventario
                    }
                    else
                    {
                        //mensagem
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            //Load
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, grabDistance))
            {
                //Teleport
                //blink
            }
        }
    }
}
