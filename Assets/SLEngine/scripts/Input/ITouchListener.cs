using UnityEngine;
using System.Collections;

namespace SLEngine.Inputs
{
	public interface ITouchListener {
		void TouchBegin (Touch data);
		void TouchMove (Touch data);
		void TouchEnd(Touch data);
	}
}
