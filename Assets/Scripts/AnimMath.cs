using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimMath
{
    public static float Lerp(float min, float max, float p, bool allowEx = true)
    {
        if (!allowEx)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }
        return (max - min) * p + min;
    }

    public static Vector3 Lerp(Vector3 min, Vector3 max, float p, bool allowEx = true)
    {
        if (!allowEx)
        {
            if (p < 0) p = 0;
            if (p > 1) p = 1;
        }
        return (max - min) * p + min;
    }

    public static float Slide(float curr, float target, float percentLeftAfter1)
    {
        float p = 1 - Mathf.Pow(percentLeftAfter1, Time.deltaTime);
        return AnimMath.Lerp(curr, target, p);
    }
    public static Vector3 Slide(Vector3 curr, Vector3 target, float percentLeftAfter1)
    {
        float p = 1 - Mathf.Pow(percentLeftAfter1, Time.deltaTime);
        return AnimMath.Lerp(curr, target, p);
    }

    public static Vector3 SpotOnCircleXZ(float radius, float currentAngle)
    {
        Vector3 offset = new Vector3();
        offset.x = Mathf.Sin(currentAngle) * radius;
        offset.z = Mathf.Cos(currentAngle) * radius;

        return offset;
    }

    public static Vector3 RandomRotation(float radius, float currentAngle, float randomNum1, float randomNum2)
    {
        Vector3 offset = new Vector3();

        if (randomNum1 < 5)
        {
            if (randomNum2 < 5)
            {
                //offset.x = Mathf.Sin(currentAngle) * radius;
                offset.y = Mathf.Sin(currentAngle) * radius;
                offset.z = Mathf.Cos(currentAngle) * radius;
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offset.x = Mathf.Cos(currentAngle) * radius;
                offset.y = -Mathf.Sin(currentAngle) * radius;
            }
            else if(randomNum2 >= 10 && randomNum2 < 15)
            {
                offset.x = Mathf.Sin(currentAngle) * radius;
                offset.y = Mathf.Cos(currentAngle) * radius;
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                //offset.x = Mathf.Cos(currentAngle) * radius;
                offset.y = Mathf.Cos(currentAngle) * radius;
                offset.z = Mathf.Sin(currentAngle) * radius;
            }
        }
        else if(randomNum1 >= 5 && randomNum1 < 10)
        {
            if (randomNum2 < 5)
            {
                offset.x = Mathf.Cos(currentAngle) * radius;
                //offset.y = Mathf.Sin(currentAngle) * radius;
                offset.z = Mathf.Sin(currentAngle) * radius;
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offset.x = Mathf.Cos(currentAngle) * radius;
                offset.z = Mathf.Sin(currentAngle) * radius;
            }
            else if (randomNum2 >= 10 && randomNum2 < 15)
            {
                offset.x = Mathf.Sin(currentAngle) * radius;
                offset.z = Mathf.Cos(currentAngle) * radius;
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                offset.x = Mathf.Sin(currentAngle) * radius;
                offset.y = Mathf.Cos(currentAngle) * radius;
                //offset.z = Mathf.Cos(currentAngle) * radius;
            }
        }
        else if (randomNum1 >= 10 && randomNum1 < 15)
        {
            if (randomNum2 < 5)
            {
                offset.x = -Mathf.Cos(currentAngle) * radius;
                //offset.y = Mathf.Sin(currentAngle) * radius;
                offset.z = Mathf.Sin(currentAngle) * radius;
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offset.x = Mathf.Cos(currentAngle) * radius;
                //offset.y = Mathf.Sin(currentAngle) * radius;
                offset.z = Mathf.Sin(currentAngle) * radius;
            }
            else if (randomNum2 >= 10 && randomNum2 < 15)
            {
                offset.x = Mathf.Sin(currentAngle) * radius;
                offset.y = Mathf.Cos(currentAngle) * radius;
                //offset.z = Mathf.Sin(currentAngle) * radius;
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                //offset.x = Mathf.Sin(currentAngle) * radius;
                offset.y = Mathf.Sin(currentAngle) * radius;
                offset.z = Mathf.Cos(currentAngle) * radius;
            }
        }
        else if (randomNum1 >= 15 && randomNum1 < 20)
        {
            if (randomNum2 < 5)
            {
                offset.x = -Mathf.Sin(currentAngle) * radius;
                offset.y = Mathf.Cos(currentAngle) * radius;
                //offset.z = Mathf.Cos(currentAngle) * radius;
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offset.x = Mathf.Sin(currentAngle) * radius;
                offset.y = -Mathf.Cos(currentAngle) * radius;
                //offset.z = Mathf.Cos(currentAngle) * radius;
            }
            else if (randomNum2 >= 10 && randomNum2 < 15)
            {
                offset.x = Mathf.Cos(currentAngle) * radius;
                offset.y = Mathf.Sin(currentAngle) * radius;
                //offset.z = Mathf.Cos(currentAngle) * radius;
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                //offset.x = Mathf.Cos(currentAngle) * radius;
                offset.y = Mathf.Cos(currentAngle) * radius;
                offset.z = Mathf.Sin(currentAngle) * radius;
            }
        }

        return offset;
    }

    public static List<string> ExtractOffset(float randomNum1, float randomNum2)
    {
        List<string> offsetMaths = new List<string>();

        if (randomNum1 < 5)
        {
            if (randomNum2 < 5)
            {
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Cos");
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offsetMaths.Add("Mathf.Cos x");
                offsetMaths.Add("Mathf.Sin y");
            }
            else if (randomNum2 >= 10 && randomNum2 < 15)
            {
                offsetMaths.Add("Mathf.Sin x");
                offsetMaths.Add("Mathf.Cos y");
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Sin");
            }
        }
        else if (randomNum1 >= 5 && randomNum1 < 10)
        {
            if (randomNum2 < 5)
            {
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Sin");
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offsetMaths.Add("Mathf.Cos x");
                offsetMaths.Add("Mathf.Sin z");
            }
            else if (randomNum2 >= 10 && randomNum2 < 15)
            {
                offsetMaths.Add("Mathf.Sin x");
                offsetMaths.Add("Mathf.Cos z");
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Cos");
            }
        }
        else if (randomNum1 >= 10 && randomNum1 < 15)
        {
            if (randomNum2 < 5)
            {
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Sin");
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Sin");
            }
            else if (randomNum2 >= 10 && randomNum2 < 15)
            {
                
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Sin");
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Cos");
            }
        }
        else if (randomNum1 >= 15 && randomNum1 < 20)
        {
            if (randomNum2 < 5)
            {
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Cos");
            }
            else if (randomNum2 >= 5 && randomNum2 < 10)
            {
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Cos");
            }
            else if (randomNum2 >= 10 && randomNum2 < 15)
            {
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Sin");
                offsetMaths.Add("Mathf.Cos");
            }
            else if (randomNum2 >= 15 && randomNum2 < 20)
            {
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Cos");
                offsetMaths.Add("Mathf.Sin");
            }
        }

        return offsetMaths;
    }
}
