using UnityEngine;
using System.Collections;

public class Utils 
{
	public static void DrawArrow(Vector3 a, Vector3 b, float radius)
	{
		Vector3 a2b = b - a;
		Vector3 b2a = -a2b;
		Vector3 flip = new Vector3(a2b.y , -a2b.x, 0f).normalized;

		Gizmos.DrawLine(a + a2b.normalized * radius, b + b2a.normalized * radius - a2b.normalized);
		Gizmos.DrawLine(b + b2a.normalized * radius, b + b2a.normalized * radius - flip * 0.3f - a2b.normalized);
		Gizmos.DrawLine(b + b2a.normalized * radius, b + b2a.normalized * radius + flip * 0.3f - a2b.normalized);
		Gizmos.DrawLine(b + b2a.normalized * radius - flip * 0.3f - a2b.normalized, b + b2a.normalized * radius + flip * 0.3f - a2b.normalized);
	}
}
