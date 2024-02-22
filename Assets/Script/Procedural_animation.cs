using UnityEngine;

public class Procedural_animation : MonoBehaviour
{
    public Transform[] legTargets;
    int numberLegs;
    Vector3[] defaultPosition;
    Vector3[] lastPosition;
    Vector3 lastSpiderPosition;
    Vector3 velocity;
    float maxdistance = 0;

    void Start()
    {
        numberLegs = legTargets.Length;
        defaultPosition = new Vector3[numberLegs];
        lastPosition = new Vector3[numberLegs];
        for (int i = 0; i < numberLegs; i++)
        {
            defaultPosition[i] = legTargets[i].localPosition;
            lastPosition[i] = legTargets[i].position;
        }
        lastSpiderPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, 0.001f);
        velocity = transform.position - lastSpiderPosition;

        for (int i = 0; i < numberLegs; i++)
        {
            Vector3 desiredPosition= transform.TransformPoint(defaultPosition[i]);// = velocity + lastPosition[i];
            Vector3 targetPoint = desiredPosition + Mathf.Clamp(velocity.magnitude * 1.5f, 0.0f, 1.5f) * (desiredPosition - legTargets[i].position) + velocity * 1.5f;
            float distance = Vector3.Distance(desiredPosition, lastPosition[i]);
            Debug.Log(distance);

            if (maxdistance < distance)
            {
                RaycastHit hit;
                Debug.DrawRay(targetPoint+velocity*1.5f, Vector3.down, Color.white);
                if (Physics.Raycast(targetPoint+velocity*1.5f, Vector3.down, out hit))
                {
                    // Adjust the leg position to the point of intersection with the ground
                    Vector3 targetPosition = hit.point;

                    // Move leg towards the target using Lerp
                    legTargets[i].position = Vector3.Lerp(lastPosition[i], targetPosition, Time.fixedDeltaTime * 5f);
                }
                else
                {
                    Debug.LogWarning("Raycast did not hit the ground!");
                }
            }
            else
            {
                Debug.Log("Velocity zero");
            }
        }

        // Move the spider and update lastSpiderPosition at the end of the FixedUpdate
        lastSpiderPosition = transform.position;

        // Update lastPosition[i] after leg movement
        for (int i = 0; i < numberLegs; i++)
        {
            lastPosition[i] = legTargets[i].position;
        }
    }
}
