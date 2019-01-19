namespace HighAR
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
            //gameObjectPointer.GetComponent<PersonProperties>().classPointer = this; // Connect the gameObject back to the classObject
            gameObjectPointer.tag = "Person";
            gameObjectPointer.name = baseObject.name;
            gameObjectPointer.transform.localScale = WorldProperties.scale * 10;
            gameObjectPointer.transform.localPosition = position;

            selected = false;

            TriageStateChange(-1);

            //WorldProperties.AddClipShader(gameObjectPointer.transform);
        }

        public Person(Vector3 position, int triageState)
        {
            GameObject baseObject = (GameObject)WorldProperties.worldObject.GetComponent<WorldProperties>().personBaseObject;
            gameObjectPointer = Object.Instantiate(baseObject, WorldProperties.worldObject.transform);
            //gameObjectPointer.GetComponent<PersonProperties>().classPointer = this; // Connect the gameObject back to the classObject
            gameObjectPointer.tag = "Person";
            gameObjectPointer.name = baseObject.name;
            gameObjectPointer.transform.localScale = WorldProperties.scale * 10;
            gameObjectPointer.transform.localPosition = position;  

            selected = false;

            TriageStateChange(triageState);

            //WorldProperties.AddClipShader(gameObjectPointer.transform);
        }

        public void TriageStateChange(int newTriageState)
        {
            triageState = newTriageState;
            MeshRenderer gameObjectRenderer = gameObjectPointer.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(Shader.Find("Standard"));

            newMaterial.color = WorldProperties.triageColors[triageState];
            gameObjectRenderer.material = newMaterial;
        }

    }
}
