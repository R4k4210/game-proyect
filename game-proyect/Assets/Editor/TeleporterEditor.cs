using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
 * 
 * This work is licensed under a Creative Commons Attribution 4.0 International License. https://creativecommons.org/licenses/by/4.0/
 * You are free to:
Share — copy and redistribute the material in any medium or format
Adapt — remix, transform, and build upon the material
for any purpose, even commercially.
 This license is acceptable for Free Cultural Works.
The licensor cannot revoke these freedoms as long as you follow the license terms.
Under the following terms:
Attribution — You must give appropriate credit, provide a link to the license, and indicate if changes were made. You may do so in any reasonable manner, but not in any way that suggests the licensor endorses you or your use.


 Custom Script Editor made by Erdrako - 07/06/2018
 Visit www.erdrako.com or email at erdrako@erdrako.com for contact
 If you manage to use this code you must credit me as the Creative Commons License specifies.
 */


/// <summary>
/// 
/// </summary>
[CustomEditor(typeof(Teleport))]
public class TeleporterEditor : Editor {


    /// <summary>
    /// 
    /// </summary>
    public override void OnInspectorGUI()
    {
        Teleport myScript = (Teleport)target;
        TeleportType teleType = myScript.teleportType;
        myScript.teleportType = (TeleportType)EditorGUILayout.EnumPopup(myScript.teleportType);
        if(myScript.Objetive == null)
        {
            myScript.Objetive = new GameObject();
        }
        switch (teleType)
        {
            case TeleportType.Coordenadas:
                myScript.VectorTarget = EditorGUILayout.Vector3IntField(new GUIContent("Coordenadas :", "Escriba las coordenadas en ENTEROS de la posicion hacia donde se desea teletransportar."), myScript.VectorTarget);
                myScript.Objetive.transform.position = myScript.VectorTarget;
                break;
            case TeleportType.Nombre:
                myScript.target = EditorGUILayout.TextField(new GUIContent("Nombre del objeto :", "Nombre del objeto hacia donde se va a teletransportar."), myScript.target);
                myScript.Objetive = GameObject.Find(myScript.target);
                break;
            case TeleportType.Referencia:
                myScript.Objetive = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Objeto de referencia:", "Arrastre el objeto hacia el cual se quiere teletransportar."), myScript.Objetive,typeof(GameObject));
                break;
            default:
                break;
        }
    }
}
