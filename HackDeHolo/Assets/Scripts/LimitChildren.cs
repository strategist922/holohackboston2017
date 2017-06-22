using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitChildren : MonoBehaviour
{
	public int Limit = 5;

	private void Start()
	{
		LimitCount();
	}

	private void Update()
	{
		LimitCount();
	}

	private void LimitCount()
	{
		if (transform.childCount > this.Limit)
		{
			for (var i = this.Limit; i < transform.childCount; i++)
			{
				var child = transform.GetChild(i);
				Destroy(child.gameObject);
			}
		}
	}
}
