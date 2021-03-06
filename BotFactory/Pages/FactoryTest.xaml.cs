﻿
using BotFactory.Factories;
using BotFactory.Tools;
using System;
using System.Windows.Controls;
using System.Windows;

using BotFactory.Common.Tools;
using BotFactory.Interface;
using BotFactory.Models;

namespace BotFactory.Pages
{
    /// <summary>
    /// Interaction logic for FactoryTest.xaml
    /// </summary>
    public partial class FactoryTest : Page
    {
        FactoryDataContext _dataContext = new FactoryDataContext();
        UnitTest _unitTestPage;

        public FactoryTest()
        {
            InitializeComponent();
            DataContext = _dataContext;
        }

        public void SetTestingFactory(UnitFactory factory)
        {
            _dataContext.Builder = factory;
            _dataContext.Builder.FactoryProgress += Builder_FactoryProgress;
        }


        private void Builder_FactoryProgress(object sender,  EventArgs e)
        {
            _dataContext.ForceUpdate();
            
        }

        private void AddUnitToQueue_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ModelsList.SelectedIndex >= 0 && !String.IsNullOrEmpty(UnitName.Text))
            {

                Type item = (Type)ModelsList.SelectedItem;

                ITestingUnit newUnit = Activator.CreateInstance(item, new object[] { }) as ITestingUnit;

                string stringToDisplay = string.Format("Vous avez choisi de construire le robot {0} qui a pour temps de construction {1} secondes, Etes-vous sûr de vouloir construire ce robot ?", newUnit.Name, newUnit.BuildTime);
        
                var name = UnitName.Text;
                if(MessageBox.Show( stringToDisplay , "" , MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _dataContext.Builder.AddWorkableUnitToQueue(item, name, new Coordinates(0, 0), new Coordinates(10, 10));
                    //MessageBox.Show(new StatusChangedEventArgs("blaal").NewStatus);
                    _dataContext.ForceUpdate();
                }


               
            }
        }



        private void UpdateButtonValidity()
        {
            AddUnitToQueue.IsEnabled = ModelsList.SelectedIndex >= 0 && !String.IsNullOrEmpty(UnitName.Text);
        }

        private void UnitName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateButtonValidity();
        }

        private void ModelsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonValidity();
        }

        private void StorageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StorageList.SelectedIndex >= 0)
            {
                if (_unitTestPage == null)
                {
                    _unitTestPage = new UnitTest();
                    _unitTestPage.SetUnitToTest((ITestingUnit)StorageList.SelectedItem);
                    UnitFrame.Navigate(_unitTestPage);
                }
                else
                {
                    _unitTestPage.SetUnitToTest((ITestingUnit)StorageList.SelectedItem);
                }
            }
        }
    }
}
