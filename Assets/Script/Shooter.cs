using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    public Transform point;
    public GameObject target;
    public Rigidbody2D rb;



    private void Start()
    {
        Cursor.visible = false;
    }




    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        worldPos.z = 0;
        target.transform.position = worldPos;


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            Ray ray = Camera.main.ScreenPointToRay(screenPos);

            Debug.DrawRay(ray.origin, ray.direction * 5, Color.aquamarine, 5f);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);


            if (hit.collider != null)
            {

                //target.transform.position = new Vector2(hit.point.x, hit.point.y);

                Vector2 projectileVelocity = CalculateProjectileVelocity(point.position, hit.point, 1f);

                Rigidbody2D shootBullet = Instantiate (rb, point.position, Quaternion.identity);

                shootBullet.linearVelocity = projectileVelocity;


            }



        }


    }


    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 direction = target - origin;
        return new Vector2(direction.x / time, direction.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time);
    
    
    
    }

}
