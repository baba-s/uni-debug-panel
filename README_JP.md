# UniDebugPanel

「UniDebugPanel」を Unity プロジェクトに導入することで  
ゲーム内にデバッグ用のカスタマイズ可能なボタンを表示できるようになります  

[![](https://img.shields.io/github/release/baba-s/uni-debug-panel.svg?label=latest%20version)](https://github.com/baba-s/uni-debug-panel/releases)
[![](https://img.shields.io/github/release-date/baba-s/uni-debug-panel.svg)](https://github.com/baba-s/uni-debug-panel/releases)
![](https://img.shields.io/badge/Unity-2017.4%2B-red.svg)
![](https://img.shields.io/badge/.NET-3.5%2B-orange.svg)
[![](https://img.shields.io/github/license/baba-s/uni-debug-panel.svg)](https://github.com/baba-s/uni-debug-panel/blob/master/LICENSE)

# 開発環境

- Unity 2018.3.9f1

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
        m_debugPanelUI.SetDisp
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

## リリースビルド時に無効化する

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805110417.png" />

Unity メニューの「File>Build Settings...」から「Player Settings...」を選択し、  
「Scripting Define Symbols」から「ENABLE_DEBUG_PANEL」を削除すると  
UniDebugPanelUI の機能はすべて無効化されます  

開発中は「ENABLE_DEBUG_PANEL」を定義しておき、  
ゲームのリリース時に「ENABLE_DEBUG_PANEL」を削除することで  
UniDebugPanelUI の機能をリリースビルドから除外できます  