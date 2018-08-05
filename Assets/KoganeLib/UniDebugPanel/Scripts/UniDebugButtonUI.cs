using System;
using UnityEngine;
using UnityEngine.UI;

namespace KoganeLib.UniDebugPanel
{
	/// <summary>
	/// デバッグボタンの UI を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed partial class UniDebugButtonUI : MonoBehaviour
	{
		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private Button	m_buttonUI	= null;
		[SerializeField] private Text	m_textUI	= null;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 表示を設定します
		/// </summary>
		public void SetDisp( UDPData data )
		{
			SetDisp( data.m_text, data.m_onClick );
		}

		/// <summary>
		/// 表示を設定します
		/// </summary>
		public void SetDisp( string text, Action onClick )
		{
			m_buttonUI.onClick.RemoveAllListeners();
			m_buttonUI.onClick.AddListener( () => onClick() );

			m_textUI.text = text;
		}
	}
}
