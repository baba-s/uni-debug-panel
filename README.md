[日本語の Readme はこちら](https://github.com/baba-s/uni-debug-panel/blob/master/README_JP.md)  

# UniDebugPanel

You can display customizable buttons for debugging in the game.  

# Version

- Unity 2018.2.2f1

# Install

1. Go to the following page and download "UniDebugPanel.unitypackage".  
https://github.com/baba-s/uni-debug-panel/blob/master/UniDebugPanel.unitypackage?raw=true  
2. Import the downloaded "UniDebugPanel.unitypackage" into the Unity project.  

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

## DontDestroyOnLoad

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805105623.png" />

You will store the "UniDebugPanelUI" prefab in the "Resources" folder.

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

Furthermore, define a static function to which the RuntimeInitializeOnLoadMethod attribute is applied,  
Make sure to generate a prefab of UniDebugPanelUI at the beginning of the game.  

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

And you create a script like the one above.

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805105836.gif" />

With this, you can call the function for debugging at any time,  
The UniDebugPanelUI object will remain on even if switching scenes.  

## Release Build

<img src="https://cdn-ak.f.st-hatena.com/images/fotolife/b/baba_s/20180805/20180805110417.png" />

Select "Player Settings ..." from "File> Build Settings ..." on the Unity menu,  
Deleting "ENABLE_DEBUG_PANEL" from "Scripting Define Symbols"  
All functions of UniDebugPanelUI are disabled.  