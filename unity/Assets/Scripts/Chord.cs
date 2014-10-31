using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Transition 
{
	public float weight = 1;
	public Chord chord;
}

public class Chord : MonoBehaviour
{
	[SerializeField] private Transition[] transitions;

	private float weightSum;

	void Awake()
	{
		weightSum = 0f;
		
		foreach (var transition in transitions)
		{
			weightSum += transition.weight;
		}	
	}

	public void OnDrawGizmos()
	{
		foreach (var transition in transitions)
		{
			if (transition.chord != null)
			{
				Utils.DrawArrow(transform.position, transition.chord.transform.position, 1f);
			}
		}
	}

	public Chord NextChord
	{
		get 
		{
			float random = Random.Range(0f, weightSum);

			foreach (var transition in transitions)
			{
				if (random <= transition.weight)
				{
					return transition.chord;
				}
				else
				{
					random -= transition.weight;
				}
			}

			throw new System.Exception("Could not find chord.");
		}
	}
}