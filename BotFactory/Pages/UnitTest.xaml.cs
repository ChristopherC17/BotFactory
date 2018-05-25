
using System;
using System.Windows;
using System.Windows.Controls;

using BotFactory.Common.Tools;
using BotFactory.Interface;
using BotFactory.Models;
using BotFactory.Tools;

namespace BotFactory.Pages
{
    /// <summary>
    /// Interaction logic for UnitTest.xaml
    /// </summary>
    public partial class UnitTest : Page
    {
        private UnitDataContext _unitDataContext = new UnitDataContext();

        public UnitTest()
        {
            InitializeComponent();

            DataContext = _unitDataContext;
        }

        public void SetUnitToTest(ITestingUnit unit)
        {
            _unitDataContext.IBot = unit;
        }
        
        private async void ButtonWork_Click(object sender, RoutedEventArgs e)
        {
            if (_unitDataContext.IBot != null)
            {
                try
                {
                    var response = await _unitDataContext.IBot.WorkBegins();
                    _unitDataContext.Response = response;
                    _unitDataContext.Working = _unitDataContext.IBot.IsWorking;
                    _unitDataContext.CurrentPos = _unitDataContext.IBot.CurrentPos;
                }
                catch(Exception)
                {
                    _unitDataContext.Response = false;
                    _unitDataContext.Working = false;
                    _unitDataContext.CurrentPos = _unitDataContext.IBot.CurrentPos;
                    //Affichage d'un message à l'opérateyur ??
                }

               
            }
        }

        private async void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            if (_unitDataContext.IBot != null)
            {
                try
                {
                    var response = await _unitDataContext.IBot.WorkEnds();
                    _unitDataContext.Response = response;
                    _unitDataContext.Working = _unitDataContext.IBot.IsWorking;
                    _unitDataContext.CurrentPos = _unitDataContext.IBot.CurrentPos;
                }
                catch(Exception)
                {
                    _unitDataContext.Response = false;
                    _unitDataContext.Working = false;
                    _unitDataContext.CurrentPos = _unitDataContext.IBot.CurrentPos;
                    //Affichage d'un message à l'opérateyur ??
                }


                //Affichage d'un message à l'opérateyur ??
            }
        }

    }
}
