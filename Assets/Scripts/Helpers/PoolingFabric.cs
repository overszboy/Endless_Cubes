using System.Collections.Generic;
using UnityEngine;

public class PoolingFabric : IService
{
    private readonly GameObject  prefub;
    private readonly Stack<GameObject> stackOfObjects;

    public PoolingFabric(GameObject obj)
    {
        prefub = obj;
        stackOfObjects = new Stack<GameObject>();
    
    }
   

   
    public GameObject CreateObject(Transform transform, Transform parent)
    {
        if (stackOfObjects.Count > 0)
        {
            GameObject obj = stackOfObjects.Pop();
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.transform.parent = parent;
            obj.SetActive(true);
            return obj;
            
        }
        else
        {
            return GameObject.Instantiate(prefub, transform.position, transform.rotation, parent);
        }
    }
        public GameObject CreateObject(Transform transform)
        {
            if (stackOfObjects.Count > 0)
            {
                GameObject obj = stackOfObjects.Pop();
                
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                obj.SetActive(true);

                return obj;
            }
            else
            {
                return GameObject. Instantiate(prefub, transform.position, transform.rotation);
            }
        }
    public GameObject CreateObject(Vector3 position ,Quaternion rotation)
    {
        if (stackOfObjects.Count > 0)
        {
            GameObject obj = stackOfObjects.Pop();

            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);

            return obj;
        }
        else
        {
            return GameObject.Instantiate(prefub, position, rotation);
        }
    }


    public void PushToStack( GameObject obj)
    {

        obj.SetActive(false);
        obj.transform.parent = null;
        stackOfObjects.Push(obj);
        
    }
   

}
