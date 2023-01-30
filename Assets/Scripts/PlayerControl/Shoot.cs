using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Camera _currentCamera;


    void Start()
    {
        _currentCamera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 position = new Vector3(_currentCamera.pixelWidth / 2, _currentCamera.pixelHeight / 2, 0);
            
            Ray ray = _currentCamera.ScreenPointToRay(position);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                StartCoroutine(SpawnSphere(hit.point));
            }
        }
    }

    private void OnGUI()
    {
        float size = 12;
        float positionX = _currentCamera.pixelWidth / 2;
        float positionY = _currentCamera.pixelHeight / 2;

        GUI.Label(new Rect(positionX, positionY, size, size), "*");
    }

    private IEnumerator SpawnSphere(Vector3 spawnPosition)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = spawnPosition;

        yield return new WaitForSeconds(3);

        Destroy(sphere);
    }
}
