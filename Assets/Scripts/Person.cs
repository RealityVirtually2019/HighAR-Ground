namespace HighAR
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Person
    {
        public GameObject gameObjectCard;
        public GameObject gameObjectPointer; // This is the related game object
        public int id;
        public bool selected;
        private int triageState;
        private string cardName;
        private string cardPhone;
        private string cardLocation;

        public Person(Vector3 position)
        {
            GameObject baseObject = (GameObject)WorldProperties.worldObject.GetComponent<WorldProperties>().personBaseObject;
            gameObjectPointer = Object.Instantiate(baseObject, WorldProperties.worldObject.transform);
            gameObjectPointer.GetComponent<PersonInteractionHandler>().classPointer = this; // Connect the gameObject back to the classObject
            gameObjectPointer.tag = "Person";
            gameObjectPointer.name = baseObject.name;
            gameObjectPointer.transform.localScale = WorldProperties.scale * 1000;
            gameObjectPointer.transform.localPosition = position + new Vector3(0, WorldProperties.scale.y * 50, 0);

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
            gameObjectPointer.transform.localScale = WorldProperties.scale * 1000;
            gameObjectPointer.transform.localPosition = position*50 + new Vector3(0, WorldProperties.scale.y * 10, 0);  
        
            selected = false;

            TriageStateChange(triageState);
        }

        public Person(Vector3 position, int triageState, string cardName)
        {
            GameObject cardObject = (GameObject)WorldProperties.worldObject.GetComponent<WorldProperties>().cardObject;
            GameObject baseObject = (GameObject)WorldProperties.worldObject.GetComponent<WorldProperties>().personBaseObject;
            gameObjectPointer = Object.Instantiate(baseObject, WorldProperties.worldObject.transform);
            gameObjectPointer.GetComponent<PersonInteractionHandler>().classPointer = this; // Connect the gameObject back to the classObject
            gameObjectPointer.tag = "Person";
            gameObjectPointer.name = baseObject.name;
            gameObjectPointer.transform.localScale = WorldProperties.scale * 500;
            gameObjectPointer.transform.localPosition = position + new Vector3(0, WorldProperties.scale.y * 100, 0);

            gameObjectCard = Object.Instantiate(cardObject, gameObjectPointer.transform);
            gameObjectCard.GetComponent<FaceMe>().Name.text = cardName;
            

            selected = false;

            WorldProperties.AddClipShader(gameObjectPointer.transform);
            TriageStateChange(triageState);
        }


        public void TriageStateChange(int newTriageState)
        {
            triageState = newTriageState;
            MeshRenderer gameObjectRenderer = gameObjectPointer.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(WorldProperties.clipShaderColored);

            newMaterial.color = WorldProperties.triageColors[triageState];
            gameObjectRenderer.material = newMaterial;
        }

        public void ClickEvent()
        {
            WorldProperties.GlobalStateHandler.MoveToLocation(gameObjectPointer.transform.position);
            WorldProperties.selectedPerson = this;
            selected = true;
            gameObjectPointer.transform.localScale *= 10;
        }

        public void HoverEvent()
        {
            MeshRenderer gameObjectRenderer = gameObjectPointer.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(WorldProperties.clipShaderColored);
            newMaterial.color = WorldProperties.triageColors[triageState];
            gameObjectRenderer.material = newMaterial;
            
        }

        public void HoverEnd()
        {
            gameObjectPointer.transform.localScale *= 10;
            MeshRenderer gameObjectRenderer = gameObjectPointer.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(WorldProperties.clipShaderColored);
            newMaterial.color = WorldProperties.triageColors[triageState];
            gameObjectRenderer.material = newMaterial;
           
        }
    }
}
