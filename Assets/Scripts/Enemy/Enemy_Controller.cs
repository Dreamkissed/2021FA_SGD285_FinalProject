//////////////////////////////////////////////
//Project: MetroidVania
//Name: Jennifer Wenner
//Section: 2021FA.SGD.285.2141
//Instructor: Prof. Wold
//Date: 11/17/2021
/////////////////////////////////////////////
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy_AI AI_Enemy;
    [SerializeField] private GameObject PlayerObject;

    [SerializeField] float Enemy_MovementSpeed;
    [SerializeField] bool Enemy_DoesFloat;
    [SerializeField] float Enemy_HoverHeight;
    [SerializeField] bool Enemy_IsImmortal;
    [SerializeField] int Enemy_Health;
    
    private void Awake()
    {
        InitializeOnAwake();
    }

    private bool InitializeOnAwake()
    {
        return true;
    }
}
