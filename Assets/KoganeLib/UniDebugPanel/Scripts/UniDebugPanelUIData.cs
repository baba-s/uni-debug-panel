using System;

namespace KoganeLib.UniDebugPanel
{
	/// <summary>
	/// デバッグパネルのデータを管理するクラス
	/// </summary>
	public sealed class UDPData
	{
		//====================================================================================
		// 変数(readonly)
		//====================================================================================
		public readonly string m_text		;
		public readonly Action m_onClick	;

		//====================================================================================
		// 関数
		//====================================================================================
		public UDPData
		(
			string text		,
			Action onClick
		)
		{
			m_text		= text		;
			m_onClick	= onClick	;
		}
	}
}