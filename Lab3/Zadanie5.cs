using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie5 : MonoBehaviour
{
    // Instantiates prefabs in a circle formation
    public GameObject block;
    public int numberOfObjects = 10;
    private List<float> listOfValuesX = new List<float>();
    private List<float> listOfValuesZ = new List<float>();
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            var position = new Vector3(Mathf.Round(Random.Range(-49.0f, 49.0f) * 10f) * 0.1f, 25, Mathf.Round(Random.Range(-49.0f, 49.0f) * 10f) * 0.1f);
            if (listOfValuesX.Contains(position.x) && listOfValuesZ.Contains(position.z))
            {
                for (int j = 0; j < numberOfObjects; j++)
                {
                    do
                    {
                        position = new Vector3(Mathf.Round(Random.Range(-49.0f, 49.0f) * 10f) * 0.1f, 25, Mathf.Round(Random.Range(-49.0f, 49.0f) * 10f) * 0.1f);
                    } while (listOfValuesX.Contains(position.x) && listOfValuesZ.Contains(position.z));
                }
            }
            listOfValuesX.Add(position.x);
            listOfValuesZ.Add(position.z);
            Instantiate(block, position, Quaternion.identity);
        }

        for (int i = 0; i < listOfValuesX.Count; i++)
        {
            Debug.Log($"Cube number{i} X: {listOfValuesX[i]} Z: {listOfValuesZ[i]}");
        }
    }
}
