using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class FieldOfView : MonoBehaviour
{
    public float viewRadius;//?��?�� 길이?
    [Range(0,360)]
    public float viewAngle; //camera?�� fieldOfView 
    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform>visibleTargets =new List<Transform>();
    public List<ISightCheck> sightTargets =new List<ISightCheck>();

    private void Update() 
    {
        FindVisibleTargets();
    }

    void FindVisibleTargets()
    {
        //viewRadious�� ���������� ��ä�� ����
        Collider[] targetsInViewRadius=Physics.OverlapSphere(transform.position,viewRadius,targetMask);

        if(targetsInViewRadius.Length!=0)
        {
            for (int i = 0; i < targetsInViewRadius.Length; i++)
            {
                Transform target = targetsInViewRadius[i].transform;
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                
                if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
                {
                    float dstToTarget = Vector3.Distance(transform.position, target.transform.position);

                    if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))//���ϴ� Layer�տ� �ٸ� ������Ʈ�� ���ٸ�
                    {
                       HitRayCast(target);
                    }
                   
                }
                else
                {
                    Initialize();//�ü����� ������
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
        visibleTargets.Add(target);//보고?��?�� 체크

        if(target.TryGetComponent(out ISightCheck sights))
        {
            sightTargets.Add(sights);

            //�ߺ� ����
            sightTargets=sightTargets.Distinct().ToList();
            visibleTargets=visibleTargets.Distinct().ToList();

           // Debug.Log(sightTargets.Count);
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
