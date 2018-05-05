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
		internal static DiaAnimationTuple diaStartAnimation  = new DiaAnimationTuple ("DiaStart", true);
		internal static DiaAnimationTuple diaEndAnimation    = new DiaAnimationTuple ("DiaStart", false);
	}
}