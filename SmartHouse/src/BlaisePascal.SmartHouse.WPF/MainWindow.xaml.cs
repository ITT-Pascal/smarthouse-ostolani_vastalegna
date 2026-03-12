using Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query;
using BlaisePascal.SmartHouse.Domain.Abstraction;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace BlaisePascal.SmartHouse.WPF
{
    public enum ActionToDo
    {
        Other,
        AddLamp,
        SetBrightness
    }
    public partial class MainWindow : Window
    {

        static ILampRepository _lampRepository;

        private ActionToDo ActionToDo { set; get; }
        private Lamp SelectedLamp { set; get; } = null;
        public MainWindow()
        {
            InitializeComponent();
            _lampRepository = new InMemoryLampRepository();
            RefreshLampList();
            ActionToDo = ActionToDo.Other;
            
        }



        private void RefreshLampList()
        {
            lampList.Items.Clear();

            var lamps = new GetAllLampsQuery(_lampRepository).Execute();
            for (int i = 0; i < lamps.Count; i++)
            {
                LampDto lamp = lamps[i];
                lampList.Items.Add($"{i + 1}) {lamp.Name} {lamp}");
            }
        }

        private void LampList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lampList.SelectedIndex;
            var lamps = _lampRepository.GetAll();

            if (index >= 0 && index < lamps.Count)
            {
                SelectedLamp = lamps[index];
                messageBox.Text = $"Lampada selezionata: {SelectedLamp.Name}";
            }
        }

        private void SubmitInput_Click(object sender, RoutedEventArgs e)
        {
            string input = inputBox.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Inserisci un valore valido.");
                return;
            }
            switch (ActionToDo)
            {
                case ActionToDo.AddLamp:
                    AddLamp(input);
                    ActionToDo = ActionToDo.Other;
                    messageBox.Text = "Seleziona un’operazione";
                    break;
                case ActionToDo.SetBrightness:
                    SetBrightnessLamp(input);
                    ActionToDo = ActionToDo.Other;
                    messageBox.Text = "Seleziona un’operazione";
                    break;
                default:
                    MessageBox.Show("Azione non riconosciuta");
                    break;



            }
        }

        // ADD LAMP
        private void AddLamp_Click(object sender, RoutedEventArgs e)
        {
            ActionToDo = ActionToDo.AddLamp;
            messageBox.Text = "Lamp name: ";
        }
        private void AddLamp(string input)
        {
            string name = input;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Invalid name");
                return;
            }

            new AddLampCommand(_lampRepository).Execute(name);
            RefreshLampList();
            inputBox.Clear();
        }

        // REMOVE LAMP
        private void RemoveLamp_Click(object sender, RoutedEventArgs e)
        {
            var lamp = SelectedLamp;
            if (lamp == null) return;

            new RemoveLampCommand(_lampRepository).Execute(lamp.Id);
            RefreshLampList();
            inputBox.Clear();
        }

        // SWITCH ON
        private void SwitchOnLamp_Click(object sender, RoutedEventArgs e)
        {
            var lamp = SelectedLamp;
            if (lamp == null) return;

            try
            {
                new SwitchOnCommand(_lampRepository).Execute(lamp.Id);
                MessageBox.Show("Lamp is now on");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            RefreshLampList();
            inputBox.Clear();
        }

        // SWITCH OFF
        private void SwitchOffLamp_Click(object sender, RoutedEventArgs e)
        {
            var lamp = SelectedLamp;
            if (lamp == null) return;

            try
            {
                new SwitchOffCommand(_lampRepository).Execute(lamp.Id);
                MessageBox.Show("Lamp is now off");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            RefreshLampList();
            inputBox.Clear();
        }

        // BRIGHTEN
        private void BrightenLamp_Click(object sender, RoutedEventArgs e)
        {
            var lamp = SelectedLamp;
            if (lamp == null) return;
            try
            {
                new BrightenCommand(_lampRepository).Execute(lamp.Id);
                MessageBox.Show("Lamp brightness increased");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            RefreshLampList();
        }

        // DIMMER
        private void DimmerLamp_Click(object sender, RoutedEventArgs e)
        {
            var lamp = SelectedLamp;
            if (lamp == null) return;
            try
            {
                new DimmerCommand(_lampRepository).Execute(lamp.Id);
                MessageBox.Show("Lamp brightness decreased");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            RefreshLampList();
        }

        // SET BRIGHTNESS
        private void SetBrightnessLamp_Click(object sender, RoutedEventArgs e)
        {
            var lamp = SelectedLamp;
            if (lamp == null) return;

            ActionToDo = ActionToDo.SetBrightness;
            messageBox.Text = "Lamp name: ";
        }
        private void SetBrightnessLamp(string input)
        {
            var lamp = SelectedLamp;
            if (lamp == null) return;
            string inputBrightness = input;
            if (!int.TryParse(inputBrightness, out int brightness))
            {
                Console.WriteLine("Invalid value");
                return;
            }

            try
            {
                new SetBrightnessCommand(_lampRepository).Execute(lamp.Id, brightness);
                MessageBox.Show("Lamp brightness decreased");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}");
            }
            RefreshLampList();
        }
    }
}