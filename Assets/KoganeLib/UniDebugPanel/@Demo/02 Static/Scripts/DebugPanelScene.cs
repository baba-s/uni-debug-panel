using UnityEngine;

namespace KoganeLib.UniDebugPanel.Demo
{
	/// <summary>
	/// デバッグパネル画面を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class DebugPanelScene : MonoBehaviour
	{
		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 初期化される時に呼び出されます
		/// </summary>
		private void Awake()
		{
			DontDestroyOnLoad( gameObject );
		}
	}
}
