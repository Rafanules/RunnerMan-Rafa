using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class LoadGame : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    private int dificultadSeleccionada;

void Start()
{
    // Asegúrate de que hay Toggles en el grupo
    if (toggleGroup != null && toggleGroup.transform.childCount > 0)
    {
        // Encuentra el primer Toggle en el grupo y actívalo
        Toggle firstToggle = toggleGroup.GetComponentInChildren<Toggle>();
        if (firstToggle != null)
        {
            firstToggle.isOn = true;
            OnToggleChanged(); // Actualiza la dificultad seleccionada inmediatamente
        }
    }
    else
    {
        Debug.LogError("No se encontraron Toggles en el ToggleGroup o el ToggleGroup no está asignado.");
    }
}

public void OnToggleChanged()
    {
        Toggle toggleActivo = toggleGroup.ActiveToggles().FirstOrDefault();
        if (toggleActivo != null)
        {
            ToggleData data = toggleActivo.GetComponent<ToggleData>();
            if (data != null)
            {
                dificultadSeleccionada = data.dificultadValor;
                PlayerPrefs.SetInt("DificultadSeleccionada", dificultadSeleccionada);
                PlayerPrefs.Save();
            }
        }
    }

    public void LoadGameScene()
    {
        // Aquí asumimos que OnToggleChanged se ha llamado y el valor está almacenado
        SceneManager.LoadScene("SampleScene");
    }


}
