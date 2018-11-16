using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour {

    // タブレット画面のオブジェクト
    public GameObject tabletScreen;

    public float fullBattry;

    // タブレットのバッテリー
    private float battery;

    // タブレットの状態
    public TabletState tabletState;

    /// <summary>
    /// タブレットの状態
    /// </summary>
    public enum TabletState
    {
        Starting,
        ShutDown,
    }

    // バッテリーのプロパティ
    public float Battery
    {
        get
        {
            return battery;
        }

        set
        {
            battery = value;
        }
    }

    // Use this for initialization
    void Start () {

        // バッテリーフルチャージ
        BatteryFull();

        // タブレット画面をオフ
        tabletScreen.gameObject.SetActive(false);

        // タブレットの状態を終了状態に
        tabletState = TabletState.ShutDown;

        // タブレットを非表示に
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update () {

        // タブレットが開いている状態だったら
        if (tabletScreen.gameObject.activeSelf == true)
        {
            // タブレットのバッテリーを減らす
            Battery -= 0.01f;
        }

        // タブレットのバッテリーがなくなったら
        if (Battery <= 0)
        {
            // タブレット画面を消す
            ShutDwonTablet();
        }

        Debug.Log(Battery);

    }

    /// <summary>
    /// タブレットの状態を切り替える
    /// </summary>
    public void ChangeStete()
    {
        // タブレットが起動していない状態なら
        if(tabletState == TabletState.ShutDown)
        {
            // タブレットの状態を起動中に
            tabletState = TabletState.Starting;
            StartUpTablet();
        }
        else
        {
            // タブレットの状態を終了に
            tabletState = TabletState.ShutDown;
            ShutDwonTablet();
        }
    }

    /// <summary>
    /// タブレットを起動する
    /// </summary>
    public void StartUpTablet()
    {
        // 起動済みなら
        if (tabletScreen.activeSelf) { return; }

        // バッテリーがあったら
        if (Battery > 0)
        {
            // タブレット画面を付ける
            tabletScreen.gameObject.SetActive(true);
        }

    }

    /// <summary>
    /// タブレットを終了する
    /// </summary>
    void ShutDwonTablet()
    {
        // 終了済みなら
        if(tabletScreen.activeSelf == false) { return; }

        // タブレット画面を消す
        tabletScreen.gameObject.SetActive(false);
    }

    void BatteryFull()
    {
        Battery = fullBattry;
    }
}
