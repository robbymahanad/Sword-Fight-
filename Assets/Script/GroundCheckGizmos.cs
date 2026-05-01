using UnityEngine;

public class GroundCheckGizmos : MonoBehaviour
{
    public Transform groundCheckPoint;
    public float radius = 0.3f;
    public LayerMask groundLayer;

    public ContactFilter2D contactFilter;

    private bool isGrounded;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheckPoint.position,
            radius,
            groundLayer
        );
    }

    void OnDrawGizmos()
    {
        if (groundCheckPoint == null) return;

        Vector3 pos = groundCheckPoint.position;

        // 🟡 Draw ground check circle
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pos, radius);

        // 🟢 Draw UP direction (0° reference)
        Gizmos.color = Color.green;
        Gizmos.DrawLine(pos, pos + Vector3.up * 1.5f);

        // Only draw angles if enabled
        if (contactFilter.useNormalAngle)
        {
            // 🔵 Min angle
            Vector3 minDir = Quaternion.Euler(0, 0, contactFilter.minNormalAngle) * Vector3.up;

            // 🔴 Max angle
            Vector3 maxDir = Quaternion.Euler(0, 0, contactFilter.maxNormalAngle) * Vector3.up;

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(pos, pos + minDir * 1.5f);

            Gizmos.color = Color.red;
            Gizmos.DrawLine(pos, pos + maxDir * 1.5f);
        }

        // 🟢/🔴 Grounded indicator
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawSphere(pos, 0.05f);
    }
}