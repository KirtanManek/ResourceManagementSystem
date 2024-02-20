﻿using SecurityDriven.Core;

namespace ResourceManagementSystem
{
	public static class PasswordGenerator
	{
		public static string Generate(
			int requiredLength = 8,
			int requiredUniqueChars = 4,
			bool requireDigit = true,
			bool requireLowercase = true,
			bool requireNonAlphanumeric = true,
			bool requireUppercase = true)
		{
			string[] randomChars = [
				"ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
				"abcdefghijkmnopqrstuvwxyz",    // lowercase
				"0123456789",                   // digits
				"!@$?_-"                        // non-alphanumeric
			];
			CryptoRandom rand = new();
			List<char> chars = [];

			if (requireUppercase)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[0][rand.Next(0, randomChars[0].Length)]);

			if (requireLowercase)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[1][rand.Next(0, randomChars[1].Length)]);

			if (requireDigit)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[2][rand.Next(0, randomChars[2].Length)]);

			if (requireNonAlphanumeric)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[3][rand.Next(0, randomChars[3].Length)]);

			for (int i = chars.Count; i < requiredLength
				|| chars.Distinct().Count() < requiredUniqueChars; i++)
			{
				string rcs = randomChars[rand.Next(0, randomChars.Length)];
				chars.Insert(rand.Next(0, chars.Count),
					rcs[rand.Next(0, rcs.Length)]);
			}

			return new string(chars.ToArray());
		}
	}
}
