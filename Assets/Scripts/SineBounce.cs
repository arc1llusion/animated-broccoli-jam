using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineBounce : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float BounceAmplitude = 3.0f;

    [SerializeField]
    private float BounceSpeed = 2.0f;

    private Vector3 startingPosition = Vector3.zero;
    private float totalDeltaTime = 0.0f;

    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        totalDeltaTime += Time.deltaTime;
        var sin = (Mathf.Sin(totalDeltaTime * BounceSpeed) * BounceAmplitude) * Time.deltaTime;

        transform.Translate(new Vector3(0.0f, sin, 0.0f), Space.Self);
    }

    private void OnDisable()
    {
        totalDeltaTime = 0;
    }
}
