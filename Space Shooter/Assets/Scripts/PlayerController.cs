using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
// inspector에서 Boundary안에 있는 것을 보기 위함

public class Boundary
{
	public float xMin,xMax,zMin,zMax;
}
//RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
	public Rigidbody rb;
	public float tilt;
	public float speed;

    public float fireRate;
    private float nextFire;

    AudioSource audioData;

    public GameObject shot;
    public Transform shotSpawn;

	public Boundary boundary;

	void Start ()
	{
	    rb = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   

    }

    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            //GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            // 발사한 총알에 대해서는 reference가 필요가 없다.
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioData.Play();
        }
        
    }
    void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal , 0.0f , moveVertical);
		rb.velocity = movement*speed;

		rb.position = new Vector3
		(
			Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax)
		);

		rb.rotation = Quaternion.Euler (0.0f,0.0f,rb.velocity.x * -tilt);
	}
}
