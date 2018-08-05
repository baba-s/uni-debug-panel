# UniDebugPanel

[https://github.com/baba-s/uni-debug-panel:embed]

「UniDebugPanel」を Unity プロジェクトに導入することで  
ゲーム内にデバッグ用のカスタマイズ可能なボタンを表示できるようになります  

# 開発環境

- Unity 2018.2.2f1

# 導入方法

1. 下記のページにアクセスして「UniDebugPanel.unitypackage」をダウンロードします  
https://github.com/baba-s/uni-debug-panel/blob/master/UniDebugPanel.unitypackage?raw=true
2. ダウンロードした「UniDebugPanel.unitypackage」を Unity プロジェクトにインポートします  

# 使い方

## 事前準備

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805104628.png" />

Unity メニューの「File>Build Settings...」から「Player Settings...」を選択し、  
「Scripting Define Symbols」に「ENABLE_DEBUG_PANEL」と入力します  

## 基本的な使い方

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805104734.png" />

シーンに「UniDebugPanelUI」プレハブを配置します  

```cs
using KoganeLib.UniDebugPanel;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public UniDebugPanelUI m_debugPanelUI = null;
    public Button          m_buttonUI     = null;

    private void Start()
    {
        m_debugPanelUI.DoSetDisp
        (
            new UDPData( "ロック"    , () => m_buttonUI.interactable = false ),
            new UDPData( "アンロック", () => m_buttonUI.interactable = true  )
        );
        
    }
}
```

そして、上記のようなスクリプトを作成します  

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805105108.gif" />

これで、そのシーンからデバッグ用の機能を呼び出せるようになります  

## DontDestroyOnLoad による使い方

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805105623.png" />

「UniDebugPanelUI」プレハブを「Resources」フォルダに格納します  

```cs
using KoganeLib.UniDebugPanel;
using UnityEngine;

public static class Example
{
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    private static void Init()
    {
        var name   = "UniDebugPanelUI";
        var prefab = Resources.Load<UniDebugPanelUI>( name );
        var obj    = GameObject.Instantiate( prefab );

        GameObject.DontDestroyOnLoad( obj.gameObject );
    }
}
```

さらに、RuntimeInitializeOnLoadMethod 属性が適用された static 関数を定義して  
ゲーム開始時に UniDebugPanelUI のプレハブを生成するようにします  

```cs
using KoganeLib.UniDebugPanel;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Button m_buttonUI = null;

    private void Start()
    {
        UniDebugPanelUI.SetDisp
        (
            new UDPData( "ロック"    , () => m_buttonUI.interactable = false ),
            new UDPData( "アンロック", () => m_buttonUI.interactable = true  )
        );
        
    }
}
```

そして、上記のようなスクリプトを作成します  

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805105836.gif" />

これで、いつでもデバッグ用の機能を呼び出せるようになり、  
シーンを切り替えても UniDebugPanelUI オブジェクトが残り続けます  

## リリースビルド時に無効化する

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805110417.png" />

Unity メニューの「File>Build Settings...」から「Player Settings...」を選択し、  
「Scripting Define Symbols」から「ENABLE_DEBUG_PANEL」を削除すると  
UniDebugPanelUI の機能はすべて無効化されます  

開発中は「ENABLE_DEBUG_PANEL」を定義しておき、  
ゲームのリリース時に「ENABLE_DEBUG_PANEL」を削除することで  
UniDebugPanelUI の機能をリリースビルドから除外できます  