using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnLocation;
    public float duration;

    private bool onScreen;
    private GameObject clone;
    private CinemachineVirtualCamera vcam;

    [SerializeField] private AudioClip FireballCreateSFX;
    [SerializeField] private AudioClip FireballDisapearSFX;
    private void Start()
    {
        onScreen = false;
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (!onScreen)
            {
                SoundManager.instance.PlaySound(FireballCreateSFX);
                clone = Instantiate(bullet, spawnLocation.position, Quaternion.identity);
                onScreen = true;
                vcam.LookAt = clone.transform;
                vcam.Follow = clone.transform;

            }            
        }
        else if(onScreen)
        {
            StartCoroutine(BulletDuration());
            onScreen = false;  
        } 
    }

    IEnumerator BulletDuration()
    {
        yield return new WaitForSeconds(duration);
        Destroy(clone);
        SoundManager.instance.PlaySound(FireballDisapearSFX);
        vcam.LookAt = transform;
        vcam.Follow = transform;
    }
}
