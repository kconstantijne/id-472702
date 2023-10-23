using System;
using Gtk;

namespace YourApplication
{
    public class MainForm : Window
    {
        public MainForm() : base("Основне вікно")
        {
            SetDefaultSize(400, 300);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (o, args) => Application.Quit();

            var label = new Label("Це основне вікно");
            var button = new Button("Виконати інший код");
            button.Clicked += OnExecuteCodeClicked;

            var vbox = new VBox();
            vbox.PackStart(label, false, false, 10);
            vbox.PackStart(button, false, false, 10);

            Add(vbox);
        }

        private void OnExecuteCodeClicked(object sender, EventArgs e)
        {
            // Тут ви можете запустити інший код, коли користувач натискає кнопку.
            Console.WriteLine("Виконуємо інший код.");
        }
    }

    public class LoginForm
    {
        private Entry txtUsername;
        private Entry txtPassword;
        private Button btnLogin;
        private Window window;

        public LoginForm()
        {
            Application.Init();

            window = new Window("Авторизація");
            window.SetDefaultSize(300, 200);
            window.SetPosition(WindowPosition.Center);
            window.DeleteEvent += Window_DeleteEvent;

            var vbox = new VBox();

            var labelUsername = new Label("Ім'я користувача:");
            txtUsername = new Entry();

            var labelPassword = new Label("Пароль:");
            txtPassword = new Entry();
            txtPassword.InvisibleChar = '*'; // Поле паролю зі заміненими символами

            btnLogin = new Button("Вхід");
            btnLogin.Clicked += OnLoginClicked;

            vbox.PackStart(labelUsername, false, false, 10);
            vbox.PackStart(txtUsername, false, false, 10);
            vbox.PackStart(labelPassword, false, false, 10);
            vbox.PackStart(txtPassword, false, false, 10);
            vbox.PackStart(btnLogin, false, false, 10);

            window.Add(vbox);
            window.ShowAll();
        }

        private void Window_DeleteEvent(object o, DeleteEventArgs args)
        {
            Application.Quit();
        }

        private void OnLoginClicked(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (IsLoginValid(username, password))
            {
                // Авторизація успішна. Запускаємо інший C# код.
                string otherCodePath = "/home/kconstantijne/Документи/Projects/id-472702/SimpleWindowApp.cs"; // Вкажіть шлях до іншого коду

                // Запускаємо інший C# код у новому процесі
                System.Diagnostics.Process.Start("mono", otherCodePath);

                // При бажанні, ви можете сховати вікно авторизації або робити інші дії.

                // Сховування вікна авторизації:
                window.Hide();
            }
            else
            {
                // Помилка авторизації. Повідомте користувача.
                var dialog = new MessageDialog(null, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Неправильне ім'я користувача або пароль.");
                dialog.Run();
                dialog.Destroy();
            }
        }

        private bool IsLoginValid(string username, string password)
        {
            // Тут ви маєте виконати перевірку авторизації на основі ваших даних користувачів.
            // Повертає true, якщо авторизація успішна, інакше - false.
            // Для прикладу, додайте просту перевірку з фіксованими даними.
            return username == "admin" && password == "password";
        }

        public static void Main(string[] args)
        {
            new LoginForm();
            Application.Run();
        }
    }
}
