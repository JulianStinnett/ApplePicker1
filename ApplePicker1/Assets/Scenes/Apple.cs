using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // Start is called before the first frame update
    public static float bottomY = -20f;
    // b

    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            //

            ApplePicker apScript =
            Camera.main.GetComponent<ApplePicker>(); // b
                                                     // Call the public AppleMissed() method of apScript
            apScript.AppleMissed();

        }
    }
}