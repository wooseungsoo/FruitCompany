using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FieldOfView : MonoBehaviour
{
    public float viewRadius;//??  κΈΈμ΄?
    [Range(0,360)]
    public float viewAngle; //camera? fieldOfView 
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform>visibleTargets =new List<Transform>();
    public List<ISightCheck> sightTargets =new List<ISightCheck>();


    // void Start()
    // {
    //     //InvokeRepeating("FindVisibleTargets",0f,0.3f);
    // }
    private void Update() 
    {
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        
        //viewRadiousλ₯? λ°μ??λ¦μΌλ‘? ? ??­ ?΄? targetlayer μ½λΌ?΄?λ₯? κ°?? Έ?΄
        Collider[] targetsInViewRadius=Physics.OverlapSphere(transform.position,viewRadius,targetMask);

        if(targetsInViewRadius.Length!=0)
        {
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                
                // ?? ?΄?΄ ??Ό ?΄? ??€λ©?
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))//??Ό λ²μ? ?€λ₯? ?€λΈμ ?Έκ°? ??€λ©?
                    {
                        //Debug.Log(targetsInViewRadius[0].gameObject.name);
                       HitRayCast(target);
                    }
                   
                }
                else
                {
                    Initialize();
                }
            }
        }
        
    }
    public void Initialize()
    {
        for(int i=0; i<sightTargets.Count; i++)
        {
            sightTargets[i].OutSight();
        }
        visibleTargets.Clear();
        sightTargets.Clear();
    }
    public void HitRayCast(Transform target)
    {
        visibleTargets.Add(target);//λ³΄κ³ ?? μ²΄ν¬

        if(target.TryGetComponent(out ISightCheck sights))
        {
            sightTargets.Add(sights);

            //ΑίΊΉ Α¦°Ε
            sightTargets=sightTargets.Distinct().ToList();
            visibleTargets=visibleTargets.Distinct().ToList();

            Debug.Log(sightTargets.Count);
            for(int j=0; j<sightTargets.Count; j++)
            {
                sightTargets[j].InSight();
            }

        }
    }
    public Vector3 DirFromAngle(float angleDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Cos((-angleDegrees + 90) * Mathf.Deg2Rad), 0, Mathf.Sin((-angleDegrees + 90) * Mathf.Deg2Rad));
    }
}
