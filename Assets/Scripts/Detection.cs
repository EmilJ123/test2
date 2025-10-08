using UnityEngine;
using UnityEngine.UI;

public class Detection : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float detectionSpeed = 0.5f;
    public float decaySpeed = 0.3f;
    public float detectionLevel = 0f;

    public Slider detectionSlider;
    public LayerMask obstacleMask; // Assign in Inspector

    void Update()
    {
        bool canSeePlayer = false;

        Vector2 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance < detectionRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, distance, obstacleMask);

            if (hit.collider == null)
            {
                // No obstacle hit — player is visible
                canSeePlayer = true;
            }
        }

        if (canSeePlayer)
            detectionLevel += detectionSpeed * Time.deltaTime;
        else
            detectionLevel -= decaySpeed * Time.deltaTime;

        detectionLevel = Mathf.Clamp01(detectionLevel);
        detectionSlider.value = detectionLevel;
        
        
        
    }
    
}
