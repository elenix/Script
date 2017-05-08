using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int rangePositionX = 0, rangePositionY = 0, rangePositionZ = 0;
    int posX = 0, posY = 0, posZ = 0;
    public float timer = 0;
    public List<GameObject> ObjectList = new List<GameObject>();

    void Start()
    {
        InvokeRepeating("SpawnObj", 0, timer);
    }

    void SpawnObj()
    {
        GameObject gObject;
        int random = Random.Range(0, ObjectList.Count);

        posX = Random.Range(-rangePositionX, rangePositionX);
        posY = Random.Range(-rangePositionY, rangePositionY);
        posZ = Random.Range(100, rangePositionZ);

        gObject = Instantiate(ObjectList[random], new Vector3(posX, posY, posZ), Quaternion.identity) as GameObject;
    }
}
