using GalaSoft.MvvmLight;

namespace WpfApp2.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
          private IGameViewModel _gameViewModel;
          public IGameViewModel GameViewModel
          { 
               get
               {
                    return _gameViewModel;
               }
               set
               {
                    _gameViewModel = value;
                    RaisePropertyChanged();
               } 
          }
          public MainViewModel(IGameViewModel gameViewModel)
          {
               _gameViewModel = gameViewModel;
          }
    }
}