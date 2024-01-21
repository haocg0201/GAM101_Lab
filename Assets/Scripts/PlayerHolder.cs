using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerHolder : MonoBehaviour
{
    public Transform playerTransform;
    public CinemachineVirtualCamera cinemachineCamera;

    void LateUpdate()
    {
        if (cinemachineCamera != null)
        {
            // Di chuyển Cinemachine camera đến vị trí của người chơi
            cinemachineCamera.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, cinemachineCamera.transform.position.z);
        }
    }
}
