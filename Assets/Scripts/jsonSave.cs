using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class jsonSave : MonoBehaviour
{
    public GameObject[] objects;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.L))
        {
            TEST();
        }
    }
    public void TEST()
    {
        SaveLoadObjects data = new SaveLoadObjects();
        Debug.Log("Saving file");

        objects = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject obj in objects)
        {
            data.objName = obj.name;
            data.posX = obj.transform.position.x;
            data.posY = obj.transform.position.y;
            data.posZ = obj.transform.position.z;

            string json = JsonUtility.ToJson(data, true);

            Debug.Log(json.ToString());
            Debug.Log();
            File.AppendText(json);
        }
    }
}