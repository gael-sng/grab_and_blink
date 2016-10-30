using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

    public Texture2D centerTexture;
    public Animator eyeAnimator;
    public string amulet;
    List<string> keys = new List<string>(); //suas chaves

    static List<string> KEYS = new List<string>();
    static List<string> DOORS = new List<string>();
    static List<string> AMULETS = new List<string>();
    static List<Texture> TEXTURES = new List<Texture>();

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - 7, Screen.height / 2 - 7, 14, 14), centerTexture);
    }

    // Use this for initialization
    void Start() {
        Cursor.visible = false;
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
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 0.6f))
            {
                    print("Hit something at distance " + hit.distance + ". " + hit.collider.gameObject.tag);

                    if (AMULETS.Contains(hit.collider.gameObject.tag)) //Se mirou um amuleto
                    {

                        if (amulet != null) //Já tenho um amuleto
                        {                   //Troca os amuletos de lugar
                            string aux = amulet;
                            amulet = hit.collider.gameObject.tag;
                            hit.collider.gameObject.tag = aux;
                            hit.transform.gameObject.GetComponent<Renderer>().material.mainTexture = TEXTURES[Convert.ToInt32(aux.Remove(0, 1))];
                        }
                        else //Não tenho amuleto, pego ele
                        {
                            amulet = hit.collider.gameObject.tag;
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if (KEYS.Contains(hit.collider.gameObject.tag)) //Se mirou em uma chave
                    {                                                    //Pega a chave e coloca no inventário
                        keys.Add(hit.collider.gameObject.tag);
                        Destroy(hit.collider.gameObject);

                    }
                    else if (DOORS.Contains(hit.collider.gameObject.tag)) //Se mirou em uma porta (tenta abrir)
                    {
                        if (keys.Contains("K" + hit.collider.gameObject.tag.Remove(0, 1))) //Tem a chave certa
                        {
                            hit.collider.gameObject.SendMessageUpwards("Open");            //Abre a porta
                            keys.Remove("K" + hit.collider.gameObject.tag.Remove(0, 1));   //Remove chave do inventario
                        }
                        else
                        {
                            //Mensagem de "Não conseguiu abrir a porta"
                        }
                    }
            }
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            //CheckPoint
        } else if (Input.GetKeyDown(KeyCode.F)) { //Tentando teeportar pela porta
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 0.6f))
            {
                if (amulet.Equals("A" + hit.collider.gameObject.tag.Remove(0, 1))) //Tem o amuleto certo
                {
                    print("Porta tag: " + hit.collider.tag);
                    if (DOORS.Contains(hit.collider.tag))
                    {
                        transform.position = hit.collider.GetComponentInParent<DoorOpening>().GetTeleportPosition(transform.position);
                    }
                    //blink
                }
            }
        }
    }
}
