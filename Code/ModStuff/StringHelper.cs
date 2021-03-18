﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ModStuff
{
	public static class StringHelper
	{
		public static bool DoStringsMatch(string string1, string string2, bool ignoreCase = true)
		{
			if (!ignoreCase) return string1 == string2;
			return string.Equals(string1, string2, StringComparison.OrdinalIgnoreCase);
		}

		public static bool DoesStringContain(string parentString, string isThisInIt, bool ignoreCase = true)
		{
			if (!ignoreCase) return parentString.Contains(isThisInIt);
			return parentString.ToLower().Contains(isThisInIt.ToLower());
		}
	}
}