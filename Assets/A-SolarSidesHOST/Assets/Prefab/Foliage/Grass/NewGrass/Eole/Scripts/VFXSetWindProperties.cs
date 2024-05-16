//Eole
//Copyright protected under Unity Asset Store EULA

using UnityEngine;
using UnityEngine.VFX;

namespace Eole.VFX
{
    [ExecuteAlways]
    public class VFXSetWindProperties : MonoBehaviour
    {
        [SerializeField] private WindManager windManager;
        [SerializeField] private VisualEffect visualEffect;
        [Space(10)]
        [Header("Property Names")]
        [SerializeField] private string windAmplitude = "_WindAmplitude";
        [SerializeField] private string windSpeed = "_WindSpeed";
        [SerializeField] private string windDirection = "_WindDirection";
        [Space(10)]
        public bool isUpdatedEachFrame;


        private void OnEnable()
        {
            windManager ??= Utility.FindObject<WindManager>();
            visualEffect ??= GetComponent<VisualEffect>();
        }

        void Update()
        {
            if (isUpdatedEachFrame == false)
                return;

            if (visualEffect == null || windManager == null)
                return;

            SetWindData();
        }

        public void SetWindData()
        {
            if (visualEffect.HasFloat(windAmplitude))
                visualEffect.SetFloat(windAmplitude, windManager.GetAmplitude()); //* windManager.GetSpeed());
            if (visualEffect.HasFloat(windSpeed))
                visualEffect.SetFloat(windSpeed, windManager.GetSpeed());
            if (visualEffect.HasVector3(windDirection))
                visualEffect.SetVector3(windDirection, windManager.GetDirection()); //Debug.Log(windManager.GetDirection());
        }
    }
}