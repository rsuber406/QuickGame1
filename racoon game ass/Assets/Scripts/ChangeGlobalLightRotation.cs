using UnityEngine;

public class ChangeGlobalLightRotation : MonoBehaviour
{
    [SerializeField] GameObject globalDirectionalLight;
    public float xRotation = 0;
    public float yRotation = 0;
    public float zRotation = 0;

    // Update is called once per frame
    void Update()
    {
        globalDirectionalLight.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
    }
}
