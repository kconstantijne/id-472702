using System;
using Gtk;

class SimpleWindowApp
{
    static void Main()
    {
        Application.Init();

        // Создаем окно
        Window window = new Window("Простое оконное приложение");
        window.SetDefaultSize(400, 200);

        // Создаем кнопку
        Button button = new Button("Нажми меня!");
        button.Clicked += Button_Click;

        // Добавляем кнопку на окно
        window.Add(button);

        // Завершаем приложение при закрытии окна
        window.DeleteEvent += (o, args) => Application.Quit();

        // Отображаем окно
        window.ShowAll();

        Application.Run();
    }

    static void Button_Click(object sender, EventArgs e)
    {
        MessageDialog dialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Привет, мир!");
        dialog.Run();
        dialog.Destroy();
    }
}
