using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
  private Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {

  }
  private void OnTriggerEnter(Collider other)
  {
    animator.SetTrigger("Get");
  }

  private void OnTriggerStay(Collider other)
  {
    Debug.Log("Stay");
  }

  private void OnTriggerExit(Collider other)
  {
    Debug.Log("Exit");
  }

  void DestroySelf()
  {
    Destroy(gameObject);
  }
}

