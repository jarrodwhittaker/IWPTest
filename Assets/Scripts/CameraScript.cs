using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Vector3 currentMousePos;
    Vector3 startingMousePos;
    Vector3 cameraLoc;
    public bool isMouseDown;
    public float scale = 2;
    float minSize = 30f;
    float maxSize = 80f;
    float sensitivity = 5f;
    float zoom;
    public float minZ;
    public float maxZ;
    public float minX;
    public float maxX;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            cameraLoc = Camera.main.transform.position;
            startingMousePos = Input.mousePosition;

        }
        if (Input.GetMouseButton(0))
        {
            Vector3 newMousePos = Input.mousePosition - startingMousePos;
            newMousePos.z = newMousePos.y;
            newMousePos.y = 0;

            Vector3 newLocation = cameraLoc + -newMousePos * scale;

            newLocation.x = Mathf.Clamp(newLocation.x, minX, maxX);
            newLocation.z = Mathf.Clamp(newLocation.z, minZ, maxZ);

            Camera.main.transform.position = newLocation;
        }


        if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }

        zoom = Camera.main.orthographicSize;
        zoom += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        zoom = Mathf.Clamp(zoom, minSize, maxSize);
        Camera.main.orthographicSize = zoom;
    }

    /*    
        // VARIABLES
        //

        public float turnSpeed = 35.0f;         // Speed of camera turning when mouse moves in along an axis
        public float panSpeed = 360.0f;         // Speed of the camera when being panned
        public float zoomSpeed = 500.0f;        // Speed of the camera going back and forth

        public float turnDrag = 5.0f;           // RigidBody Drag when rotating camera
        public float panDrag = 3.5f;            // RigidBody Drag when panning camera
        public float zoomDrag = 3.3f;           // RigidBody Drag when zooming camera

        private Vector3 mouseOrigin;            // Position of cursor when mouse dragging starts
        private bool isPanning;             // Is the camera being panned?
        private bool isRotating;            // Is the camera being rotated?
        private bool isZooming;             // Is the camera zooming?
        private Rigidbody rigidbody;
        //
        // AWAKE
        //

        void Awake()
        {
            // Setup camera physics properties
            rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.useGravity = false;
        }

        //
        // UPDATE: For input
        //

        void Update()
        {
            // == Getting Input ==

            // Get the left mouse button
            /*if (Input.GetMouseButtonDown(0))
            {
                // Get mouse origin
                mouseOrigin = Input.mousePosition;
                isRotating = true;
            }

            // Get the right mouse button
            if (Input.GetMouseButtonDown(0))
            {
                // Get mouse origin
                mouseOrigin = Input.mousePosition;
                isPanning = true;
            }

            // Get the middle mouse button
            if (Input.GetMouseButtonDown(2))
            {
                // Get mouse origin
                mouseOrigin = Input.mousePosition;
                isZooming = true;
            }


            // == Disable movements on Input Release ==

            //if (!Input.GetMouseButton(0)) isRotating = false;
            if (!Input.GetMouseButton(0)) isPanning = false;
            if (!Input.GetMouseButton(2)) isZooming = false;

        }

        //
        // Fixed Update: For Physics
        //

        void FixedUpdate()
        {
            // == Movement Code ==

            // Rotate camera along X and Y axis
            /*if (isRotating)
            {
                // Get mouse displacement vector from original to current position
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                // Set Drag
                rigidbody.angularDrag = turnDrag;

                // Two rotations are required, one for x-mouse movement and one for y-mouse movement
                rigidbody.AddTorque(-pos.y * turnSpeed * transform.right, ForceMode.Acceleration);
                rigidbody.AddTorque(pos.x * turnSpeed * transform.up, ForceMode.Acceleration);
            }

            // Move (pan) the camera on it's XY plane
            if (isPanning)
            {
                // Get mouse displacement vector from original to current position
                Vector3 pos = -Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
                Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);

                // Apply the pan's move vector in the orientation of the camera's front
                Quaternion forwardRotation = Quaternion.LookRotation(transform.forward, transform.up);
                move = forwardRotation * move;

                // Set Drag
                rigidbody.drag = panDrag;

                // Pan
                rigidbody.AddForce(move, ForceMode.Acceleration);
            }

            // Move the camera linearly along Z axis
            if (isZooming)
            {
                // Get mouse displacement vector from original to current position
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
                Vector3 move = pos.y * zoomSpeed * transform.forward;

                // Set Drag
                rigidbody.drag = zoomDrag;

                // Zoom
                rigidbody.AddForce(move, ForceMode.Acceleration);
            }
        }
        */


}