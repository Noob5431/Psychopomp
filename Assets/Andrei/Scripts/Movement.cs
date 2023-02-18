using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed,jumpForce,thrustForce;
    [SerializeField]
    private float initial_velocity, time_to_initial_velocity, final_velocity, time_to_final_velocity;
    [SerializeField]
    private float velocity;
    [SerializeField]
    Transform cam,gunTip;
    [SerializeField]
    LayerMask grappable;
    LineRenderer lr;
    [SerializeField]
    float maxSwingDistance;
    Vector3 swingPoint;
    SpringJoint joint;

    Rigidbody current_rigidbody;
    Vector3 moveVector;
    Vector3 globalMoveVector;

    Vector2 lookRotation;
    public bool isGrounded,isSwinging,canClimb;
    [SerializeField]
    float wallDetectionLenght;
    [SerializeField]
    float wallSphereRadius;
    [SerializeField]
    float maxWallLookAngle;
    float wallLookAngle;

    RaycastHit frontWallHit;
    [SerializeField]
    bool isClimbing = false;
    [SerializeField]
    float climbSpeed;
    float climbTimer;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lookRotation = GetComponent<MouseLook>().lookRotation;
        current_rigidbody = GetComponent<Rigidbody>();
        velocity = 0;
    }
    private void FixedUpdate()
    {
        OnRun();
        if (!isSwinging)
            Run();
        if (isSwinging)
            SwingThrust();
    }

    private void Update()
    {
        WallCheck();
        if(Input.GetMouseButtonDown(0) && !isSwinging)
        {
            StartSwing();
        }
        if(Input.GetMouseButtonUp(0) && isSwinging)
        {
            StopSwing();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump();
        }
    }

    private void LateUpdate()
    {
        DrawRope();
    }
    public void Run()
    {
        if (moveVector.magnitude < 0.1)
            velocity = 0;
        //initial acceleration
        if (moveVector.magnitude > 0.01)
        {
            if (velocity < initial_velocity)
            {
                float dx = (initial_velocity * Time.deltaTime) / time_to_initial_velocity; //rate of change needed in this frame
                velocity += dx;
            }
            //second acceleration
            else if (velocity < final_velocity)
            {
                float dx = (final_velocity * Time.deltaTime) / time_to_final_velocity;
                velocity += dx;
            }
        }

        //change of basis from local to global of moveVector
        globalMoveVector.x = transform.right.x * moveVector.x + transform.forward.x * moveVector.z;
        globalMoveVector.z = transform.right.z * moveVector.x + transform.forward.z * moveVector.z;
        globalMoveVector.Normalize();

        //apply velocity
        current_rigidbody.velocity = new Vector3(velocity * globalMoveVector.x, current_rigidbody.velocity.y, velocity * globalMoveVector.z);
    }

    void WallCheck()
    {
        canClimb = Physics.SphereCast(transform.position, wallSphereRadius, cam.forward, out frontWallHit, wallDetectionLenght, grappable);
        wallLookAngle = Vector3.Angle(cam.forward, -frontWallHit.normal);
    }    

    void SwingThrust()
    {
        if(moveVector.x>0.1)
            current_rigidbody.AddForce(transform.right * thrustForce * Time.deltaTime);
        if(moveVector.x<-0.1)
            current_rigidbody.AddForce(-transform.right * thrustForce * Time.deltaTime);
    }

    public void OnRun()
    {
        Vector2 input_trans = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input_trans.Normalize();
        moveVector = new Vector3(input_trans.x, 0, input_trans.y);
    }    

    public void OnJump()
    {
        /*if(canClimb && wallLookAngle<maxWallLookAngle)
        {
            if (!isClimbing && climbTimer > 0) StartClimbing();
            if (climbTimer > 0) climbTimer -= Time.deltaTime;
            if (climbTimer < 0) StopClimbing();
        }*/
        if(isGrounded)
            current_rigidbody.AddForce(jumpForce * transform.up, ForceMode.VelocityChange);
    }
  
    void StartSwing()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position,cam.forward,out hit,maxSwingDistance,grappable))
        {
            isSwinging = true;
            swingPoint = hit.point;
            joint = gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = swingPoint;

            float distanceFromPoint = Vector3.Distance(transform.position, swingPoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            
        }
    }
    void StopSwing()
    {
        isSwinging = false;
        lr.positionCount = 0;
        Destroy(joint);
    }
    void DrawRope()
    {
        if (!isSwinging)
            return;
        if (lr.positionCount != 2)
            return;
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, swingPoint);
    }

    private void StartClimbing()
    {
        isClimbing = true;


    }
    private void ClimbingMovement()
    {
        current_rigidbody.velocity = new Vector3(current_rigidbody.velocity.x, climbSpeed, current_rigidbody.velocity.z);

    }
    private void StopClimbing()
    {
        isClimbing = false;

    }
}