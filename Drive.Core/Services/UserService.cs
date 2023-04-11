using Drive.Core.Entities;
using Drive.Core.Exceptions;
using Drive.Core.Interfaces.Repository;
using Drive.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drive.Core.Services
{
    /// <summary>
    /// Validate dữ liệu
    /// </summary>
    public class UserService : BaseService<User>, IUserSevice
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        protected override bool Validate(User user)
        {
            if (string.IsNullOrEmpty(user.UserName))
            {
                ErrorValidateMsgs.Add("Tên tài khoản không được để trống!");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                ErrorValidateMsgs.Add("Mật khẩu không được để trống!");
            }
            if (string.IsNullOrEmpty(user.FullName))
            {
                ErrorValidateMsgs.Add("Tên người dùng không được phép để trống!");
            }
            // tồn tại tên tài khoản
            var isExits = _userRepository.CheckUserExits(user.UserName);
            if (isExits)
            {
                ErrorValidateMsgs.Add("Tên tài khoản đã tồn tại, vui lòng đăng ký với tên tài khoản khác!");
            }
            if (ErrorValidateMsgs.Count > 0)
            {
                return false;
            }
            return true; 
        } 
    }
}
