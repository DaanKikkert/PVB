using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.Multi
{
    public class FieldCustom : MonoBehaviour
    {
        [Header("Input field Settings: ")]
        [SerializeField] private InputField nameField;

        [Header("Show Username: ")] 
        [SerializeField] private Text showText;

        private void Update() => showText.text = "Welcome: " + nameField.text;
        public void SubmitName() => PhotonNetwork.NickName = nameField.text;
    }
}
