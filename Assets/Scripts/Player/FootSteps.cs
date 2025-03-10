using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] footstepClips;
    private AudioSource audioSource;
    private Rigidbody _rigidbody;
    public float footstepThreshold;
    public float footstepRate;
    private float footStepTime;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Mathf.Abs(_rigidbody.velocity.y) <0.1f)
        {
            if(_rigidbody.velocity.magnitude > footstepThreshold)
            {
                if(Time.time - footStepTime > footstepRate)
                {
                    footStepTime = Time.time;
                    audioSource.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
                        //이전 오디오가 완전히 재생이 끝나지 않았더라도 다음꺼를 재생함으로써
                        //끊기지 않도록. 끊기게 되면 부자연스러울 것 
                }
            }
        }
    }
}
