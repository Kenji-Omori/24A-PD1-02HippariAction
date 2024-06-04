using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
  private Rigidbody rb;
  private Vector3 clickPosition;
  [SerializeField]
  private float jumpPower = 10;
  private bool isCanJump = false;

  // Start is called before the first frame update
  void Start()
  {
    rb = gameObject.GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      clickPosition = Input.mousePosition;
    }
    if (isCanJump && Input.GetMouseButtonUp(0))
    {
      // クリックした座標と離した座標の差分を取得
      Vector3 dist = clickPosition - Input.mousePosition;
      // クリックとリリースが同じ座標ならば無視
      if (dist.sqrMagnitude == 0) { return; }
      // 差分を標準化し、jumpPowerをかけ合わせた値を移動量とする。
      rb.velocity = dist.normalized * jumpPower;

    }
    if (Input.GetKeyDown(KeyCode.Space))
    {
      rb.velocity = new Vector3(0, 10, 0);
    }

  }

  private void OnCollisionEnter(Collision collision)
  {
    ContactPoint[] contacts = collision.contacts;
    Vector3 otherNormal = contacts[0].normal;
    Vector3 upVector = Vector3.up;
    float dotUN = Vector3.Dot(otherNormal, upVector);
    float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
    if (dotDeg <= 45)
    { 
      isCanJump = true;
    }

  }

  private void OnCollisionStay(Collision collision)
  {
    Debug.Log("接触中");
  }

  private void OnCollisionExit(Collision collision)
  {
    Debug.Log("離脱した");
    isCanJump = false;
  }

}
