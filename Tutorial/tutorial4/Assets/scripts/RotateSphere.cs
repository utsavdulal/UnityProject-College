using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSphere: MonoBehaviour
{
   // Rotation speed in degrees per second
   public float rotationSpeed = 30f;

   void Update()
   {
       // Apply horizontal rotation (around the Y-axis) to the sphere
       transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
   }
}