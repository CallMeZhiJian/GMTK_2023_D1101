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
    private void Awake()
    {
        onScreen = false;
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(onScreen);
        if (Input.GetMouseButtonDown(1))
        {
            if (!onScreen)
            {
                clone = Instantiate(bullet, spawnLocation.position, Quaternion.identity);
                SoundManager.instance.PlaySound(FireballCreateSFX);
                onScreen = true;
                vcam.LookAt = clone.transform;
                vcam.Follow = clone.transform;
                StartCoroutine(BulletDuration());
            }
        }
    }

    IEnumerator BulletDuration()
    {
        yield return new WaitForSeconds(duration);
        Destroy(clone);
        onScreen = false;
        SoundManager.instance.PlaySound(FireballDisapearSFX);
        vcam.LookAt = transform;
        vcam.Follow = transform;
    }
}
