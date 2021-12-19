using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zadanie1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public int numberOfItemsToGenerate = 0;
    public float delay = 3f;
    private int objectCounter = 0;
    public GameObject block;
    public Material[] mats;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfItemsToGenerate; i++)
        {
            this.positions.Add(new Vector3(
                UnityEngine.Random.Range(this.transform.position.x, this.transform.position.x + 10), 
                5,
                UnityEngine.Random.Range(this.transform.position.z, this.transform.position.z + 10)
                )
            );
        }

        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }

        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("Wywołano Courutine");
        foreach (Vector3 pos in positions)
        {
            GameObject obj = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            int matIndex = UnityEngine.Random.Range(0, mats.Length);
            obj.GetComponent<MeshRenderer>().material = mats[matIndex];
            yield return new WaitForSeconds(this.delay);
        }

        StopCoroutine(GenerujObiekt());
    }
}
