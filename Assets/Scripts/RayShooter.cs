using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;

    
    
    void Start()
    {
        _camera = GetComponent<Camera>();

    }

    
    void Update()
    {
        


        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
		{
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
			{
                GameObject hitObject = hitInfo.transform.gameObject;
                Enemy enemy = hitObject.GetComponent<Enemy>();
                if (enemy != null)
				{
                    
                    enemy.gotHit();
                    
				}
                else
				{
                    StartCoroutine(SphereIndicator(hitInfo.point));
                }
                
			}
		}
    }


	private void OnGUI()
	{
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	private IEnumerator SphereIndicator (Vector3 pos)
	{
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
	}
}
