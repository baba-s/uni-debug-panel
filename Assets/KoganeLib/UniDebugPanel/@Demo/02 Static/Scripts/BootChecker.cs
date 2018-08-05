using UnityEngine;
using UnityEngine.SceneManagement;

namespace KoganeLib.UniDebugPanel.Demo
{
	/// <summary>
	/// 起動を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class BootChecker : MonoBehaviour
	{
		//====================================================================================
		// 変数(static)
		//====================================================================================
		private static bool m_isInit;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 初期化される時に呼び出されます
		/// </summary>
		private void Awake()
		{
			if ( m_isInit )
			{
				Destroy( gameObject );
				return;
			}

			m_isInit = true;
			SceneManager.LoadScene( "DebugPanelScene", LoadSceneMode.Additive );
		}
	}
}
