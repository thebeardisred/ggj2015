﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class s_formulaic : MonoBehaviour {

	public GameObject formula;
    public int difficulty;
	public float reqDelay;
	private float lastReqTime;
	public List<int[]> formulas = new List<int[]>();
	public int formCount;
	public List<s_formulaInstance> formInstances;

	// Use this for initialization
	void Start () {
		formCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		generateRequirement();
	}

	//display requirements

	struct formulaicStruct {
		public int[] reqIntStruct;
		public reqType[] reqTypeStuct;
	}

	//generate random element requirements
	private formulaicStruct newRequirement(){
		formulaicStruct rs = new formulaicStruct();
		int[] reqInt = new int[4];
		for(int i = 0; i < 4; i++){
			reqInt[i] = UnityEngine.Random.Range(0,difficulty + 1);
		}
		rs.reqIntStruct = reqInt;

		reqType[] reqT = new reqType[4];
		Array values = Enum.GetValues(typeof(reqType));
		for(int i = 0; i < 4; i++){
			reqT[i] = (reqType)values.GetValue(UnityEngine.Random.Range(0,values.Length));
		}
		rs.reqTypeStuct = reqT;

		return rs;
	}

	private void generateRequirement(){
		float now = Time.realtimeSinceStartup;
		float timeSinceLast = now - lastReqTime;
		if (timeSinceLast > reqDelay){
			lastReqTime = now;
			formulaicStruct req = newRequirement();
			GameObject i_requirement = Instantiate(formula,
			                                       transform.position + new Vector3(-25,-25,0),
			                                       new Quaternion(0, 0, 0, 0)) as GameObject;
//			i_requirement.transform.parent = gameObject.transform;
			i_requirement.transform.SetParent(gameObject.transform);
			s_formulaInstance s_i_requirement = i_requirement.GetComponent<s_formulaInstance>();
			s_i_requirement.numReq = req.reqIntStruct;
			s_i_requirement.reqTypeArray = req.reqTypeStuct;
			s_i_requirement.formNumber = ++formCount;
			formInstances.Add(s_i_requirement);
		}
	}

	public void achieveFormula(s_formulaInstance fi){
		formInstances.Remove(fi);
	}

}