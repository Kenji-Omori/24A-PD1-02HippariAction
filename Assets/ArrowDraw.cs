using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{

  [SerializeField] 
  private Image arrowImage;
  private Vector3 clickPosition;

  void Start()
  {

  }

  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      clickPosition = Input.mousePosition;
      arrowImage.gameObject.SetActive(true);
    }
    if (Input.GetMouseButton(0))
    {
      Vector3 dist = clickPosition - Input.mousePosition;
      // ベクトルの長さを算出
      float size = dist.magnitude;
      // ベクトルから角度(弧度法)を算出
      float angleRad = Mathf.Atan2(dist.y, dist.x);
      // 矢印の画像をクリックした場所に画像を移動
      arrowImage.rectTransform.position = clickPosition;
      // 矢印の画像をベクトルから算出した角度を度数法に変換してZ軸回転
      arrowImage.rectTransform.rotation
        = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);
      // 矢印の画像の大きさをドラッグした距離に合わせる
      arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
    }
    if (Input.GetMouseButtonUp(0))
    {
      arrowImage.gameObject.SetActive(false);
    }

  }



}
