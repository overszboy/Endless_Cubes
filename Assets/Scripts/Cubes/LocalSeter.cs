using UnityEngine;

public class LocalSeter : MonoBehaviour
{
    
    void Update()
    {
        transform.localPosition = new Vector3(0f,transform.localPosition.y,0f);
        
    }
}
