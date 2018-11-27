using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    // カメラ用レンダーテクスチャを収めるレンダーテクスチャリスト
    public List<RenderTexture> cameraTextures;

    // タブレットゲームオブジェクト
    public GameObject tabletScreen;

    // カメラモード
    private ViewMode viewMode;

    // 選んでいるカメラ
    private int selectCamera;

    // 視点モード
    private enum ViewMode
    {
        // プレイヤー視点
        PlayerView,
        // カメラ視点
        ObjectCameraView
    }

    // Use this for initialization
    void Start()
    {
        viewMode = ViewMode.PlayerView;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(selectCamera);
        Debug.Log(viewMode);
    }

    /// <summary>
    /// 視点モードを切り替える
    /// </summary>
    void ViewChange()
    {
        // 視点フラグを切り替える
        if(viewMode == ViewMode.PlayerView)
        {
            // カメラモード
            viewMode = ViewMode.ObjectCameraView;
        }
        else
        {
            // プレイヤー視点モード
            viewMode = ViewMode.PlayerView;
        }
    }

    /// <summary>
    /// プレイヤーカメラに変更
    /// </summary>
    void PlayerCamera()
    {
        viewMode = ViewMode.PlayerView;
    }

    /// <summary>
    /// オブジェクトカメラに変更
    /// </summary>
    public void ObjectCameraRoll()
    {
        if(tabletScreen.activeSelf == false) { return; }

        viewMode = ViewMode.ObjectCameraView;

        // 選択カメラが最後だったら
        if (selectCamera == cameraTextures.Count -1)
        {
            // 最初に戻す
            selectCamera = 0;
        }
        else
        {
            // カメラ番号を進める
            selectCamera++;
        }

        // テクスチャを削除
        tabletScreen.gameObject.GetComponent<Renderer>().material.mainTexture = null;

        // 選択中のレンダーテクスチャをセットする
        tabletScreen.gameObject.GetComponent<Renderer>().material.mainTexture = cameraTextures[selectCamera];
    }
}
