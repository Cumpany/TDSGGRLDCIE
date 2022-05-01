using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Material matt;
    public static bool isDead = false;
    public static float deathTimer = 0f;
    public static void Die()
    {
        Movement.mFrames = float.PositiveInfinity;
        isDead = true;
    }
    void Start()
    {
        matt.SetFloat("_Float", 1f);
    }
    void FixedUpdate()
    {
        if (isDead)
        {
            matt.SetFloat("_Float", 1f - deathTimer);
            deathTimer += 0.02f;
        }
        if (deathTimer <= 0)
        {
            matt.SetFloat("_Float", 1f);
            Application.Quit(69);
        }
    }
}
