using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanEventHandler : MonoBehaviour, Vuforia.ITrackableEventHandler 
{
	// モデル
	public GameObject[] model;
	int modelIndex = 0;

	[SerializeField]
	private Vuforia.TrackableBehaviour mTrackableBehaviour;

	[SerializeField]
	MeshRenderer alphaPlane;

	// Use this for initialization
	IEnumerator Start () 
	{
		mTrackableBehaviour.RegisterTrackableEventHandler(this);

		// temp
		yield return null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	/// <summary>
	/// xxxのイベント
	/// </summary>
	public void OnTrackableStateChanged( Vuforia.TrackableBehaviour.Status previousStatus, Vuforia.TrackableBehaviour.Status newStatus )
	{
		Debug.LogError("previousStatus:" + previousStatus + "newStatus" + newStatus );

		if( newStatus.Equals( Vuforia.TrackableBehaviour.Status.TRACKED ) && newStatus.Equals( Vuforia.TrackableBehaviour.Status.NOT_FOUND ) )
		{
			StartCoroutine( Fade( false ) );
		}

	}

	/// <summary>
	/// フェード処理
	/// </summary>
	/// <param name="bIn">If set to <c>true</c> b in.</param>
	private IEnumerator Fade(bool bIn)
	{
		Debug.Log("フェード処理開始");

		if( bIn )
		{
			
		}
		else
		{
			// フェードアウト
			// BGM

			// モデル
			var a = 1f;
			var color = alphaPlane.material.color;
			while( a > 0 )
			{
				a -= Time.deltaTime;
				alphaPlane.material.color = new Color( color.r, color.g, color.b, a );

				yield return null;
			}
		}
		Debug.Log("フェード処理完了");

	}

	public void SwitchModel()
	{
		modelIndex++;
		if( modelIndex >= model.Length )
			modelIndex = 0;

		for( int i=0 ; i < model.Length ; ++i )
		{
			var m = model[i];
			m.SetActive( i.Equals( modelIndex ) );
		}
	}
}
