using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingHook : MonoBehaviour
{
    public Camera MainCamera;
    public LineRenderer LineRenderer;
    public DistanceJoint2D DistanceJoint;
    public Rigidbody2D RB;
    public float force;

    private Vector3 MouseDir;
    public Transform LinePosition;
    public bool CanGrappling;
    // Start is called before the first frame update
    void Start()
    {
        CanGrappling = true;
        DistanceJoint.autoConfigureDistance = true;
        DistanceJoint.enabled = false;
        LineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        MouseDir = MainCamera.ScreenToWorldPoint(Input.mousePosition);

		if (CanGrappling == true)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
                Vector2 MousePos = (Vector2)MainCamera.ScreenToWorldPoint(Input.mousePosition);
                LineRenderer.SetPosition(0, MousePos);

                DistanceJoint.connectedAnchor = MousePos;
                DistanceJoint.enabled = true;
                LinePosition.position = MousePos;


			}
			if (Input.GetKey(KeyCode.Mouse0))
			{
                LineRenderer.SetPosition(1, transform.position);
                LineRenderer.enabled = true;
			}
            else if (Input.GetKeyUp(KeyCode.Mouse0))
			{
                DistanceJoint.enabled = false;
                LineRenderer.enabled = false;
			}

            if(DistanceJoint.enabled == true)
			{
                LineRenderer.SetPosition(1, transform.position);
			}

			if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Mouse0))
			{
                Vector3 Direction = LinePosition.position - transform.position;

                RB.velocity = new Vector2(Direction.x * force, Direction.y * force).normalized * force * Time.deltaTime;
                DistanceJoint.enabled = false;
			}
            if(Input.GetKeyUp(KeyCode.E)&& Input.GetKey(KeyCode.Mouse0))
			{
                DistanceJoint.enabled = true;
			}
		}
        
    }
}
