using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Teleport))]
public class TeleporterEditor : Editor {

    public override void OnInspectorGUI()
    {
        Teleport myScript = (Teleport)target;
        TeleportType teleType =  myScript.teleportType /*= GUILayout.Toggle(myScript.flag, "Flag")*/;
        myScript.teleportType = (TeleportType)EditorGUILayout.EnumPopup(myScript.teleportType);
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
