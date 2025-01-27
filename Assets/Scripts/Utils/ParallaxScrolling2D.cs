using UnityEngine;

public class ParallaxScrolling2D : MonoBehaviour
{
    public Transform cameraTransform;

    public Transform[] backgrounds;
    public float[] factors;
    public float[] factorsOffset;

    private Vector3 previousCameraPosition;

    private void Start()
    {
        previousCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - previousCameraPosition;

        for(int i = 0; i < backgrounds.Length; i++)
        {
            // Calculate parallax
            backgrounds[i].transform.position += new Vector3(deltaMovement.x * factors[i], 0, 0);

            // Loop the background
            if (Mathf.Abs(cameraTransform.position.x - backgrounds[i].transform.position.x) >= factorsOffset[i])
            {
                float offset = (cameraTransform.position.x - backgrounds[i].transform.position.x) % factorsOffset[i];
                backgrounds[i].transform.position = new Vector3(cameraTransform.position.x + offset, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);
            }
        }

        previousCameraPosition = cameraTransform.position;
    }
}