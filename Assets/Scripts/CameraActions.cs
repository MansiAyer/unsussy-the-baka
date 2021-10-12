using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraActions : MonoBehaviour
{
    public Transform followTransform;
    public Tilemap mapBounds;

    private float xMin, xMax, yMin, yMax;
    private float camY, camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;
    //private Vector3 smoothPos;
    Vector3 smoothPos;
    public float smoothSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        xMin = mapBounds.localBounds.min.x;
        xMax = mapBounds.localBounds.max.x;
        yMin = mapBounds.localBounds.min.y;
        yMax = mapBounds.localBounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        //camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        //smoothPos = Vector3.Lerp(this.transform.position, new Vector3(camX, camY, this.transform.position.z), smoothSpeed);
        smoothPos = new Vector3(followTransform.position.x, followTransform.position.y, transform.position.z);
        this.transform.position = smoothPos;
    }
}
