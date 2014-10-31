using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SystemJazzGenerator : MonoBehaviour
{
	[SerializeField] private Chord startChord;
	[SerializeField] private Loop loop;

	private List<Chord> chords;

	[SerializeField] private TextMesh[] chordTexts;
	[SerializeField] private Transform bar;

	void Awake()
	{
		chords = new List<Chord>();
	}

	private void UpdateChords()
	{
		while(chords.Count < chordTexts.Length)
		{
			Chord lastChord = chords[chords.Count - 1];
			chords.Add(lastChord.NextChord);
		}

		for (int i = 0; i < chordTexts.Length; i++)
		{
			chordTexts[i].text = chords[i].gameObject.name;
		}
	}

	IEnumerator Start()
	{
		chords.Add(startChord);
		UpdateChords();

		audio.clip = loop.clip;
		audio.Play();
		float lastTime = 0;

		int i = 0;
		while (true)
		{
			bar.localScale = new Vector3(audio.time/audio.clip.length, 1f, 1f);

			if (audio.time < lastTime)
			{
				i++;
				chords.RemoveAt(0);
				UpdateChords();
			}

			lastTime = audio.time;

			yield return null;
		}
	}

	void OnDrawGizmos()
	{
		if (chords != null && chords.Count > 0)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(chords[0].transform.position, 1f);
		}
	}
}