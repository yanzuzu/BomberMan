using UnityEngine;
using System.Collections;

namespace SLEngine.Inputs
{
	public interface ITouchListener {
		void TouchBegin (Vector2 startPos);
		void TouchMove (Vector2 currentPos, Vector2 deltaPos);
		void TouchEnd(Vector2 endPos);
	}
}
