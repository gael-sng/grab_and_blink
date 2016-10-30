﻿using UnityEngine;
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
    static List<Material> TEXTURES = new List<Material>();
    static List<string> COLOR = new List<String>();

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 2 - 7, Screen.height / 2 - 7, 14, 14), centerTexture);
    }
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        
        amulet = null;

        COLOR.Add("yellow");
        COLOR.Add("red");
        COLOR.Add("marine");
        COLOR.Add("green");
        COLOR.Add("purple");
        COLOR.Add("pink");
        COLOR.Add("orange");
        COLOR.Add("anil");

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

        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave1.mat", typeof(Material)));
        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave2.mat", typeof(Material)));
        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave3.mat", typeof(Material)));
        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave4.mat", typeof(Material)));
        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave5.mat", typeof(Material)));
        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave6.mat", typeof(Material)));
        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave7.mat", typeof(Material)));
        TEXTURES.Add((Material)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Objects/Chave/Materials/Chave8.mat", typeof(Material)));
    }
    
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            
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
                            GetComponent<GUIController>().GotAmuletMessage(COLOR[Convert.ToInt32(amulet.Remove(0, 1)) - 1]);
                            hit.transform.gameObject.GetComponent<Renderer>().material = TEXTURES[Convert.ToInt32(aux.Remove(0, 1)) - 1];
                        }
                        else //Não tenho amuleto, pego ele
                        {
                            //Mensagem
                            amulet = hit.collider.gameObject.tag;
                            GetComponent<GUIController>().GotAmuletMessage(COLOR[Convert.ToInt32(amulet.Remove(0, 1)) - 1]);
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else if (KEYS.Contains(hit.collider.gameObject.tag)) //Se mirou em uma chave
                    {                                                    //Pega a chave e coloca no inventário
                        keys.Add(hit.collider.gameObject.tag);
                        GetComponent<GUIController>().GotKeyMessage(COLOR[Convert.ToInt32(hit.collider.gameObject.tag.Remove(0, 1)) - 1]);
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
                             GetComponent<GUIController>().DontHaveKeyMessage();
                        }
                    }
            }
        } else if (Input.GetMouseButtonDown(1)) { //Tentando teeportar pela porta
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
                    else
                    {
                        GetComponent<GUIController>().DontHaveAmuletMessage();
                    }
                    //blink animation
                }
            }
        }
    }
}
