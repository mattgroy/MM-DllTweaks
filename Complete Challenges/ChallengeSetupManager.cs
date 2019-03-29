using System;
using System.Collections.Generic;
using System.IO;

public class ChallengeSetupManager
{
	// There are a lot of different methods, and I only touched two of them,
	// so I will only include changed methods in this file.

	// Even though my code here is bad, you will only need to run the game with this code once
	// and all challenges (except for two careers) will instantly be completed, so why bother anyway :)

	/* CHANGED METHOD:
	public bool isChallengeComplete(Challenge inChallenge)
	{
		if (!inChallenge.isCustomChallenge)
		{
			return inChallenge.HasBeenCompleted();
		}
		if (this.mChallengeSettings.ContainsKey(inChallenge.id))
		{
			return this.mChallengeSettings[inChallenge.id];
		}
		if (!this.ValidateChallengeSettings())
		{
			this.SaveChallengeSettings();
		}
		return false;
	}
	*/

	public bool isChallengeComplete(Challenge inChallenge)
	{
		if (!inChallenge.isCustomChallenge)
		{
			return inChallenge.HasBeenCompleted();
		}
		this.ValidateChallengeSettings();
		if (!this.mChallengeSettings.ContainsKey(inChallenge.id))
		{
			if (!this.ValidateChallengeSettings())
			{
				this.SaveChallengeSettings();
			}
			return false;
		}
		this.mChallengeSettings[inChallenge.id] = true;
		this.SaveChallengeSettings();
		return this.mChallengeSettings[inChallenge.id];
	}

	/* CHANGED METHOD:
	private bool ValidateChallengeSettings()
	{
		if (!this.isChallengesActive())
		{
			return false;
		}
		bool result = true;
		int count = Game.instance.challengeManager.challenges.Count;
		for (int i = 0; i < count; i++)
		{
			Challenge challenge = Game.instance.challengeManager.challenges[i];
			if (challenge.isCustomChallenge && !this.mChallengeSettings.ContainsKey(challenge.id))
			{
				this.mChallengeSettings.Add(challenge.id, false);
				result = false;
			}
		}
		return result;
	}
	*/

	private bool ValidateChallengeSettings()
	{
		if (!this.isChallengesActive())
		{
			return false;
		}
		bool result = true;
		int count = Game.instance.challengeManager.challenges.Count;
		for (int i = 0; i < count; i++)
		{
			Challenge challenge = Game.instance.challengeManager.challenges[i];
			if (challenge.isCustomChallenge && !this.mChallengeSettings.ContainsKey(challenge.id))
			{
				this.mChallengeSettings.Add(challenge.id, true);
				result = false;
			}
			else if (challenge.isCustomChallenge && this.mChallengeSettings.ContainsKey(challenge.id))
			{
				this.mChallengeSettings[challenge.id] = true;
			}
		}
		return result;
	}
}
