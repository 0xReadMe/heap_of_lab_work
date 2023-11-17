using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agents
{
    /// <summary>
    /// Логика взаимодействия для AddingAgentWindow.xaml
    /// </summary>
    public partial class AddingAgentWindow : Window
    {
        private Agent _agent = new Agent(); 

        public AddingAgentWindow()
        {
            InitializeComponent();
            var allTypes = RustleEntities3.GetContext().AgentTypes.ToList();
            CBFilter.ItemsSource = allTypes;
            CBFilter.SelectedIndex = 0;


            DataContext = _agent;
        }

        private void ButAdd_Click(object sender, RoutedEventArgs e)
        {
            _agent.TypeID = CBFilter.SelectedIndex + 1;

            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_agent.AgentName))
            {
                errors.AppendLine("Имя слишком короткое");
            }
            if (string.IsNullOrEmpty(_agent.AgentEmail) || _agent.AgentEmail.Length < 6)
            {
                errors.AppendLine("Email слишком короткий");
            }
            if (string.IsNullOrEmpty(_agent.AgentEmail) || _agent.AgentPhone.Length < 6)
            {
                errors.AppendLine("Номер телефона слишком короткий");
            }
            if (string.IsNullOrEmpty(_agent.AgentLogo))
            {
                errors.AppendLine("Выбирете логотип");
            }
            if (string.IsNullOrEmpty(_agent.AgentAddress) || _agent.AgentAddress.Length < 10)
            {
                errors.AppendLine("Адресс слишком короткий");
            }
            if (_agent.AgentPriority < 0)
            {
                errors.AppendLine("Укажите приоритет");
            }
            if (string.IsNullOrEmpty(_agent.Director) || _agent.Director.Length < 3)
            {
                errors.AppendLine("Укажите имя директора");
            }
            if (_agent.AgentINN < 99999)
            {
                errors.AppendLine("Укажите ИНН");
            }
            if (_agent.AgentKPP < 99999)
            {
                errors.AppendLine("Укажите КПП");
            }


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_agent.AgentID == 0)
            {
               
                RustleEntities3.GetContext().Agent.Add(_agent);
            }

            try
            {
                RustleEntities3.GetContext().SaveChanges();
                MessageBox.Show("Агент добавлен в список");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void ButRet_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void BtAddImg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var _agentForCount = RustleEntities3.GetContext().Agent.ToList();

                OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
                openFileDialog.ShowDialog(); // показываем
                string _BaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var resourcePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(_BaseDirectory, @"..\..\")) + $"Resources\\agents\\agent_{_agentForCount.Count + 1}.png";
                if (File.Exists(resourcePath))
                {
                    File.Delete(resourcePath);
                }
                File.Copy(openFileDialog.FileName, resourcePath);
                _agent.AgentLogo = "Resources\\agents\\" + $"agent_{_agentForCount.Count + 1}.png";
            }
            catch
            {
                MessageBox.Show($"Вы не выбрали изображение");
            }
        }
    }
}
