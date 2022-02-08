using UnityEngine;

public class RotatingObject : MonoBehaviour {

    private bool isMoving = false;
    private float rotatedDegrees = 0;

    [HideInInspector]
    public bool opened = false;
    public float degreesPerSecond = 45f;
    public float maxDegrees = 85;
    public bool xDir;
    public bool yDir;
    public bool zDir = true;

    private void Update() {
        if (isMoving) {
            float deg = opened ? degreesPerSecond : -degreesPerSecond;
            deg *= Time.deltaTime;

            if (opened && rotatedDegrees + Mathf.Abs( deg ) >= maxDegrees) {
                deg = (maxDegrees - rotatedDegrees) * Mathf.Sign( deg );

                isMoving = false;
            }
            else if (!opened && rotatedDegrees - Mathf.Abs( deg ) <= 0) {
                deg = rotatedDegrees * Mathf.Sign( deg );

                isMoving = false;
            }
            if (opened) {
                rotatedDegrees += Mathf.Abs( deg );
            }
            else {
                rotatedDegrees -= Mathf.Abs( deg );
            }
            Vector3 vector = new Vector3();
            if (xDir)
                vector.x = deg;
            else if (yDir)
                vector.y = deg;
            else if (zDir)
                vector.z = deg;
            transform.Rotate( vector );
        }
    }

    public void Interact() {
        opened = !opened;
        isMoving = true;
    }
}
