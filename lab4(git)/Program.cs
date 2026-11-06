using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab4Git
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }

    public class MainWindow : Form
    {
        public MainWindow()
        {
            Text = "Главная форма";
            ClientSize = new Size(460, 260);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label();
            title.Text = "Лабораторная работа № 4";
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.Location = new Point(40, 30);
            title.Size = new Size(390, 40);

            Button openButton = new Button();
            openButton.Text = "Перейти на вторую форму";
            openButton.Location = new Point(100, 100);
            openButton.Size = new Size(260, 45);
            openButton.Click += OpenSecondWindow;

            Button exitButton = new Button();
            exitButton.Text = "Выход";
            exitButton.Location = new Point(100, 165);
            exitButton.Size = new Size(260, 45);
            exitButton.Click += delegate { Close(); };

            Controls.Add(title);
            Controls.Add(openButton);
            Controls.Add(exitButton);
        }

        private void OpenSecondWindow(object sender, EventArgs e)
        {
            Hide();

            using (SecondWindow secondWindow = new SecondWindow())
            {
                secondWindow.ShowDialog();
            }

            Show();
        }
    }

    public class SecondWindow : Form
    {
        public SecondWindow()
        {
            Text = "Вторая форма";
            ClientSize = new Size(460, 300);
            StartPosition = FormStartPosition.CenterScreen;

            Label message = new Label();
            message.Text = "Вы перешли на вторую форму!";
            message.Font = new Font("Arial", 13);
            message.Location = new Point(40, 35);
            message.Size = new Size(390, 40);

            Button backButton = new Button();
            backButton.Text = "Вернуться назад";
            backButton.Location = new Point(100, 220);
            backButton.Size = new Size(260, 45);
            backButton.Click += delegate { Close(); };

            Controls.Add(message);
            Controls.Add(backButton);
        }
    }
}