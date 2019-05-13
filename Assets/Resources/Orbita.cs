using UnityEngine;

public static class Orbita {

	public static void DibujarOrbita(this GameObject container, float radius, float lineWidth, int electrons) {
		var segments = 360;
		var line = container.AddComponent<LineRenderer> ();
		line.material.color = Color.black;
		line.useWorldSpace = false;
		line.startWidth = lineWidth;
		line.endWidth = lineWidth;
		line.positionCount = segments + 1;

		var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
		var points = new Vector3[pointCount];

		var degree = -1;
		var actual = -1;

		if (electrons != 0) {
			degree = segments / electrons;
			actual = degree;
		}

		for (int i = 0; i < pointCount; i++) {
			var rad = Mathf.Deg2Rad * (i * 360f / segments);
			points[i] = new Vector3(Mathf.Sin(rad) * radius, 1.5f, Mathf.Cos(rad) * radius);
			if (actual == i) {
				var tmpSphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
				tmpSphere.transform.GetComponent<Renderer> ().material.color = Color.blue;
				tmpSphere.transform.SetParent(container.transform);
				tmpSphere.transform.position = tmpSphere.transform.parent.transform.position + points[i];
				tmpSphere.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
				actual += degree;
			}
		}

		line.SetPositions(points);
	}
}