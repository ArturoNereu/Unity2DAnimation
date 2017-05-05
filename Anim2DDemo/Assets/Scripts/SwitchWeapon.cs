using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private Animator animator;

    private int weaponIndex = 0;

    [SerializeField]
    private GameObject[] weapons;

    [SerializeField]
    private GameObject handBone;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");

            if(handBone)
            {
                weapons[weaponIndex].transform.SetParent(null);
                weapons[weaponIndex].transform.position = new Vector3(-10, 0, 0);

                weaponIndex++;
                weaponIndex = weaponIndex % weapons.Length;
          
                weapons[weaponIndex].transform.SetParent(handBone.transform);
                weapons[weaponIndex].transform.localPosition = Vector3.zero;
            }
        }
	}
}
