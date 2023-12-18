
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float rotationSpeed = 100f;


    private void Update()
    {
       

      
       transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        
    }
}
