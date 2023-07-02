using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class InputTest : MonoBehaviour
{
    public Camera cam;

    public Vector2 input = new Vector2(1, 0);
    public float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var flattenedInput = Quaternion.AngleAxis(-45, Vector3.up) * Quaternion.Euler(30.0f, 45.0f, 0.0f) *  new Vector3(input.x, 0, input.y).normalized;
        DebugExtension.DebugArrow(this.transform.position, flattenedInput, Color.red);


        var projected = Vector3.ProjectOnPlane(flattenedInput, cam.gameObject.transform.forward);
        DebugExtension.DebugArrow(this.transform.position, projected, Color.green);


        angle = Vector2.Angle(Vector2.right, projected);
    }
}
