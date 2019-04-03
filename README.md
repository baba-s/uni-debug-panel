[日本語の Readme はこちら](https://github.com/baba-s/uni-debug-panel/blob/master/README_JP.md)  

# UniDebugPanel

You can display customizable buttons for debugging in the game.  

[![](https://img.shields.io/github/release/baba-s/uni-debug-panel.svg?label=latest%20version)](https://github.com/baba-s/uni-debug-panel/releases)
[![](https://img.shields.io/github/release-date/baba-s/uni-debug-panel.svg)](https://github.com/baba-s/uni-debug-panel/releases)
![](https://img.shields.io/badge/Unity-2018.3%2B-red.svg)
![](https://img.shields.io/badge/.NET-4.x%2B-orange.svg)
[![](https://img.shields.io/github/license/baba-s/uni-debug-panel.svg)](https://github.com/baba-s/uni-debug-panel/blob/master/LICENSE)

# Version

- Unity 2018.3.9f1

# Usage

## Symbol

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805104628.png" />

Select "Player Settings ..." from "File> Build Settings ..." on the Unity menu,  
Enter "ENABLE_DEBUG_PANEL" in "Scripting Define Symbols".  

## Basic Usage

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805104734.png" />

Place the "UniDebugPanelUI" prefab in the scene.  

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

And you create a script like the one above.  

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805105108.gif" />

You can now call the debugging functions from that scene.

## Release Build

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805110417.png" />

Select "Player Settings ..." from "File> Build Settings ..." on the Unity menu,  
Deleting "ENABLE_DEBUG_PANEL" from "Scripting Define Symbols"  
All functions of UniDebugPanelUI are disabled.  