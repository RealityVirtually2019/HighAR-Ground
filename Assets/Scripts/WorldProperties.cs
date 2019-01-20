namespace HighAR
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor;
    using UnityEngine;

#if WINDOWS_UWP
    using Windows.Storage;
    using System.Threading.Tasks;
    using Windows.Data.Xml.Dom;
    using System;
#endif

    /// <summary>
    /// This is the only class that should have static variables or functions that are consistent throughout the entire program.
    /// </summary>
    public class WorldProperties : MonoBehaviour
    {
        [SerializeField]
        public static GameObject worldObject;
        public GameObject personBaseObject;
        public GameObject cardObject;

        public Shader clipShaderInstance;
        public static Shader clipShader;
        public Shader clipShaderColoredInstance;
        public static Shader clipShaderColored;
        public Shader glowShaderInstance;
        public static Shader glowShader;

        public static Dictionary<int, Person> personDict;
        public static Dictionary<int, string> triageDescriptions;
        public static Dictionary<int, Color> triageColors;

        public static Person selectedPerson;

        public static StateHandler GlobalStateHandler;

        public static Vector3 scale;
        public static Vector3 currentScale;

        // Use this for initialization
        void Start()
        {
            worldObject = gameObject;
            clipShader = clipShaderInstance;
            clipShaderColored = clipShaderColoredInstance;
            glowShader = glowShaderInstance;

            personDict = new Dictionary<int, Person>(); // Collection of all the drone classObjects
            triageDescriptions = new Dictionary<int, string>(); // Collection of all the drone classObjects
            triageColors = new Dictionary<int, Color>(); // Collection of all the drone classObjects

            selectedPerson = null;

            GlobalStateHandler = gameObject.GetComponent<StateHandler>();

            scale = new Vector3(1, 1, 1);

            SetupTriageStates();
            
            AddClipShader(gameObject.transform);

            LoadPeople();
        }

        public void SetupTriageStates()
        {
            triageDescriptions[0] = "PRIORITY 0 – these patients are not considered to be savable out in the field – prioritize care for other patient categorizations";
            triageColors[0] = Color.black;
            triageDescriptions[1] = "PRIORITY 1 – these patients are in immediate need of higher-level medical care, top priority on evacuation – risk loss of life/limb/eyesight without intervention";
            triageColors[1] = Color.red;
            triageDescriptions[2] = "PRIORITY 2 – these patients require immediate assistance, but there is not necessarily a risk to life/ limb / eyesight at the moment";
            triageColors[2] = Color.yellow;
            triageDescriptions[3] = "PRIORITY 3 – lowest priority “walking wounded” – minor injuries that are not expected to be life-threatening";
            triageColors[3] = Color.green;
            triageDescriptions[-1] = "Involved - Uninjured";
            triageColors[-1] = Color.grey;
        }

        public bool LoadPeople()
        {
            //Testing
            new Person(new Vector3(0, 0, 0), 1);
            new Person(new Vector3(0, 0, 1), 1);
            new Person(new Vector3(0, 0, -1), 1);
            new Person(new Vector3(1, 0, 0), 1);
            new Person(new Vector3(-1, 0, 0), 1);
            new Person(new Vector3(-2, 0, 0), 1, "hello world!", "617-222-5555", "42.359, -71.053");

            string plainTextData = "";

//#if WINDOWS_UWP

//                    Task task = new Task(

//                        async () =>
//                        {                              
//                            StorageFile textFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Text.txt"));
//                            plainTextData = await FileIO.ReadTextAsync(textFile);
//                        });
//                    task.Start();
//                    task.Wait();

//#endif
            if (plainTextData != "")
            {
                new Person(new Vector3(-1, 0, 2), 2);
            }

            string[] linesInFile = plainTextData.Split('\n');
            foreach (string line in linesInFile)
            {
                string[] entries = line.Split(',');
                if (entries.Length >= 4)
                {
                    new Person(new Vector3(
                        float.Parse(entries[0]),
                        float.Parse(entries[1]),
                        float.Parse(entries[2])),
                        int.Parse(entries[3]));
                }
                // x, y, z
                else if (entries.Length >= 3)
                {
                    new Person(new Vector3(
                        float.Parse(entries[0]),
                        float.Parse(entries[1]),
                        float.Parse(entries[2])));
                }
            }

            return true;
        }

        /// <summary>
        /// Recursively adds the clipShader to the parent and all its children
        /// </summary>
        /// <param name="parent">The topmost container of the objects which will have the shader added to them</param>
        public static void AddClipShader(Transform parent)
        {
            if (parent.GetComponent<Renderer>())
            {
                parent.GetComponent<Renderer>().material.shader = clipShader;
            }

            foreach (Transform child in parent)
            {
                AddClipShader(child);
            }
        }
    }
}