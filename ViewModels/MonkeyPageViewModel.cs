using MonkeysMVVM.Models;
using System.Windows.Input;
using MonkeysMVVM.Services;

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
            SearchByCountryCommand = new Command(FindMonkeys,()=>Country!=null&&Country!=string.Empty);
        }

        private void FindMonkeys()
        {
            MonkeysService service =new MonkeysService();
            List<Monkey> lst= service.FindMonkeysByLocation(Country);
            if (lst.Count > 0)
                monkey = lst[0];
            else
                monkey = new Monkey() { Name = "No monkeys right now" };
            Count = lst.Count();
            RefreshData();
            Country = null;
        }

        private void RefreshData()
        {
            OnPropertyChanged("Name");
            OnPropertyChanged(nameof(ImageUrl));
        }
    }
}
