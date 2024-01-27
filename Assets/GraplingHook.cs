using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraplingHook : MonoBehaviour
{

    public LineRenderer LineRenderer;
    public DistanceJoint2D DistanceJoint;
    public Rigidbody2D RB;
    public float force;

    public Transform LinePosition;
    public bool CanGrappling;

    [SerializeField] Movmen Mov;

    [SerializeField] float Walkspeed;
    //Check vars
    [SerializeField] List<GameObject> points = new();

    [SerializeField, Range(0f, 360f)] private float maxAngle;
    [SerializeField, Range(0f, 5f)] private float maxDistance;

    private GameObject grapplePointSelected;

    Vector2 PointPos;

    bool isHanging=false;

    enum LastButtonPressed { None, A, D }
    LastButtonPressed lastButtonPressed = LastButtonPressed.None;

    // Start is called before the first frame update
    void Start()
    {
        CanGrappling = true;
        DistanceJoint.autoConfigureDistance = true;
        DistanceJoint.enabled = false;
        LineRenderer.enabled = false;


        if (points.Count <= 0)
        {
            Debug.Log("Inga points inlaggda");
        }
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKeyDown(KeyCode.D))
		{
            lastButtonPressed = LastButtonPressed.A;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lastButtonPressed = LastButtonPressed.D;
        }


        //Debug.DrawLine(transform.position + transform.right, transform.position + transform.right * 10f, Color.red, 10f);


		if (CanGrappling == true)
		{
            CheckIfInfront();
			if (Input.GetKeyDown(KeyCode.K))
			{
                if (grapplePointSelected == null) return;

                PointPos = grapplePointSelected.transform.position;

                LineRenderer.SetPosition(0, PointPos);

                DistanceJoint.connectedAnchor = PointPos;
                DistanceJoint.enabled = true;
                LinePosition.position = PointPos;

                isHanging = true;
                
			}
			if (Input.GetKey(KeyCode.K)&& grapplePointSelected != null)
			{
                //if (grapplePointSelected == null) return;
                LineRenderer.SetPosition(1, transform.position);
                LineRenderer.enabled = true;

                
            }
    
			
            else if (Input.GetKeyUp(KeyCode.K))
			{
                DistanceJoint.enabled = false;
                LineRenderer.enabled = false;
                //Mov.TopSpeed = Walkspeed;
                isHanging = false;
            }

			if (isHanging && transform.position.y > PointPos.y)
			{   
                    Mov.TopSpeed = 0.1f;
			}
			else
			{
                Mov.TopSpeed = Mov.OriginalSpeed;
            }



            if(DistanceJoint.enabled == true)
			{
                LineRenderer.SetPosition(1, transform.position);
			}


		}
        
    }

    void CheckIfInfront()
    {

        float nearestDistance = Mathf.Infinity;
        GameObject nearestPoint = null;

        foreach (GameObject point in points)
        {
            float distance = Vector2.Distance(transform.position, point.transform.position);


            if (distance < maxDistance && IsOnCorrectSide(point.transform.position))
            {
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestPoint = point;
                }
            }
        }

        grapplePointSelected = nearestPoint;
    }


    bool IsOnCorrectSide(Vector3 pointPosition)
    {
        if (lastButtonPressed == LastButtonPressed.D)
        {

            return pointPosition.x < transform.position.x;
        }
        else if (lastButtonPressed == LastButtonPressed.A)
        {
            return pointPosition.x > transform.position.x;
        }
        return false;
    }

}

