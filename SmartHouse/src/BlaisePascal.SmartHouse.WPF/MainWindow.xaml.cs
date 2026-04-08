using Blaisepascal.SmartHouse.Infrastructure.Repositories.Devices.Illumination.Lamps;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Commands;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Dto;
using BlaisePascal.SmartHouse.Application.Devices.Lightning.Lamps.Query;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice;
using BlaisePascal.SmartHouse.Domain.LuminuosDevice.Repository;
using System.Windows;
using System.Windows.Controls;

namespace BlaisePascal.SmartHouse.WPF
{
    public partial class MainWindow : Window
    {
        static ILampRepository _lampRepository;

        private LampDto SelectedLamp { get; set; } = null;

        public MainWindow()
        {
            InitializeComponent();
            _lampRepository = new InMemoryLampRepository();
            RefreshLampList();
        }

        private void RefreshLampList()
        {
            var selectedId = SelectedLamp?.Id;
            LampList.Items.Clear();

            var lamps = new GetAllLampsQuery(_lampRepository).Execute();
            foreach (var lamp in lamps)
            {
                LampList.Items.Add(lamp);
                if (lamp.Id == selectedId)
                    LampList.SelectedItem = lamp;
            }
        }

        private void LampList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = LampList.SelectedIndex;
            var lamps = new GetAllLampsQuery(_lampRepository).Execute();

            if (index >= 0 && index < lamps.Count)
                SelectedLamp = lamps[index] ;
        }

        // ADD LAMP
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = NewLampNameTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Insert a lamp name");
                    return;
                }

                new AddLampCommand(_lampRepository).Execute(name);

                if (int.TryParse(NewLampIntensityTextBox.Text.Trim(), out int intensity))
                {
                    var addedLamp = new GetAllLampsQuery(_lampRepository).Execute().Last();
                    new SwitchOnCommand(_lampRepository).Execute(addedLamp.Id);
                    new SetBrightnessCommand(_lampRepository).Execute(addedLamp.Id, intensity);
                }

                NewLampNameTextBox.Clear();
                NewLampIntensityTextBox.Clear();
                RefreshLampList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // SWITCH ON
        private void On_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedLamp == null) return;
                new SwitchOnCommand(_lampRepository).Execute(SelectedLamp.Id);
                RefreshLampList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // SWITCH OFF
        private void Off_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedLamp == null) return;
                new SwitchOffCommand(_lampRepository).Execute(SelectedLamp.Id);
                RefreshLampList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // SET BRIGHTNESS
        private void ApplyIntensity_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedLamp == null) return;
                if (!int.TryParse(SetIntensityTextBox.Text.Trim(), out int brightness))
                {
                    MessageBox.Show("Invalid value. Enter a number between 0 and 100.");
                    return;
                }
                new SetBrightnessCommand(_lampRepository).Execute(SelectedLamp.Id, brightness);
                SetIntensityTextBox.Clear();
                RefreshLampList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // REMOVE LAMP
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SelectedLamp == null) return;
                new RemoveLampCommand(_lampRepository).Execute(SelectedLamp.Id);
                SelectedLamp = null;
                RefreshLampList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}