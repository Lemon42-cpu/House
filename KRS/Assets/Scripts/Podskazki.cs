using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Podskazki : MonoBehaviour {
    RotatingObject[] allObjects;
    RotatingObject target;
    Camera cam;

    public Text text;
    public float distanceToInteract = 1.7f;

    // Start is called before the first frame update
    void Start() {
        allObjects = FindObjectsOfType<RotatingObject>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update() {
        target = null;
        List<RotatingObject> closeObjects = new List<RotatingObject>();
        for (int i = 0; i < allObjects.Length; i++) {
            var dist = Vector3.Distance( cam.transform.position, allObjects[i].transform.position );
            if (dist < distanceToInteract) {
                closeObjects.Add( allObjects[i] );
            }
        }
        float closestDot = -1.0f;
        RotatingObject closest = null;
        for (int i = 0; i < closeObjects.Count; i++) {
            Vector3 dir = (closeObjects[i].transform.position - cam.transform.position).normalized;
            float dot = Vector3.Dot( dir, cam.transform.forward );
            if(dot >= closestDot) {
                closest = closeObjects[i];
                closestDot = dot;
            }
        }
        if (closest != null && closestDot > 0.20f) {
            target = closest;
        }
        if (target != null) {
            if (target.opened) {
                text.text = "Нажмите E чтобы закрыть";
            }
            else {
                text.text = "Нажмите E чтобы открыть";
            }
            if (Input.GetKeyDown( KeyCode.E )) {
                target.Interact();
            }
        }
        else {
            text.text = "";
        }
    }
}