using FBTool.Domain.Entities;

namespace FBTool.BLL.Interface.Facebook
{
    public interface IFacebookBussiness
    {
        void Login(FacebookAccount facebookAccount);
        void Close();
    }
}
