using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // membuat variabel yg menjadi target, untuk diikuti oleh kamera
    [SerializeField] private Transform target;


    private void Update()
    {
       // this.transform.position adalah camera
       // tiap ada update maka posisi camera persisnya pada sumbu x akan bertambah/berkurang sesuai dg sumbu x yg ada pada player
       this.transform.position = new Vector3(target.transform.position.x,
       target.transform.position.y, target.transform.position.z - 10f); 
    }
}
