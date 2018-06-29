using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// public class ValueWrapper<T>
// {
// 	public ValueWrapper(T value)
// 	{
// 		Value = value;
// 	}
// 
// 	public T Value;
// }
// 
// public class TestReferenceList : MonoBehaviour
// {
// 	public ValueWrapper<int> TestInt = new ValueWrapper<int>(1);
// 
// 	public List<ValueWrapper<int>> TestList;
// 
// 
// 	void Start()
// 	{
// 		TestFunc();
// 		Debug.Log("Hello");
// 	}
// 
// 	void TestFunc()
// 	{
// 		TestList = new List<ValueWrapper<int>>();
// 		TestList.Add(TestInt);
// 
// 		for (int i = 0; i < TestList.Count; i++)
// 		{
// 			TestList[i].Value++;
// 			Debug.Log("Class field: " + TestInt.Value + ", list element: " + TestList[i].Value);
// 			// prints Class field: 2, list element: 2
// 		}
// 	}
// }
// 
// 