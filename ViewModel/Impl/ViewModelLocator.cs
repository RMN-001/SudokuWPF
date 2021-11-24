using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using WpfApp2.ViewModel.Impl;
using WpfApp2.Factories;

namespace WpfApp2.ViewModel
{
    public class ViewModelLocator
    {
        

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public ViewModelLocator()
        {
               ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

               SimpleIoc.Default.Register<IGameViewModel, GameViewModel>();
               SimpleIoc.Default.Register<MainViewModel>();
               SimpleIoc.Default.Register<IBuildSudokuFactory, BuildSudokuFactory>();
        }

          public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}