namespace MVC_Windows.Models{
    public class MyViewModel{

        // public MyViewModel(bool Islogin)
        // {
        //     onLogin = Islogin;
        // }

        public CustomerModel? Cust { get; set; }
        public List<CustomerModel>? CustomerModelList { get; set; }
        public bool onLogin {get; set;} = false;


    }
}