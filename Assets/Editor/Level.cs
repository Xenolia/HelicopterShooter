﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Level : MonoBehaviour
{
    
    Transform StartLine;
    public int LevelNumber;
    [Header("Road")]
    public GameObject _StartBlock;
    public GameObject Block1;
    public GameObject Block2;
    public GameObject Block3;
    public GameObject Block4;
    public GameObject Block5;
    public GameObject Block6;

    public GameObject EndBlock;
    GameObject Empty;
    // Update is called once per frame
    public void StartBlock()
    {

        GameObject Track = PrefabUtility.InstantiatePrefab(_StartBlock) as GameObject;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);


    }

    public void block1()
    {

        int RandRot = Random.Range(0, 4);
        GameObject Track = PrefabUtility.InstantiatePrefab(Block1) as GameObject;
        Track.transform.position = StartLine.transform.position;
        Track.transform.Rotate(Vector3.up * 90 * RandRot);
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }

    public void block2()
    {
        int RandRot = Random.Range(0, 4);
        GameObject Track = PrefabUtility.InstantiatePrefab(Block2) as GameObject;
        Track.transform.position = StartLine.transform.position;
        Track.transform.Rotate(Vector3.up * 90 * RandRot);
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }


    public void block3()
    {
        int RandRot = Random.Range(0, 4);
        GameObject Track = PrefabUtility.InstantiatePrefab(Block3) as GameObject;
        Track.transform.position = StartLine.transform.position;
        Track.transform.Rotate(Vector3.up * 90 * RandRot);
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }


    public void block4()
    {
        int RandRot = Random.Range(0, 4);

        GameObject Track = PrefabUtility.InstantiatePrefab(Block4) as GameObject;
        Track.transform.position = StartLine.transform.position;
        Track.transform.Rotate(Vector3.up * 90 * RandRot);

        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }

    public void block5()
    {
        int RandRot = Random.Range(0, 4);
        GameObject Track = PrefabUtility.InstantiatePrefab(Block5) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.Rotate(Vector3.up * 90 * RandRot);
        Track.transform.SetParent(Empty.transform);
    }


    public void block6()
    {
        int RandRot = Random.Range(0, 4);
        GameObject Track = PrefabUtility.InstantiatePrefab(Block6) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.Rotate(Vector3.up * 90 * RandRot);
        Track.transform.SetParent(Empty.transform);
    }


    public void endblock()
    {
        GameObject Track = PrefabUtility.InstantiatePrefab(EndBlock) as GameObject;
        Track.transform.position = StartLine.transform.position;
        StartLine = Track.transform.GetChild(0).transform;
        Track.transform.SetParent(Empty.transform);
    }

    public void CreateLevelEmpty()
    {
        Empty = new GameObject("Level_" + LevelNumber);

    }
}
