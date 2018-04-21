//*******************************************************************************************************
//* Some constants.																						*
//* We use constants for animations.																	*
//*																										*
//*******************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiaConstants{

	struct DiaAnimationTuple {
		public string parameter;
		public bool value;

		public DiaAnimationTuple(string param, bool val){
			this.parameter = param;
			this.value = val;
		}
	}

	internal class DiaAnimationTuples{
		internal static DiaAnimationTuple diaLeftStartAnimation  = new DiaAnimationTuple ("DiaLeftStart", true);
		internal static DiaAnimationTuple diaLeftEndAnimation    = new DiaAnimationTuple ("DiaLeftStart", false);
		internal static DiaAnimationTuple diaRightStartAnimation = new DiaAnimationTuple ("DiaRightStart", true);
		internal static DiaAnimationTuple diaRightEndAnimation   = new DiaAnimationTuple ("DiaRightStart", false);
	}
}