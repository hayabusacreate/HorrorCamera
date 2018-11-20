using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{

    [SerializeField] private Text area_name_text;
    [SerializeField] private GameObject minimap_UI;
    [SerializeField] private GameObject area_name_UI;
    [SerializeField] private List<GameObject> cameras = new List<GameObject>();
    [SerializeField] private int currentCamera = 0;
    [SerializeField] private CameraMode cameraMode;

    /// <summary>
    /// カメラのモード
    /// </summary>
    public enum CameraMode
    {
        Player,
        SecurityCamera,
    }

    private void Awake()
    {
        CameraInitialize();
    }

    /// <summary>
    /// カメラの初期化
    /// </summary>
    private void CameraInitialize()
    {
        // プレイヤーのカメラだけをオンにする
        cameras.ForEach(c => c.SetActive(false));

        minimap_UI.SetActive(false);
        area_name_UI.SetActive(false);

        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].name.Contains("Player"))
            {
                cameras[i].SetActive(true);
            }
        }

        cameraMode = CameraMode.Player;
    }

    private void Update()
    {
        ChangeCamera();

        // 監視カメラモードならカメラロール可能
        if (cameraMode == CameraMode.SecurityCamera)
        {
            RollCamera();
        }

        Change_UI();
    }

    /// <summary>
    /// 対象のカメラを変更
    /// </summary>
    private void ChangeCamera()
    {
        if (Input.GetButtonDown("KeyPad_XButton") || Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("カメラモードが切り替わりました" + "CanmeraMode:" + cameraMode);
            if (cameraMode == CameraMode.Player) { SecurityCamera_Initialize(); return; }
            if (cameraMode == CameraMode.SecurityCamera) { CameraInitialize(); return; }
        }

    }

    /// <summary>
    /// 監視カメラ用初期化
    /// </summary>
    private void SecurityCamera_Initialize()
    {
        minimap_UI.SetActive(true);
        area_name_UI.SetActive(true);
        cameraMode = CameraMode.SecurityCamera;
        Debug.Log("現在のカメラロール:" + currentCamera);
    }

    /// <summary>
    /// カメラロール
    /// </summary>
    private void RollCamera()
    {
        //　カメラロールを進める
        if (Input.GetButtonDown("KeyPad_R1") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentCamera++;
            if (currentCamera >= cameras.Count) { currentCamera = 0; return; }
            //Debug.Log("カメラロールを進めました:" + currentCamera);
        }

        //　カメラロールを戻す
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentCamera <= 0) { currentCamera = cameras.Count -1; return; }
            currentCamera--;
            //Debug.Log("カメラロールを戻しました:" + currentCamera);
        }

        // プレイヤーカメラ以外に切り替える
        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].activeSelf == true) { cameras[i].SetActive(false); }

            cameras[currentCamera].SetActive(true);
            //Debug.Log("カメラ" + currentCamera + "をアクティブにしました");
        }
    }

    private void Change_UI()
    {
        if (cameraMode == CameraMode.SecurityCamera)
        {
            //cameras[currentCamera].ToString();
            //Debug.Log(cameras[currentCamera].ToString());

            area_name_text.text = cameras[currentCamera].name;
        }
    }
}
