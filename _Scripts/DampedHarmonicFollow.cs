using UnityEngine;

public class DampedHarmonicFollow : MonoBehaviour
{
[SerializeField]
private float m_Height;
public bool lockHeight;
[SerializeField]
private float m_MaxSpeed;

[SerializeField]
private float m_Damping;

private Vector3 velocity = new Vector3();


public Transform followTarget;
void Update()
{
      //  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     //   if (!Physics.Raycast(ray, out RaycastHit hit)) return;

     if (lockHeight)
     {
         var target = new Vector3(followTarget.position.x + m_Height,  transform.position.y + m_Height, followTarget.position.z + m_Height);
         velocity = Vector3.ClampMagnitude(velocity, m_MaxSpeed);

         var n1 = velocity - (transform.position - target) * m_Damping * m_Damping * Time.deltaTime;
         var n2 = 1 + m_Damping * Time.deltaTime;
         velocity = n1 / (n2 * n2);

         transform.position += velocity * Time.deltaTime;
     }
     else
     { 
         var target = new Vector3(followTarget.position.x, followTarget.position.y , followTarget.position.z);
         velocity = Vector3.ClampMagnitude(velocity, m_MaxSpeed);

         var n1 = velocity - (transform.position - target) * m_Damping * m_Damping * Time.deltaTime;
         var n2 = 1 + m_Damping * Time.deltaTime;
         velocity = n1 / (n2 * n2);

         transform.position += velocity * Time.deltaTime;
        
     }
}}

/* NOTE
   For an cube with a scale of about 5, a max speed of 50 and damping of 12 produced the results in the gif. Also if you have motion like snapping to a tile or clicking to get a target, setting the initial velocity like this looks nice:

   velocity = distance.sqrMagnitude * (target - transform.position);

 */
