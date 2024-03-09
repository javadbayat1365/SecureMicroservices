namespace Movie.Client.Models
{
    public class UserInfoViewModel
    {
        public Dictionary<string, string> UserInfoDic { get;private set; } = null;

        public UserInfoViewModel(Dictionary<string,string> userInfoDic)
        {
            UserInfoDic = userInfoDic;
        }
    }
}
