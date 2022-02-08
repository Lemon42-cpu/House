using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightScript: MonoBehaviour
{
    public Light[] lights;
    private bool lightsTurned = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            foreach (Light l in lights)
            {
                l.enabled = !l.enabled;
            }
        }
    }
}
