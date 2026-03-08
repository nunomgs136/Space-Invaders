using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;

    public int pontos = 0;

    void Awake()
    {
        instance = this;
    }

    public void InimigoDestruido()
    {
        pontos++;
        Debug.Log("Pontos: " + pontos);
    }

    void OnGUI()
    {
        GUIStyle estilo = new GUIStyle(GUI.skin.label);
        estilo.fontSize = 30;
        estilo.normal.textColor = Color.white;

        GUI.Label(new Rect(Screen.width - 200, 20, 300, 40), "Pontos: " + pontos, estilo);
    }
}