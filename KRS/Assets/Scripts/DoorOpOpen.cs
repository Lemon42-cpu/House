using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpOpen : MonoBehaviour
{
    public GameObject door;
    private bool isOpen = false;
    private Renderer RenderProp;
    public GameObject MainCharacter;
    public GameObject Door;
    public int distance = 10;
    // Start is called before the first frame update
    void Start()
    {
        RenderProp = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        // откр
        if (isOpen == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Vector3.Distance(MainCharacter.transform.position, Door.transform.position) <= distance)
                {
                    door.transform.Rotate(0f, 0f, -90f);
                    isOpen = true;
                }
            }
        }
        if (isOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (Vector3.Distance(MainCharacter.transform.position, Door.transform.position) <= distance)
                {
                    door.transform.Rotate(0f, 0f, 90f);
                    isOpen = false;
                }
            }
        }

    }

}
