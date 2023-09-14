using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using UnityEngine.UIElements;

public class CoreUI : MonoBehaviour
{
    Button populateButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        //Получаем ссылку на компонент UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //Находим кнопку таким запросом, в параметр передаем имя кнопки
        populateButton = uiDocument.rootVisualElement.Q<Button>("populateButton");
        //Регистрируем событие нажатия кнопки
        populateButton.RegisterCallback<ClickEvent>(ClickMessage);
    }

    void ClickMessage(ClickEvent e)
    {
        //Реализуем тут любые действия при нажатии кнопки
        Debug.Log("ok");
    }
}
