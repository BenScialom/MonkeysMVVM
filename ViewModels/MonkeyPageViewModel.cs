using MonkeysMVVM.Models;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class MonkeyPageViewModel : ViewModel
    {
        private string country;
        private int count;
        public string Country { get { return country; } set { country = value; OnPropertyChanged();((Command)SearchByCountryCommand).ChangeCanExecute(); } }
        public int Count { get { return count; } set { count = value; OnPropertyChanged(); } }
        public ICommand SearchByCountryCommand { get; set; }
        private Monkey monkey;
        public string Name { get { return monkey.Name; } }
        public string ImageUrl {  get { return monkey.ImageUrl; } }
        public MonkeyPageViewModel()
        {
            monkey = new Monkey() { Name = "No Monkeys right now" };
            SearchByCountryCommand = new Command(FindMonkeys,()=>Country!=null);
        }

        private void FindMonkeys()
        {
           
        }
    }
}
