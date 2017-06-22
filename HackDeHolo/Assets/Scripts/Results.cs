using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

class Results : MonoBehaviour
{
	public GameObject ElementPrefab = null;
	public bool ClearOnNewResults = true;

	public void OnResults(List<string> tags)
	{
		if (this.ClearOnNewResults)
		{
			for (var i = 0; i < transform.childCount; i++)
			{
				Destroy(transform.GetChild(i).gameObject);
			}
		}

		foreach (var tag in tags)
		{
			var go = (GameObject)Instantiate(this.ElementPrefab, this.transform);
			go.GetComponent<Text>().text = tag;
		}
	}
}
