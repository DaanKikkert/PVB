using System;
using UnityEngine;

namespace Code.Scripts.Build_Structure
{
    public class BuildStructure : MonoBehaviour
    {

        [SerializeField] private GameObject buildUI;
        [SerializeField] private GameObject[] structures;
        
        private bool _canBuild;
        private Transform _getTransform;

        private void Start() => buildUI.SetActive(false);
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _canBuild)
                buildUI.SetActive(true);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("BuildSite"))
            {
                _getTransform = other.transform;
                if (_getTransform.childCount == 0)
                    _canBuild = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            buildUI.SetActive(false);
            _canBuild = false;
        }

        public void Build(int numberOfStructure)
        {
            _canBuild = false;
            GameObject spawnedObject = Instantiate(structures[numberOfStructure], _getTransform.position, Quaternion.identity);
            spawnedObject.transform.parent = _getTransform;
            spawnedObject.transform.localPosition += Vector3.up;
            
            buildUI.SetActive(false);
        }
    }
}
