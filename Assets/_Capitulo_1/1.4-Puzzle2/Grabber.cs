using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectecObject;

    private void Update(){
        if (Input.GetMouseButtonDown(0)){
            if (selectecObject == null){
                RaycastHit hit = CastRay();

                if (hit.collider != null){
                    if (!hit.collider.CompareTag("drag")){
                        return;
                    }

                    selectecObject = hit.collider.gameObject;
                    Cursor.visible = false;
                }
            }
            else{
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectecObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
                selectecObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, selectecObject.transform.position.z);

                selectecObject = null;
                Cursor.visible = true; 
            }
        }

        if (selectecObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectecObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectecObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, selectecObject.transform.position.z);

            if (Input.GetMouseButtonDown(1))
            {
                selectecObject.transform.rotation = Quaternion.Euler(new Vector3(selectecObject.transform.rotation.eulerAngles.x, selectecObject.transform.rotation.eulerAngles.y + 90f , selectecObject.transform.rotation.eulerAngles.z)); 
            }
        }
    }

    private RaycastHit CastRay(){
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }
}