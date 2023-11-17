using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Agents
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int countNow = 0;
        
        public MainWindow()
        {
            InitializeComponent();

            var allTypes = RustleEntities3.GetContext().AgentTypes.ToList();
            allTypes.Insert(0, new AgentTypes
            {
                TypeName = "Все типы"
            });
            CBFilter.ItemsSource = allTypes;
            CBFilter.SelectedIndex = 0;

            CBSort.SelectedIndex = 0;

            var agnt = RustleEntities3.GetContext().Agent.ToList();
            

            UpdateAgents();
        }

        List<List<Agent>> agentsL = new List<List<Agent>>();

        private void UpdateAgents()
        {
            var currentAgents = RustleEntities3.GetContext().Agent.ToList();

            var currentAgentsType = RustleEntities3.GetContext().AgentTypes.ToList();

            //фильтр
            if (CBFilter.SelectedIndex > 0)
            {
                currentAgents = currentAgents.Where(p => p.AgentTypes.TypeId
                == (CBFilter.SelectedItem as AgentTypes).TypeId).ToList();

            }

            //методы для поиска по номеру телефона и почте
            currentAgents =
                 currentAgents.Where(agent => agent.AgentName.ToLower().Contains(TBSearch.Text.ToLower()) ||
                 agent.AgentPhone.Contains(TBSearch.Text.ToLower()) ||
                 agent.AgentEmail.Contains(TBSearch.Text)).ToList();
            
            if(currentAgents.Count == 0)
            {
                LVAgents.ItemsSource = currentAgents.OrderBy(p => p.AgentID).ToList();
            }
            else
            {
                //реализация сортировки
                if (CBSort.SelectedIndex == 0)
                {
                    var t = currentAgents.OrderBy(p => p.AgentID).ToList();
                    MByPages(in t, ref agentsL);
                    LVAgents.ItemsSource = agentsL[countNow];
                }
                if (CBSort.SelectedIndex == 1)
                {
                    var t = currentAgents.OrderBy(p => p.AgentName).ToList();
                    MByPages(in t, ref agentsL);
                    LVAgents.ItemsSource = agentsL;
                }
                if (CBSort.SelectedIndex == 2)
                {
                    var t = currentAgents.OrderBy(p => p.Sale).ToList();
                    MByPages(in t, ref agentsL);
                    LVAgents.ItemsSource = agentsL[countNow];
                }
                if (CBSort.SelectedIndex == 3)
                {
                    var t = currentAgents.OrderBy(p => p.AgentPriority).ToList();
                    MByPages(in t, ref agentsL);
                    LVAgents.ItemsSource = agentsL[countNow];
                }
                if (CBSort.SelectedIndex == 4)
                {
                    var t = currentAgents.OrderByDescending(p => p.AgentName).ToList();
                    MByPages(in t, ref agentsL);
                    LVAgents.ItemsSource = agentsL[countNow];
                }
                if (CBSort.SelectedIndex == 5)
                {
                    var t = currentAgents.OrderByDescending(p => p.Sale).ToList();
                    MByPages(in t, ref agentsL);
                    LVAgents.ItemsSource = agentsL[countNow];
                }
                if (CBSort.SelectedIndex == 6)
                {
                    var t = currentAgents.OrderByDescending(p => p.AgentPriority).ToList();
                    MByPages(in t, ref agentsL);
                    LVAgents.ItemsSource = agentsL[countNow];
                }
            }
        }

        //slider
        private void MByPages<T>(in List<T> _DataList, ref List<List<T>> _CurrentList)
        {
            _CurrentList.Clear();
            int a = 1;
            bool isPage = false;
            Range range = new Range();

            foreach (var agents in _DataList)
            {
                if (a > 0 && a % 10 == 0)//
                {
                    range = new Range(a - 10, a);

                    isPage = true;
                }
                if (_DataList.Count < 10) 
                {
                    range = new Range(0, _DataList.Count);
                    isPage = true;
                }
                else if (a > (_DataList.Count - (_DataList.Count % 10)))
                {
                    if (a == _DataList.Count)
                    {
                        range = new Range(range.End, a);

                        isPage = true;
                    }
                }

                if (isPage)
                {
                    _CurrentList.Add(Range.GetRange(_DataList, range).ToList());
                }

                a++;
                isPage = false;
            }
        }

        private void TBSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void CBFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgents();
        }

        private void PrewPage_Click(object sender, RoutedEventArgs e)
        {
            if (countNow != 0)
            {
                countNow--;
                TBCount.Text = (countNow + 1).ToString();
                UpdateAgents();                
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (countNow != agentsL.Count - 1)
            {
                countNow++;
                TBCount.Text = (countNow + 1).ToString();
                UpdateAgents();
            }
        }

        private void AddingAgent_Click(object sender, RoutedEventArgs e)
        {
            AddingAgentWindow addingAgentWindow = new AddingAgentWindow();
            addingAgentWindow.Show();
            this.Close();
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditingAgent editingAgent = new EditingAgent((sender as ListViewItem).DataContext as Agent);
            editingAgent.Show();
            this.Close();
        }

        private void EditAgentPriority_Click(object sender, RoutedEventArgs e)
        {
            ChangingPriority.Visibility = Visibility;
        }

        private void BTCancel_Click(object sender, RoutedEventArgs e)
        {
            ChangingPriority.Visibility = Visibility.Collapsed;
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in LVAgents.SelectedItems)
            {
                var agent = item as Agent;
                agent.AgentPriority = Convert.ToInt32(TBPriority.Text);
                try
                {
                    RustleEntities3.GetContext().SaveChanges();
                    MessageBox.Show("Данные обновлены");
                    UpdateAgents();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    MessageBox.Show(ex.ToString());
                }
            }
            
            ChangingPriority.Visibility = Visibility.Collapsed;
        }
    }
}
