using UnityEngine;
using UnityEngine.UI;

namespace KoganeLib.UniDebugPanel.Demo
{
	/// <summary>
	/// デモを管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class DemoScene : MonoBehaviour
	{
		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private UniDebugPanelUI	m_debugPanelUI	= null;
		[SerializeField] private Button				m_startButtonUI	= null;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 開始する時に呼び出されます
		/// </summary>
		private void Start()
		{
			m_debugPanelUI.SetDisp
			(
				new UDPData( "ロック"		, () => m_startButtonUI.interactable = false	),
				new UDPData( "アンロック"	, () => m_startButtonUI.interactable = true		)
			);

			m_startButtonUI.onClick.AddListener( () => print( "押された" ) );
		}
	}
}
