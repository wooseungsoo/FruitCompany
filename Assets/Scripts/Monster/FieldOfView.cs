using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FieldOfView : MonoBehaviour
{
    public float viewRadius;//시선 길이?
    [Range(0,360)]
    public float viewAngle; //camera의 fieldOfView 
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
        
        //viewRadious를 반지름으로 한 영역 내에 targetlayer 콜라이더를 가져옴
        Collider[] targetsInViewRadius=Physics.OverlapSphere(transform.position,viewRadius,targetMask);

        if(targetsInViewRadius.Length!=0)
        {
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                
                // 플레이어 시야 내에 있다면
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))//시야 범위에 다른 오브젝트가 없다면
                    {
                        //Debug.Log(targetsInViewRadius[0].gameObject.name);
                        visibleTargets.Add(target);//보고있음 체크

                        if(target.TryGetComponent(out ISightCheck sights))
                        {
                            sightTargets.Add(sights);
                            for(int j=0; j<sightTargets.Count; j++)
                            {
                                sightTargets[j].InSight();
                            }

                        }
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
    public Vector3 DirFromAngle(float angleDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Cos((-angleDegrees + 90) * Mathf.Deg2Rad), 0, Mathf.Sin((-angleDegrees + 90) * Mathf.Deg2Rad));
    }
}
