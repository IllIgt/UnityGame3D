using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Camera))]
public class RayShooter : MonoBehaviour
{
    public enum MouseButtons
    {
        leftButton = 0,
        rightButton = 1
    }

    public int hitLifetime = 4;
    public int markSize = 12;
    public MouseButtons shootButton = MouseButtons.leftButton;
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnGUI()
    {
        float positionX = _camera.pixelWidth / 2;
        float positionY = _camera.pixelHeight / 2;
        GUI.Label(new Rect(positionX, positionY, markSize, markSize), "*");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown((int)shootButton))
        {
            Vector3 point = new Vector3(
                _camera.pixelWidth / 2,
                _camera.pixelHeight / 2,
                0
            );
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                } else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        
        yield return new WaitForSeconds(hitLifetime);
        
        Destroy(sphere);
    }
}
