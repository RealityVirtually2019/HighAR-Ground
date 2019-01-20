﻿namespace HighAR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Person
    {

        public GameObject gameObjectPointer; // This is the related game object
        public int id;
        public bool selected;
        private int triageState;

        public Person(Vector3 position)
        {
            GameObject baseObject = (GameObject)WorldProperties.worldObject.GetComponent<WorldProperties>().personBaseObject;
            gameObjectPointer = Object.Instantiate(baseObject, WorldProperties.worldObject.transform);
            gameObjectPointer.GetComponent<PersonInteractionHandler>().classPointer = this; // Connect the gameObject back to the classObject
            gameObjectPointer.tag = "Person";
            gameObjectPointer.name = baseObject.name;
            gameObjectPointer.transform.localScale = WorldProperties.scale * 500;
            gameObjectPointer.transform.localPosition = position + new Vector3(0, WorldProperties.scale.y * 100, 0);

            selected = false;

            WorldProperties.AddClipShader(gameObjectPointer.transform);
            TriageStateChange(-1);
        }

        public Person(Vector3 position, int triageState)
        {
            GameObject baseObject = (GameObject)WorldProperties.worldObject.GetComponent<WorldProperties>().personBaseObject;
            gameObjectPointer = Object.Instantiate(baseObject, WorldProperties.worldObject.transform);
            gameObjectPointer.GetComponent<PersonInteractionHandler>().classPointer = this; // Connect the gameObject back to the classObject
            gameObjectPointer.tag = "Person";
            gameObjectPointer.name = baseObject.name;
            gameObjectPointer.transform.localScale = WorldProperties.scale * 500;
            gameObjectPointer.transform.localPosition = position + new Vector3(0, WorldProperties.scale.y * 100, 0);  
        
            selected = false;

            WorldProperties.AddClipShader(gameObjectPointer.transform);
            TriageStateChange(triageState);
        }

        public void TriageStateChange(int newTriageState)
        {
            triageState = newTriageState;
            MeshRenderer gameObjectRenderer = gameObjectPointer.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(WorldProperties.clipShader);

            newMaterial.color = WorldProperties.triageColors[triageState];
            gameObjectRenderer.material = newMaterial;
        }

        public void ClickEvent()
        {
            WorldProperties.GlobalStateHandler.MoveToLocation(gameObjectPointer.transform.position);
            WorldProperties.selectedPerson = this;
            selected = true;
        }

    }
}
