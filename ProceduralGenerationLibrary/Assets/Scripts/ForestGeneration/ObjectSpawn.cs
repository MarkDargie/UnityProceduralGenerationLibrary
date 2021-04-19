using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{

    public GameObject[] ObjectsToSpawn;

    public int numberOfObjectsToSpawn = 10;

    public GameObject SingleObjectToSpwan;
    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

    public Transform ParentObject;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(spawn());

    }

    void SelectSingleObjectToSpawn()
    {
        int RandomObjectIndex = Random.Range(0, ObjectsToSpawn.Length);
        GameObject ObjectClone = Instantiate(ObjectsToSpawn[RandomObjectIndex], transform.position, Quaternion.identity);
    }

    void SpawnObjects()
    {
        int RandomObjectIndex = Random.Range(0, ObjectsToSpawn.Length);

        Vector3 RandomPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        GameObject ClonedObject = Instantiate(ObjectsToSpawn[RandomObjectIndex], RandomPosition, Quaternion.Euler(new Vector3(0, Random.Range(0,360), 0) ));
        ClonedObject.transform.parent = ParentObject;
    }

    IEnumerator spawn()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            SpawnObjects();

            yield return new WaitForSeconds(0.05f);

        }


    }

}
