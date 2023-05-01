//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class HookBody : MonoBehaviour
//{
//    public GameObject jointPerfabs;
//    public List<HookJoint> joints;
//    private Hook hookInfo;
//    private void Start()
//    {
//        hookInfo = transform.parent.GetComponent<Hook>();
//        hookInfo.hookHead.transform.SetParent(joints[joints.Count - 1].transform);
//        hookInfo.hookHead.transform.position = joints[joints.Count - 1].tail.transform.position;
        
//    }
//    [EditorButton("´´½¨ÐÂË÷Á´")]
//    public void AddNewNode()
//    {
//        var newJoint = Instantiate(jointPerfabs,transform).GetComponent<HookJoint>();
//        var chainEnd = joints[joints.Count - 1];
//        var dir = chainEnd.tail.position - chainEnd.head.position;
//        //LookAt2DTool.LookAt2DWithDirection(newJoint.transform, dir);
//        newJoint.transform.position = chainEnd.tail.position - newJoint.head.position + newJoint.transform.position;
//        newJoint.thishingeJoint.connectedBody = chainEnd.rb2d;
//        newJoint.thishingeJoint.connectedAnchor = chainEnd.tail.localPosition;
//        hookInfo.hookHead.transform.SetParent(newJoint.transform);
//        hookInfo.hookHead.transform.position = newJoint.tail.transform.position;
//        joints.Add(newJoint);
//    }
//    public void SetAllRbMode()
//    {
//        foreach(var joint in joints)
//        {
            
//        }
//    }
//}
