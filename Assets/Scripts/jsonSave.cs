using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class jsonSave : MonoBehaviour
{
    public GameObject[] objects;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            SaveLocations();
            Debug.Log("save stuff happening");
        }

        if (Input.GetKeyUp(KeyCode.L))
        {
            LoadLocations();
            Debug.Log("load stuff happening");
        }
    }

    public void SaveLocations()
    {
        List<SaveLoadObject> objectList = new List<SaveLoadObject>();

        Debug.Log("Saving file");

        objects = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject obj in objects)
        {
            SaveLoadObject data = new SaveLoadObject
            {
                objName = obj.name,
                posX = obj.transform.position.x,
                posY = obj.transform.position.y,
                posZ = obj.transform.position.z
            };
            objectList.Add(data);
        }

        objects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in objects)
        {
            SaveLoadObject data = new SaveLoadObject
            {
                objName = obj.name,
                posX = obj.transform.position.x,
                posY = obj.transform.position.y,
                posZ = obj.transform.position.z
            };
            objectList.Add(data);
        }

        SaveLoadObjectsWrapper wrapper = new SaveLoadObjectsWrapper { objects = objectList };
        string json = JsonUtility.ToJson(wrapper, true);

        string path = Application.persistentDataPath + "/SavedObjects.json";
        File.WriteAllText(path, json);
        Debug.Log("File saved at: " + path);
    }

    public void LoadLocations()
    {
        string path = Application.persistentDataPath + "/SavedObjects.json";

        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found.");
            return;
        }

        string json = File.ReadAllText(path);
        SaveLoadObjectsWrapper wrapper = JsonUtility.FromJson<SaveLoadObjectsWrapper>(json);

        foreach (SaveLoadObject data in wrapper.objects)
        {
            GameObject obj = GameObject.Find(data.objName);

            if (obj != null)
            {
                obj.transform.position = new Vector3(data.posX, data.posY, data.posZ);
                Debug.Log("Loaded position for " + data.objName);
            }
            else
            {
                Debug.LogWarning("Object with name " + data.objName + " not found in scene.");
            }
        }
    }

}

[System.Serializable]
public class SaveLoadObject
{
    public string objName;
    public float posX;
    public float posY;
    public float posZ;
}

[System.Serializable]
public class SaveLoadObjectsWrapper
{
    public List<SaveLoadObject> objects;
}
