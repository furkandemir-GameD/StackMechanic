using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    private CinemachineFramingTransposer cinemachineFramingTransposer;

    [SerializeField]
    private float softRotateMultipler;

    public float cameraDistance;
    public float axisDampingZ;
    public float axisRotateY;
    void Awake() => cinemachineFramingTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    public void OffsetCalculator(float cameraDistanceP,float axisDampingZP,float axisRotateYP)
    {
        cinemachineFramingTransposer.m_CameraDistance += cameraDistanceP;
        cinemachineFramingTransposer.m_ZDamping += axisDampingZP;
        cinemachineVirtualCamera.transform.eulerAngles = new Vector3(transform.eulerAngles.x + axisRotateYP , transform.eulerAngles.y, transform.eulerAngles.z);
        Run loop = Run.EachFrame(() =>
        {
            cinemachineVirtualCamera.transform.eulerAngles = Vector3.Lerp(cinemachineVirtualCamera.transform.eulerAngles,
                new Vector3(transform.eulerAngles.x + axisRotateYP, transform.eulerAngles.y, transform.eulerAngles.z), softRotateMultipler*Time.deltaTime);
        });
        Run.After(1f, loop.Abort);
    }
}
