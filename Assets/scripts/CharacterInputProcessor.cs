using UnityEngine;
using System.Collections;
using SLEngine.Inputs;
using SLEngine;
using SLEngine.Debug;

public class CharacterInputProcessor: ITouchListener {

	public CharacterInputProcessor()
	{
		Singleton<TouchProcessor>.Instance.Register (this);
	}

	#region TOUCH LISTENER
	public void TouchBegin (Vector2 startPos)
	{
		SLDebug.Log ("TouchBegin pos = " + startPos );
	}

	public void TouchMove (Vector2 currentPos, Vector2 deltaPos)
	{
		SLDebug.Log ("TouchMove pos = " + currentPos );
	}

	public void TouchEnd(Vector2 endPos)
	{
		SLDebug.Log ("TouchEnd pos = " + endPos );
	}

	#endregion
}
